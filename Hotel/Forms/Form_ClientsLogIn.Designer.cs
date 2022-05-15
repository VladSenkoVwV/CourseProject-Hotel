
namespace Hotel.Forms
{
    partial class Form_ClientsLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ClientsLogIn));
            this.button_Prev = new System.Windows.Forms.Button();
            this.button_LogIn = new System.Windows.Forms.Button();
            this.textBox_DocSeries = new System.Windows.Forms.TextBox();
            this.textBox_DocNumber = new System.Windows.Forms.TextBox();
            this.label_DocSeries = new System.Windows.Forms.Label();
            this.label_DocNumber = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_Surname = new System.Windows.Forms.Label();
            this.label_Patronymic = new System.Windows.Forms.Label();
            this.comboBox_Sex = new System.Windows.Forms.ComboBox();
            this.label_Sex = new System.Windows.Forms.Label();
            this.textBox_Patronymic = new System.Windows.Forms.TextBox();
            this.textBox_Surname = new System.Windows.Forms.TextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label_Address = new System.Windows.Forms.Label();
            this.label_PhoneNumber = new System.Windows.Forms.Label();
            this.textBox_PhoneNumber = new System.Windows.Forms.TextBox();
            this.dateTimePicker_Birthday = new System.Windows.Forms.DateTimePicker();
            this.label_Birthday = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Prev
            // 
            this.button_Prev.BackColor = System.Drawing.Color.SeaShell;
            this.button_Prev.Location = new System.Drawing.Point(10, 303);
            this.button_Prev.Name = "button_Prev";
            this.button_Prev.Size = new System.Drawing.Size(166, 32);
            this.button_Prev.TabIndex = 0;
            this.button_Prev.Text = "Выйти в меню";
            this.button_Prev.UseVisualStyleBackColor = false;
            this.button_Prev.Click += new System.EventHandler(this.button_Prev_Click);
            // 
            // button_LogIn
            // 
            this.button_LogIn.BackColor = System.Drawing.Color.SeaShell;
            this.button_LogIn.Location = new System.Drawing.Point(182, 303);
            this.button_LogIn.Name = "button_LogIn";
            this.button_LogIn.Size = new System.Drawing.Size(272, 32);
            this.button_LogIn.TabIndex = 1;
            this.button_LogIn.Text = "Зарегистрироваться";
            this.button_LogIn.UseVisualStyleBackColor = false;
            this.button_LogIn.Click += new System.EventHandler(this.button_LogIn_Click);
            // 
            // textBox_DocSeries
            // 
            this.textBox_DocSeries.BackColor = System.Drawing.Color.SeaShell;
            this.textBox_DocSeries.Location = new System.Drawing.Point(182, 168);
            this.textBox_DocSeries.MaxLength = 20;
            this.textBox_DocSeries.Name = "textBox_DocSeries";
            this.textBox_DocSeries.Size = new System.Drawing.Size(212, 27);
            this.textBox_DocSeries.TabIndex = 2;
            // 
            // textBox_DocNumber
            // 
            this.textBox_DocNumber.BackColor = System.Drawing.Color.SeaShell;
            this.textBox_DocNumber.Location = new System.Drawing.Point(182, 201);
            this.textBox_DocNumber.MaxLength = 20;
            this.textBox_DocNumber.Name = "textBox_DocNumber";
            this.textBox_DocNumber.Size = new System.Drawing.Size(212, 27);
            this.textBox_DocNumber.TabIndex = 3;
            // 
            // label_DocSeries
            // 
            this.label_DocSeries.AutoSize = true;
            this.label_DocSeries.BackColor = System.Drawing.Color.Transparent;
            this.label_DocSeries.ForeColor = System.Drawing.Color.SeaShell;
            this.label_DocSeries.Location = new System.Drawing.Point(26, 171);
            this.label_DocSeries.Name = "label_DocSeries";
            this.label_DocSeries.Size = new System.Drawing.Size(151, 18);
            this.label_DocSeries.TabIndex = 4;
            this.label_DocSeries.Text = "Серия документа";
            // 
            // label_DocNumber
            // 
            this.label_DocNumber.AutoSize = true;
            this.label_DocNumber.BackColor = System.Drawing.Color.Transparent;
            this.label_DocNumber.ForeColor = System.Drawing.Color.SeaShell;
            this.label_DocNumber.Location = new System.Drawing.Point(24, 204);
            this.label_DocNumber.Name = "label_DocNumber";
            this.label_DocNumber.Size = new System.Drawing.Size(153, 18);
            this.label_DocNumber.TabIndex = 5;
            this.label_DocNumber.Text = "Номер документа";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.BackColor = System.Drawing.Color.Transparent;
            this.label_Name.ForeColor = System.Drawing.Color.SeaShell;
            this.label_Name.Location = new System.Drawing.Point(136, 9);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(41, 18);
            this.label_Name.TabIndex = 6;
            this.label_Name.Text = "Имя";
            // 
            // label_Surname
            // 
            this.label_Surname.AutoSize = true;
            this.label_Surname.BackColor = System.Drawing.Color.Transparent;
            this.label_Surname.ForeColor = System.Drawing.Color.SeaShell;
            this.label_Surname.Location = new System.Drawing.Point(95, 42);
            this.label_Surname.Name = "label_Surname";
            this.label_Surname.Size = new System.Drawing.Size(82, 18);
            this.label_Surname.TabIndex = 7;
            this.label_Surname.Text = "Фамилия";
            // 
            // label_Patronymic
            // 
            this.label_Patronymic.AutoSize = true;
            this.label_Patronymic.BackColor = System.Drawing.Color.Transparent;
            this.label_Patronymic.ForeColor = System.Drawing.Color.SeaShell;
            this.label_Patronymic.Location = new System.Drawing.Point(93, 75);
            this.label_Patronymic.Name = "label_Patronymic";
            this.label_Patronymic.Size = new System.Drawing.Size(84, 18);
            this.label_Patronymic.TabIndex = 8;
            this.label_Patronymic.Text = "Отчество";
            // 
            // comboBox_Sex
            // 
            this.comboBox_Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Sex.FormattingEnabled = true;
            this.comboBox_Sex.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.comboBox_Sex.Location = new System.Drawing.Point(182, 103);
            this.comboBox_Sex.Name = "comboBox_Sex";
            this.comboBox_Sex.Size = new System.Drawing.Size(212, 26);
            this.comboBox_Sex.TabIndex = 9;
            // 
            // label_Sex
            // 
            this.label_Sex.AutoSize = true;
            this.label_Sex.BackColor = System.Drawing.Color.Transparent;
            this.label_Sex.ForeColor = System.Drawing.Color.SeaShell;
            this.label_Sex.Location = new System.Drawing.Point(136, 106);
            this.label_Sex.Name = "label_Sex";
            this.label_Sex.Size = new System.Drawing.Size(40, 18);
            this.label_Sex.TabIndex = 10;
            this.label_Sex.Text = "Пол";
            // 
            // textBox_Patronymic
            // 
            this.textBox_Patronymic.BackColor = System.Drawing.Color.SeaShell;
            this.textBox_Patronymic.Location = new System.Drawing.Point(182, 72);
            this.textBox_Patronymic.MaxLength = 50;
            this.textBox_Patronymic.Name = "textBox_Patronymic";
            this.textBox_Patronymic.Size = new System.Drawing.Size(272, 27);
            this.textBox_Patronymic.TabIndex = 11;
            // 
            // textBox_Surname
            // 
            this.textBox_Surname.BackColor = System.Drawing.Color.SeaShell;
            this.textBox_Surname.Location = new System.Drawing.Point(182, 39);
            this.textBox_Surname.MaxLength = 50;
            this.textBox_Surname.Name = "textBox_Surname";
            this.textBox_Surname.Size = new System.Drawing.Size(272, 27);
            this.textBox_Surname.TabIndex = 12;
            // 
            // textBox_Name
            // 
            this.textBox_Name.BackColor = System.Drawing.Color.SeaShell;
            this.textBox_Name.Location = new System.Drawing.Point(182, 6);
            this.textBox_Name.MaxLength = 50;
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(272, 27);
            this.textBox_Name.TabIndex = 13;
            // 
            // textBox_Address
            // 
            this.textBox_Address.BackColor = System.Drawing.Color.SeaShell;
            this.textBox_Address.Location = new System.Drawing.Point(182, 234);
            this.textBox_Address.MaxLength = 200;
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(272, 27);
            this.textBox_Address.TabIndex = 14;
            // 
            // label_Address
            // 
            this.label_Address.AutoSize = true;
            this.label_Address.BackColor = System.Drawing.Color.Transparent;
            this.label_Address.ForeColor = System.Drawing.Color.SeaShell;
            this.label_Address.Location = new System.Drawing.Point(118, 237);
            this.label_Address.Name = "label_Address";
            this.label_Address.Size = new System.Drawing.Size(58, 18);
            this.label_Address.TabIndex = 15;
            this.label_Address.Text = "Адрес";
            // 
            // label_PhoneNumber
            // 
            this.label_PhoneNumber.AutoSize = true;
            this.label_PhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.label_PhoneNumber.ForeColor = System.Drawing.Color.SeaShell;
            this.label_PhoneNumber.Location = new System.Drawing.Point(7, 270);
            this.label_PhoneNumber.Name = "label_PhoneNumber";
            this.label_PhoneNumber.Size = new System.Drawing.Size(170, 18);
            this.label_PhoneNumber.TabIndex = 16;
            this.label_PhoneNumber.Text = "Домашний телефон";
            // 
            // textBox_PhoneNumber
            // 
            this.textBox_PhoneNumber.BackColor = System.Drawing.Color.SeaShell;
            this.textBox_PhoneNumber.Location = new System.Drawing.Point(182, 267);
            this.textBox_PhoneNumber.MaxLength = 30;
            this.textBox_PhoneNumber.Name = "textBox_PhoneNumber";
            this.textBox_PhoneNumber.Size = new System.Drawing.Size(272, 27);
            this.textBox_PhoneNumber.TabIndex = 17;
            // 
            // dateTimePicker_Birthday
            // 
            this.dateTimePicker_Birthday.Location = new System.Drawing.Point(182, 135);
            this.dateTimePicker_Birthday.Name = "dateTimePicker_Birthday";
            this.dateTimePicker_Birthday.Size = new System.Drawing.Size(212, 27);
            this.dateTimePicker_Birthday.TabIndex = 19;
            // 
            // label_Birthday
            // 
            this.label_Birthday.AutoSize = true;
            this.label_Birthday.BackColor = System.Drawing.Color.Transparent;
            this.label_Birthday.ForeColor = System.Drawing.Color.SeaShell;
            this.label_Birthday.Location = new System.Drawing.Point(41, 141);
            this.label_Birthday.Name = "label_Birthday";
            this.label_Birthday.Size = new System.Drawing.Size(136, 18);
            this.label_Birthday.TabIndex = 20;
            this.label_Birthday.Text = "Дата рождения";
            // 
            // Form_ClientsLogIn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(460, 342);
            this.ControlBox = false;
            this.Controls.Add(this.label_Birthday);
            this.Controls.Add(this.dateTimePicker_Birthday);
            this.Controls.Add(this.textBox_PhoneNumber);
            this.Controls.Add(this.label_PhoneNumber);
            this.Controls.Add(this.label_Address);
            this.Controls.Add(this.textBox_Address);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.textBox_Surname);
            this.Controls.Add(this.textBox_Patronymic);
            this.Controls.Add(this.label_Sex);
            this.Controls.Add(this.comboBox_Sex);
            this.Controls.Add(this.label_Patronymic);
            this.Controls.Add(this.label_Surname);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.label_DocNumber);
            this.Controls.Add(this.label_DocSeries);
            this.Controls.Add(this.textBox_DocNumber);
            this.Controls.Add(this.textBox_DocSeries);
            this.Controls.Add(this.button_LogIn);
            this.Controls.Add(this.button_Prev);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ClientsLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отель | Клиенты | Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Prev;
        private System.Windows.Forms.Button button_LogIn;
        private System.Windows.Forms.TextBox textBox_DocSeries;
        private System.Windows.Forms.TextBox textBox_DocNumber;
        private System.Windows.Forms.Label label_DocSeries;
        private System.Windows.Forms.Label label_DocNumber;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Surname;
        private System.Windows.Forms.Label label_Patronymic;
        private System.Windows.Forms.ComboBox comboBox_Sex;
        private System.Windows.Forms.Label label_Sex;
        private System.Windows.Forms.TextBox textBox_Patronymic;
        private System.Windows.Forms.TextBox textBox_Surname;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label_Address;
        private System.Windows.Forms.Label label_PhoneNumber;
        private System.Windows.Forms.TextBox textBox_PhoneNumber;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Birthday;
        private System.Windows.Forms.Label label_Birthday;
    }
}