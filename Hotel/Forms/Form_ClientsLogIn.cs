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
    public partial class Form_ClientsLogIn : Form
    {
        public Form_ClientsLogIn(string docSeries, string docNumber)
        {
            InitializeComponent();

            textBox_DocSeries.Text = docSeries;
            textBox_DocNumber.Text = docNumber;
            comboBox_Sex.SelectedItem = 0;
        }

        private void button_Prev_Click(object sender, EventArgs e)
        {
            MyForms.Form_ClientsLogIn.Close();
            MyForms.Form_Menu.Show();
        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            string name = textBox_Name.Text.ToString(),
                surname = textBox_Surname.Text.ToString(),
                patronymic = textBox_Patronymic.Text.ToString(),
                docSeries = textBox_DocSeries.Text.ToString(),
                docNumber = textBox_DocNumber.Text.ToString(),
                address = textBox_Address.Text.ToString(),
                phoneNumber = textBox_PhoneNumber.Text.ToString();
            bool sex = comboBox_Sex.SelectedItem.ToString() == "Мужской";

            DateTime birthday = dateTimePicker_Birthday.Value;

            List<bool> checkList = new List<bool>()
            {
                name != string.Empty,
                surname != string.Empty,
                patronymic != string.Empty,
                docSeries != string.Empty,
                address != string.Empty,
                phoneNumber != string.Empty,
                int.TryParse(docNumber, out _),
                MyMethods.IsText(name),
                MyMethods.IsText(surname),
                MyMethods.IsText(patronymic),
                MyMethods.GetAge(birthday) > 17
            };

            if (checkList.Contains(false))
            {
                MessageBox.Show("Введены некорректные данные", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (HotelContext hotel = new HotelContext())
            {
                if (hotel.Clients.FirstOrDefault(p =>
                p.DocSeries == docSeries &&
                p.DocNumber == docNumber) != null)
                {
                    MessageBox.Show("Клиент с таким документом уже есть в базе", "Ошибка возможности",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hotel.Clients.Add(new Client(name, surname, patronymic, sex, docSeries,
                    docNumber, birthday, address, phoneNumber, false));

                hotel.SaveChanges();
            }

            MyForms.Form_ClientsMain = new Form_ClientsMain(docSeries, docNumber);
            MyForms.Form_ClientsMain.Show();
            MyForms.Form_ClientsLogIn.Close();
        }
    }
}
