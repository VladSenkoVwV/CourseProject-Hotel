using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel.MyClasses;
using Hotel.HotelDb;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Hotel.Forms
{
    public partial class Form_Archive : Form
    {
        public Form_Archive()
        {
            InitializeComponent();

            GetArchiveTable();
        }

        private void ArchiveTableUpdate(List<ArchivalRecord> archivalRecords)
        {
            dataGridView_Archive.Rows.Clear();

            archivalRecords.ForEach(record =>
            {
                decimal amountOfPayment = MyMethods.ClientCardAmountOfPayment(record),
                    servicesCost = MyMethods.ClientCardServicesCost(record);

                dataGridView_Archive.Rows.Add
                    (record.ClientSurname + " " + record.ClientName + " " + record.ClientPatronymic,
                    MyMethods.GetAge(record.ClientBirthday),
                    record.ClientDocSeries + ", " + record.ClientDocNumber,
                    record.RoomNumber + ", " + record.SeatNumber,
                    record.ArrivalDate.ToString("yyyy.MM.dd"),
                    record.DepartureDate.ToString("yyyy.MM.dd"),
                    MyMethods.StayedDaysInHotel(record),
                    amountOfPayment,
                    servicesCost,
                    amountOfPayment + servicesCost,
                    record.ClientPaid);
            });
        }

        private void GetArchiveTable()
        {
            using (HotelContext hotel = new HotelContext())
            {
                ArchiveTableUpdate(hotel.ArchivalRecords.ToList());
            }
        }

        private void button_Prev_Click(object sender, EventArgs e)
        {
            MyForms.Form_Archive.Close();
            MyForms.Form_Admin.Show();
        }

        private void button_Current_Click(object sender, EventArgs e)
        {
            using (HotelContext hotel = new HotelContext())
            {
                DateTime today = DateTime.Today;

                ArchiveTableUpdate(hotel.ArchivalRecords
                    .Where(archivalRecord =>
                    archivalRecord.ArrivalDate <= today &&
                    archivalRecord.DepartureDate >= today).ToList());
            }
        }

        private void button_GetStartTable_Click(object sender, EventArgs e)
        {
            GetArchiveTable();
        }

        private void button_Query1_Click(object sender, EventArgs e)
        {
            using (HotelContext hotel = new HotelContext())
            {
                List<ArchivalRecord> archivalRecords = new List<ArchivalRecord>();

                foreach (var recordGroup in hotel.ArchivalRecords
                    .Where(archivalRecord =>
                    archivalRecord.DepartureDate < DateTime.Today &&
                    archivalRecord.RoomType == "Люкс").GroupBy(archivalRecord => archivalRecord.RoomNumber))
                {
                    int max = recordGroup.Max(archivalRecord => MyMethods.StayedDaysInHotel(archivalRecord));

                    archivalRecords.AddRange(recordGroup.ToList()
                        .FindAll(archivalRecord => MyMethods.StayedDaysInHotel(archivalRecord) == max));
                }

                ArchiveTableUpdate(archivalRecords);
            }
        }

        private void button_Query2_Click(object sender, EventArgs e)
        {
            using (HotelContext hotel = new HotelContext())
            {
                Func<ArchivalRecord, bool> check = archivalRecord =>
                {
                    int currentYear = DateTime.Today.Year;

                    return currentYear - archivalRecord.ArrivalDate.Year == 1 &&
                    currentYear - archivalRecord.DepartureDate.Year == 1 &&
                    MyMethods.GetAge(archivalRecord.ClientBirthday) > 59;
                };

                ArchiveTableUpdate(hotel.ArchivalRecords.Where(check).ToList());
            }
        }

        private void button_Query3_Click(object sender, EventArgs e)
        {
            using (HotelContext hotel = new HotelContext())
            {
                MyForms.Form_Admin.HotelRoomsTableUpdate(hotel.HotelRooms
                    .Where(room => room.Seats
                    .FirstOrDefault(seat => seat.ClientsCards.Any()) == null).ToList());
            }

            MyForms.Form_Admin.SetIndexTabControl(1);
            MyForms.Form_Admin.Show();
            MyForms.Form_Archive.Close();
        }

        private void button_Query4_Click(object sender, EventArgs e)
        {
            using (HotelContext hotel = new HotelContext())
            {
                List<ArchivalRecord> archivalRecords = hotel.ArchivalRecords.ToList();

                Comparison<ArchivalRecord> comparison = (p1, p2) =>
                {
                    int stayedDays1 = MyMethods.StayedDaysInHotel(p1);
                    int stayedDays2 = MyMethods.StayedDaysInHotel(p2);

                    if (stayedDays1 < stayedDays2)
                    {
                        return -1;
                    }
                    if (stayedDays1 > stayedDays2)
                    {
                        return 1;
                    }
                    else return 0;
                };

                archivalRecords.Sort(comparison);
                ArchiveTableUpdate(archivalRecords);
            }
        }

        private void button_Query5_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView_Archive.SelectedRows;

            dataGridView_OrderedServices.Rows.Clear();

            if (selectedRows.Count < 1)
            {
                return;
            }

            var selectedRow = selectedRows[0];

            string[] docData = selectedRow.Cells[2].Value.ToString().Split(',');
            docData[1] = docData[1].Remove(0, 1);
            DateTime arrivalDate = Convert.ToDateTime(selectedRow.Cells[4].Value.ToString());

            ArchivalRecord archivalRecord;

            using (HotelContext hotel = new HotelContext())
            {
                string[] nameOfEachService, numbersOfCallsForEachService, spentOnEachService;

                nameOfEachService = new string[0];
                numbersOfCallsForEachService = new string[0];
                spentOnEachService = new string[0];

                archivalRecord = hotel.ArchivalRecords.ToList()
                    .Find(archivalRecordP =>
                    archivalRecordP.ClientDocSeries == docData[0] &&
                    archivalRecordP.ClientDocNumber == docData[1] &&
                    archivalRecordP.ArrivalDate == arrivalDate);
            }

            Word.Application wordApp = new Word.Application();

            object missingObj = Type.Missing,
                templatePathObj = "E:/University/Второй курс/Четвертый семестр/Курсовой проект/Резервы/6/Карточка регистрации (Шаблон).docx",
                pathToSaveObj;

            wordApp.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);
            MyMethods.UpdateWordDoc(wordApp, "ClientName", archivalRecord.ClientName);
            MyMethods.UpdateWordDoc(wordApp, "ClientSurname", archivalRecord.ClientSurname);
            MyMethods.UpdateWordDoc(wordApp, "ClientPatronymic", archivalRecord.ClientPatronymic);
            MyMethods.UpdateWordDoc(wordApp, "DocInfo", archivalRecord.ClientDocSeries + ", " + archivalRecord.ClientDocNumber);
            MyMethods.UpdateWordDoc(wordApp, "ClientBirthday", archivalRecord.ClientBirthday.ToString("D"));
            MyMethods.UpdateWordDoc(wordApp, "ClientSex", archivalRecord.ClientSex ? "мужской" : "женский");
            MyMethods.UpdateWordDoc(wordApp, "ClientAddress", archivalRecord.ClientAddress);
            MyMethods.UpdateWordDoc(wordApp, "ClientPhoneNumber", archivalRecord.ClientHomePhoneNumber);
            MyMethods.UpdateWordDoc(wordApp, "CardId", archivalRecord.Id.ToString());
            MyMethods.UpdateWordDoc(wordApp, "RoomNumber", archivalRecord.RoomNumber.ToString());
            MyMethods.UpdateWordDoc(wordApp, "SeatNumber", archivalRecord.SeatNumber.ToString());
            MyMethods.UpdateWordDoc(wordApp, "ArrivalDate", archivalRecord.ArrivalDate.ToString("D"));
            MyMethods.UpdateWordDoc(wordApp, "DepartureDate", archivalRecord.DepartureDate.ToString("D"));

            saveFileDialog_SaveDocs.Title = "Выберите место для сохранения карточки регистрации";
            saveFileDialog_SaveDocs.FileName = "Карточка регистрации №" + archivalRecord.Id;
            saveFileDialog_SaveDocs.DefaultExt = "docx";
            
            if (saveFileDialog_SaveDocs.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            pathToSaveObj = saveFileDialog_SaveDocs.FileName.Replace("\\", "/");
            wordApp.ActiveDocument.SaveAs(ref pathToSaveObj, Word.WdSaveFormat.wdFormatDocumentDefault);

            wordApp.Quit();

            templatePathObj = "E:/University/Второй курс/Четвертый семестр/Курсовой проект/Резервы/6/Расчетная карточка.xlsx";

            Excel.Application excelApp = new Excel.Application();
            Excel.Worksheet worksheet;

            decimal amountOfPayment = MyMethods.ClientCardAmountOfPayment(archivalRecord),
                servicesCost = MyMethods.ClientCardServicesCost(archivalRecord);

            excelApp.Workbooks.Open(templatePathObj.ToString());
            worksheet = excelApp.ActiveSheet;
            worksheet.Range["C4"].Value = archivalRecord.Id;
            worksheet.Range["C6"].Value = archivalRecord.RoomNumber;
            worksheet.Range["C8"].Value = archivalRecord.SeatNumber;
            worksheet.Range["C10"].Value = archivalRecord.ArrivalDate.ToString("D");
            worksheet.Range["C12"].Value = archivalRecord.DepartureDate.ToString("D");
            worksheet.Range["C14"].Value = amountOfPayment;
            worksheet.Range["C16"].Value = servicesCost;
            worksheet.Range["C18"].Value = amountOfPayment + servicesCost;
            worksheet.Range["C20"].Value = archivalRecord.ClientPaid;

            saveFileDialog_SaveDocs.Title = "Выберите место для сохранения расчетной карточки";
            saveFileDialog_SaveDocs.FileName = "Расчетная карточка №" + archivalRecord.Id;
            saveFileDialog_SaveDocs.DefaultExt = "xlsx";

            if (saveFileDialog_SaveDocs.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            pathToSaveObj = saveFileDialog_SaveDocs.FileName.Replace("\\", "/");
            excelApp.ActiveWorkbook.SaveCopyAs(pathToSaveObj);

            excelApp.Quit();
        }

        private void button_Query6_Click(object sender, EventArgs e)
        {
            MyForms.Form_CreateChart = new Form_CreateChart();
            MyForms.Form_CreateChart.Show();
            MyForms.Form_Archive.Hide();
        }

        private void dataGridView_Archive_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridView_Archive.SelectedRows;

            dataGridView_OrderedServices.Rows.Clear();

            if (selectedRows.Count < 1)
            {
                return;
            }

            var selectedRow = selectedRows[0];

            string[] docData = selectedRow.Cells[2].Value.ToString().Split(',');
            string docSeries, docNumber;

            docSeries = docData[0];
            docNumber = docData[1].Remove(0, 1);
            DateTime arrivalDate = Convert.ToDateTime(selectedRow.Cells[4].Value.ToString());

            using (HotelContext hotel = new HotelContext())
            {
                string[] nameOfEachService, numbersOfCallsForEachService, spentOnEachService;

                nameOfEachService = new string[0];
                numbersOfCallsForEachService = new string[0];
                spentOnEachService = new string[0];

                ArchivalRecord record = hotel.ArchivalRecords
                    .First(archivalRecord =>
                    archivalRecord.ClientDocSeries == docSeries &&
                    archivalRecord.ClientDocNumber == docNumber &&
                    archivalRecord.ArrivalDate == arrivalDate);

                if (record.NameOfEachService != null)
                {
                    nameOfEachService = record.NameOfEachService.Split('|');
                    numbersOfCallsForEachService = record.NumberOfCallsForEachService.Split('|');
                    spentOnEachService = record.SpentOnEachService.Split('|');
                }

                for (int i = 0; i < nameOfEachService.Length; i++)
                {
                    dataGridView_OrderedServices.Rows.Add(
                        nameOfEachService[i],
                        numbersOfCallsForEachService[i],
                        spentOnEachService[i]);
                }
            }
        }
    }
}
