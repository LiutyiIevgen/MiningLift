namespace VisualizationSystem.View.UserControls.GeneralView
{
    partial class CycleUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series29 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series30 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series31 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series32 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.checkedListBoxGraphic = new System.Windows.Forms.CheckedListBox();
            this.chartVA = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartVA)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBoxGraphic
            // 
            this.checkedListBoxGraphic.BackColor = System.Drawing.Color.Gray;
            this.checkedListBoxGraphic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxGraphic.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkedListBoxGraphic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBoxGraphic.FormattingEnabled = true;
            this.checkedListBoxGraphic.Items.AddRange(new object[] {
            "V(S)",
            "Iя",
            "Iв"});
            this.checkedListBoxGraphic.Location = new System.Drawing.Point(693, 0);
            this.checkedListBoxGraphic.MaximumSize = new System.Drawing.Size(30, 30);
            this.checkedListBoxGraphic.Name = "checkedListBoxGraphic";
            this.checkedListBoxGraphic.Size = new System.Drawing.Size(30, 30);
            this.checkedListBoxGraphic.TabIndex = 2;
            // 
            // chartVA
            // 
            this.chartVA.BackColor = System.Drawing.Color.Gray;
            chartArea8.AxisX.LabelAutoFitMaxFontSize = 13;
            chartArea8.AxisX.LabelAutoFitMinFontSize = 12;
            chartArea8.AxisX.MaximumAutoSize = 90F;
            chartArea8.AxisX.Title = "м";
            chartArea8.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea8.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea8.AxisY.LabelAutoFitMaxFontSize = 13;
            chartArea8.AxisY.LabelAutoFitMinFontSize = 12;
            chartArea8.AxisY.MaximumAutoSize = 90F;
            chartArea8.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea8.AxisY.Title = "%";
            chartArea8.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea8.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea8.BackColor = System.Drawing.Color.Gray;
            chartArea8.Name = "ChartArea1";
            this.chartVA.ChartAreas.Add(chartArea8);
            this.chartVA.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.BackColor = System.Drawing.Color.Gray;
            legend8.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend8.Name = "Legend1";
            this.chartVA.Legends.Add(legend8);
            this.chartVA.Location = new System.Drawing.Point(0, 0);
            this.chartVA.Name = "chartVA";
            series29.BorderWidth = 2;
            series29.ChartArea = "ChartArea1";
            series29.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series29.Color = System.Drawing.Color.LimeGreen;
            series29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series29.Legend = "Legend1";
            series29.Name = "V(S)";
            series30.BorderWidth = 2;
            series30.ChartArea = "ChartArea1";
            series30.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series30.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series30.Legend = "Legend1";
            series30.Name = "Iя";
            series31.BorderWidth = 2;
            series31.ChartArea = "ChartArea1";
            series31.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series31.Color = System.Drawing.Color.Yellow;
            series31.Legend = "Legend1";
            series31.Name = "Iв";
            series32.BorderWidth = 2;
            series32.ChartArea = "ChartArea1";
            series32.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series32.Legend = "Legend1";
            series32.Name = "Защитная диаграмма";
            this.chartVA.Series.Add(series29);
            this.chartVA.Series.Add(series30);
            this.chartVA.Series.Add(series31);
            this.chartVA.Series.Add(series32);
            this.chartVA.Size = new System.Drawing.Size(723, 568);
            this.chartVA.TabIndex = 1;
            this.chartVA.TabStop = false;
            this.chartVA.Text = "chart1";
            // 
            // CycleUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkedListBoxGraphic);
            this.Controls.Add(this.chartVA);
            this.Name = "CycleUC";
            this.Size = new System.Drawing.Size(723, 568);
            ((System.ComponentModel.ISupportInitialize)(this.chartVA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxGraphic;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVA;
    }
}
