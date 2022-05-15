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
    public partial class Form_Admin : Form
    {
        private List<List<string>> DataForComboBox { get; set; }

        public Form_Admin()
        {
            InitializeComponent();

            GetClientsTable();
            GetHotelRoomsTable();
            GetServicesTable();
            GetSeatsTable();

            DataForComboBox = new List<List<string>>();
            for (int i = 0; i < 4; i++)
            {
                DataForComboBox.Add(new List<string>());
            };

            foreach (DataGridViewColumn column in dataGridView_Clients.Columns)
            {
                DataForComboBox[0].Add(column.HeaderText);
            }
            foreach (DataGridViewColumn column in dataGridView_HotelRooms.Columns)
            {
                DataForComboBox[1].Add(column.HeaderText);
            }
            foreach (DataGridViewColumn column in dataGridView_Seats.Columns)
            {
                DataForComboBox[2].Add(column.HeaderText);
            }
            foreach (DataGridViewColumn column in dataGridView_Services.Columns)
            {
                DataForComboBox[3].Add(column.HeaderText);
            }

            comboBox_SearchCriteria.DataSource = DataForComboBox[0];
            comboBox_SearchCriteria.SelectedIndex = 0;
            comboBox_Type.SelectedIndex = 0;

            HideOrShowLabelsAndTrackBar(false);
            HideOrShowInterfaceEdit(false);
            HideOrShowInterfaceEdit2(false);
        }

        private void ClientsTableUpdate(List<Client> clients)
        {
            dataGridView_Clients.Rows.Clear();

            clients.ForEach(client =>
            {
                dataGridView_Clients.Rows.Add
                    (client.Name,
                    client.Surname,
                    client.Patronymic,
                    client.Sex ? "Мужской" : "Женский",
                    client.Birthday.ToString("yyyy.MM.dd"),
                    client.Address,
                    client.HomePhoneNumber,
                    client.DocSeries,
                    client.DocNumber,
                    client.Status ? "Черный список" : "Обычный");
            });
        }

        public void HotelRoomsTableUpdate(List<HotelRoom> hotelRooms)
        {
            dataGridView_HotelRooms.Rows.Clear();

            hotelRooms.ForEach(room =>
            {
                dataGridView_HotelRooms.Rows.Add
                    (room.Number,
                    room.Type,
                    room.Floor,
                    room.NumberOfRooms,
                    room.Seats.Count,
                    room.PayPerDay,
                    room.PhoneNumber);
            });
        }

        private void ServicesTableUpdate(List<Service> services)
        {
            dataGridView_Services.Rows.Clear();

            services.ForEach(service =>
            {
                dataGridView_Services.Rows.Add
                    (service.Name,
                    MyMethods.ServicePriceForSpecificTime(service, DateTime.Now));
            });
        }

        private void SeatsTableUpdate(List<Seat> seats)
        {
            dataGridView_Seats.Rows.Clear();

            seats.ForEach(seat =>
            {
                dataGridView_Seats.Rows.Add
                    (seat.HotelRoom.Number,
                    seat.SeatNumber,
                    seat.ClientsCards.Count);
            });
        }

        private void GetClientsTable()
        {
            using (HotelContext hotel = new HotelContext())
            {
                ClientsTableUpdate(hotel.Clients.ToList());
            }
        }

        private void GetHotelRoomsTable()
        {
            using (HotelContext hotel = new HotelContext())
            {
                HotelRoomsTableUpdate(hotel.HotelRooms.ToList());
            }
        }

        private void GetSeatsTable()
        {
            using (HotelContext hotel = new HotelContext())
            {
                SeatsTableUpdate(hotel.Seats.ToList());
            }
        }

        private void GetServicesTable()
        {
            using (HotelContext hotel = new HotelContext())
            {
                ServicesTableUpdate(hotel.Services.Where(p => p.Enabled).ToList());
            }
        }

        private void HideOrShowLabelsAndTrackBar(in bool state)
        {
            label_U.Visible = state;
            label_D.Visible = state;
            trackBar_Comparison.Visible = state;
        }

        private void HideOrShowInterfaceEdit(in bool state)
        {
            label_RoomType.Visible = state;
            label_PhoneNumber.Visible = state;
            label_RoomFloor.Visible = state;
            label_Payment.Visible = state;
            label_NumberOfRooms.Visible = state;
            label_NumberOfSeats.Visible = state;
            label_CurrentFloor.Visible = state;

            comboBox_Type.Visible = state;
            textBox_PhoneNumber.Visible = state;
            trackBar_Floor.Visible = state;
            textBox_Payment.Visible = state;
            numericUpDown_NumberOfRooms.Visible = state;
            numericUpDown_NumberOfSeats.Visible = state;
            button_SaveChanges.Visible = state;
            button_Cancel.Visible = state;

            textBox_RoomNumber.Enabled = !state;
            button_DeleteOrEdit.Enabled = !state;
            button_GetStartTable.Enabled = !state;
            button_Find.Enabled = !state;
            button_Archive.Enabled = !state;
            trackBar_DeleteOrEdit.Enabled = !state;
            dataGridView_HotelRooms.Enabled = !state;
        }

        private void HideOrShowInterfaceEdit2(in bool state)
        {
            label_NewCostPerCall.Visible = state;
            textBox_NewCostPerCall.Visible = state;
            button_Cancel2.Visible = state;
            button_SaveChanges2.Visible = state;

            textBox_Service.Enabled = !state;
            button_EditOrAdd.Enabled = !state;
            button_GetStartTable.Enabled = !state;
            button_Find.Enabled = !state;
            button_Archive.Enabled = !state;
            trackBar_DeleteOrEdit2.Enabled = !state;
            dataGridView_Services.Enabled = !state;

            if (!state)
            {
                textBox_NewCostPerCall.Clear();
            }
        }

        public void SetIndexTabControl(in int i)
        {
            tabControl_Menu.SelectedIndex = i;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            MyForms.Form_Admin.Close();
            MyForms.Form_Menu.Show();
        }

        private void trackBar_Choice_ValueChanged(object sender, EventArgs e)
        {
            button_DeleteOrBlackList.Text = trackBar_Choice.Value == 0 ?
                "Удалить из базы" : "Добавить в черный список";
        }

        private void button_DeleteOrBlackList_Click(object sender, EventArgs e)
        {
            string docSeries = textBox_DocSeries.Text.ToString(),
                docNumber = textBox_DocNumber.Text.ToString();

            if (docSeries == string.Empty || !int.TryParse(docNumber, out _))
            {
                MessageBox.Show("Введены некорректные данные", "Ошибка поиска",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (HotelContext hotel = new HotelContext())
            {
                Client client = hotel.Clients
                    .FirstOrDefault(clientP =>
                    clientP.DocSeries == docSeries &&
                    clientP.DocNumber == docNumber);

                if (trackBar_Choice.Value == 0)
                {
                    if (client != null)
                    {
                        if (!MyMethods.HasClientCardsToday(client))
                        {
                            if (MessageBox.Show("Вы уверены, что желаете удалить данного клиента из списка?",
                            "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                hotel.Clients.Remove(client);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Вы не можете просто так удалить клиента, у которого все еще есть забронированные места. " +
                                "Вы только можете добавить его в черный список", "Ошибка права", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данного клиента нет в базе", "Ошибка поиска",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (MessageBox.Show("Вы уверены, что желаете добавить данного клиента в черный список?",
                        "Подтверждение внесения в черный список", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                    {
                        client.Status = true;
                        hotel.ClientsCards.RemoveRange(client.ClientCards);
                        hotel.ArchivalRecords.RemoveRange(hotel.ArchivalRecords
                            .Where(archivalRecord =>
                            archivalRecord.ClientDocSeries == client.DocSeries &&
                            archivalRecord.ClientDocNumber == client.DocNumber &&
                            archivalRecord.ArrivalDate > DateTime.Today));
                    }
                }

                hotel.SaveChanges();
            }

            GetSeatsTable();
            GetClientsTable();
        }

        private void tabControl_Menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_SearchCriteria.DataSource = DataForComboBox[tabControl_Menu.SelectedIndex];
            comboBox_SearchCriteria.SelectedIndex = 0;
        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            string info = textBox_Criteria.Text;

            using (HotelContext hotel = new HotelContext())
            {
                switch (comboBox_SearchCriteria.SelectedItem.ToString())
                {
                    case "Имя": ClientsTableUpdate(hotel.Clients.Where(p => p.Name == info).ToList()); break;
                    case "Фамилия": ClientsTableUpdate(hotel.Clients.Where(p => p.Surname == info).ToList()); break;
                    case "Отчество": ClientsTableUpdate(hotel.Clients.Where(p => p.Patronymic == info).ToList()); break;
                    case "Пол":
                        bool sex;
                        if (info == "Мужской") sex = true;
                        else if (info == "Женский") sex = false;
                        else
                        {
                            MessageBox.Show("Такого пола не существует", "Ошибка поиска",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        ClientsTableUpdate(hotel.Clients.Where(p => p.Sex == sex).ToList()); break;
                    case "Дата рождения":
                        if (!DateTime.TryParse(info, out DateTime birthday))
                        {
                            MessageBox.Show("Неверный формат даты", "Ошибка поиска",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        ClientsTableUpdate(hotel.Clients.Where(p => p.Birthday == birthday).ToList()); break;
                    case "Адрес": ClientsTableUpdate(hotel.Clients.Where(p => p.Address == info).ToList()); break;
                    case "Серия документа": ClientsTableUpdate(hotel.Clients.Where(p => p.DocSeries == info).ToList()); break;
                    case "Номер документа": ClientsTableUpdate(hotel.Clients.Where(p => p.DocNumber == info).ToList()); break;
                    case "Статус":
                        bool status;
                        if (info == "Черный список") status = true;
                        else if (info == "Обычный") status = false;
                        else
                        {
                            MessageBox.Show("Такого статуса нет", "Ошибка поиска",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        ClientsTableUpdate(hotel.Clients.Where(p => p.Status == status).ToList()); break;
                    case "Тип номера": HotelRoomsTableUpdate(hotel.HotelRooms.Where(p => p.Type == info).ToList()); break;
                    case "Этаж":
                        if (!int.TryParse(info, out int floor))
                        {
                            MessageBox.Show("Номер этажа не введен правильно", "Ошибка поиска",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        HotelRoomsTableUpdate(hotel.HotelRooms.Where(p => p.Floor == floor).ToList()); break;
                    case "Количество комнат":
                        if (!int.TryParse(info, out int numberOfRooms))
                        {
                            MessageBox.Show("Количество комнат не введено правильно", "Ошибка поиска",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        HotelRoomsTableUpdate(hotel.HotelRooms.Where(p => p.NumberOfRooms == numberOfRooms).ToList()); break;
                    case "Количество мест":
                        if (!int.TryParse(info, out int numberOfSeats))
                        {
                            MessageBox.Show("Количество мест не введено правильно", "Ошибка поиска",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        HotelRoomsTableUpdate(hotel.HotelRooms.Where(p => p.Seats.Count == numberOfSeats).ToList()); break;
                    case "Оплата за сутки":
                        if (!decimal.TryParse(info, out decimal payment) && payment <= 0)
                        {
                            MessageBox.Show("Оплата за сутки не введена правильно", "Ошибка поиска",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (trackBar_Comparison.Value == 0)
                        {
                            HotelRoomsTableUpdate(hotel.HotelRooms.Where(p => p.PayPerDay <= payment).ToList()); break;
                        }
                        HotelRoomsTableUpdate(hotel.HotelRooms.Where(p => p.PayPerDay >= payment).ToList()); break;
                    case "Телефон":
                        HotelRoomsTableUpdate(hotel.HotelRooms.Where(p => p.PhoneNumber == info).ToList()); break;
                    case "Номер в отеле":
                        if (!int.TryParse(info, out int number) && number <= 0)
                        {
                            MessageBox.Show("Номер отеля не введен правильно", "Ошибка поиска",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (tabControl_Menu.SelectedTab.Text.ToString() == "Номера в отеле")
                        {
                            HotelRoomsTableUpdate(hotel.HotelRooms.Where(p => p.Number == number).ToList()); break;
                        }
                        SeatsTableUpdate(hotel.Seats.Where(p => p.HotelRoom.Number == number).ToList()); break;
                    case "Номер места":
                        if (!int.TryParse(info, out int seatNumber))
                        {
                            MessageBox.Show("Номер места не введен правильно", "Ошибка поиска",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        SeatsTableUpdate(hotel.Seats.Where(p => p.SeatNumber == seatNumber).ToList()); break;
                    case "Количество регистраций":
                        if (!int.TryParse(info, out int numberOfRegistrations))
                        {
                            MessageBox.Show("Количество регистраций не введено правильно", "Ошибка поиска",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        SeatsTableUpdate(hotel.Seats.Where(p => p.ClientsCards.Count == numberOfRegistrations).ToList()); break;
                    case "Услуга": ServicesTableUpdate(hotel.Services.Where(p => p.Name == info).ToList()); break;
                    case "Стоимость за вызов/минуту":
                        if (!decimal.TryParse(info, out decimal costPerUnit))
                        {
                            MessageBox.Show("Стоимость услуги не введена правильно", "Ошибка поиска",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (trackBar_Comparison.Value == 0)
                        {
                            ServicesTableUpdate(hotel.Services.ToList().FindAll(p => MyMethods.ServicePriceForSpecificTime(p, DateTime.Now) <= costPerUnit)); break;
                        }
                        ServicesTableUpdate(hotel.Services.ToList().FindAll(p => MyMethods.ServicePriceForSpecificTime(p, DateTime.Now) >= costPerUnit)); break;
                    default: break;
                }
            }
        }

        private void button_GetStartTable_Click(object sender, EventArgs e)
        {
            switch (tabControl_Menu.SelectedTab.Text)
            {
                case "Клиенты": GetClientsTable(); break;
                case "Номера в отеле": GetHotelRoomsTable(); break;
                case "Места в отеле": GetSeatsTable(); break;
                case "Услуги": GetServicesTable(); break;
                default: break;
            }
        }

        private void comboBox_SearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_SearchCriteria.SelectedItem.ToString() == "Оплата за сутки" ||
                comboBox_SearchCriteria.SelectedItem.ToString() == "Стоимость за вызов/минуту")
            {
                HideOrShowLabelsAndTrackBar(true);
            }
            else HideOrShowLabelsAndTrackBar(false);
        }

        private void trackBar_DeleteOrEdit_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar_DeleteOrEdit.Value == 0)
            {
                button_DeleteOrEdit.Text = label_Delete2.Text;
            }
            else
            {
                button_DeleteOrEdit.Text = label_EditOrCreate.Text;
            }
        }

        private void button_DeleteOrEdit_Click(object sender, EventArgs e)
        {
            HideOrShowInterfaceEdit(false);

            if (!int.TryParse(textBox_RoomNumber.Text.ToString(), out int roomNumber))
            {
                MessageBox.Show("Номер отеля не введен правильно", "Ошибка поиска",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (HotelContext hotel = new HotelContext())
            {
                HotelRoom room = hotel.HotelRooms.ToList().Find(p => p.Number == roomNumber);

                button_SaveChanges.Text = "Сохранить изменения";

                if (room == null)
                {
                    if (trackBar_DeleteOrEdit.Value == 0)
                    {
                        MessageBox.Show("Такого номера нет в отеле", "Ошибка поиска",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MessageBox.Show("Вы собираетесь добавить новый номер?", "Подтверждение добавления",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    room = new HotelRoom()
                    {
                        NumberOfRooms = 0,
                    };

                    button_SaveChanges.Text = "Добавить номер";
                }
                else
                {
                    if (room.Seats.Find(p => p.ClientsCards.Any()) != null)
                    {
                        MessageBox.Show("Данный номер забронирован как минимум одним " +
                            "клиентом - вы не можете изменять данный номер или удалять его",
                            "Ошибка права", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (trackBar_DeleteOrEdit.Value == 1)
                {
                    HideOrShowInterfaceEdit(true);
                    textBox_RoomNumber.Enabled = false;

                    numericUpDown_NumberOfRooms.Minimum = -room.NumberOfRooms + 1;
                    numericUpDown_NumberOfRooms.Maximum = 20 - room.NumberOfRooms;
                    numericUpDown_NumberOfSeats.Minimum = -room.Seats.Count + 1;
                    numericUpDown_NumberOfSeats.Maximum = 50 - room.Seats.Count;
                }
                else
                {
                    if (MessageBox.Show("Вы уверены, что желаете удалить этот номер?", "Подтверждение удаления",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    hotel.HotelRooms.Remove(room);
                    hotel.SaveChanges();
                    GetHotelRoomsTable();
                    GetSeatsTable();
                }
            }
        }

        private void button_SaveChanges_Click(object sender, EventArgs e)
        {
            using (HotelContext hotel = new HotelContext())
            {
                HotelRoom room = hotel.HotelRooms.ToList().Find
                    (p => p.Number == int.Parse(textBox_RoomNumber.Text.ToString()));

                int numberOfRoomsD = Convert.ToInt32(numericUpDown_NumberOfRooms.Value),
                    numberOfSeatsD = Convert.ToInt32(numericUpDown_NumberOfSeats.Value);
                string roomType = comboBox_Type.Text,
                    phoneNumber = textBox_PhoneNumber.Text.ToString(),
                    paymentStr = textBox_Payment.Text.ToString();
                decimal payment = 0;

                if (room == null)
                {
                    if (paymentStr == string.Empty || roomType == string.Empty ||
                        phoneNumber == string.Empty)
                    {
                        MessageBox.Show("Для добавления нового номера обязательно ввести все данные",
                            "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (paymentStr != string.Empty)
                {
                    if (!decimal.TryParse(paymentStr, out payment) || payment <= 0)
                    {
                        MessageBox.Show("Оплата в сутки не введена правильно",
                            "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (room != null)
                    {
                        room.PayPerDay = payment;
                    }
                }

                if (room == null)
                {
                    room = new HotelRoom()
                    {
                        Number = int.Parse(textBox_RoomNumber.Text.ToString()),
                        PayPerDay = payment,
                        Type = roomType,
                        PhoneNumber = phoneNumber,
                        Floor = trackBar_Floor.Value,
                        NumberOfRooms = numberOfRoomsD
                    };
                }
                else
                {
                    if (roomType != string.Empty)
                    {
                        room.Type = roomType;
                    }
                    if (phoneNumber != string.Empty)
                    {
                        if (hotel.HotelRooms
                            .FirstOrDefault(roomP => roomP.PhoneNumber == phoneNumber) != null)
                        {
                            MessageBox.Show("Данный номер телефона есть в отеле",
                                "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!long.TryParse(phoneNumber, out _))
                        {
                            MessageBox.Show("Данный номер телефона не был введен правильно",
                                "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        room.PhoneNumber = textBox_PhoneNumber.Text.ToString();
                    }
                    room.Floor = trackBar_Floor.Value;
                    room.NumberOfRooms += numberOfRoomsD;
                }

                hotel.SaveChanges();

                if (numberOfSeatsD < 0)
                {
                    List<Seat> seats = new List<Seat>();
                    for (int i = 0; i < Math.Abs(numberOfSeatsD); i++)
                    {
                        seats.Add(hotel.Seats.ToList()
                            .Find(seat =>
                            seat.HotelRoom.Number == room.Number &&
                            seat.SeatNumber == room.Seats.Count - i));
                    }
                    hotel.Seats.RemoveRange(seats);
                }
                else
                {
                    for (int i = 0; i < numberOfSeatsD; i++)
                    {
                        hotel.Seats.Add(new Seat(room));
                    }
                }

                hotel.SaveChanges();
            }

            GetHotelRoomsTable();
            GetSeatsTable();

            HideOrShowInterfaceEdit(false);
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            HideOrShowInterfaceEdit(false);
        }

        private void button_Archive_Click(object sender, EventArgs e)
        {
            MyForms.Form_Archive = new Form_Archive();
            MyForms.Form_Archive.Show();
            MyForms.Form_Admin.Hide();
        }

        private void dataGridView_Clients_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridView_Clients.SelectedRows;

            if (selectedRows.Count != 0)
            {
                var selectedRow = selectedRows[0];

                textBox_DocSeries.Text = selectedRow.Cells[7].Value.ToString();
                textBox_DocNumber.Text = selectedRow.Cells[8].Value.ToString();
            }
        }

        private void dataGridView_HotelRooms_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridView_HotelRooms.SelectedRows;

            if (selectedRows.Count != 0)
            {
                textBox_RoomNumber.Text = selectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void dataGridView_Services_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridView_Services.SelectedRows;

            if (selectedRows.Count != 0)
            {
                textBox_Service.Text = selectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void trackBar_Floor_ValueChanged(object sender, EventArgs e)
        {
            label_CurrentFloor.Text = trackBar_Floor.Value.ToString();
        }

        private void button_EditOrAdd_Click(object sender, EventArgs e)
        {
            string name = textBox_Service.Text.ToString();

            using (HotelContext hotel = new HotelContext())
            {
                Service service = hotel.Services.FirstOrDefault(p =>
                p.Name == name);
                int choice = trackBar_DeleteOrEdit2.Value;

                if (choice == 0)
                {
                    if (service == null)
                    {
                        MessageBox.Show("Вы не можете удалить несуществующую услугу", "Ошибка возможности",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MessageBox.Show("Вы точно желаете удалить услугу?", "Подтверждение удаления услуги",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    if (service.ClientsCardsAndServices.Any())
                    {
                        service.Enabled = false;
                    }
                    else
                    {
                        hotel.Services.Remove(service);
                    }

                    hotel.SaveChanges();

                    GetServicesTable();
                    return;
                }

                if (service == null)
                {
                    button_SaveChanges2.Text = "Добавить услугу";

                    if (MessageBox.Show("Вы точно желаете добавить услугу?", "Подтверждение добавления услуги",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    hotel.Services.Add(new Service(name, 0, DateTime.Now));

                    hotel.SaveChanges();
                }
                else
                {
                    if (MessageBox.Show("Вы точно желаете изменить стоимость услуги?", "Подтверждение изменения стоимости услуги",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    button_SaveChanges2.Text = "Сохранить изменения";
                }
            }

            HideOrShowInterfaceEdit2(true);
        }

        private void button_Cancel2_Click(object sender, EventArgs e)
        {
            HideOrShowInterfaceEdit2(false);
        }

        private void button_SaveChanges2_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBox_NewCostPerCall.Text.ToString(), out decimal newCostPerCall) ||
                newCostPerCall <= 0)
            {
                MessageBox.Show("Стоимость услуги не введена правильно", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (HotelContext hotel = new HotelContext())
            {
                string name = textBox_Service.Text.ToString();

                Service service = hotel.Services.FirstOrDefault(p =>
                p.Name == name);

                if (newCostPerCall == MyMethods.ServicePriceForSpecificTime(service, DateTime.Now))
                {
                    MessageBox.Show("Стоимость услуги не была изменена правильно", "Ошибка возможности",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (service == null)
                {
                    hotel.Services.Add(new Service(name, newCostPerCall, DateTime.Now));
                }
                else
                {
                    service.ServicePriceRecords.Add(new ServicePriceRecord(service, newCostPerCall, DateTime.Now));
                }
                hotel.SaveChanges();
            }

            HideOrShowInterfaceEdit2(false);
            GetServicesTable();
        }

        private void trackBar_DeleteOrEdit2_ValueChanged(object sender, EventArgs e)
        {
            button_EditOrAdd.Text = trackBar_DeleteOrEdit2.Value == 0 ? label_Delete3.Text : label_EditOrCreate2.Text;
        }
    }
}
