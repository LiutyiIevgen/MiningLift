using System.Drawing;
using System.Windows.Forms;
using VisualizationSystem.Model;

namespace VisualizationSystem.View.UserControls
{
    partial class MainView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.splitContainer9 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer11 = new System.Windows.Forms.SplitContainer();
            this.splitContainer14 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.splitContainer12 = new System.Windows.Forms.SplitContainer();
            this.splitContainer15 = new System.Windows.Forms.SplitContainer();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.splitContainer13 = new System.Windows.Forms.SplitContainer();
            this.splitContainer16 = new System.Windows.Forms.SplitContainer();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.splitContainer17 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chartVA = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.splitContainer18 = new System.Windows.Forms.SplitContainer();
            this.splitContainer19 = new System.Windows.Forms.SplitContainer();
            this.label59 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.textBoxNoInf = new System.Windows.Forms.TextBox();
            this.textBoxLogicZero = new System.Windows.Forms.TextBox();
            this.textBoxLogicOne = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.splitContainer20 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox53 = new System.Windows.Forms.TextBox();
            this.textBox52 = new System.Windows.Forms.TextBox();
            this.textBox51 = new System.Windows.Forms.TextBox();
            this.textBox50 = new System.Windows.Forms.TextBox();
            this.textBox49 = new System.Windows.Forms.TextBox();
            this.textBox48 = new System.Windows.Forms.TextBox();
            this.textBox47 = new System.Windows.Forms.TextBox();
            this.textBox46 = new System.Windows.Forms.TextBox();
            this.textBox45 = new System.Windows.Forms.TextBox();
            this.textBox44 = new System.Windows.Forms.TextBox();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.textBox42 = new System.Windows.Forms.TextBox();
            this.textBox41 = new System.Windows.Forms.TextBox();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.textBox39 = new System.Windows.Forms.TextBox();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label60 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label61 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label62 = new System.Windows.Forms.Label();
            this.textBoxRecordsCount = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.textBoxCurrentRecord = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridViewParameters = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new VisualizationSystem.Model.MyPanel();
            this.richTextBox1 = new VisualizationSystem.Model.MyRichTextBox();
            this.panel6 = new VisualizationSystem.Model.MyPanel();
            this.richTextBox2 = new VisualizationSystem.Model.MyRichTextBox();
            this.panel3 = new VisualizationSystem.Model.MyPanel();
            this.panel4 = new VisualizationSystem.Model.MyPanel();
            this.panel5 = new VisualizationSystem.Model.MyPanel();
            this.richTextBox16 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox28 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox27 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox26 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox25 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox24 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox23 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox22 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox21 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox20 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox19 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox18 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox17 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox15 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox14 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox13 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox12 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox11 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox10 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox9 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox8 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox7 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox6 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox5 = new VisualizationSystem.Model.MyRichTextBox();
            this.richTextBox3 = new VisualizationSystem.Model.MyRichTextBox();
            this.panel7 = new VisualizationSystem.Model.MyPanel();
            this.richTextBox4 = new VisualizationSystem.Model.MyRichTextBox();
            this.panel2 = new VisualizationSystem.Model.MyPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).BeginInit();
            this.splitContainer9.Panel1.SuspendLayout();
            this.splitContainer9.Panel2.SuspendLayout();
            this.splitContainer9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).BeginInit();
            this.splitContainer11.Panel1.SuspendLayout();
            this.splitContainer11.Panel2.SuspendLayout();
            this.splitContainer11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer14)).BeginInit();
            this.splitContainer14.Panel1.SuspendLayout();
            this.splitContainer14.Panel2.SuspendLayout();
            this.splitContainer14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).BeginInit();
            this.splitContainer12.Panel1.SuspendLayout();
            this.splitContainer12.Panel2.SuspendLayout();
            this.splitContainer12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer15)).BeginInit();
            this.splitContainer15.Panel1.SuspendLayout();
            this.splitContainer15.Panel2.SuspendLayout();
            this.splitContainer15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer13)).BeginInit();
            this.splitContainer13.Panel1.SuspendLayout();
            this.splitContainer13.Panel2.SuspendLayout();
            this.splitContainer13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer16)).BeginInit();
            this.splitContainer16.Panel1.SuspendLayout();
            this.splitContainer16.Panel2.SuspendLayout();
            this.splitContainer16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer17)).BeginInit();
            this.splitContainer17.Panel2.SuspendLayout();
            this.splitContainer17.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVA)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer18)).BeginInit();
            this.splitContainer18.Panel1.SuspendLayout();
            this.splitContainer18.Panel2.SuspendLayout();
            this.splitContainer18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer19)).BeginInit();
            this.splitContainer19.Panel1.SuspendLayout();
            this.splitContainer19.Panel2.SuspendLayout();
            this.splitContainer19.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer20)).BeginInit();
            this.splitContainer20.Panel1.SuspendLayout();
            this.splitContainer20.Panel2.SuspendLayout();
            this.splitContainer20.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).BeginInit();
            this.splitContainer8.Panel1.SuspendLayout();
            this.splitContainer8.Panel2.SuspendLayout();
            this.splitContainer8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).BeginInit();
            this.splitContainer10.Panel1.SuspendLayout();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1344, 662);
            this.splitContainer1.SplitterDistance = 302;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.splitContainer3.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Size = new System.Drawing.Size(302, 662);
            this.splitContainer3.SplitterDistance = 51;
            this.splitContainer3.TabIndex = 0;
            this.splitContainer3.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem1.Text = "Настройки";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Gray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBox1.Location = new System.Drawing.Point(4, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 47);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer7);
            this.splitContainer5.Size = new System.Drawing.Size(302, 607);
            this.splitContainer5.SplitterDistance = 164;
            this.splitContainer5.TabIndex = 0;
            this.splitContainer5.TabStop = false;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.richTextBox1);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.splitContainer9);
            this.splitContainer7.Size = new System.Drawing.Size(134, 607);
            this.splitContainer7.SplitterDistance = 29;
            this.splitContainer7.TabIndex = 0;
            this.splitContainer7.TabStop = false;
            // 
            // splitContainer9
            // 
            this.splitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer9.Location = new System.Drawing.Point(0, 0);
            this.splitContainer9.Name = "splitContainer9";
            this.splitContainer9.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer9.Panel1
            // 
            this.splitContainer9.Panel1.Controls.Add(this.panel6);
            // 
            // splitContainer9.Panel2
            // 
            this.splitContainer9.Panel2.Controls.Add(this.richTextBox2);
            this.splitContainer9.Size = new System.Drawing.Size(134, 574);
            this.splitContainer9.SplitterDistance = 540;
            this.splitContainer9.TabIndex = 0;
            this.splitContainer9.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer11);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(1038, 662);
            this.splitContainer2.SplitterDistance = 732;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // splitContainer11
            // 
            this.splitContainer11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer11.Location = new System.Drawing.Point(0, 0);
            this.splitContainer11.Name = "splitContainer11";
            this.splitContainer11.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer11.Panel1
            // 
            this.splitContainer11.Panel1.Controls.Add(this.splitContainer14);
            // 
            // splitContainer11.Panel2
            // 
            this.splitContainer11.Panel2.Controls.Add(this.splitContainer12);
            this.splitContainer11.Size = new System.Drawing.Size(732, 662);
            this.splitContainer11.SplitterDistance = 53;
            this.splitContainer11.TabIndex = 0;
            this.splitContainer11.TabStop = false;
            // 
            // splitContainer14
            // 
            this.splitContainer14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer14.Location = new System.Drawing.Point(0, 0);
            this.splitContainer14.Name = "splitContainer14";
            // 
            // splitContainer14.Panel1
            // 
            this.splitContainer14.Panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.splitContainer14.Panel1.Controls.Add(this.label6);
            this.splitContainer14.Panel1.Controls.Add(this.label3);
            this.splitContainer14.Panel1.Controls.Add(this.textBox3);
            // 
            // splitContainer14.Panel2
            // 
            this.splitContainer14.Panel2.Controls.Add(this.panel3);
            this.splitContainer14.Size = new System.Drawing.Size(732, 53);
            this.splitContainer14.SplitterDistance = 206;
            this.splitContainer14.TabIndex = 0;
            this.splitContainer14.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ContextMenuStrip = this.contextMenuStrip1;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(149, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 33);
            this.label6.TabIndex = 3;
            this.label6.Text = "м/с";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ContextMenuStrip = this.contextMenuStrip1;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(4, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "V";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Gray;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.textBox3.Location = new System.Drawing.Point(39, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(110, 47);
            this.textBox3.TabIndex = 0;
            this.textBox3.TabStop = false;
            // 
            // splitContainer12
            // 
            this.splitContainer12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer12.Location = new System.Drawing.Point(0, 0);
            this.splitContainer12.Name = "splitContainer12";
            this.splitContainer12.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer12.Panel1
            // 
            this.splitContainer12.Panel1.Controls.Add(this.splitContainer15);
            // 
            // splitContainer12.Panel2
            // 
            this.splitContainer12.Panel2.Controls.Add(this.splitContainer13);
            this.splitContainer12.Size = new System.Drawing.Size(732, 605);
            this.splitContainer12.SplitterDistance = 51;
            this.splitContainer12.TabIndex = 0;
            this.splitContainer12.TabStop = false;
            // 
            // splitContainer15
            // 
            this.splitContainer15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer15.Location = new System.Drawing.Point(0, 0);
            this.splitContainer15.Name = "splitContainer15";
            // 
            // splitContainer15.Panel1
            // 
            this.splitContainer15.Panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.splitContainer15.Panel1.Controls.Add(this.label8);
            this.splitContainer15.Panel1.Controls.Add(this.label7);
            this.splitContainer15.Panel1.Controls.Add(this.textBox4);
            // 
            // splitContainer15.Panel2
            // 
            this.splitContainer15.Panel2.Controls.Add(this.panel4);
            this.splitContainer15.Size = new System.Drawing.Size(732, 51);
            this.splitContainer15.SplitterDistance = 206;
            this.splitContainer15.TabIndex = 1;
            this.splitContainer15.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ContextMenuStrip = this.contextMenuStrip1;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(155, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 33);
            this.label8.TabIndex = 4;
            this.label8.Text = "кA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ContextMenuStrip = this.contextMenuStrip1;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(1, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 33);
            this.label7.TabIndex = 3;
            this.label7.Text = "Iя";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Gray;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.textBox4.Location = new System.Drawing.Point(40, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(110, 47);
            this.textBox4.TabIndex = 1;
            this.textBox4.TabStop = false;
            // 
            // splitContainer13
            // 
            this.splitContainer13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer13.Location = new System.Drawing.Point(0, 0);
            this.splitContainer13.Name = "splitContainer13";
            this.splitContainer13.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer13.Panel1
            // 
            this.splitContainer13.Panel1.Controls.Add(this.splitContainer16);
            // 
            // splitContainer13.Panel2
            // 
            this.splitContainer13.Panel2.Controls.Add(this.splitContainer17);
            this.splitContainer13.Size = new System.Drawing.Size(732, 550);
            this.splitContainer13.SplitterDistance = 52;
            this.splitContainer13.TabIndex = 0;
            this.splitContainer13.TabStop = false;
            // 
            // splitContainer16
            // 
            this.splitContainer16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer16.Location = new System.Drawing.Point(0, 0);
            this.splitContainer16.Name = "splitContainer16";
            // 
            // splitContainer16.Panel1
            // 
            this.splitContainer16.Panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.splitContainer16.Panel1.Controls.Add(this.label9);
            this.splitContainer16.Panel1.Controls.Add(this.label10);
            this.splitContainer16.Panel1.Controls.Add(this.textBox5);
            // 
            // splitContainer16.Panel2
            // 
            this.splitContainer16.Panel2.Controls.Add(this.panel5);
            this.splitContainer16.Size = new System.Drawing.Size(732, 52);
            this.splitContainer16.SplitterDistance = 206;
            this.splitContainer16.TabIndex = 1;
            this.splitContainer16.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ContextMenuStrip = this.contextMenuStrip1;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(160, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 33);
            this.label9.TabIndex = 4;
            this.label9.Text = "A";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ContextMenuStrip = this.contextMenuStrip1;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(1, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 33);
            this.label10.TabIndex = 3;
            this.label10.Text = "Iв";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Gray;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.textBox5.Location = new System.Drawing.Point(40, 3);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(110, 47);
            this.textBox5.TabIndex = 1;
            this.textBox5.TabStop = false;
            // 
            // splitContainer17
            // 
            this.splitContainer17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer17.IsSplitterFixed = true;
            this.splitContainer17.Location = new System.Drawing.Point(0, 0);
            this.splitContainer17.Name = "splitContainer17";
            this.splitContainer17.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer17.Panel1
            // 
            this.splitContainer17.Panel1.ContextMenuStrip = this.contextMenuStrip1;
            // 
            // splitContainer17.Panel2
            // 
            this.splitContainer17.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer17.Size = new System.Drawing.Size(732, 494);
            this.splitContainer17.SplitterDistance = 25;
            this.splitContainer17.TabIndex = 0;
            this.splitContainer17.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(732, 465);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gray;
            this.tabPage1.Controls.Add(this.chartVA);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(724, 373);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " Цикл";
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
            this.chartVA.ContextMenuStrip = this.contextMenuStrip1;
            this.chartVA.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Gray;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chartVA.Legends.Add(legend1);
            this.chartVA.Location = new System.Drawing.Point(3, 3);
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
            series4.Legend = "Legend1";
            series4.Name = "Защитная диаграмма";
            this.chartVA.Series.Add(series1);
            this.chartVA.Series.Add(series2);
            this.chartVA.Series.Add(series3);
            this.chartVA.Series.Add(series4);
            this.chartVA.Size = new System.Drawing.Size(718, 367);
            this.chartVA.TabIndex = 0;
            this.chartVA.TabStop = false;
            this.chartVA.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gray;
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(724, 373);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Цепь ТП";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.richTextBox16, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox28, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox27, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox26, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox25, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox24, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox23, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox22, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox21, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox20, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox19, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox18, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox17, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox15, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox14, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox13, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox12, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox11, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox10, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox9, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox8, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(718, 409);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gray;
            this.tabPage3.Controls.Add(this.tabControl2);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(724, 373);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "АУЗИ-Д";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(724, 415);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.TabStop = false;
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.Gray;
            this.tabPage8.Controls.Add(this.splitContainer18);
            this.tabPage8.Location = new System.Drawing.Point(4, 29);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(716, 382);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "Входные и выходные сигналы";
            // 
            // splitContainer18
            // 
            this.splitContainer18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer18.Location = new System.Drawing.Point(3, 3);
            this.splitContainer18.Name = "splitContainer18";
            // 
            // splitContainer18.Panel1
            // 
            this.splitContainer18.Panel1.Controls.Add(this.splitContainer19);
            // 
            // splitContainer18.Panel2
            // 
            this.splitContainer18.Panel2.Controls.Add(this.splitContainer20);
            this.splitContainer18.Size = new System.Drawing.Size(710, 376);
            this.splitContainer18.SplitterDistance = 477;
            this.splitContainer18.TabIndex = 0;
            this.splitContainer18.TabStop = false;
            // 
            // splitContainer19
            // 
            this.splitContainer19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer19.Location = new System.Drawing.Point(0, 0);
            this.splitContainer19.Name = "splitContainer19";
            this.splitContainer19.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer19.Panel1
            // 
            this.splitContainer19.Panel1.Controls.Add(this.label59);
            this.splitContainer19.Panel1.Controls.Add(this.label58);
            this.splitContainer19.Panel1.Controls.Add(this.label57);
            this.splitContainer19.Panel1.Controls.Add(this.textBoxNoInf);
            this.splitContainer19.Panel1.Controls.Add(this.textBoxLogicZero);
            this.splitContainer19.Panel1.Controls.Add(this.textBoxLogicOne);
            this.splitContainer19.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer19.Panel2
            // 
            this.splitContainer19.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer19.Size = new System.Drawing.Size(477, 376);
            this.splitContainer19.SplitterDistance = 28;
            this.splitContainer19.TabIndex = 0;
            this.splitContainer19.TabStop = false;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label59.Location = new System.Drawing.Point(397, 4);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(74, 15);
            this.label59.TabIndex = 38;
            this.label59.Text = "нет данных";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label58.Location = new System.Drawing.Point(321, 4);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(44, 15);
            this.label58.TabIndex = 37;
            this.label58.Text = "лог \"1\"";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label57.Location = new System.Drawing.Point(243, 4);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(44, 15);
            this.label57.TabIndex = 36;
            this.label57.Text = "лог \"0\"";
            // 
            // textBoxNoInf
            // 
            this.textBoxNoInf.BackColor = System.Drawing.Color.White;
            this.textBoxNoInf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNoInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNoInf.Location = new System.Drawing.Point(374, 4);
            this.textBoxNoInf.Name = "textBoxNoInf";
            this.textBoxNoInf.ReadOnly = true;
            this.textBoxNoInf.Size = new System.Drawing.Size(17, 15);
            this.textBoxNoInf.TabIndex = 35;
            this.textBoxNoInf.TabStop = false;
            // 
            // textBoxLogicZero
            // 
            this.textBoxLogicZero.BackColor = System.Drawing.Color.Red;
            this.textBoxLogicZero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLogicZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLogicZero.Location = new System.Drawing.Point(299, 4);
            this.textBoxLogicZero.Name = "textBoxLogicZero";
            this.textBoxLogicZero.ReadOnly = true;
            this.textBoxLogicZero.Size = new System.Drawing.Size(17, 15);
            this.textBoxLogicZero.TabIndex = 34;
            this.textBoxLogicZero.TabStop = false;
            // 
            // textBoxLogicOne
            // 
            this.textBoxLogicOne.BackColor = System.Drawing.Color.LightGray;
            this.textBoxLogicOne.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLogicOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLogicOne.Location = new System.Drawing.Point(221, 4);
            this.textBoxLogicOne.Name = "textBoxLogicOne";
            this.textBoxLogicOne.ReadOnly = true;
            this.textBoxLogicOne.Size = new System.Drawing.Size(17, 15);
            this.textBoxLogicOne.TabIndex = 33;
            this.textBoxLogicOne.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Входные";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.Controls.Add(this.textBox37, 2, 15);
            this.tableLayoutPanel2.Controls.Add(this.textBox36, 2, 14);
            this.tableLayoutPanel2.Controls.Add(this.textBox35, 2, 13);
            this.tableLayoutPanel2.Controls.Add(this.textBox34, 2, 12);
            this.tableLayoutPanel2.Controls.Add(this.textBox33, 2, 11);
            this.tableLayoutPanel2.Controls.Add(this.textBox32, 2, 10);
            this.tableLayoutPanel2.Controls.Add(this.textBox31, 2, 9);
            this.tableLayoutPanel2.Controls.Add(this.textBox30, 2, 8);
            this.tableLayoutPanel2.Controls.Add(this.textBox29, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.textBox28, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.textBox27, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.textBox26, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBox25, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBox24, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox23, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox22, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label12, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label13, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label14, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label15, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label16, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.label17, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.label18, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.label19, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.label20, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.label21, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.label22, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.label23, 1, 14);
            this.tableLayoutPanel2.Controls.Add(this.label25, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label26, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label27, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label28, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.label29, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.label30, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.label31, 3, 6);
            this.tableLayoutPanel2.Controls.Add(this.label32, 3, 7);
            this.tableLayoutPanel2.Controls.Add(this.label33, 3, 8);
            this.tableLayoutPanel2.Controls.Add(this.label34, 3, 9);
            this.tableLayoutPanel2.Controls.Add(this.label35, 3, 10);
            this.tableLayoutPanel2.Controls.Add(this.label36, 3, 11);
            this.tableLayoutPanel2.Controls.Add(this.label37, 3, 12);
            this.tableLayoutPanel2.Controls.Add(this.label38, 3, 13);
            this.tableLayoutPanel2.Controls.Add(this.label39, 3, 14);
            this.tableLayoutPanel2.Controls.Add(this.label40, 3, 15);
            this.tableLayoutPanel2.Controls.Add(this.textBox6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox9, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBox10, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBox11, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.textBox12, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.textBox13, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.textBox14, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.textBox15, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.textBox16, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.textBox17, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.textBox18, 0, 12);
            this.tableLayoutPanel2.Controls.Add(this.textBox19, 0, 13);
            this.tableLayoutPanel2.Controls.Add(this.textBox20, 0, 14);
            this.tableLayoutPanel2.Controls.Add(this.textBox21, 0, 15);
            this.tableLayoutPanel2.Controls.Add(this.label24, 1, 15);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 16;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(475, 342);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // textBox37
            // 
            this.textBox37.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox37.Location = new System.Drawing.Point(239, 318);
            this.textBox37.Name = "textBox37";
            this.textBox37.ReadOnly = true;
            this.textBox37.Size = new System.Drawing.Size(17, 15);
            this.textBox37.TabIndex = 63;
            this.textBox37.TabStop = false;
            // 
            // textBox36
            // 
            this.textBox36.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox36.Location = new System.Drawing.Point(239, 297);
            this.textBox36.Name = "textBox36";
            this.textBox36.ReadOnly = true;
            this.textBox36.Size = new System.Drawing.Size(17, 15);
            this.textBox36.TabIndex = 62;
            this.textBox36.TabStop = false;
            // 
            // textBox35
            // 
            this.textBox35.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox35.Location = new System.Drawing.Point(239, 276);
            this.textBox35.Name = "textBox35";
            this.textBox35.ReadOnly = true;
            this.textBox35.Size = new System.Drawing.Size(17, 15);
            this.textBox35.TabIndex = 61;
            this.textBox35.TabStop = false;
            // 
            // textBox34
            // 
            this.textBox34.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox34.Location = new System.Drawing.Point(239, 255);
            this.textBox34.Name = "textBox34";
            this.textBox34.ReadOnly = true;
            this.textBox34.Size = new System.Drawing.Size(17, 15);
            this.textBox34.TabIndex = 60;
            this.textBox34.TabStop = false;
            // 
            // textBox33
            // 
            this.textBox33.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox33.Location = new System.Drawing.Point(239, 234);
            this.textBox33.Name = "textBox33";
            this.textBox33.ReadOnly = true;
            this.textBox33.Size = new System.Drawing.Size(17, 15);
            this.textBox33.TabIndex = 59;
            this.textBox33.TabStop = false;
            // 
            // textBox32
            // 
            this.textBox32.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox32.Location = new System.Drawing.Point(239, 213);
            this.textBox32.Name = "textBox32";
            this.textBox32.ReadOnly = true;
            this.textBox32.Size = new System.Drawing.Size(17, 15);
            this.textBox32.TabIndex = 58;
            this.textBox32.TabStop = false;
            // 
            // textBox31
            // 
            this.textBox31.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox31.Location = new System.Drawing.Point(239, 192);
            this.textBox31.Name = "textBox31";
            this.textBox31.ReadOnly = true;
            this.textBox31.Size = new System.Drawing.Size(17, 15);
            this.textBox31.TabIndex = 57;
            this.textBox31.TabStop = false;
            // 
            // textBox30
            // 
            this.textBox30.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox30.Location = new System.Drawing.Point(239, 171);
            this.textBox30.Name = "textBox30";
            this.textBox30.ReadOnly = true;
            this.textBox30.Size = new System.Drawing.Size(17, 15);
            this.textBox30.TabIndex = 56;
            this.textBox30.TabStop = false;
            // 
            // textBox29
            // 
            this.textBox29.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox29.Location = new System.Drawing.Point(239, 150);
            this.textBox29.Name = "textBox29";
            this.textBox29.ReadOnly = true;
            this.textBox29.Size = new System.Drawing.Size(17, 15);
            this.textBox29.TabIndex = 55;
            this.textBox29.TabStop = false;
            // 
            // textBox28
            // 
            this.textBox28.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox28.Location = new System.Drawing.Point(239, 129);
            this.textBox28.Name = "textBox28";
            this.textBox28.ReadOnly = true;
            this.textBox28.Size = new System.Drawing.Size(17, 15);
            this.textBox28.TabIndex = 54;
            this.textBox28.TabStop = false;
            // 
            // textBox27
            // 
            this.textBox27.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox27.Location = new System.Drawing.Point(239, 108);
            this.textBox27.Name = "textBox27";
            this.textBox27.ReadOnly = true;
            this.textBox27.Size = new System.Drawing.Size(17, 15);
            this.textBox27.TabIndex = 53;
            this.textBox27.TabStop = false;
            // 
            // textBox26
            // 
            this.textBox26.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox26.Location = new System.Drawing.Point(239, 87);
            this.textBox26.Name = "textBox26";
            this.textBox26.ReadOnly = true;
            this.textBox26.Size = new System.Drawing.Size(17, 15);
            this.textBox26.TabIndex = 52;
            this.textBox26.TabStop = false;
            // 
            // textBox25
            // 
            this.textBox25.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox25.Location = new System.Drawing.Point(239, 66);
            this.textBox25.Name = "textBox25";
            this.textBox25.ReadOnly = true;
            this.textBox25.Size = new System.Drawing.Size(17, 15);
            this.textBox25.TabIndex = 51;
            this.textBox25.TabStop = false;
            // 
            // textBox24
            // 
            this.textBox24.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox24.Location = new System.Drawing.Point(239, 45);
            this.textBox24.Name = "textBox24";
            this.textBox24.ReadOnly = true;
            this.textBox24.Size = new System.Drawing.Size(17, 15);
            this.textBox24.TabIndex = 50;
            this.textBox24.TabStop = false;
            // 
            // textBox23
            // 
            this.textBox23.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox23.Location = new System.Drawing.Point(239, 24);
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(17, 15);
            this.textBox23.TabIndex = 49;
            this.textBox23.TabStop = false;
            // 
            // textBox22
            // 
            this.textBox22.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox22.Location = new System.Drawing.Point(239, 3);
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(17, 15);
            this.textBox22.TabIndex = 48;
            this.textBox22.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(26, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(26, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "label5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(26, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(26, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "label12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(26, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 15);
            this.label13.TabIndex = 4;
            this.label13.Text = "label13";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(26, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 15);
            this.label14.TabIndex = 5;
            this.label14.Text = "label14";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(26, 126);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 15);
            this.label15.TabIndex = 6;
            this.label15.Text = "label15";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(26, 147);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 15);
            this.label16.TabIndex = 7;
            this.label16.Text = "label16";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(26, 168);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 15);
            this.label17.TabIndex = 8;
            this.label17.Text = "label17";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(26, 189);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 15);
            this.label18.TabIndex = 9;
            this.label18.Text = "label18";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(26, 210);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 15);
            this.label19.TabIndex = 10;
            this.label19.Text = "label19";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(26, 231);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 15);
            this.label20.TabIndex = 11;
            this.label20.Text = "label20";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(26, 252);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 15);
            this.label21.TabIndex = 12;
            this.label21.Text = "label21";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(26, 273);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 15);
            this.label22.TabIndex = 13;
            this.label22.Text = "label22";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(26, 294);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 15);
            this.label23.TabIndex = 14;
            this.label23.Text = "label23";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.Location = new System.Drawing.Point(262, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 15);
            this.label25.TabIndex = 16;
            this.label25.Text = "label25";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(262, 21);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 15);
            this.label26.TabIndex = 17;
            this.label26.Text = "label26";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(262, 42);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(48, 15);
            this.label27.TabIndex = 18;
            this.label27.Text = "label27";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label28.Location = new System.Drawing.Point(262, 63);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 15);
            this.label28.TabIndex = 19;
            this.label28.Text = "label28";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label29.Location = new System.Drawing.Point(262, 84);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(48, 15);
            this.label29.TabIndex = 20;
            this.label29.Text = "label29";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label30.Location = new System.Drawing.Point(262, 105);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(48, 15);
            this.label30.TabIndex = 21;
            this.label30.Text = "label30";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label31.Location = new System.Drawing.Point(262, 126);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 15);
            this.label31.TabIndex = 22;
            this.label31.Text = "label31";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label32.Location = new System.Drawing.Point(262, 147);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(48, 15);
            this.label32.TabIndex = 23;
            this.label32.Text = "label32";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label33.Location = new System.Drawing.Point(262, 168);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(48, 15);
            this.label33.TabIndex = 24;
            this.label33.Text = "label33";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label34.Location = new System.Drawing.Point(262, 189);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(48, 15);
            this.label34.TabIndex = 25;
            this.label34.Text = "label34";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label35.Location = new System.Drawing.Point(262, 210);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(48, 15);
            this.label35.TabIndex = 26;
            this.label35.Text = "label35";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label36.Location = new System.Drawing.Point(262, 231);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(48, 15);
            this.label36.TabIndex = 27;
            this.label36.Text = "label36";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label37.Location = new System.Drawing.Point(262, 252);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(48, 15);
            this.label37.TabIndex = 28;
            this.label37.Text = "label37";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label38.Location = new System.Drawing.Point(262, 273);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(48, 15);
            this.label38.TabIndex = 29;
            this.label38.Text = "label38";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label39.Location = new System.Drawing.Point(262, 294);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(48, 15);
            this.label39.TabIndex = 30;
            this.label39.Text = "label39";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label40.Location = new System.Drawing.Point(262, 315);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(48, 15);
            this.label40.TabIndex = 31;
            this.label40.Text = "label40";
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox6.Location = new System.Drawing.Point(3, 3);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(17, 15);
            this.textBox6.TabIndex = 32;
            this.textBox6.TabStop = false;
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox7.Location = new System.Drawing.Point(3, 24);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(17, 15);
            this.textBox7.TabIndex = 33;
            this.textBox7.TabStop = false;
            // 
            // textBox8
            // 
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox8.Location = new System.Drawing.Point(3, 45);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(17, 15);
            this.textBox8.TabIndex = 34;
            this.textBox8.TabStop = false;
            // 
            // textBox9
            // 
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox9.Location = new System.Drawing.Point(3, 66);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(17, 15);
            this.textBox9.TabIndex = 35;
            this.textBox9.TabStop = false;
            // 
            // textBox10
            // 
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox10.Location = new System.Drawing.Point(3, 87);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(17, 15);
            this.textBox10.TabIndex = 36;
            this.textBox10.TabStop = false;
            // 
            // textBox11
            // 
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox11.Location = new System.Drawing.Point(3, 108);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(17, 15);
            this.textBox11.TabIndex = 37;
            this.textBox11.TabStop = false;
            // 
            // textBox12
            // 
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox12.Location = new System.Drawing.Point(3, 129);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(17, 15);
            this.textBox12.TabIndex = 38;
            this.textBox12.TabStop = false;
            // 
            // textBox13
            // 
            this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox13.Location = new System.Drawing.Point(3, 150);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(17, 15);
            this.textBox13.TabIndex = 39;
            this.textBox13.TabStop = false;
            // 
            // textBox14
            // 
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox14.Location = new System.Drawing.Point(3, 171);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(17, 15);
            this.textBox14.TabIndex = 40;
            this.textBox14.TabStop = false;
            // 
            // textBox15
            // 
            this.textBox15.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox15.Location = new System.Drawing.Point(3, 192);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(17, 15);
            this.textBox15.TabIndex = 41;
            this.textBox15.TabStop = false;
            // 
            // textBox16
            // 
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox16.Location = new System.Drawing.Point(3, 213);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(17, 15);
            this.textBox16.TabIndex = 42;
            this.textBox16.TabStop = false;
            // 
            // textBox17
            // 
            this.textBox17.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox17.Location = new System.Drawing.Point(3, 234);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(17, 15);
            this.textBox17.TabIndex = 43;
            this.textBox17.TabStop = false;
            // 
            // textBox18
            // 
            this.textBox18.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox18.Location = new System.Drawing.Point(3, 255);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(17, 15);
            this.textBox18.TabIndex = 44;
            this.textBox18.TabStop = false;
            // 
            // textBox19
            // 
            this.textBox19.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox19.Location = new System.Drawing.Point(3, 276);
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(17, 15);
            this.textBox19.TabIndex = 45;
            this.textBox19.TabStop = false;
            // 
            // textBox20
            // 
            this.textBox20.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox20.Location = new System.Drawing.Point(3, 297);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(17, 15);
            this.textBox20.TabIndex = 46;
            this.textBox20.TabStop = false;
            // 
            // textBox21
            // 
            this.textBox21.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox21.Location = new System.Drawing.Point(3, 318);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(17, 15);
            this.textBox21.TabIndex = 47;
            this.textBox21.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.Location = new System.Drawing.Point(26, 315);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 15);
            this.label24.TabIndex = 15;
            this.label24.Text = "label24";
            // 
            // splitContainer20
            // 
            this.splitContainer20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer20.Location = new System.Drawing.Point(0, 0);
            this.splitContainer20.Name = "splitContainer20";
            this.splitContainer20.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer20.Panel1
            // 
            this.splitContainer20.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer20.Panel2
            // 
            this.splitContainer20.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer20.Size = new System.Drawing.Size(229, 376);
            this.splitContainer20.SplitterDistance = 28;
            this.splitContainer20.TabIndex = 0;
            this.splitContainer20.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Выходные";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.textBox53, 0, 15);
            this.tableLayoutPanel3.Controls.Add(this.textBox52, 0, 14);
            this.tableLayoutPanel3.Controls.Add(this.textBox51, 0, 13);
            this.tableLayoutPanel3.Controls.Add(this.textBox50, 0, 12);
            this.tableLayoutPanel3.Controls.Add(this.textBox49, 0, 11);
            this.tableLayoutPanel3.Controls.Add(this.textBox48, 0, 10);
            this.tableLayoutPanel3.Controls.Add(this.textBox47, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.textBox46, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.textBox45, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.textBox44, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.textBox43, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.textBox42, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.textBox41, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.textBox40, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.textBox39, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox38, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label41, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label42, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label43, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label44, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label45, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label46, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.label47, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.label48, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.label49, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.label50, 1, 9);
            this.tableLayoutPanel3.Controls.Add(this.label51, 1, 10);
            this.tableLayoutPanel3.Controls.Add(this.label52, 1, 11);
            this.tableLayoutPanel3.Controls.Add(this.label53, 1, 12);
            this.tableLayoutPanel3.Controls.Add(this.label54, 1, 13);
            this.tableLayoutPanel3.Controls.Add(this.label55, 1, 14);
            this.tableLayoutPanel3.Controls.Add(this.label56, 1, 15);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 16;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(227, 342);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // textBox53
            // 
            this.textBox53.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox53.Location = new System.Drawing.Point(3, 318);
            this.textBox53.Name = "textBox53";
            this.textBox53.ReadOnly = true;
            this.textBox53.Size = new System.Drawing.Size(16, 15);
            this.textBox53.TabIndex = 63;
            this.textBox53.TabStop = false;
            // 
            // textBox52
            // 
            this.textBox52.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox52.Location = new System.Drawing.Point(3, 297);
            this.textBox52.Name = "textBox52";
            this.textBox52.ReadOnly = true;
            this.textBox52.Size = new System.Drawing.Size(16, 15);
            this.textBox52.TabIndex = 62;
            this.textBox52.TabStop = false;
            // 
            // textBox51
            // 
            this.textBox51.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox51.Location = new System.Drawing.Point(3, 276);
            this.textBox51.Name = "textBox51";
            this.textBox51.ReadOnly = true;
            this.textBox51.Size = new System.Drawing.Size(16, 15);
            this.textBox51.TabIndex = 61;
            this.textBox51.TabStop = false;
            // 
            // textBox50
            // 
            this.textBox50.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox50.Location = new System.Drawing.Point(3, 255);
            this.textBox50.Name = "textBox50";
            this.textBox50.ReadOnly = true;
            this.textBox50.Size = new System.Drawing.Size(16, 15);
            this.textBox50.TabIndex = 60;
            this.textBox50.TabStop = false;
            // 
            // textBox49
            // 
            this.textBox49.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox49.Location = new System.Drawing.Point(3, 234);
            this.textBox49.Name = "textBox49";
            this.textBox49.ReadOnly = true;
            this.textBox49.Size = new System.Drawing.Size(16, 15);
            this.textBox49.TabIndex = 59;
            this.textBox49.TabStop = false;
            // 
            // textBox48
            // 
            this.textBox48.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox48.Location = new System.Drawing.Point(3, 213);
            this.textBox48.Name = "textBox48";
            this.textBox48.ReadOnly = true;
            this.textBox48.Size = new System.Drawing.Size(16, 15);
            this.textBox48.TabIndex = 58;
            this.textBox48.TabStop = false;
            // 
            // textBox47
            // 
            this.textBox47.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox47.Location = new System.Drawing.Point(3, 192);
            this.textBox47.Name = "textBox47";
            this.textBox47.ReadOnly = true;
            this.textBox47.Size = new System.Drawing.Size(16, 15);
            this.textBox47.TabIndex = 57;
            this.textBox47.TabStop = false;
            // 
            // textBox46
            // 
            this.textBox46.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox46.Location = new System.Drawing.Point(3, 171);
            this.textBox46.Name = "textBox46";
            this.textBox46.ReadOnly = true;
            this.textBox46.Size = new System.Drawing.Size(16, 15);
            this.textBox46.TabIndex = 56;
            this.textBox46.TabStop = false;
            // 
            // textBox45
            // 
            this.textBox45.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox45.Location = new System.Drawing.Point(3, 150);
            this.textBox45.Name = "textBox45";
            this.textBox45.ReadOnly = true;
            this.textBox45.Size = new System.Drawing.Size(16, 15);
            this.textBox45.TabIndex = 55;
            this.textBox45.TabStop = false;
            // 
            // textBox44
            // 
            this.textBox44.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox44.Location = new System.Drawing.Point(3, 129);
            this.textBox44.Name = "textBox44";
            this.textBox44.ReadOnly = true;
            this.textBox44.Size = new System.Drawing.Size(16, 15);
            this.textBox44.TabIndex = 54;
            this.textBox44.TabStop = false;
            // 
            // textBox43
            // 
            this.textBox43.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox43.Location = new System.Drawing.Point(3, 108);
            this.textBox43.Name = "textBox43";
            this.textBox43.ReadOnly = true;
            this.textBox43.Size = new System.Drawing.Size(16, 15);
            this.textBox43.TabIndex = 53;
            this.textBox43.TabStop = false;
            // 
            // textBox42
            // 
            this.textBox42.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox42.Location = new System.Drawing.Point(3, 87);
            this.textBox42.Name = "textBox42";
            this.textBox42.ReadOnly = true;
            this.textBox42.Size = new System.Drawing.Size(16, 15);
            this.textBox42.TabIndex = 52;
            this.textBox42.TabStop = false;
            // 
            // textBox41
            // 
            this.textBox41.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox41.Location = new System.Drawing.Point(3, 66);
            this.textBox41.Name = "textBox41";
            this.textBox41.ReadOnly = true;
            this.textBox41.Size = new System.Drawing.Size(16, 15);
            this.textBox41.TabIndex = 51;
            this.textBox41.TabStop = false;
            // 
            // textBox40
            // 
            this.textBox40.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox40.Location = new System.Drawing.Point(3, 45);
            this.textBox40.Name = "textBox40";
            this.textBox40.ReadOnly = true;
            this.textBox40.Size = new System.Drawing.Size(16, 15);
            this.textBox40.TabIndex = 50;
            this.textBox40.TabStop = false;
            // 
            // textBox39
            // 
            this.textBox39.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox39.Location = new System.Drawing.Point(3, 24);
            this.textBox39.Name = "textBox39";
            this.textBox39.ReadOnly = true;
            this.textBox39.Size = new System.Drawing.Size(16, 15);
            this.textBox39.TabIndex = 49;
            this.textBox39.TabStop = false;
            // 
            // textBox38
            // 
            this.textBox38.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox38.Location = new System.Drawing.Point(3, 3);
            this.textBox38.Name = "textBox38";
            this.textBox38.ReadOnly = true;
            this.textBox38.Size = new System.Drawing.Size(16, 15);
            this.textBox38.TabIndex = 48;
            this.textBox38.TabStop = false;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label41.Location = new System.Drawing.Point(25, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(48, 15);
            this.label41.TabIndex = 32;
            this.label41.Text = "label41";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label42.Location = new System.Drawing.Point(25, 21);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(48, 15);
            this.label42.TabIndex = 33;
            this.label42.Text = "label42";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label43.Location = new System.Drawing.Point(25, 42);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(48, 15);
            this.label43.TabIndex = 34;
            this.label43.Text = "label43";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label44.Location = new System.Drawing.Point(25, 63);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(48, 15);
            this.label44.TabIndex = 35;
            this.label44.Text = "label44";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label45.Location = new System.Drawing.Point(25, 84);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(48, 15);
            this.label45.TabIndex = 36;
            this.label45.Text = "label45";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label46.Location = new System.Drawing.Point(25, 105);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(48, 15);
            this.label46.TabIndex = 37;
            this.label46.Text = "label46";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label47.Location = new System.Drawing.Point(25, 126);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(48, 15);
            this.label47.TabIndex = 38;
            this.label47.Text = "label47";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label48.Location = new System.Drawing.Point(25, 147);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(48, 15);
            this.label48.TabIndex = 39;
            this.label48.Text = "label48";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label49.Location = new System.Drawing.Point(25, 168);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(48, 15);
            this.label49.TabIndex = 40;
            this.label49.Text = "label49";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label50.Location = new System.Drawing.Point(25, 189);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(48, 15);
            this.label50.TabIndex = 41;
            this.label50.Text = "label50";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label51.Location = new System.Drawing.Point(25, 210);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(48, 15);
            this.label51.TabIndex = 42;
            this.label51.Text = "label51";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label52.Location = new System.Drawing.Point(25, 231);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(48, 15);
            this.label52.TabIndex = 43;
            this.label52.Text = "label52";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label53.Location = new System.Drawing.Point(25, 252);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(48, 15);
            this.label53.TabIndex = 44;
            this.label53.Text = "label53";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label54.Location = new System.Drawing.Point(25, 273);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(48, 15);
            this.label54.TabIndex = 45;
            this.label54.Text = "label54";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label55.Location = new System.Drawing.Point(25, 294);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(48, 15);
            this.label55.TabIndex = 46;
            this.label55.Text = "label55";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label56.Location = new System.Drawing.Point(25, 315);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(48, 15);
            this.label56.TabIndex = 47;
            this.label56.Text = "label56";
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.Gray;
            this.tabPage9.Location = new System.Drawing.Point(4, 29);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(716, 382);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "tabPage9";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(724, 373);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Журнал";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Gray;
            this.tabPage5.Controls.Add(this.tableLayoutPanel4);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(724, 373);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Архив";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 10;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.523546F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.38781F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.72853F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.74515F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.49584F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.74515F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.800554F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.108033F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.509695F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.955679F));
            this.tableLayoutPanel4.Controls.Add(this.dateTimePicker1, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label60, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.treeView1, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.label61, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.dateTimePicker2, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.label62, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.textBoxRecordsCount, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.label63, 4, 2);
            this.tableLayoutPanel4.Controls.Add(this.textBoxCurrentRecord, 5, 2);
            this.tableLayoutPanel4.Controls.Add(this.buttonFind, 8, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonNext, 9, 2);
            this.tableLayoutPanel4.Controls.Add(this.buttonPrevious, 8, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.246948F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.231955F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.51064F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.00523F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.00523F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(724, 415);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy  HH:mm";
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(217, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 26);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label60.Location = new System.Drawing.Point(89, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(122, 30);
            this.label60.TabIndex = 1;
            this.label60.Text = "От:";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treeView1
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.treeView1, 5);
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.Location = new System.Drawing.Point(14, 71);
            this.treeView1.Name = "treeView1";
            this.tableLayoutPanel4.SetRowSpan(this.treeView1, 3);
            this.treeView1.Size = new System.Drawing.Size(594, 341);
            this.treeView1.TabIndex = 3;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label61.Location = new System.Drawing.Point(374, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(77, 30);
            this.label61.TabIndex = 4;
            this.label61.Text = "До:";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd.MM.yyyy  HH:mm";
            this.dateTimePicker2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(457, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(151, 26);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.label62, 2);
            this.label62.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label62.Location = new System.Drawing.Point(14, 34);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(197, 30);
            this.label62.TabIndex = 6;
            this.label62.Text = "Найдено записей:";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxRecordsCount
            // 
            this.textBoxRecordsCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRecordsCount.Location = new System.Drawing.Point(217, 37);
            this.textBoxRecordsCount.Name = "textBoxRecordsCount";
            this.textBoxRecordsCount.Size = new System.Drawing.Size(151, 26);
            this.textBoxRecordsCount.TabIndex = 7;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label63.Location = new System.Drawing.Point(374, 34);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(77, 30);
            this.label63.TabIndex = 8;
            this.label63.Text = "Текущая:";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCurrentRecord
            // 
            this.textBoxCurrentRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCurrentRecord.Location = new System.Drawing.Point(457, 37);
            this.textBoxCurrentRecord.Name = "textBoxCurrentRecord";
            this.textBoxCurrentRecord.Size = new System.Drawing.Size(76, 26);
            this.textBoxCurrentRecord.TabIndex = 9;
            // 
            // buttonFind
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.buttonFind, 2);
            this.buttonFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFind.Location = new System.Drawing.Point(635, 3);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(86, 24);
            this.buttonFind.TabIndex = 12;
            this.buttonFind.Text = "Поиск";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNext.Location = new System.Drawing.Point(682, 37);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(39, 24);
            this.buttonNext.TabIndex = 11;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPrevious.Location = new System.Drawing.Point(635, 37);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(41, 24);
            this.buttonPrevious.TabIndex = 10;
            this.buttonPrevious.Text = "<";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.Gray;
            this.tabPage6.Controls.Add(this.dataGridViewParameters);
            this.tabPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(724, 373);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Параметры";
            // 
            // dataGridViewParameters
            // 
            this.dataGridViewParameters.AllowUserToAddRows = false;
            this.dataGridViewParameters.AllowUserToDeleteRows = false;
            this.dataGridViewParameters.AllowUserToResizeColumns = false;
            this.dataGridViewParameters.AllowUserToResizeRows = false;
            this.dataGridViewParameters.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewParameters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewParameters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column1,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewParameters.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewParameters.EnableHeadersVisualStyles = false;
            this.dataGridViewParameters.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewParameters.Name = "dataGridViewParameters";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewParameters.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewParameters.Size = new System.Drawing.Size(724, 373);
            this.dataGridViewParameters.TabIndex = 2;
            this.dataGridViewParameters.TabStop = false;
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
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Название";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Тип";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Значение";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(724, 373);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Статистика";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.splitContainer4.Panel1.Controls.Add(this.labelDate);
            this.splitContainer4.Panel1.Controls.Add(this.labelTime);
            this.splitContainer4.Panel1.Controls.Add(this.textBox2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer4.Size = new System.Drawing.Size(302, 662);
            this.splitContainer4.SplitterDistance = 51;
            this.splitContainer4.TabIndex = 1;
            this.splitContainer4.TabStop = false;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelDate.Location = new System.Drawing.Point(27, 27);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(41, 20);
            this.labelDate.TabIndex = 3;
            this.labelDate.Text = "date";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTime.Location = new System.Drawing.Point(35, 3);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(39, 20);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "time";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Gray;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBox2.Location = new System.Drawing.Point(148, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(145, 47);
            this.textBox2.TabIndex = 1;
            this.textBox2.TabStop = false;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.splitContainer8);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.panel2);
            this.splitContainer6.Size = new System.Drawing.Size(302, 607);
            this.splitContainer6.SplitterDistance = 134;
            this.splitContainer6.TabIndex = 0;
            this.splitContainer6.TabStop = false;
            // 
            // splitContainer8
            // 
            this.splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer8.Location = new System.Drawing.Point(0, 0);
            this.splitContainer8.Name = "splitContainer8";
            this.splitContainer8.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer8.Panel1
            // 
            this.splitContainer8.Panel1.Controls.Add(this.richTextBox3);
            // 
            // splitContainer8.Panel2
            // 
            this.splitContainer8.Panel2.Controls.Add(this.splitContainer10);
            this.splitContainer8.Size = new System.Drawing.Size(134, 607);
            this.splitContainer8.SplitterDistance = 29;
            this.splitContainer8.TabIndex = 1;
            this.splitContainer8.TabStop = false;
            // 
            // splitContainer10
            // 
            this.splitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer10.Location = new System.Drawing.Point(0, 0);
            this.splitContainer10.Name = "splitContainer10";
            this.splitContainer10.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer10.Panel1
            // 
            this.splitContainer10.Panel1.Controls.Add(this.panel7);
            // 
            // splitContainer10.Panel2
            // 
            this.splitContainer10.Panel2.Controls.Add(this.richTextBox4);
            this.splitContainer10.Size = new System.Drawing.Size(134, 574);
            this.splitContainer10.SplitterDistance = 540;
            this.splitContainer10.TabIndex = 1;
            this.splitContainer10.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 607);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Gray;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(134, 29);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gray;
            this.panel6.ContextMenuStrip = this.contextMenuStrip1;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(134, 540);
            this.panel6.TabIndex = 0;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.Gray;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox2.ForeColor = System.Drawing.Color.White;
            this.richTextBox2.Location = new System.Drawing.Point(0, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(134, 30);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.TabStop = false;
            this.richTextBox2.Text = "";
            // 
            // panel3
            // 
            this.panel3.ContextMenuStrip = this.contextMenuStrip1;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(522, 53);
            this.panel3.TabIndex = 0;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel4
            // 
            this.panel4.ContextMenuStrip = this.contextMenuStrip1;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(522, 51);
            this.panel4.TabIndex = 0;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel5
            // 
            this.panel5.ContextMenuStrip = this.contextMenuStrip1;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(522, 52);
            this.panel5.TabIndex = 0;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // richTextBox16
            // 
            this.richTextBox16.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox16.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox16.ForeColor = System.Drawing.Color.White;
            this.richTextBox16.Location = new System.Drawing.Point(540, 139);
            this.richTextBox16.Name = "richTextBox16";
            this.richTextBox16.ReadOnly = true;
            this.richTextBox16.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox16.Size = new System.Drawing.Size(175, 62);
            this.richTextBox16.TabIndex = 12;
            this.richTextBox16.TabStop = false;
            this.richTextBox16.Text = "";
            // 
            // richTextBox28
            // 
            this.richTextBox28.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox28.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox28.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox28.ForeColor = System.Drawing.Color.White;
            this.richTextBox28.Location = new System.Drawing.Point(540, 343);
            this.richTextBox28.Name = "richTextBox28";
            this.richTextBox28.ReadOnly = true;
            this.richTextBox28.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox28.Size = new System.Drawing.Size(175, 63);
            this.richTextBox28.TabIndex = 24;
            this.richTextBox28.TabStop = false;
            this.richTextBox28.Text = "";
            // 
            // richTextBox27
            // 
            this.richTextBox27.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox27.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox27.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox27.ForeColor = System.Drawing.Color.White;
            this.richTextBox27.Location = new System.Drawing.Point(361, 343);
            this.richTextBox27.Name = "richTextBox27";
            this.richTextBox27.ReadOnly = true;
            this.richTextBox27.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox27.Size = new System.Drawing.Size(173, 63);
            this.richTextBox27.TabIndex = 23;
            this.richTextBox27.TabStop = false;
            this.richTextBox27.Text = "";
            // 
            // richTextBox26
            // 
            this.richTextBox26.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox26.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox26.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox26.ForeColor = System.Drawing.Color.White;
            this.richTextBox26.Location = new System.Drawing.Point(182, 343);
            this.richTextBox26.Name = "richTextBox26";
            this.richTextBox26.ReadOnly = true;
            this.richTextBox26.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox26.Size = new System.Drawing.Size(173, 63);
            this.richTextBox26.TabIndex = 22;
            this.richTextBox26.TabStop = false;
            this.richTextBox26.Text = "";
            // 
            // richTextBox25
            // 
            this.richTextBox25.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox25.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox25.ForeColor = System.Drawing.Color.White;
            this.richTextBox25.Location = new System.Drawing.Point(3, 343);
            this.richTextBox25.Name = "richTextBox25";
            this.richTextBox25.ReadOnly = true;
            this.richTextBox25.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox25.Size = new System.Drawing.Size(173, 63);
            this.richTextBox25.TabIndex = 21;
            this.richTextBox25.TabStop = false;
            this.richTextBox25.Text = "";
            // 
            // richTextBox24
            // 
            this.richTextBox24.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox24.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox24.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox24.ForeColor = System.Drawing.Color.White;
            this.richTextBox24.Location = new System.Drawing.Point(540, 275);
            this.richTextBox24.Name = "richTextBox24";
            this.richTextBox24.ReadOnly = true;
            this.richTextBox24.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox24.Size = new System.Drawing.Size(175, 62);
            this.richTextBox24.TabIndex = 20;
            this.richTextBox24.TabStop = false;
            this.richTextBox24.Text = "";
            // 
            // richTextBox23
            // 
            this.richTextBox23.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox23.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox23.ForeColor = System.Drawing.Color.White;
            this.richTextBox23.Location = new System.Drawing.Point(361, 275);
            this.richTextBox23.Name = "richTextBox23";
            this.richTextBox23.ReadOnly = true;
            this.richTextBox23.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox23.Size = new System.Drawing.Size(173, 62);
            this.richTextBox23.TabIndex = 19;
            this.richTextBox23.TabStop = false;
            this.richTextBox23.Text = "";
            // 
            // richTextBox22
            // 
            this.richTextBox22.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox22.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox22.ForeColor = System.Drawing.Color.White;
            this.richTextBox22.Location = new System.Drawing.Point(182, 275);
            this.richTextBox22.Name = "richTextBox22";
            this.richTextBox22.ReadOnly = true;
            this.richTextBox22.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox22.Size = new System.Drawing.Size(173, 62);
            this.richTextBox22.TabIndex = 18;
            this.richTextBox22.TabStop = false;
            this.richTextBox22.Text = "";
            // 
            // richTextBox21
            // 
            this.richTextBox21.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox21.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox21.ForeColor = System.Drawing.Color.White;
            this.richTextBox21.Location = new System.Drawing.Point(3, 275);
            this.richTextBox21.Name = "richTextBox21";
            this.richTextBox21.ReadOnly = true;
            this.richTextBox21.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox21.Size = new System.Drawing.Size(173, 62);
            this.richTextBox21.TabIndex = 17;
            this.richTextBox21.TabStop = false;
            this.richTextBox21.Text = "";
            // 
            // richTextBox20
            // 
            this.richTextBox20.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox20.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox20.ForeColor = System.Drawing.Color.White;
            this.richTextBox20.Location = new System.Drawing.Point(540, 207);
            this.richTextBox20.Name = "richTextBox20";
            this.richTextBox20.ReadOnly = true;
            this.richTextBox20.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox20.Size = new System.Drawing.Size(175, 62);
            this.richTextBox20.TabIndex = 16;
            this.richTextBox20.TabStop = false;
            this.richTextBox20.Text = "";
            // 
            // richTextBox19
            // 
            this.richTextBox19.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox19.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox19.ForeColor = System.Drawing.Color.White;
            this.richTextBox19.Location = new System.Drawing.Point(361, 207);
            this.richTextBox19.Name = "richTextBox19";
            this.richTextBox19.ReadOnly = true;
            this.richTextBox19.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox19.Size = new System.Drawing.Size(173, 62);
            this.richTextBox19.TabIndex = 15;
            this.richTextBox19.TabStop = false;
            this.richTextBox19.Text = "";
            // 
            // richTextBox18
            // 
            this.richTextBox18.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox18.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox18.ForeColor = System.Drawing.Color.White;
            this.richTextBox18.Location = new System.Drawing.Point(182, 207);
            this.richTextBox18.Name = "richTextBox18";
            this.richTextBox18.ReadOnly = true;
            this.richTextBox18.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox18.Size = new System.Drawing.Size(173, 62);
            this.richTextBox18.TabIndex = 14;
            this.richTextBox18.TabStop = false;
            this.richTextBox18.Text = "";
            // 
            // richTextBox17
            // 
            this.richTextBox17.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox17.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox17.ForeColor = System.Drawing.Color.White;
            this.richTextBox17.Location = new System.Drawing.Point(3, 207);
            this.richTextBox17.Name = "richTextBox17";
            this.richTextBox17.ReadOnly = true;
            this.richTextBox17.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox17.Size = new System.Drawing.Size(173, 62);
            this.richTextBox17.TabIndex = 13;
            this.richTextBox17.TabStop = false;
            this.richTextBox17.Text = "";
            // 
            // richTextBox15
            // 
            this.richTextBox15.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox15.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox15.ForeColor = System.Drawing.Color.White;
            this.richTextBox15.Location = new System.Drawing.Point(361, 139);
            this.richTextBox15.Name = "richTextBox15";
            this.richTextBox15.ReadOnly = true;
            this.richTextBox15.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox15.Size = new System.Drawing.Size(173, 62);
            this.richTextBox15.TabIndex = 11;
            this.richTextBox15.TabStop = false;
            this.richTextBox15.Text = "";
            // 
            // richTextBox14
            // 
            this.richTextBox14.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox14.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox14.ForeColor = System.Drawing.Color.White;
            this.richTextBox14.Location = new System.Drawing.Point(182, 139);
            this.richTextBox14.Name = "richTextBox14";
            this.richTextBox14.ReadOnly = true;
            this.richTextBox14.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox14.Size = new System.Drawing.Size(173, 62);
            this.richTextBox14.TabIndex = 10;
            this.richTextBox14.TabStop = false;
            this.richTextBox14.Text = "";
            // 
            // richTextBox13
            // 
            this.richTextBox13.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox13.ForeColor = System.Drawing.Color.White;
            this.richTextBox13.Location = new System.Drawing.Point(3, 139);
            this.richTextBox13.Name = "richTextBox13";
            this.richTextBox13.ReadOnly = true;
            this.richTextBox13.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox13.Size = new System.Drawing.Size(173, 62);
            this.richTextBox13.TabIndex = 9;
            this.richTextBox13.TabStop = false;
            this.richTextBox13.Text = "";
            // 
            // richTextBox12
            // 
            this.richTextBox12.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox12.ForeColor = System.Drawing.Color.White;
            this.richTextBox12.Location = new System.Drawing.Point(540, 71);
            this.richTextBox12.Name = "richTextBox12";
            this.richTextBox12.ReadOnly = true;
            this.richTextBox12.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox12.Size = new System.Drawing.Size(175, 62);
            this.richTextBox12.TabIndex = 8;
            this.richTextBox12.TabStop = false;
            this.richTextBox12.Text = "";
            // 
            // richTextBox11
            // 
            this.richTextBox11.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox11.ForeColor = System.Drawing.Color.White;
            this.richTextBox11.Location = new System.Drawing.Point(361, 71);
            this.richTextBox11.Name = "richTextBox11";
            this.richTextBox11.ReadOnly = true;
            this.richTextBox11.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox11.Size = new System.Drawing.Size(173, 62);
            this.richTextBox11.TabIndex = 7;
            this.richTextBox11.TabStop = false;
            this.richTextBox11.Text = "";
            // 
            // richTextBox10
            // 
            this.richTextBox10.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox10.ForeColor = System.Drawing.Color.White;
            this.richTextBox10.Location = new System.Drawing.Point(182, 71);
            this.richTextBox10.Name = "richTextBox10";
            this.richTextBox10.ReadOnly = true;
            this.richTextBox10.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox10.Size = new System.Drawing.Size(173, 62);
            this.richTextBox10.TabIndex = 6;
            this.richTextBox10.TabStop = false;
            this.richTextBox10.Text = "";
            // 
            // richTextBox9
            // 
            this.richTextBox9.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox9.ForeColor = System.Drawing.Color.White;
            this.richTextBox9.Location = new System.Drawing.Point(3, 71);
            this.richTextBox9.Name = "richTextBox9";
            this.richTextBox9.ReadOnly = true;
            this.richTextBox9.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox9.Size = new System.Drawing.Size(173, 62);
            this.richTextBox9.TabIndex = 5;
            this.richTextBox9.TabStop = false;
            this.richTextBox9.Text = "";
            // 
            // richTextBox8
            // 
            this.richTextBox8.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox8.ForeColor = System.Drawing.Color.White;
            this.richTextBox8.Location = new System.Drawing.Point(540, 3);
            this.richTextBox8.Name = "richTextBox8";
            this.richTextBox8.ReadOnly = true;
            this.richTextBox8.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox8.Size = new System.Drawing.Size(175, 62);
            this.richTextBox8.TabIndex = 4;
            this.richTextBox8.TabStop = false;
            this.richTextBox8.Text = "";
            // 
            // richTextBox7
            // 
            this.richTextBox7.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox7.ForeColor = System.Drawing.Color.White;
            this.richTextBox7.Location = new System.Drawing.Point(361, 3);
            this.richTextBox7.Name = "richTextBox7";
            this.richTextBox7.ReadOnly = true;
            this.richTextBox7.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox7.Size = new System.Drawing.Size(173, 62);
            this.richTextBox7.TabIndex = 3;
            this.richTextBox7.TabStop = false;
            this.richTextBox7.Text = "";
            // 
            // richTextBox6
            // 
            this.richTextBox6.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox6.ForeColor = System.Drawing.Color.White;
            this.richTextBox6.Location = new System.Drawing.Point(182, 3);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.ReadOnly = true;
            this.richTextBox6.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox6.Size = new System.Drawing.Size(173, 62);
            this.richTextBox6.TabIndex = 2;
            this.richTextBox6.TabStop = false;
            this.richTextBox6.Text = "";
            // 
            // richTextBox5
            // 
            this.richTextBox5.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox5.ForeColor = System.Drawing.Color.White;
            this.richTextBox5.Location = new System.Drawing.Point(3, 3);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.ReadOnly = true;
            this.richTextBox5.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox5.Size = new System.Drawing.Size(173, 62);
            this.richTextBox5.TabIndex = 1;
            this.richTextBox5.TabStop = false;
            this.richTextBox5.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.Color.Gray;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox3.ForeColor = System.Drawing.Color.White;
            this.richTextBox3.Location = new System.Drawing.Point(0, 0);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(134, 29);
            this.richTextBox3.TabIndex = 1;
            this.richTextBox3.TabStop = false;
            this.richTextBox3.Text = "";
            // 
            // panel7
            // 
            this.panel7.ContextMenuStrip = this.contextMenuStrip1;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(134, 540);
            this.panel7.TabIndex = 0;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.Color.Gray;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox4.ForeColor = System.Drawing.Color.White;
            this.richTextBox4.Location = new System.Drawing.Point(0, 0);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(134, 30);
            this.richTextBox4.TabIndex = 1;
            this.richTextBox4.TabStop = false;
            this.richTextBox4.Text = "";
            // 
            // panel2
            // 
            this.panel2.ContextMenuStrip = this.contextMenuStrip1;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 607);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1344, 662);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.splitContainer9.Panel1.ResumeLayout(false);
            this.splitContainer9.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).EndInit();
            this.splitContainer9.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer11.Panel1.ResumeLayout(false);
            this.splitContainer11.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).EndInit();
            this.splitContainer11.ResumeLayout(false);
            this.splitContainer14.Panel1.ResumeLayout(false);
            this.splitContainer14.Panel1.PerformLayout();
            this.splitContainer14.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer14)).EndInit();
            this.splitContainer14.ResumeLayout(false);
            this.splitContainer12.Panel1.ResumeLayout(false);
            this.splitContainer12.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).EndInit();
            this.splitContainer12.ResumeLayout(false);
            this.splitContainer15.Panel1.ResumeLayout(false);
            this.splitContainer15.Panel1.PerformLayout();
            this.splitContainer15.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer15)).EndInit();
            this.splitContainer15.ResumeLayout(false);
            this.splitContainer13.Panel1.ResumeLayout(false);
            this.splitContainer13.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer13)).EndInit();
            this.splitContainer13.ResumeLayout(false);
            this.splitContainer16.Panel1.ResumeLayout(false);
            this.splitContainer16.Panel1.PerformLayout();
            this.splitContainer16.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer16)).EndInit();
            this.splitContainer16.ResumeLayout(false);
            this.splitContainer17.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer17)).EndInit();
            this.splitContainer17.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVA)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.splitContainer18.Panel1.ResumeLayout(false);
            this.splitContainer18.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer18)).EndInit();
            this.splitContainer18.ResumeLayout(false);
            this.splitContainer19.Panel1.ResumeLayout(false);
            this.splitContainer19.Panel1.PerformLayout();
            this.splitContainer19.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer19)).EndInit();
            this.splitContainer19.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer20.Panel1.ResumeLayout(false);
            this.splitContainer20.Panel1.PerformLayout();
            this.splitContainer20.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer20)).EndInit();
            this.splitContainer20.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer8.Panel1.ResumeLayout(false);
            this.splitContainer8.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).EndInit();
            this.splitContainer8.ResumeLayout(false);
            this.splitContainer10.Panel1.ResumeLayout(false);
            this.splitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).EndInit();
            this.splitContainer10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.SplitContainer splitContainer9;
        private System.Windows.Forms.SplitContainer splitContainer8;
        private System.Windows.Forms.SplitContainer splitContainer10;
        private System.Windows.Forms.TextBox textBox1;
        private MyPanel panel1;
        private MyRichTextBox richTextBox1;
        private MyPanel panel6;
        private MyRichTextBox richTextBox2;
        private System.Windows.Forms.SplitContainer splitContainer11;
        private System.Windows.Forms.SplitContainer splitContainer14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private MyPanel panel3;
        private System.Windows.Forms.SplitContainer splitContainer12;
        private System.Windows.Forms.SplitContainer splitContainer15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private MyPanel panel4;
        private System.Windows.Forms.SplitContainer splitContainer13;
        private System.Windows.Forms.SplitContainer splitContainer16;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private MyPanel panel5;
        private System.Windows.Forms.SplitContainer splitContainer17;
        private System.Windows.Forms.TextBox textBox2;
        private MyRichTextBox richTextBox3;
        private MyPanel panel7;
        private MyRichTextBox richTextBox4;
        private MyPanel panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelDate;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVA;
        private TabPage tabPage2;
        private TableLayoutPanel tableLayoutPanel1;
        private MyRichTextBox richTextBox16;
        private MyRichTextBox richTextBox28;
        private MyRichTextBox richTextBox27;
        private MyRichTextBox richTextBox26;
        private MyRichTextBox richTextBox25;
        private MyRichTextBox richTextBox24;
        private MyRichTextBox richTextBox23;
        private MyRichTextBox richTextBox22;
        private MyRichTextBox richTextBox21;
        private MyRichTextBox richTextBox20;
        private MyRichTextBox richTextBox19;
        private MyRichTextBox richTextBox18;
        private MyRichTextBox richTextBox17;
        private MyRichTextBox richTextBox15;
        private MyRichTextBox richTextBox14;
        private MyRichTextBox richTextBox13;
        private MyRichTextBox richTextBox12;
        private MyRichTextBox richTextBox11;
        private MyRichTextBox richTextBox10;
        private MyRichTextBox richTextBox9;
        private MyRichTextBox richTextBox8;
        private MyRichTextBox richTextBox7;
        private MyRichTextBox richTextBox6;
        private MyRichTextBox richTextBox5;
        private TabPage tabPage3;
        private TabControl tabControl2;
        private TabPage tabPage8;
        private SplitContainer splitContainer18;
        private SplitContainer splitContainer19;
        private Label label59;
        private Label label58;
        private Label label57;
        private TextBox textBoxNoInf;
        private TextBox textBoxLogicZero;
        private TextBox textBoxLogicOne;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBox37;
        private TextBox textBox36;
        private TextBox textBox35;
        private TextBox textBox34;
        private TextBox textBox33;
        private TextBox textBox32;
        private TextBox textBox31;
        private TextBox textBox30;
        private TextBox textBox29;
        private TextBox textBox28;
        private TextBox textBox27;
        private TextBox textBox26;
        private TextBox textBox25;
        private TextBox textBox24;
        private TextBox textBox23;
        private TextBox textBox22;
        private Label label4;
        private Label label5;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label40;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox19;
        private TextBox textBox20;
        private TextBox textBox21;
        private Label label24;
        private SplitContainer splitContainer20;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBox53;
        private TextBox textBox52;
        private TextBox textBox51;
        private TextBox textBox50;
        private TextBox textBox49;
        private TextBox textBox48;
        private TextBox textBox47;
        private TextBox textBox46;
        private TextBox textBox45;
        private TextBox textBox44;
        private TextBox textBox43;
        private TextBox textBox42;
        private TextBox textBox41;
        private TextBox textBox40;
        private TextBox textBox39;
        private TextBox textBox38;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label50;
        private Label label51;
        private Label label52;
        private Label label53;
        private Label label54;
        private Label label55;
        private Label label56;
        private TabPage tabPage9;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TableLayoutPanel tableLayoutPanel4;
        private DateTimePicker dateTimePicker1;
        private Label label60;
        private TreeView treeView1;
        private Label label61;
        private DateTimePicker dateTimePicker2;
        private Label label62;
        private TextBox textBoxRecordsCount;
        private Label label63;
        private TextBox textBoxCurrentRecord;
        private Button buttonFind;
        private Button buttonNext;
        private Button buttonPrevious;
        private TabPage tabPage6;
        private DataGridView dataGridViewParameters;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private TabPage tabPage7;
    }
}
