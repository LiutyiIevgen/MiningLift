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
            this.checkedListBoxGraphic = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
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
            "Зд"});
            this.checkedListBoxGraphic.Location = new System.Drawing.Point(693, 0);
            this.checkedListBoxGraphic.MaximumSize = new System.Drawing.Size(30, 30);
            this.checkedListBoxGraphic.Name = "checkedListBoxGraphic";
            this.checkedListBoxGraphic.Size = new System.Drawing.Size(30, 30);
            this.checkedListBoxGraphic.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 568);
            this.panel1.TabIndex = 3;
            // 
            // CycleUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkedListBoxGraphic);
            this.Name = "CycleUC";
            this.Size = new System.Drawing.Size(723, 568);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxGraphic;
        private System.Windows.Forms.Panel panel1;
    }
}
