
namespace Hotel.Forms
{
    partial class Form_ClientsEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ClientsEntry));
            this.button_Prev = new System.Windows.Forms.Button();
            this.button_Clients = new System.Windows.Forms.Button();
            this.button_LogIn = new System.Windows.Forms.Button();
            this.textBox_DocSeries = new System.Windows.Forms.TextBox();
            this.textBox_DocNumber = new System.Windows.Forms.TextBox();
            this.label_DocSeries = new System.Windows.Forms.Label();
            this.label_DocNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Prev
            // 
            this.button_Prev.BackColor = System.Drawing.Color.SeaShell;
            this.button_Prev.Location = new System.Drawing.Point(189, 77);
            this.button_Prev.Name = "button_Prev";
            this.button_Prev.Size = new System.Drawing.Size(172, 32);
            this.button_Prev.TabIndex = 0;
            this.button_Prev.Text = "Выйти в меню";
            this.button_Prev.UseVisualStyleBackColor = false;
            this.button_Prev.Click += new System.EventHandler(this.button_Prev_Click);
            // 
            // button_Clients
            // 
            this.button_Clients.BackColor = System.Drawing.Color.SeaShell;
            this.button_Clients.Location = new System.Drawing.Point(12, 77);
            this.button_Clients.Name = "button_Clients";
            this.button_Clients.Size = new System.Drawing.Size(171, 32);
            this.button_Clients.TabIndex = 1;
            this.button_Clients.Text = "Войти";
            this.button_Clients.UseVisualStyleBackColor = false;
            this.button_Clients.Click += new System.EventHandler(this.button_Clients_Click);
            // 
            // button_LogIn
            // 
            this.button_LogIn.BackColor = System.Drawing.Color.SeaShell;
            this.button_LogIn.Location = new System.Drawing.Point(12, 115);
            this.button_LogIn.Name = "button_LogIn";
            this.button_LogIn.Size = new System.Drawing.Size(349, 32);
            this.button_LogIn.TabIndex = 2;
            this.button_LogIn.Text = "Зарегистрироваться";
            this.button_LogIn.UseVisualStyleBackColor = false;
            this.button_LogIn.Click += new System.EventHandler(this.button_LogIn_Click);
            // 
            // textBox_DocSeries
            // 
            this.textBox_DocSeries.BackColor = System.Drawing.Color.SeaShell;
            this.textBox_DocSeries.Location = new System.Drawing.Point(169, 12);
            this.textBox_DocSeries.Name = "textBox_DocSeries";
            this.textBox_DocSeries.Size = new System.Drawing.Size(193, 27);
            this.textBox_DocSeries.TabIndex = 3;
            // 
            // textBox_DocNumber
            // 
            this.textBox_DocNumber.BackColor = System.Drawing.Color.SeaShell;
            this.textBox_DocNumber.Location = new System.Drawing.Point(169, 44);
            this.textBox_DocNumber.Name = "textBox_DocNumber";
            this.textBox_DocNumber.Size = new System.Drawing.Size(193, 27);
            this.textBox_DocNumber.TabIndex = 4;
            // 
            // label_DocSeries
            // 
            this.label_DocSeries.AutoSize = true;
            this.label_DocSeries.BackColor = System.Drawing.Color.Transparent;
            this.label_DocSeries.ForeColor = System.Drawing.Color.SeaShell;
            this.label_DocSeries.Location = new System.Drawing.Point(12, 16);
            this.label_DocSeries.Name = "label_DocSeries";
            this.label_DocSeries.Size = new System.Drawing.Size(151, 18);
            this.label_DocSeries.TabIndex = 5;
            this.label_DocSeries.Text = "Серия документа";
            // 
            // label_DocNumber
            // 
            this.label_DocNumber.AutoSize = true;
            this.label_DocNumber.BackColor = System.Drawing.Color.Transparent;
            this.label_DocNumber.ForeColor = System.Drawing.Color.SeaShell;
            this.label_DocNumber.Location = new System.Drawing.Point(10, 47);
            this.label_DocNumber.Name = "label_DocNumber";
            this.label_DocNumber.Size = new System.Drawing.Size(153, 18);
            this.label_DocNumber.TabIndex = 6;
            this.label_DocNumber.Text = "Номер документа";
            // 
            // Form_ClientsEntry
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(369, 154);
            this.ControlBox = false;
            this.Controls.Add(this.label_DocNumber);
            this.Controls.Add(this.label_DocSeries);
            this.Controls.Add(this.textBox_DocNumber);
            this.Controls.Add(this.textBox_DocSeries);
            this.Controls.Add(this.button_LogIn);
            this.Controls.Add(this.button_Clients);
            this.Controls.Add(this.button_Prev);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ClientsEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отель | Клиенты | Вход";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Prev;
        private System.Windows.Forms.Button button_Clients;
        private System.Windows.Forms.Button button_LogIn;
        private System.Windows.Forms.TextBox textBox_DocSeries;
        private System.Windows.Forms.TextBox textBox_DocNumber;
        private System.Windows.Forms.Label label_DocSeries;
        private System.Windows.Forms.Label label_DocNumber;
    }
}