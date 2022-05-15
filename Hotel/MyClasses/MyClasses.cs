using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Hotel.Forms;
using Hotel.HotelDb;
using Word = Microsoft.Office.Interop.Word;

namespace Hotel.MyClasses
{
    static class MyForms
    {
        public static Form_Menu Form_Menu { get; set; }
        public static Form_Admin Form_Admin { get; set; }
        public static Form_Archive Form_Archive { get; set; }
        public static Form_CreateChart Form_CreateChart { get; set; }
        public static Form_ClientsEntry Form_ClientsEntry { get; set; }
        public static Form_ClientsLogIn Form_ClientsLogIn { get; set; }
        public static Form_ClientsMain Form_ClientsMain { get; set; }
    }

    static class MyMethods
    {
        public static bool IsText(string str)
        {
            return !str.ToList().Exists(p => !char.IsLetter(p));
        }

        public static int GetAge(in DateTime birthday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthday.Year;

            return today.DayOfYear < birthday.DayOfYear ? --age : age;
        }

        public static DateTime? SeatNearArrivalDate(Seat seat)
        {
            if (!seat.ClientsCards.Any()) return null;

            return seat.ClientsCards.Max(p => p.DepartureDate).AddDays(1).Date;
        }

        private static int StayedDaysBase(in DateTime arrivalDate, in DateTime departureDate)
        {
            DateTime today = DateTime.Today;

            if (arrivalDate > today)
            {
                return 0;
            }
            if (departureDate < today)
            {
                return (departureDate - arrivalDate).Days;
            }
            return (today - arrivalDate).Days;
        }

        public static int StayedDaysInHotel(ClientCard card)
        {
            return StayedDaysBase(card.ArrivalDate, card.DepartureDate);
        }

        public static int StayedDaysInHotel(ArchivalRecord record)
        {
            return StayedDaysBase(record.ArrivalDate, record.DepartureDate);
        }

        public static bool HasClientCardsToday(Client client)
        {
            return client.ClientCards.Find(p => p.ArrivalDate >= DateTime.Today) != null;
        }

        private static void UpdateServicesInArchivalRecord(ArchivalRecord record, Service service, in int numberOfCalls)
        {
            string serviceName = service.Name;
            decimal spent = ServicePriceForSpecificTime(service, DateTime.Now) * numberOfCalls;

            if (record.NameOfEachService != null)
            {
                List<string> nameOfEachService = record.NameOfEachService.Split('|').ToList();
                List<string> numbersOfCallsForEachService = record.NumberOfCallsForEachService.Split('|').ToList();
                List<string> spentOnEachService = record.SpentOnEachService.Split('|').ToList();

                if (nameOfEachService.Contains(serviceName))
                {
                    int i = nameOfEachService.IndexOf(serviceName);

                    numbersOfCallsForEachService[i] = (int.Parse(numbersOfCallsForEachService[i]) + numberOfCalls).ToString();
                    spentOnEachService[i] = (decimal.Parse(spentOnEachService[i]) + spent).ToString();

                    record.NameOfEachService = string.Join("|", nameOfEachService);
                    record.NumberOfCallsForEachService = string.Join("|", numbersOfCallsForEachService);
                    record.SpentOnEachService = string.Join("|", spentOnEachService);
                }
                else
                {
                    record.NameOfEachService += "|" + serviceName;
                    record.NumberOfCallsForEachService += "|" + numberOfCalls.ToString();
                    record.SpentOnEachService += "|" + spent.ToString();
                }
            }
            else
            {
                record.NameOfEachService = serviceName;
                record.NumberOfCallsForEachService = numberOfCalls.ToString();
                record.SpentOnEachService = spent.ToString();
            }
        }

        public static void ClientCardServiceCall(ClientCard card, Service service, in int numberOfCalls)
        {
            using (HotelContext hotel = new HotelContext())
            {
                DateTime now = DateTime.Now;
                ClientCardAndService cardAndService = card.ClientCardAndServices.Find(p =>
                    p.Service == service &&
                    ServicePriceForSpecificTime(p.Service, p.LastDateTimeCall) == ServicePriceForSpecificTime(service, now));

                if (cardAndService == null)
                {
                    card.ClientCardAndServices.Add(new ClientCardAndService(card, service, numberOfCalls, now));
                }
                else
                {
                    cardAndService.NumberOfUnits += numberOfCalls;
                }

                Client client = card.Client;
                ArchivalRecord record = hotel.ArchivalRecords.ToList().Find(p =>
                p.ClientDocSeries == client.DocSeries &&
                p.ClientDocNumber == client.DocNumber &&
                p.ArrivalDate == card.ArrivalDate);

                UpdateServicesInArchivalRecord(record, service, numberOfCalls);

                hotel.SaveChanges();
            }
        }

        public static void ClientCardPaid(ClientCard card, in decimal addition)
        {
            Client client = card.Client;
            ArchivalRecord record;

            using (HotelContext hotel = new HotelContext())
            {
                record = hotel.ArchivalRecords.First(p =>
                p.ClientDocSeries == client.DocSeries &&
                p.ClientDocNumber == client.DocNumber &&
                p.ArrivalDate == card.ArrivalDate);

                record.ClientPaid += addition;

                hotel.SaveChanges();
            }

            card.Paid += addition;
        }

        public static decimal ClientCardAmountOfPayment(ClientCard card)
        {
            return StayedDaysInHotel(card) * card.Seat.HotelRoom.PayPerDay;
        }

        public static decimal ClientCardAmountOfPayment(ArchivalRecord record)
        {
            return StayedDaysInHotel(record) * record.RoomPayPerDay;
        }

        public static decimal ClientCardServicesCost(ClientCard card)
        {
            return card.ClientCardAndServices.Sum(p => p.NumberOfUnits * ServicePriceForSpecificTime(p.Service, p.LastDateTimeCall));
        }

        public static decimal ClientCardServicesCost(ArchivalRecord record)
        {
            if (record.SpentOnEachService != null)
            {
                return record.SpentOnEachService.Split('|').Sum(p => Convert.ToDecimal(p));
            }
            return 0;
        }

        public static decimal ServicePriceForSpecificTime(Service service, DateTime time)
        {
            List<ServicePriceRecord> priceRecords = service.ServicePriceRecords.FindAll(p => p.DateTimeSet <= time);

            return priceRecords.Find(p => p.DateTimeSet == priceRecords.Max(x => x.DateTimeSet)).Price;
        }

        public static decimal RoomFullCost(HotelRoom room, in DateTime arrivalDate, in DateTime departureDate)
        {
            if (departureDate < arrivalDate)
            {
                return Convert.ToDecimal(-1);
            }

            return room.PayPerDay * (departureDate - arrivalDate).Days;
        }

        public static void UpdateWordDoc(Word.Application wordApp, string strToFind, string replaceStr)
        {
            object strToFindObj = strToFind;
            object replaceStrObj = replaceStr;
            object missingObj = Missing.Value;

            Word.Range wordRange;

            object replaceTypeObj;
            replaceTypeObj = Word.WdReplace.wdReplaceAll;

            for (int i = 1; i <= wordApp.ActiveDocument.Sections.Count; i++)
            {
                wordRange = wordApp.ActiveDocument.Sections[i].Range;

                Word.Find wordFindObj = wordRange.Find;
                object[] wordFindParameters = new object[15]
                {
                    strToFindObj, missingObj, missingObj, missingObj, missingObj,
                    missingObj, missingObj, missingObj, missingObj, replaceStrObj,
                    replaceTypeObj, missingObj, missingObj, missingObj, missingObj
                };

                wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);
            }
        }
    }
}
