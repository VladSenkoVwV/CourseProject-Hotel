using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.HotelDb
{
    public class HotelRoom
    {
        public HotelRoom()
        {
            Seats = new List<Seat>();
        }

        public HotelRoom(in int number, string type, string phoneNumber, in int floor, in decimal payPerDay, in int numberOfRooms)
        {
            Seats = new List<Seat>();

            Number = number;
            Type = type;
            PhoneNumber = phoneNumber;
            Floor = floor;
            PayPerDay = payPerDay;
            NumberOfRooms = numberOfRooms;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required, Index("UK1_dbo.HotelRooms", IsUnique = true)] public int Number { get; set; }
        [Required, StringLength(20)] public string Type { get; set; }
        [Required, StringLength(30), Index("UK2_dbo.HotelRooms", IsUnique = true)] public string PhoneNumber { get; set; }
        [Required] public int Floor { get; set; }
        [Required] public decimal PayPerDay { get; set; }
        [Required] public int NumberOfRooms { get; set; }
        public virtual List<Seat> Seats { get; set; }
    }

    public class Seat
    {
        public Seat()
        {
            ClientsCards = new List<ClientCard>();
        }

        public Seat(HotelRoom room)
        {
            ClientsCards = new List<ClientCard>();

            HotelRoom = room;
            SeatNumber = room.Seats.Count() + 1;
            room.Seats.Add(this);
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required] public virtual HotelRoom HotelRoom { get; set; }
        [Required] public int SeatNumber { get; set; }
        public virtual List<ClientCard> ClientsCards { get; set; }
    }

    public class Service
    {
        public Service()
        {
            ClientsCardsAndServices = new List<ClientCardAndService>();
            ServicePriceRecords = new List<ServicePriceRecord>();
        }

        public Service(string name, in decimal price, in DateTime time)
        {
            ClientsCardsAndServices = new List<ClientCardAndService>();
            ServicePriceRecords = new List<ServicePriceRecord>
            {
                new ServicePriceRecord(this, price, time)
            };

            Name = name;
            Enabled = true;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required, MaxLength(100), Index("UK1_dbo.Services", IsUnique = true)] public string Name { get; set; }
        public virtual bool Enabled { get; set; }
        public virtual List<ClientCardAndService> ClientsCardsAndServices { get; set; }
        public virtual List<ServicePriceRecord> ServicePriceRecords { get; set; }
    }

    public class ServicePriceRecord
    {
        public ServicePriceRecord()
        {

        }

        public ServicePriceRecord(Service service, in decimal price, in DateTime time)
        {
            Price = price;
            DateTimeSet = time;
            Service = service;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required] public DateTime DateTimeSet { get; set; }
        [Required] public decimal Price { get; set; }
        [Required] public virtual Service Service { get; set; }
    }

    public class Client
    {
        public Client()
        {
            ClientCards = new List<ClientCard>();
        }

        public Client(string name, string surname, string patronymic, in bool sex, string docSeries, string docNumber,
            in DateTime birthday, in string address, string homePhoneNumber, in bool status)
        {
            ClientCards = new List<ClientCard>();

            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Sex = sex;
            DocSeries = docSeries;
            DocNumber = docNumber;
            Birthday = birthday;
            Address = address;
            HomePhoneNumber = homePhoneNumber;
            Status = status;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required, StringLength(50)] public string Name { get; set; }
        [Required, StringLength(50)] public string Surname { get; set; }
        [Required, StringLength(50)] public string Patronymic { get; set; }
        [Required, Range(0, 1)] public bool Sex { get; set; }
        [Required, StringLength(20), Index("UK1_dbo.Clients", Order = 1, IsUnique = true)] public string DocSeries { get; set; }
        [Required, StringLength(20), Index("UK1_dbo.Clients", Order = 2, IsUnique = true)] public string DocNumber { get; set; }
        [Required] public DateTime Birthday { get; set; }
        [Required, StringLength(200)] public string Address { get; set; }
        [Required, StringLength(30)] public string HomePhoneNumber { get; set; }
        public bool Status { get; set; }
        public virtual List<ClientCard> ClientCards { get; set; }
    }

    public class ClientCard
    {
        public ClientCard()
        {
            ClientCardAndServices = new List<ClientCardAndService>();
        }

        public ClientCard(Client client, Seat seat, in DateTime arrivalDate, in DateTime departureDate)
        {
            ClientCardAndServices = new List<ClientCardAndService>();

            Client = client;
            Seat = seat;
            ArrivalDate = arrivalDate;
            DepartureDate = departureDate;
            Paid = 0;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required] public virtual Client Client { get; set; }
        [Required] public virtual Seat Seat { get; set; }
        [Required] public DateTime ArrivalDate { get; set; }
        [Required] public DateTime DepartureDate { get; set; }
        [Required] public decimal Paid { get; set; }
        public virtual List<ClientCardAndService> ClientCardAndServices { get; set; }
    }

    public class ClientCardAndService
    {
        public ClientCardAndService()
        {

        }

        public ClientCardAndService(ClientCard card, Service service, in int numberOfUnits, in DateTime dateTimeCall)
        {
            ClientCard = card;
            Service = service;
            NumberOfUnits = numberOfUnits;
            LastDateTimeCall = dateTimeCall;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required] public virtual ClientCard ClientCard { get; set; }
        [Required] public virtual Service Service { get; set; }
        [Required] public int NumberOfUnits { get; set; }
        [Required] public DateTime LastDateTimeCall { get; set; }
    }

    public class ArchivalRecord
    {
        public ArchivalRecord()
        {

        }

        public ArchivalRecord(Client client, Seat seat, DateTime arrivalDate, DateTime departureDate)
        {
            HotelRoom room = seat.HotelRoom;

            ClientName = client.Name;
            ClientSurname = client.Surname;
            ClientPatronymic = client.Patronymic;
            ClientDocSeries = client.DocSeries;
            ClientDocNumber = client.DocNumber;
            ClientBirthday = client.Birthday;
            ClientSex = client.Sex;
            ClientAddress = client.Address;
            ClientHomePhoneNumber = client.HomePhoneNumber;
            ArrivalDate = arrivalDate;
            DepartureDate = departureDate;
            RoomNumber = room.Number;
            RoomType = room.Type;
            RoomPayPerDay = room.PayPerDay;
            SeatNumber = seat.SeatNumber;
            ClientPaid = 0;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required, StringLength(50)] public string ClientName { get; set; }
        [Required, StringLength(50)] public string ClientSurname { get; set; }
        [Required, StringLength(50)] public string ClientPatronymic { get; set; }
        [Required] public DateTime ClientBirthday { get; set; }
        [Required, StringLength(20), Index("UK1_dbo.Records", Order = 1, IsUnique = true)] public string ClientDocSeries { get; set; }
        [Required, StringLength(20), Index("UK1_dbo.Records", Order = 2, IsUnique = true)] public string ClientDocNumber { get; set; }
        [Required, Range(0, 1)] public bool ClientSex { get; set; }
        [Required, StringLength(200)] public string ClientAddress { get; set; }
        [Required, StringLength(30)] public string ClientHomePhoneNumber { get; set; }
        [Required] public int RoomNumber { get; set; }
        [Required, StringLength(10)] public string RoomType { get; set; }
        [Required] public decimal RoomPayPerDay { get; set; }
        [Required] public int SeatNumber { get; set; }
        [Required, Index("UK1_dbo.Records", Order = 3, IsUnique = true)] public DateTime ArrivalDate { get; set; }
        [Required] public DateTime DepartureDate { get; set; }
        [Required] public decimal ClientPaid { get; set; }
        public string NameOfEachService { get; set; }
        public string NumberOfCallsForEachService { get; set; }
        public string SpentOnEachService { get; set; }
    }
}
