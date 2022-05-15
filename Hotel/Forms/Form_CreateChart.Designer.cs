
namespace Hotel.Forms
{
    partial class Form_CreateChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CreateChart));
            this.button_Prev = new System.Windows.Forms.Button();
            this.chart_Query = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Query)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Prev
            // 
            this.button_Prev.BackColor = System.Drawing.Color.SeaShell;
            this.button_Prev.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Prev.Location = new System.Drawing.Point(12, 418);
            this.button_Prev.Name = "button_Prev";
            this.button_Prev.Size = new System.Drawing.Size(601, 32);
            this.button_Prev.TabIndex = 0;
            this.button_Prev.Text = "Назад";
            this.button_Prev.UseVisualStyleBackColor = false;
            this.button_Prev.Click += new System.EventHandler(this.button_Prev_Click);
            // 
            // chart_Query
            // 
            this.chart_Query.BackColor = System.Drawing.Color.SeaShell;
            chartArea1.BackColor = System.Drawing.Color.Gray;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart_Query.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Gray;
            legend1.BorderColor = System.Drawing.Color.Black;
            legend1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend1.ForeColor = System.Drawing.Color.SeaShell;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart_Query.Legends.Add(legend1);
            this.chart_Query.Location = new System.Drawing.Point(12, 12);
            this.chart_Query.Name = "chart_Query";
            series1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            series1.BackSecondaryColor = System.Drawing.Color.SeaShell;
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Color = System.Drawing.Color.Transparent;
            series1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.IsValueShownAsLabel = true;
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.LabelBorderColor = System.Drawing.Color.Transparent;
            series1.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Black;
            series1.Name = "Series_ClientsAndRoomTypes";
            series1.ShadowOffset = 10;
            this.chart_Query.Series.Add(series1);
            this.chart_Query.Size = new System.Drawing.Size(601, 400);
            this.chart_Query.TabIndex = 1;
            this.chart_Query.Text = "Текст";
            title1.BackColor = System.Drawing.Color.Gray;
            title1.BorderColor = System.Drawing.Color.Black;
            title1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.ForeColor = System.Drawing.Color.SeaShell;
            title1.Name = "Title_Query";
            title1.Text = "Количество проживающих по типам номеров в текущем месяце";
            this.chart_Query.Titles.Add(title1);
            // 
            // Form_CreateChart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(625, 459);
            this.ControlBox = false;
            this.Controls.Add(this.chart_Query);
            this.Controls.Add(this.button_Prev);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_CreateChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отель | Администрирование | Архив | Диаграмма";
            ((System.ComponentModel.ISupportInitialize)(this.chart_Query)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Prev;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Query;
    }
}