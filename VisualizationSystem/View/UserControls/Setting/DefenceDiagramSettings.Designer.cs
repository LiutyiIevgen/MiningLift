namespace VisualizationSystem.View.UserControls.Setting
{
    partial class DefenceDiagramSettings
    {
        /// <summary> 
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CodtDomainComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.CodtDomainComboBox);
            this.splitContainer1.Size = new System.Drawing.Size(758, 448);
            this.splitContainer1.SplitterDistance = 27;
            this.splitContainer1.TabIndex = 0;
            // 
            // CodtDomainComboBox
            // 
            this.CodtDomainComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CodtDomainComboBox.FormattingEnabled = true;
            this.CodtDomainComboBox.Location = new System.Drawing.Point(170, 3);
            this.CodtDomainComboBox.Name = "CodtDomainComboBox";
            this.CodtDomainComboBox.Size = new System.Drawing.Size(374, 21);
            this.CodtDomainComboBox.TabIndex = 0;
            this.CodtDomainComboBox.SelectedIndexChanged += new System.EventHandler(this.CodtDomainComboBox_SelectedIndexChanged);
            // 
            // DefenceDiagramSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.splitContainer1);
            this.Name = "DefenceDiagramSettings";
            this.Size = new System.Drawing.Size(758, 448);
            this.Load += new System.EventHandler(this.DefenceDiagramSettings_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox CodtDomainComboBox;

    }
}
