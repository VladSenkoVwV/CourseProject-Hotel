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
    public partial class Form_CreateChart : Form
    {
        public Form_CreateChart()
        {
            InitializeComponent();

            Dictionary<string, int> data = new Dictionary<string, int>();

            using (HotelContext hotel = new HotelContext())
            {
                foreach (var roomGroup in hotel.HotelRooms.GroupBy(p => p.Type))
                {
                    data.Add(roomGroup.Key, 0);
                }

                foreach (var card in hotel.ClientsCards
                    .Where(card => card.ArrivalDate <= DateTime.Today))
                {
                    data[card.Seat.HotelRoom.Type]++;
                }
            }

            foreach (var dataItem in data)
            {
                chart_Query.Series[0].Points.AddY(dataItem.Value);
                chart_Query.Series[0].Points.Last().Label = dataItem.Value.ToString();
                chart_Query.Series[0].Points.Last().LegendText = dataItem.Key;
            }
        }

        private void button_Prev_Click(object sender, EventArgs e)
        {
            MyForms.Form_Archive.Show();
            MyForms.Form_CreateChart.Hide();
        }
    }
}
