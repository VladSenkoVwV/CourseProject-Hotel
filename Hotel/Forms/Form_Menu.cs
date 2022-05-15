using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel.HotelDb;
using Hotel.MyClasses;

namespace Hotel.Forms
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();

            MyForms.Form_Menu = this;

            using (HotelContext hotel = new HotelContext())
            {
                DateTime today = DateTime.Today;

                List<ClientCard> cards = hotel.ClientsCards.ToList();

                hotel.ClientsCards.RemoveRange(cards
                    .Where(card =>
                    card.DepartureDate < today &&
                    card.Paid == MyMethods.ClientCardAmountOfPayment(card) +
                    MyMethods.ClientCardServicesCost(card)));

                hotel.SaveChanges();

                Action<ClientCard> removeCards = card =>
                {
                    Client client = card.Client;

                    if (client == null)
                    {
                        return;
                    }

                    client.Status = true;
                    hotel.ClientsCards.RemoveRange(client.ClientCards);
                    hotel.ArchivalRecords.RemoveRange(hotel.ArchivalRecords.Where(x =>
                    x.ClientDocSeries == client.DocSeries &&
                    x.ClientDocNumber == client.DocNumber &&
                    x.ArrivalDate > card.ArrivalDate));

                    hotel.SaveChanges();
                };

                hotel.ClientsCards.OrderBy(p => p.ArrivalDate).ToList()
                    .FindAll(card =>
                    card.DepartureDate < today &&
                    card.Paid < MyMethods.ClientCardAmountOfPayment(card) +
                    MyMethods.ClientCardServicesCost(card)).ForEach(removeCards);

                hotel.SaveChanges();
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            MyForms.Form_Menu.Close();
        }

        private void button_Administration_Click(object sender, EventArgs e)
        {
            MyForms.Form_Admin = new Form_Admin();
            MyForms.Form_Admin.Show();
            MyForms.Form_Menu.Hide();
        }

        private void button_Clients_Click(object sender, EventArgs e)
        {
            MyForms.Form_ClientsEntry = new Form_ClientsEntry();
            MyForms.Form_ClientsEntry.Show();
            MyForms.Form_Menu.Hide();
        }
    }
}
