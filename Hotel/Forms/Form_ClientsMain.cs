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
    public partial class Form_ClientsMain : Form
    {
        private string DocSeries { get; set; }
        private string DocNumber { get; set; }
        private int Mode { get; set; }

        public Form_ClientsMain(string docSeries, string docNumber)
        {
            InitializeComponent();

            DocSeries = docSeries;
            DocNumber = docNumber;

            button_StartOrder.Enabled = false;
            button_Departure.Enabled = false;
            button_StartPay.Enabled = false;
            button_Cancel.Visible = false;

            GetCardsTable();
            RegistrationState(false);
            OrderServiceState(false);
            PayState(false);
        }

        private void GetCardsTable()
        {
            dataGridView_Cards.Rows.Clear();

            using (HotelContext hotel = new HotelContext())
            {
                foreach (var card in hotel.Clients.First(p =>
                p.DocNumber == DocNumber &&
                p.DocSeries == DocSeries).ClientCards)
                {
                    Seat seat = card.Seat;
                    decimal amountOfPayment = MyMethods.ClientCardAmountOfPayment(card),
                        servicesCost = MyMethods.ClientCardServicesCost(card);

                    dataGridView_Cards.Rows.Add(
                        seat.HotelRoom.Number,
                        seat.SeatNumber,
                        card.ArrivalDate.ToString("yyyy.MM.dd"),
                        card.DepartureDate.ToString("yyyy.MM.dd"),
                        amountOfPayment,
                        servicesCost,
                        amountOfPayment + servicesCost,
                        card.Paid);
                }
            }
        }

        private void RegistrationState(in bool state)
        {
            label_ArrivalDate.Visible = state;
            label_DepartureDate.Visible = state;
            label_Info.Visible = state;
            label_RoomNumber.Visible = state;
            label_SeatId.Visible = state;
            label_RoomCost.Visible = state;
            dateTimePicker_ArrivalDate.Visible = state;
            dateTimePicker_DepartureDate.Visible = state;
            comboBox_RoomNumber.Visible = state;
            comboBox_SeatId.Visible = state;
            dataGridView_Times.Visible = state;
            button_Registration.Visible = state;
            button_Cancel.Visible = state;
            checkBox_Available.Visible = state;

            if (!state)
            {
                dateTimePicker_ArrivalDate.Value = DateTime.Today;
                dateTimePicker_DepartureDate.Value = DateTime.Today;
                comboBox_RoomNumber.SelectedItem = null;
                comboBox_SeatId.SelectedItem = null;
                dataGridView_Times.Rows.Clear();
                checkBox_Available.Checked = state;
            }
        }

        private void OrderServiceState(in bool state)
        {
            label_OrderService.Visible = state;
            label_NumberOfCalls.Visible = state;
            label_ServiceCost.Visible = state;
            comboBox_Services.Visible = state;
            numericUpDown_NumberOfCalls.Visible = state;
            button_Order.Visible = state;
            button_Cancel.Visible = state;

            if (!state)
            {
                comboBox_Services.SelectedItem = null;
                numericUpDown_NumberOfCalls.Value = 1;
            }
        }

        private void PayState(in bool state)
        {
            label_Pay.Visible = state;
            numericUpDown_Pay.Visible = state;
            button_Pay.Visible = state;
            button_Cancel.Visible = state;

            if (!state)
            {
                numericUpDown_Pay.Value = 0;
            }
        }

        private void ButtonsState(in bool state)
        {
            button_StartOrder.Enabled = state;
            button_Departure.Enabled = state;
            button_StartPay.Enabled = state;
            button_CancelArrival.Enabled = !state;
        }

        private void DateChanged()
        {
            HotelRoom room;
            int roomNumber = GetRoomNumberFromChoiceString();

            using (HotelContext hotel = new HotelContext())
            {
                room = hotel.HotelRooms.FirstOrDefault(p => p.Number == roomNumber);
            }

            label_RoomCost.Text = "Полное проживание в этом номере обойдется в ";

            if (room == null)
            {
                label_RoomCost.Text += "?";
                return;
            }

            decimal roomFullCost = MyMethods.RoomFullCost(room,
                dateTimePicker_ArrivalDate.Value, dateTimePicker_DepartureDate.Value);

            if (roomFullCost == -1)
            {
                label_RoomCost.Text = "Полное проживание в этом номере обойдется в ?";
                return;
            }

            label_RoomCost.Text += roomFullCost;
        }

        private int GetRoomNumberFromChoiceString()
        {
            if (comboBox_RoomNumber.SelectedItem == null)
            {
                return -1;
            }

            string info = comboBox_RoomNumber.SelectedItem.ToString();
            int startIndex = info.IndexOf('№') + 1, endIndex = info.IndexOf(',');

            return int.Parse(info.Substring(startIndex, endIndex - startIndex));
        }

        private int GetSeatNumberFromChoiceString()
        {
            return int.Parse(comboBox_SeatId.SelectedItem.ToString().Substring(7));
        }

        private void button_Prev_Click(object sender, EventArgs e)
        {
            MyForms.Form_ClientsMain.Close();
            MyForms.Form_Menu.Show();
        }

        private void dataGridView_Cards_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView_OrderedServices.Rows.Clear();

            RegistrationState(false);
            OrderServiceState(false);
            PayState(false);

            var selectedRows = dataGridView_Cards.SelectedRows;
            bool check1, check2 = false;

            check1 = selectedRows.Count != 0;

            if (check1)
            {
                using (HotelContext hotel = new HotelContext())
                {
                    ClientCard card = hotel.Clients.First(p =>
                    p.DocNumber == DocNumber &&
                    p.DocSeries == DocSeries).ClientCards[selectedRows[0].Index];

                    foreach (var orderedServiceGroup in card.ClientCardAndServices
                        .GroupBy(p => p.Service.Name))
                    {
                        int numberOfCalls = orderedServiceGroup.Sum(p => p.NumberOfUnits);

                        dataGridView_OrderedServices.Rows.Add(
                            orderedServiceGroup.Key,
                            numberOfCalls,
                            orderedServiceGroup.Sum(p => p.NumberOfUnits * MyMethods.ServicePriceForSpecificTime(p.Service, p.LastDateTimeCall)));
                    }

                    check2 = card.ArrivalDate <= DateTime.Today;
                }
            }

            ButtonsState(check1 && check2);
        }

        private void comboBox_Services_Enter(object sender, EventArgs e)
        {
            using (HotelContext hotel = new HotelContext())
            {
                comboBox_Services.Items.Clear();

                foreach (var service in hotel.Services.Where(p => p.Enabled))
                {
                    comboBox_Services.Items.Add(service.Name +
                        " (" + MyMethods.ServicePriceForSpecificTime(service, DateTime.Now) + ")");
                }
            }
        }

        private void numericUpDown_NumberOfCalls_ValueChanged(object sender, EventArgs e)
        {
            int i = comboBox_Services.SelectedIndex;

            if (i < 0)
            {
                label_ServiceCost.Text = "будет стоить ?";
                return;
            }

            using (HotelContext hotel = new HotelContext())
            {
                Service service = hotel.Services.Where(p => p.Enabled).ToList()[i];

                label_ServiceCost.Text = "будет стоить " + MyMethods.ServicePriceForSpecificTime(service, DateTime.Now) *
                    numericUpDown_NumberOfCalls.Value;
            }
        }

        private void button_Order_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView_Cards.SelectedRows;
            int numberOfCalls = Convert.ToInt32(numericUpDown_NumberOfCalls.Value);

            if (selectedRows.Count < 0)
            {
                MessageBox.Show("Карта оплаты не выбрана", "Ошибка выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int i = comboBox_Services.SelectedIndex;

            if (i < 0)
            {
                MessageBox.Show("Услуга не выбрана", "Ошибка выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (HotelContext hotel = new HotelContext())
            {
                Service service = hotel.Services.Where(p => p.Enabled).ToList()[i];
                Client client = hotel.Clients.First(p =>
                    p.DocNumber == DocNumber &&
                    p.DocSeries == DocSeries);

                ClientCard card = client.ClientCards[selectedRows[0].Index];

                MyMethods.ClientCardServiceCall(card, service, numberOfCalls);

                hotel.SaveChanges();
            }

            GetCardsTable();
        }

        private void button_Departure_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView_Cards.SelectedRows;

            if (selectedRows.Count != 0)
            {
                using (HotelContext hotel = new HotelContext())
                {
                    ClientCard card = hotel.Clients.First(p =>
                    p.DocNumber == DocNumber &&
                    p.DocSeries == DocSeries).ClientCards[selectedRows[0].Index];

                    if (MyMethods.StayedDaysInHotel(card) < 1)
                    {
                        MessageBox.Show("Вы не можете выехать в тот же день, в который и приехали. " +
                            "Минимум пребывания в отеле - 1 день", "Ошибка возможности",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (card.Paid < MyMethods.ClientCardAmountOfPayment(card) + MyMethods.ClientCardServicesCost(card))
                    {
                        MessageBox.Show("Вы не можете выехать пока все не оплатили", "Ошибка возможности",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MessageBox.Show("Вы точно желаете покинуть отель?", "Подтверждение выезда",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    decimal finalSettlement = MyMethods.ClientCardAmountOfPayment(card) + MyMethods.ClientCardServicesCost(card);

                    if (card.Paid < finalSettlement)
                    {
                        MessageBox.Show("Вы не можете выехать пока все не оплатили", "Ошибка возможности",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DateTime today = DateTime.Today;
                    ArchivalRecord record = hotel.ArchivalRecords.First(p =>
                    p.ClientDocSeries == card.Client.DocSeries &&
                    p.ClientDocNumber == card.Client.DocNumber &&
                    p.ArrivalDate == card.ArrivalDate);

                    if (card.Paid > finalSettlement)
                    {
                        MessageBox.Show("Вы переплатили за свое пребывание в отеле. " +
                            "Поговорите по этому поводу с администрцией отеля", "Предупреждение перед выездом",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    hotel.ClientsCards.Remove(card);
                    record.ClientPaid = finalSettlement;
                    record.DepartureDate = today;

                    hotel.SaveChanges();
                }

                GetCardsTable();
            }
        }

        private void button_Pay_Click(object sender, EventArgs e)
        {
            decimal paid = numericUpDown_Pay.Value;

            var selectedRows = dataGridView_Cards.SelectedRows;

            if (selectedRows.Count != 0)
            {
                using (HotelContext hotel = new HotelContext())
                {
                    ClientCard card = hotel.Clients.First(p =>
                    p.DocNumber == DocNumber &&
                    p.DocSeries == DocSeries).ClientCards[selectedRows[0].Index];
                    ArchivalRecord record = hotel.ArchivalRecords.ToList().Find(p =>
                    p.ClientDocSeries == card.Client.DocSeries &&
                    p.ClientDocNumber == card.Client.DocNumber &&
                    p.ArrivalDate == card.ArrivalDate);

                    card.Paid += paid;
                    record.ClientPaid += paid;

                    hotel.SaveChanges();

                    GetCardsTable();
                }
            }
        }

        private void comboBox_RoomNumber_Enter(object sender, EventArgs e)
        {
            bool check = checkBox_Available.Checked;

            comboBox_RoomNumber.Items.Clear();

            using (HotelContext hotel = new HotelContext())
            {
                foreach (var room in hotel.HotelRooms.ToList()
                    .FindAll(p => !(check && p.Seats.Find(x => !x.ClientsCards.Any()) == null)))
                {
                    string info = "№" + room.Number +
                        ", " + room.Type +
                        ", K = " + room.NumberOfRooms +
                        ", M = " + room.Seats.Count() +
                        ", O = " + room.PayPerDay;

                    comboBox_RoomNumber.Items.Add(info);
                }
            }
        }

        private void comboBox_SeatId_Enter(object sender, EventArgs e)
        {
            comboBox_SeatId.Items.Clear();

            if (comboBox_RoomNumber.SelectedItem == null)
            {
                return;
            }

            bool check = checkBox_Available.Checked;
            int number = GetRoomNumberFromChoiceString();

            using (HotelContext hotel = new HotelContext())
            {
                foreach (var seat in hotel.HotelRooms.First(p => p.Number == number).Seats
                    .Where(p => !(check && p.ClientsCards.Any())))
                {
                    comboBox_SeatId.Items.Add("Место №" + seat.SeatNumber);
                }
            }
        }

        private void button_Registration_Click(object sender, EventArgs e)
        {
            DateTime arrivalDate = dateTimePicker_ArrivalDate.Value.Date,
                departureDate = dateTimePicker_DepartureDate.Value.Date;

            if (comboBox_RoomNumber.SelectedItem == null ||
                comboBox_SeatId.SelectedItem == null ||
                arrivalDate < DateTime.Today ||
                arrivalDate > departureDate)
            {
                MessageBox.Show("Введены некорректные данные", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int number = GetRoomNumberFromChoiceString();

            if (arrivalDate == departureDate)
            {
                MessageBox.Show("Вы не можете выехать в тот же день, в который и приехали. " +
                    "Минимум пребывания в отеле - 1 день", "Ошибка возможности",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (HotelContext hotel = new HotelContext())
            {
                HotelRoom room = hotel.HotelRooms.ToList().Find(p => p.Number == GetRoomNumberFromChoiceString());
                Seat seat = room.Seats.ToList().Find(p => p.SeatNumber == GetSeatNumberFromChoiceString());
                Client client = hotel.Clients.First(p =>
                p.DocSeries == DocSeries &&
                p.DocNumber == DocNumber);

                List<ClientCard> checkDates = seat.ClientsCards.Concat(client.ClientCards).ToList();

                if (checkDates.Find(p =>
                arrivalDate >= p.ArrivalDate && arrivalDate <= p.DepartureDate ||
                departureDate >= p.ArrivalDate && departureDate <= p.DepartureDate ||
                p.ArrivalDate >= arrivalDate && p.ArrivalDate <= departureDate ||
                p.DepartureDate >= arrivalDate && p.DepartureDate <= departureDate) != null)
                {
                    MessageBox.Show("Вы не можете прибывать в этом номере на этом месте в указанное вами время",
                        "Ошибка возможности", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hotel.ClientsCards.Add(new ClientCard(client, seat, arrivalDate, departureDate));
                hotel.ArchivalRecords.Add(new ArchivalRecord(client, seat, arrivalDate, departureDate));

                hotel.SaveChanges();

                GetCardsTable();
            }

            RegistrationState(false);
        }

        private void comboBox_SeatId_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView_Times.Rows.Clear();

            if (comboBox_RoomNumber.SelectedItem == null || comboBox_SeatId.SelectedItem == null)
            {
                return;
            }

            int number = GetRoomNumberFromChoiceString(),
                seatNumber = GetSeatNumberFromChoiceString();

            using (HotelContext hotel = new HotelContext())
            {
                foreach (var card in hotel.HotelRooms.First(p => p.Number == number)
                    .Seats.Find(p => p.SeatNumber == seatNumber).ClientsCards)
                {
                    dataGridView_Times.Rows.Add(
                        card.ArrivalDate.ToString("yyyy.MM.dd"),
                        card.DepartureDate.ToString("yyyy.MM.dd"));
                }
            }
        }

        private void button_StartRegistration_Click(object sender, EventArgs e)
        {
            Mode = 1;
            OrderServiceState(false);
            PayState(false);
            RegistrationState(true);

            button_Cancel.Location = new Point(button_Registration.Location.X - button_Cancel.Size.Width - 6,
                button_Registration.Location.Y);
        }

        private void button_StartOrder_Click(object sender, EventArgs e)
        {
            Mode = 2;
            RegistrationState(false);
            PayState(false);
            OrderServiceState(true);

            button_Cancel.Location = new Point(button_Order.Location.X - button_Cancel.Size.Width - 6,
                button_Order.Location.Y);
        }

        private void button_StartPay_Click(object sender, EventArgs e)
        {
            Mode = 3;
            OrderServiceState(false);
            RegistrationState(false);
            PayState(true);

            button_Cancel.Location = new Point(button_Pay.Location.X - button_Cancel.Size.Width - 6,
                button_Pay.Location.Y);
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case 1: RegistrationState(false); break;
                case 2: OrderServiceState(false); break;
                case 3: PayState(false); break;
                default: break;
            }
        }

        private void dateTimePicker_ArrivalDate_ValueChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void dateTimePicker_DepartureDate_ValueChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void button_CancelArrival_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView_Cards.SelectedRows;

            if (selectedRows.Count != 0)
            {
                if (MessageBox.Show("Вы точно желаете выехать заранее?", "Подтверждение выезда",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                using (HotelContext hotel = new HotelContext())
                {
                    ClientCard card = hotel.Clients.First(p =>
                    p.DocNumber == DocNumber &&
                    p.DocSeries == DocSeries).ClientCards[selectedRows[0].Index];
                    ArchivalRecord record = hotel.ArchivalRecords.First(p =>
                    p.ClientDocSeries == DocSeries &&
                    p.ClientDocNumber == DocNumber &&
                    p.ArrivalDate == card.ArrivalDate);

                    hotel.ClientsCards.Remove(card);
                    hotel.ArchivalRecords.Remove(record);

                    hotel.SaveChanges();
                }

                GetCardsTable();
            }
        }
    }
}
