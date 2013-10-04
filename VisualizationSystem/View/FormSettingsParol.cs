﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VisualizationSystem.Model;

namespace VisualizationSystem.View
{
    public partial class FormSettingsParol : Form
    {
        private string _parol = "12777";
        public FormSettingsParol()
        {
            InitializeComponent();
        }

        private void FormSettingsParol_Load(object sender, EventArgs e)
        {
            textBoxSettingsParol.Clear();
        }

        private void buttonSettingsParol_Click(object sender, EventArgs e)
        {
            if (textBoxSettingsParol.Text == _parol)
            {
                IoC.Resolve<FormSettings>().ShowDialog();
                IoC.Resolve<FormSettingsParol>().Close();
            }
            else
            {
                MessageBox.Show("Введенный пароль - неверный!", "Неверный пароль", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                textBoxSettingsParol.Clear();
            }
        }

        private void textBoxSettingsParol_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == '\b');
        }
    }
}
