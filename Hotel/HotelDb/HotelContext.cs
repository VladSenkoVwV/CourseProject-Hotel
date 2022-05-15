using System;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.HotelDb
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base("name=HotelContext")
        {
            
        }

        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ClientCard> ClientsCards { get; set; }
        public DbSet<ClientCardAndService> ClientsCardsAndServices { get; set; }
        public DbSet<ArchivalRecord> ArchivalRecords { get; set; }
        public DbSet<ServicePriceRecord> ServicesPricesRecords { get; set; }
    }
}