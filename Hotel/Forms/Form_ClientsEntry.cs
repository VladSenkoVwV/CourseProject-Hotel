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

namespace Hotel.Forms
{
    public partial class Form_ClientsEntry : Form
    {
        public Form_ClientsEntry()
        {
            InitializeComponent();
        }

        private void button_Prev_Click(object sender, EventArgs e)
        {
            MyForms.Form_ClientsEntry.Close();
            MyForms.Form_Menu.Show();
        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            MyForms.Form_ClientsLogIn = new Form_ClientsLogIn(string.Empty, string.Empty);
            MyForms.Form_ClientsLogIn.Show();
            MyForms.Form_ClientsEntry.Close();
        }

        private void button_Clients_Click(object sender, EventArgs e)
        {
            string docSeries = textBox_DocSeries.Text.ToString(),
                docNumber = textBox_DocNumber.Text.ToString();

            if (docSeries == string.Empty || !uint.TryParse(docNumber, out _))
            {
                MessageBox.Show("Введены некорректные данные",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (HotelContext hotel = new HotelContext())
            {
                Client client = hotel.Clients.ToList().Find(p =>
                p.DocSeries == docSeries &&
                p.DocNumber == docNumber);

                if (client == null)
                {
                    if (MessageBox.Show("Вас нет в базе. Желаете зарегистрироваться?", "Регистрация",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MyForms.Form_ClientsLogIn = new Form_ClientsLogIn(docSeries, docNumber);
                        MyForms.Form_ClientsLogIn.Show();
                        MyForms.Form_ClientsEntry.Close();
                    }
                }
                else
                {
                    if (client.Status)
                    {
                        MessageBox.Show("Вы были добавлены в черный список. Вы не можете войти","Ошибка входа",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MyForms.Form_ClientsMain = new Form_ClientsMain(docSeries, docNumber);
                    MyForms.Form_ClientsMain.Show();
                    MyForms.Form_ClientsEntry.Close();
                }
            }
        }
    }
}
