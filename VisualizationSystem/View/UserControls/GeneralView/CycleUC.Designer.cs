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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series28 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            chartArea7.AxisX.LabelAutoFitMaxFontSize = 13;
            chartArea7.AxisX.LabelAutoFitMinFontSize = 12;
            chartArea7.AxisX.MaximumAutoSize = 90F;
            chartArea7.AxisX.Title = "м";
            chartArea7.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea7.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea7.AxisY.LabelAutoFitMaxFontSize = 13;
            chartArea7.AxisY.LabelAutoFitMinFontSize = 12;
            chartArea7.AxisY.MaximumAutoSize = 90F;
            chartArea7.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea7.AxisY.Title = "%";
            chartArea7.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea7.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea7.BackColor = System.Drawing.Color.Gray;
            chartArea7.Name = "ChartArea1";
            this.chartVA.ChartAreas.Add(chartArea7);
            this.chartVA.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.BackColor = System.Drawing.Color.Gray;
            legend7.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend7.Name = "Legend1";
            this.chartVA.Legends.Add(legend7);
            this.chartVA.Location = new System.Drawing.Point(0, 0);
            this.chartVA.Name = "chartVA";
            series25.BorderWidth = 2;
            series25.ChartArea = "ChartArea1";
            series25.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series25.Color = System.Drawing.Color.LimeGreen;
            series25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series25.Legend = "Legend1";
            series25.Name = "V(S)";
            series26.BorderWidth = 2;
            series26.ChartArea = "ChartArea1";
            series26.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series26.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series26.Legend = "Legend1";
            series26.Name = "Iя";
            series27.BorderWidth = 2;
            series27.ChartArea = "ChartArea1";
            series27.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series27.Color = System.Drawing.Color.Yellow;
            series27.Legend = "Legend1";
            series27.Name = "Iв";
            series28.BorderWidth = 2;
            series28.ChartArea = "ChartArea1";
            series28.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series28.Legend = "Legend1";
            series28.Name = "Защитная диаграмма";
            this.chartVA.Series.Add(series25);
            this.chartVA.Series.Add(series26);
            this.chartVA.Series.Add(series27);
            this.chartVA.Series.Add(series28);
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
