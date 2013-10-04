namespace VisualizationSystem.View
{
    partial class FormSettingsParol
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSettingsParol = new System.Windows.Forms.TextBox();
            this.buttonSettingsParol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите пароль";
            // 
            // textBoxSettingsParol
            // 
            this.textBoxSettingsParol.BackColor = System.Drawing.Color.White;
            this.textBoxSettingsParol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSettingsParol.Location = new System.Drawing.Point(35, 46);
            this.textBoxSettingsParol.Name = "textBoxSettingsParol";
            this.textBoxSettingsParol.PasswordChar = '*';
            this.textBoxSettingsParol.Size = new System.Drawing.Size(100, 22);
            this.textBoxSettingsParol.TabIndex = 1;
            this.textBoxSettingsParol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSettingsParol_KeyPress);
            // 
            // buttonSettingsParol
            // 
            this.buttonSettingsParol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonSettingsParol.FlatAppearance.BorderSize = 0;
            this.buttonSettingsParol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettingsParol.Location = new System.Drawing.Point(47, 82);
            this.buttonSettingsParol.Name = "buttonSettingsParol";
            this.buttonSettingsParol.Size = new System.Drawing.Size(75, 23);
            this.buttonSettingsParol.TabIndex = 2;
            this.buttonSettingsParol.Text = "OK";
            this.buttonSettingsParol.UseVisualStyleBackColor = false;
            this.buttonSettingsParol.Click += new System.EventHandler(this.buttonSettingsParol_Click);
            // 
            // FormSettingsParol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(175, 117);
            this.Controls.Add(this.buttonSettingsParol);
            this.Controls.Add(this.textBoxSettingsParol);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettingsParol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пароль для настроек";
            this.Load += new System.EventHandler(this.FormSettingsParol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSettingsParol;
        private System.Windows.Forms.Button buttonSettingsParol;
    }
}