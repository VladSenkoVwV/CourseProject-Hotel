
namespace Hotel.Forms
{
    partial class Form_Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Menu));
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Administration = new System.Windows.Forms.Button();
            this.button_Clients = new System.Windows.Forms.Button();
            this.label_Info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.BackColor = System.Drawing.Color.SeaShell;
            this.button_Exit.Location = new System.Drawing.Point(12, 88);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(223, 32);
            this.button_Exit.TabIndex = 0;
            this.button_Exit.Text = "Выйти";
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Administration
            // 
            this.button_Administration.BackColor = System.Drawing.Color.SeaShell;
            this.button_Administration.Location = new System.Drawing.Point(12, 50);
            this.button_Administration.Name = "button_Administration";
            this.button_Administration.Size = new System.Drawing.Size(223, 32);
            this.button_Administration.TabIndex = 1;
            this.button_Administration.Text = "Администрирование";
            this.button_Administration.UseVisualStyleBackColor = false;
            this.button_Administration.Click += new System.EventHandler(this.button_Administration_Click);
            // 
            // button_Clients
            // 
            this.button_Clients.BackColor = System.Drawing.Color.SeaShell;
            this.button_Clients.Location = new System.Drawing.Point(12, 12);
            this.button_Clients.Name = "button_Clients";
            this.button_Clients.Size = new System.Drawing.Size(223, 32);
            this.button_Clients.TabIndex = 2;
            this.button_Clients.Text = "Клиенты";
            this.button_Clients.UseVisualStyleBackColor = false;
            this.button_Clients.Click += new System.EventHandler(this.button_Clients_Click);
            // 
            // label_Info
            // 
            this.label_Info.AutoSize = true;
            this.label_Info.BackColor = System.Drawing.Color.Transparent;
            this.label_Info.ForeColor = System.Drawing.Color.SeaShell;
            this.label_Info.Location = new System.Drawing.Point(9, 123);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(226, 36);
            this.label_Info.TabIndex = 3;
            this.label_Info.Text = "Разработано Сенько П. А.\r\n(БарГУ, ИСТ-21)";
            this.label_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(245, 166);
            this.ControlBox = false;
            this.Controls.Add(this.label_Info);
            this.Controls.Add(this.button_Clients);
            this.Controls.Add(this.button_Administration);
            this.Controls.Add(this.button_Exit);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отель | Меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Administration;
        private System.Windows.Forms.Button button_Clients;
        private System.Windows.Forms.Label label_Info;
    }
}

