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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            "Iв",
            "ЗД"});
            this.checkedListBoxGraphic.Location = new System.Drawing.Point(693, 0);
            this.checkedListBoxGraphic.MaximumSize = new System.Drawing.Size(30, 30);
            this.checkedListBoxGraphic.Name = "checkedListBoxGraphic";
            this.checkedListBoxGraphic.Size = new System.Drawing.Size(30, 30);
            this.checkedListBoxGraphic.TabIndex = 2;
            // 
            // chartVA
            // 
            this.chartVA.BackColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 13;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 12;
            chartArea1.AxisX.MaximumAutoSize = 90F;
            chartArea1.AxisX.Title = "м";
            chartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 13;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 12;
            chartArea1.AxisY.MaximumAutoSize = 90F;
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisY.Title = "%";
            chartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.BackColor = System.Drawing.Color.Gray;
            chartArea1.Name = "ChartArea1";
            this.chartVA.ChartAreas.Add(chartArea1);
            this.chartVA.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Gray;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chartVA.Legends.Add(legend1);
            this.chartVA.Location = new System.Drawing.Point(0, 0);
            this.chartVA.Name = "chartVA";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.LimeGreen;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.Legend = "Legend1";
            series1.Name = "V(S)";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.Name = "Iя";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Yellow;
            series3.Legend = "Legend1";
            series3.Name = "Iв";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "Защитная диаграмма";
            this.chartVA.Series.Add(series1);
            this.chartVA.Series.Add(series2);
            this.chartVA.Series.Add(series3);
            this.chartVA.Series.Add(series4);
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
