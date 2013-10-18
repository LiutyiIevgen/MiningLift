namespace VisualizationSystem.View
{
    partial class ParametersSettings
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
            this.dataGridViewVariableParameters = new System.Windows.Forms.DataGridView();
            this.dataGridViewReadOnlyParameters = new System.Windows.Forms.DataGridView();
            this.AddRowButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariableParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadOnlyParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewVariableParameters
            // 
            this.dataGridViewVariableParameters.AllowUserToAddRows = false;
            this.dataGridViewVariableParameters.AllowUserToDeleteRows = false;
            this.dataGridViewVariableParameters.AllowUserToResizeColumns = false;
            this.dataGridViewVariableParameters.AllowUserToResizeRows = false;
            this.dataGridViewVariableParameters.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewVariableParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVariableParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewVariableParameters.Location = new System.Drawing.Point(20, 3);
            this.dataGridViewVariableParameters.Name = "dataGridViewVariableParameters";
            this.dataGridViewVariableParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewVariableParameters.Size = new System.Drawing.Size(719, 309);
            this.dataGridViewVariableParameters.TabIndex = 0;
            this.dataGridViewVariableParameters.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVariableParameters_CellEndEdit);
            this.dataGridViewVariableParameters.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewVariableParameters_EditingControlShowing);
            // 
            // dataGridViewReadOnlyParameters
            // 
            this.dataGridViewReadOnlyParameters.AllowUserToAddRows = false;
            this.dataGridViewReadOnlyParameters.AllowUserToDeleteRows = false;
            this.dataGridViewReadOnlyParameters.AllowUserToResizeColumns = false;
            this.dataGridViewReadOnlyParameters.AllowUserToResizeRows = false;
            this.dataGridViewReadOnlyParameters.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewReadOnlyParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReadOnlyParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewReadOnlyParameters.Location = new System.Drawing.Point(20, 356);
            this.dataGridViewReadOnlyParameters.Name = "dataGridViewReadOnlyParameters";
            this.dataGridViewReadOnlyParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewReadOnlyParameters.Size = new System.Drawing.Size(719, 89);
            this.dataGridViewReadOnlyParameters.TabIndex = 1;
            // 
            // AddRowButton
            // 
            this.AddRowButton.Location = new System.Drawing.Point(570, 318);
            this.AddRowButton.Name = "AddRowButton";
            this.AddRowButton.Size = new System.Drawing.Size(79, 23);
            this.AddRowButton.TabIndex = 2;
            this.AddRowButton.Text = "Добавить";
            this.AddRowButton.UseVisualStyleBackColor = true;
            this.AddRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(655, 318);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(84, 23);
            this.ApplyButton.TabIndex = 3;
            this.ApplyButton.Text = "Применить";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "№";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Индекс";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Название";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 400;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Значение";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Индекс";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Название";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 400;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Значение";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ParametersSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.AddRowButton);
            this.Controls.Add(this.dataGridViewReadOnlyParameters);
            this.Controls.Add(this.dataGridViewVariableParameters);
            this.Name = "ParametersSettings";
            this.Size = new System.Drawing.Size(758, 448);
            this.Load += new System.EventHandler(this.ParametersSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariableParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadOnlyParameters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewVariableParameters;
        private System.Windows.Forms.DataGridView dataGridViewReadOnlyParameters;
        private System.Windows.Forms.Button AddRowButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
