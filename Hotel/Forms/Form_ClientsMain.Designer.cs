
namespace Hotel.Forms
{
    partial class Form_ClientsMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ClientsMain));
            this.button_Prev = new System.Windows.Forms.Button();
            this.dataGridView_Cards = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_OrderedServices = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Registration = new System.Windows.Forms.Button();
            this.comboBox_Services = new System.Windows.Forms.ComboBox();
            this.label_OrderService = new System.Windows.Forms.Label();
            this.label_NumberOfCalls = new System.Windows.Forms.Label();
            this.numericUpDown_NumberOfCalls = new System.Windows.Forms.NumericUpDown();
            this.label_ServiceCost = new System.Windows.Forms.Label();
            this.button_Order = new System.Windows.Forms.Button();
            this.button_Departure = new System.Windows.Forms.Button();
            this.button_StartPay = new System.Windows.Forms.Button();
            this.comboBox_RoomNumber = new System.Windows.Forms.ComboBox();
            this.comboBox_SeatId = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_ArrivalDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_DepartureDate = new System.Windows.Forms.DateTimePicker();
            this.label_RoomNumber = new System.Windows.Forms.Label();
            this.label_SeatId = new System.Windows.Forms.Label();
            this.label_ArrivalDate = new System.Windows.Forms.Label();
            this.label_DepartureDate = new System.Windows.Forms.Label();
            this.label_Info = new System.Windows.Forms.Label();
            this.dataGridView_Times = new System.Windows.Forms.DataGridView();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_CancelArrival = new System.Windows.Forms.Button();
            this.button_StartRegistration = new System.Windows.Forms.Button();
            this.button_StartOrder = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.checkBox_Available = new System.Windows.Forms.CheckBox();
            this.label_RoomCost = new System.Windows.Forms.Label();
            this.numericUpDown_Pay = new System.Windows.Forms.NumericUpDown();
            this.label_Pay = new System.Windows.Forms.Label();
            this.button_Pay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OrderedServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NumberOfCalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Times)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Pay)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Prev
            // 
            this.button_Prev.BackColor = System.Drawing.Color.SeaShell;
            this.button_Prev.Location = new System.Drawing.Point(963, 524);
            this.button_Prev.Name = "button_Prev";
            this.button_Prev.Size = new System.Drawing.Size(187, 32);
            this.button_Prev.TabIndex = 0;
            this.button_Prev.Text = "Выйти в меню";
            this.button_Prev.UseVisualStyleBackColor = false;
            this.button_Prev.Click += new System.EventHandler(this.button_Prev_Click);
            // 
            // dataGridView_Cards
            // 
            this.dataGridView_Cards.AllowUserToAddRows = false;
            this.dataGridView_Cards.AllowUserToDeleteRows = false;
            this.dataGridView_Cards.AllowUserToResizeColumns = false;
            this.dataGridView_Cards.AllowUserToResizeRows = false;
            this.dataGridView_Cards.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Cards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Cards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Cards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column9,
            this.Column10,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column13});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Cards.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Cards.Location = new System.Drawing.Point(11, 12);
            this.dataGridView_Cards.MultiSelect = false;
            this.dataGridView_Cards.Name = "dataGridView_Cards";
            this.dataGridView_Cards.ReadOnly = true;
            this.dataGridView_Cards.RowHeadersVisible = false;
            this.dataGridView_Cards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Cards.Size = new System.Drawing.Size(790, 209);
            this.dataGridView_Cards.TabIndex = 1;
            this.dataGridView_Cards.SelectionChanged += new System.EventHandler(this.dataGridView_Cards_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Номер в отеле";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 90;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Место в номере";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Дата въезда";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 105;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Дата выезда";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 105;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Оплата за номер";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Стоимость всех услуг";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Окончательный счет";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 140;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Оплачено";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column13.Width = 90;
            // 
            // dataGridView_OrderedServices
            // 
            this.dataGridView_OrderedServices.AllowUserToAddRows = false;
            this.dataGridView_OrderedServices.AllowUserToDeleteRows = false;
            this.dataGridView_OrderedServices.AllowUserToResizeRows = false;
            this.dataGridView_OrderedServices.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_OrderedServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_OrderedServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_OrderedServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_OrderedServices.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_OrderedServices.Location = new System.Drawing.Point(807, 12);
            this.dataGridView_OrderedServices.MultiSelect = false;
            this.dataGridView_OrderedServices.Name = "dataGridView_OrderedServices";
            this.dataGridView_OrderedServices.ReadOnly = true;
            this.dataGridView_OrderedServices.RowHeadersVisible = false;
            this.dataGridView_OrderedServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_OrderedServices.Size = new System.Drawing.Size(491, 209);
            this.dataGridView_OrderedServices.TabIndex = 2;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Услуга";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 260;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Количество вызовов / минут";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column7.Width = 110;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Потрачено";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // button_Registration
            // 
            this.button_Registration.BackColor = System.Drawing.Color.SeaShell;
            this.button_Registration.Location = new System.Drawing.Point(285, 471);
            this.button_Registration.Name = "button_Registration";
            this.button_Registration.Size = new System.Drawing.Size(265, 32);
            this.button_Registration.TabIndex = 3;
            this.button_Registration.Text = "Забронировать";
            this.button_Registration.UseVisualStyleBackColor = false;
            this.button_Registration.Click += new System.EventHandler(this.button_Registration_Click);
            // 
            // comboBox_Services
            // 
            this.comboBox_Services.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Services.FormattingEnabled = true;
            this.comboBox_Services.Location = new System.Drawing.Point(893, 227);
            this.comboBox_Services.Name = "comboBox_Services";
            this.comboBox_Services.Size = new System.Drawing.Size(405, 26);
            this.comboBox_Services.TabIndex = 4;
            this.comboBox_Services.Enter += new System.EventHandler(this.comboBox_Services_Enter);
            // 
            // label_OrderService
            // 
            this.label_OrderService.AutoSize = true;
            this.label_OrderService.BackColor = System.Drawing.Color.Transparent;
            this.label_OrderService.ForeColor = System.Drawing.Color.SeaShell;
            this.label_OrderService.Location = new System.Drawing.Point(770, 230);
            this.label_OrderService.Name = "label_OrderService";
            this.label_OrderService.Size = new System.Drawing.Size(117, 18);
            this.label_OrderService.TabIndex = 5;
            this.label_OrderService.Text = "Заказ услуги";
            // 
            // label_NumberOfCalls
            // 
            this.label_NumberOfCalls.AutoSize = true;
            this.label_NumberOfCalls.BackColor = System.Drawing.Color.Transparent;
            this.label_NumberOfCalls.ForeColor = System.Drawing.Color.SeaShell;
            this.label_NumberOfCalls.Location = new System.Drawing.Point(769, 266);
            this.label_NumberOfCalls.Name = "label_NumberOfCalls";
            this.label_NumberOfCalls.Size = new System.Drawing.Size(120, 18);
            this.label_NumberOfCalls.TabIndex = 6;
            this.label_NumberOfCalls.Text = "В количестве";
            // 
            // numericUpDown_NumberOfCalls
            // 
            this.numericUpDown_NumberOfCalls.BackColor = System.Drawing.Color.SeaShell;
            this.numericUpDown_NumberOfCalls.Location = new System.Drawing.Point(895, 264);
            this.numericUpDown_NumberOfCalls.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_NumberOfCalls.Name = "numericUpDown_NumberOfCalls";
            this.numericUpDown_NumberOfCalls.ReadOnly = true;
            this.numericUpDown_NumberOfCalls.Size = new System.Drawing.Size(51, 27);
            this.numericUpDown_NumberOfCalls.TabIndex = 7;
            this.numericUpDown_NumberOfCalls.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_NumberOfCalls.ValueChanged += new System.EventHandler(this.numericUpDown_NumberOfCalls_ValueChanged);
            // 
            // label_ServiceCost
            // 
            this.label_ServiceCost.AutoSize = true;
            this.label_ServiceCost.BackColor = System.Drawing.Color.Transparent;
            this.label_ServiceCost.ForeColor = System.Drawing.Color.SeaShell;
            this.label_ServiceCost.Location = new System.Drawing.Point(952, 266);
            this.label_ServiceCost.Name = "label_ServiceCost";
            this.label_ServiceCost.Size = new System.Drawing.Size(127, 18);
            this.label_ServiceCost.TabIndex = 8;
            this.label_ServiceCost.Text = "будет стоить ?";
            // 
            // button_Order
            // 
            this.button_Order.BackColor = System.Drawing.Color.SeaShell;
            this.button_Order.ForeColor = System.Drawing.Color.Black;
            this.button_Order.Location = new System.Drawing.Point(1047, 297);
            this.button_Order.Name = "button_Order";
            this.button_Order.Size = new System.Drawing.Size(251, 32);
            this.button_Order.TabIndex = 9;
            this.button_Order.Text = "Заказать услугу";
            this.button_Order.UseVisualStyleBackColor = false;
            this.button_Order.Click += new System.EventHandler(this.button_Order_Click);
            // 
            // button_Departure
            // 
            this.button_Departure.BackColor = System.Drawing.Color.SeaShell;
            this.button_Departure.Location = new System.Drawing.Point(773, 524);
            this.button_Departure.Name = "button_Departure";
            this.button_Departure.Size = new System.Drawing.Size(184, 32);
            this.button_Departure.TabIndex = 10;
            this.button_Departure.Text = "Выехать";
            this.button_Departure.UseVisualStyleBackColor = false;
            this.button_Departure.Click += new System.EventHandler(this.button_Departure_Click);
            // 
            // button_StartPay
            // 
            this.button_StartPay.BackColor = System.Drawing.Color.SeaShell;
            this.button_StartPay.Location = new System.Drawing.Point(392, 524);
            this.button_StartPay.Name = "button_StartPay";
            this.button_StartPay.Size = new System.Drawing.Size(184, 32);
            this.button_StartPay.TabIndex = 11;
            this.button_StartPay.Text = "Оплатить";
            this.button_StartPay.UseVisualStyleBackColor = false;
            this.button_StartPay.Click += new System.EventHandler(this.button_StartPay_Click);
            // 
            // comboBox_RoomNumber
            // 
            this.comboBox_RoomNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RoomNumber.FormattingEnabled = true;
            this.comboBox_RoomNumber.Location = new System.Drawing.Point(147, 260);
            this.comboBox_RoomNumber.Name = "comboBox_RoomNumber";
            this.comboBox_RoomNumber.Size = new System.Drawing.Size(403, 26);
            this.comboBox_RoomNumber.TabIndex = 12;
            this.comboBox_RoomNumber.Enter += new System.EventHandler(this.comboBox_RoomNumber_Enter);
            // 
            // comboBox_SeatId
            // 
            this.comboBox_SeatId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SeatId.FormattingEnabled = true;
            this.comboBox_SeatId.Location = new System.Drawing.Point(147, 346);
            this.comboBox_SeatId.Name = "comboBox_SeatId";
            this.comboBox_SeatId.Size = new System.Drawing.Size(121, 26);
            this.comboBox_SeatId.TabIndex = 13;
            this.comboBox_SeatId.SelectedIndexChanged += new System.EventHandler(this.comboBox_SeatId_SelectedIndexChanged);
            this.comboBox_SeatId.Enter += new System.EventHandler(this.comboBox_SeatId_Enter);
            // 
            // dateTimePicker_ArrivalDate
            // 
            this.dateTimePicker_ArrivalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ArrivalDate.Location = new System.Drawing.Point(147, 382);
            this.dateTimePicker_ArrivalDate.Name = "dateTimePicker_ArrivalDate";
            this.dateTimePicker_ArrivalDate.Size = new System.Drawing.Size(121, 27);
            this.dateTimePicker_ArrivalDate.TabIndex = 14;
            this.dateTimePicker_ArrivalDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ArrivalDate_ValueChanged);
            // 
            // dateTimePicker_DepartureDate
            // 
            this.dateTimePicker_DepartureDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_DepartureDate.Location = new System.Drawing.Point(147, 415);
            this.dateTimePicker_DepartureDate.Name = "dateTimePicker_DepartureDate";
            this.dateTimePicker_DepartureDate.Size = new System.Drawing.Size(121, 27);
            this.dateTimePicker_DepartureDate.TabIndex = 15;
            this.dateTimePicker_DepartureDate.ValueChanged += new System.EventHandler(this.dateTimePicker_DepartureDate_ValueChanged);
            // 
            // label_RoomNumber
            // 
            this.label_RoomNumber.AutoSize = true;
            this.label_RoomNumber.BackColor = System.Drawing.Color.Transparent;
            this.label_RoomNumber.ForeColor = System.Drawing.Color.SeaShell;
            this.label_RoomNumber.Location = new System.Drawing.Point(11, 263);
            this.label_RoomNumber.Name = "label_RoomNumber";
            this.label_RoomNumber.Size = new System.Drawing.Size(130, 18);
            this.label_RoomNumber.TabIndex = 16;
            this.label_RoomNumber.Text = "Номер в отеле";
            // 
            // label_SeatId
            // 
            this.label_SeatId.AutoSize = true;
            this.label_SeatId.BackColor = System.Drawing.Color.Transparent;
            this.label_SeatId.ForeColor = System.Drawing.Color.SeaShell;
            this.label_SeatId.Location = new System.Drawing.Point(27, 349);
            this.label_SeatId.Name = "label_SeatId";
            this.label_SeatId.Size = new System.Drawing.Size(114, 18);
            this.label_SeatId.TabIndex = 17;
            this.label_SeatId.Text = "Номер места";
            // 
            // label_ArrivalDate
            // 
            this.label_ArrivalDate.AutoSize = true;
            this.label_ArrivalDate.BackColor = System.Drawing.Color.Transparent;
            this.label_ArrivalDate.ForeColor = System.Drawing.Color.SeaShell;
            this.label_ArrivalDate.Location = new System.Drawing.Point(9, 388);
            this.label_ArrivalDate.Name = "label_ArrivalDate";
            this.label_ArrivalDate.Size = new System.Drawing.Size(132, 18);
            this.label_ArrivalDate.TabIndex = 18;
            this.label_ArrivalDate.Text = "Дата прибытия";
            // 
            // label_DepartureDate
            // 
            this.label_DepartureDate.AutoSize = true;
            this.label_DepartureDate.BackColor = System.Drawing.Color.Transparent;
            this.label_DepartureDate.ForeColor = System.Drawing.Color.SeaShell;
            this.label_DepartureDate.Location = new System.Drawing.Point(27, 421);
            this.label_DepartureDate.Name = "label_DepartureDate";
            this.label_DepartureDate.Size = new System.Drawing.Size(114, 18);
            this.label_DepartureDate.TabIndex = 19;
            this.label_DepartureDate.Text = "Дата выезда";
            // 
            // label_Info
            // 
            this.label_Info.AutoSize = true;
            this.label_Info.BackColor = System.Drawing.Color.Transparent;
            this.label_Info.ForeColor = System.Drawing.Color.SeaShell;
            this.label_Info.Location = new System.Drawing.Point(13, 289);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(255, 54);
            this.label_Info.TabIndex = 20;
            this.label_Info.Text = "K - количество комнат,\r\nМ - количество мест,\r\nO - оплата за прожитый день";
            // 
            // dataGridView_Times
            // 
            this.dataGridView_Times.AllowUserToAddRows = false;
            this.dataGridView_Times.AllowUserToDeleteRows = false;
            this.dataGridView_Times.AllowUserToResizeColumns = false;
            this.dataGridView_Times.AllowUserToResizeRows = false;
            this.dataGridView_Times.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Times.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_Times.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Times.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column11,
            this.Column12});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Times.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_Times.Location = new System.Drawing.Point(285, 297);
            this.dataGridView_Times.MultiSelect = false;
            this.dataGridView_Times.Name = "dataGridView_Times";
            this.dataGridView_Times.ReadOnly = true;
            this.dataGridView_Times.RowHeadersVisible = false;
            this.dataGridView_Times.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Times.Size = new System.Drawing.Size(265, 150);
            this.dataGridView_Times.TabIndex = 21;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Дата прибытия";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column11.Width = 120;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Дата выезда";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column12.Width = 120;
            // 
            // button_CancelArrival
            // 
            this.button_CancelArrival.BackColor = System.Drawing.Color.SeaShell;
            this.button_CancelArrival.Location = new System.Drawing.Point(582, 524);
            this.button_CancelArrival.Name = "button_CancelArrival";
            this.button_CancelArrival.Size = new System.Drawing.Size(184, 32);
            this.button_CancelArrival.TabIndex = 22;
            this.button_CancelArrival.Text = "Отменить въезд";
            this.button_CancelArrival.UseVisualStyleBackColor = false;
            this.button_CancelArrival.Click += new System.EventHandler(this.button_CancelArrival_Click);
            // 
            // button_StartRegistration
            // 
            this.button_StartRegistration.BackColor = System.Drawing.Color.SeaShell;
            this.button_StartRegistration.Location = new System.Drawing.Point(12, 524);
            this.button_StartRegistration.Name = "button_StartRegistration";
            this.button_StartRegistration.Size = new System.Drawing.Size(184, 32);
            this.button_StartRegistration.TabIndex = 23;
            this.button_StartRegistration.Text = "Бронирование";
            this.button_StartRegistration.UseVisualStyleBackColor = false;
            this.button_StartRegistration.Click += new System.EventHandler(this.button_StartRegistration_Click);
            // 
            // button_StartOrder
            // 
            this.button_StartOrder.BackColor = System.Drawing.Color.SeaShell;
            this.button_StartOrder.Location = new System.Drawing.Point(202, 524);
            this.button_StartOrder.Name = "button_StartOrder";
            this.button_StartOrder.Size = new System.Drawing.Size(184, 32);
            this.button_StartOrder.TabIndex = 24;
            this.button_StartOrder.Text = "Заказать услугу";
            this.button_StartOrder.UseVisualStyleBackColor = false;
            this.button_StartOrder.Click += new System.EventHandler(this.button_StartOrder_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackColor = System.Drawing.Color.SeaShell;
            this.button_Cancel.Location = new System.Drawing.Point(773, 297);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(268, 32);
            this.button_Cancel.TabIndex = 25;
            this.button_Cancel.Text = "Отменить";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // checkBox_Available
            // 
            this.checkBox_Available.AutoSize = true;
            this.checkBox_Available.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Available.ForeColor = System.Drawing.Color.SeaShell;
            this.checkBox_Available.Location = new System.Drawing.Point(11, 236);
            this.checkBox_Available.Name = "checkBox_Available";
            this.checkBox_Available.Size = new System.Drawing.Size(539, 22);
            this.checkBox_Available.TabIndex = 26;
            this.checkBox_Available.Text = "Показывать только номера, в которых есть свободные места";
            this.checkBox_Available.UseVisualStyleBackColor = false;
            // 
            // label_RoomCost
            // 
            this.label_RoomCost.AutoSize = true;
            this.label_RoomCost.BackColor = System.Drawing.Color.Transparent;
            this.label_RoomCost.ForeColor = System.Drawing.Color.SeaShell;
            this.label_RoomCost.Location = new System.Drawing.Point(27, 450);
            this.label_RoomCost.Name = "label_RoomCost";
            this.label_RoomCost.Size = new System.Drawing.Size(452, 18);
            this.label_RoomCost.TabIndex = 27;
            this.label_RoomCost.Text = "Полное проживание в данном номере обойдется в ?";
            // 
            // numericUpDown_Pay
            // 
            this.numericUpDown_Pay.BackColor = System.Drawing.Color.SeaShell;
            this.numericUpDown_Pay.DecimalPlaces = 2;
            this.numericUpDown_Pay.Location = new System.Drawing.Point(452, 232);
            this.numericUpDown_Pay.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_Pay.Name = "numericUpDown_Pay";
            this.numericUpDown_Pay.Size = new System.Drawing.Size(92, 27);
            this.numericUpDown_Pay.TabIndex = 29;
            // 
            // label_Pay
            // 
            this.label_Pay.AutoSize = true;
            this.label_Pay.BackColor = System.Drawing.Color.Transparent;
            this.label_Pay.ForeColor = System.Drawing.Color.SeaShell;
            this.label_Pay.Location = new System.Drawing.Point(313, 235);
            this.label_Pay.Name = "label_Pay";
            this.label_Pay.Size = new System.Drawing.Size(133, 18);
            this.label_Pay.TabIndex = 30;
            this.label_Pay.Text = "Размер оплаты";
            // 
            // button_Pay
            // 
            this.button_Pay.BackColor = System.Drawing.Color.SeaShell;
            this.button_Pay.Location = new System.Drawing.Point(556, 260);
            this.button_Pay.Name = "button_Pay";
            this.button_Pay.Size = new System.Drawing.Size(251, 32);
            this.button_Pay.TabIndex = 31;
            this.button_Pay.Text = "Оплатить";
            this.button_Pay.UseVisualStyleBackColor = false;
            this.button_Pay.Click += new System.EventHandler(this.button_Pay_Click);
            // 
            // Form_ClientsMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1313, 566);
            this.ControlBox = false;
            this.Controls.Add(this.button_Pay);
            this.Controls.Add(this.label_Pay);
            this.Controls.Add(this.numericUpDown_Pay);
            this.Controls.Add(this.label_RoomCost);
            this.Controls.Add(this.checkBox_Available);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_StartOrder);
            this.Controls.Add(this.button_StartRegistration);
            this.Controls.Add(this.button_CancelArrival);
            this.Controls.Add(this.dataGridView_Times);
            this.Controls.Add(this.label_Info);
            this.Controls.Add(this.label_DepartureDate);
            this.Controls.Add(this.label_ArrivalDate);
            this.Controls.Add(this.label_SeatId);
            this.Controls.Add(this.label_RoomNumber);
            this.Controls.Add(this.dateTimePicker_DepartureDate);
            this.Controls.Add(this.dateTimePicker_ArrivalDate);
            this.Controls.Add(this.comboBox_SeatId);
            this.Controls.Add(this.comboBox_RoomNumber);
            this.Controls.Add(this.button_StartPay);
            this.Controls.Add(this.button_Departure);
            this.Controls.Add(this.button_Order);
            this.Controls.Add(this.label_ServiceCost);
            this.Controls.Add(this.numericUpDown_NumberOfCalls);
            this.Controls.Add(this.label_NumberOfCalls);
            this.Controls.Add(this.label_OrderService);
            this.Controls.Add(this.comboBox_Services);
            this.Controls.Add(this.button_Registration);
            this.Controls.Add(this.dataGridView_OrderedServices);
            this.Controls.Add(this.dataGridView_Cards);
            this.Controls.Add(this.button_Prev);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ClientsMain";
            this.Text = "Отель | Клиенты | Главная";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OrderedServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NumberOfCalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Times)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Pay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Prev;
        private System.Windows.Forms.DataGridView dataGridView_Cards;
        private System.Windows.Forms.DataGridView dataGridView_OrderedServices;
        private System.Windows.Forms.Button button_Registration;
        private System.Windows.Forms.ComboBox comboBox_Services;
        private System.Windows.Forms.Label label_OrderService;
        private System.Windows.Forms.Label label_NumberOfCalls;
        private System.Windows.Forms.NumericUpDown numericUpDown_NumberOfCalls;
        private System.Windows.Forms.Label label_ServiceCost;
        private System.Windows.Forms.Button button_Order;
        private System.Windows.Forms.Button button_Departure;
        private System.Windows.Forms.Button button_StartPay;
        private System.Windows.Forms.ComboBox comboBox_RoomNumber;
        private System.Windows.Forms.ComboBox comboBox_SeatId;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ArrivalDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DepartureDate;
        private System.Windows.Forms.Label label_RoomNumber;
        private System.Windows.Forms.Label label_SeatId;
        private System.Windows.Forms.Label label_ArrivalDate;
        private System.Windows.Forms.Label label_DepartureDate;
        private System.Windows.Forms.Label label_Info;
        private System.Windows.Forms.DataGridView dataGridView_Times;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.Button button_CancelArrival;
        private System.Windows.Forms.Button button_StartRegistration;
        private System.Windows.Forms.Button button_StartOrder;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.CheckBox checkBox_Available;
        private System.Windows.Forms.Label label_RoomCost;
        private System.Windows.Forms.NumericUpDown numericUpDown_Pay;
        private System.Windows.Forms.Label label_Pay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button button_Pay;
    }
}