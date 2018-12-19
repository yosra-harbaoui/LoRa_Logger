namespace LoRa_Logger
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addEntryButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.floorsComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.exportButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.matchButton = new System.Windows.Forms.Button();
            this.matchUL2Button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.findButton = new System.Windows.Forms.Button();
            this.maximumButton = new System.Windows.Forms.Button();
            this.heatMapButton = new System.Windows.Forms.Button();
            this.formulaButton = new System.Windows.Forms.Button();
            this.vectorButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 200);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(666, 309);
            this.dataGridView1.TabIndex = 0;
            // 
            // addEntryButton
            // 
            this.addEntryButton.Location = new System.Drawing.Point(74, 124);
            this.addEntryButton.Name = "addEntryButton";
            this.addEntryButton.Size = new System.Drawing.Size(75, 23);
            this.addEntryButton.TabIndex = 1;
            this.addEntryButton.Text = "Add";
            this.addEntryButton.UseVisualStyleBackColor = true;
            this.addEntryButton.Click += new System.EventHandler(this.addEntryButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.floorsComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown3);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.addEntryButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 153);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entry";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(155, 99);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(98, 17);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "Auto-Increment";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(155, 73);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(98, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Auto-Increment";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(155, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Auto-Increment";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Floor";
            // 
            // floorsComboBox
            // 
            this.floorsComboBox.FormattingEnabled = true;
            this.floorsComboBox.Location = new System.Drawing.Point(74, 19);
            this.floorsComboBox.Name = "floorsComboBox";
            this.floorsComboBox.Size = new System.Drawing.Size(75, 21);
            this.floorsComboBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "UL(2)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "UL(1)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "N°";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(74, 98);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown3.TabIndex = 4;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(74, 72);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown2.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(74, 46);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(603, 171);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 3;
            this.exportButton.Text = "Export CSV";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 171);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 5;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(93, 175);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(122, 17);
            this.checkBox4.TabIndex = 6;
            this.checkBox4.Text = "Clear Current Entries";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // matchButton
            // 
            this.matchButton.Location = new System.Drawing.Point(6, 19);
            this.matchButton.Name = "matchButton";
            this.matchButton.Size = new System.Drawing.Size(75, 23);
            this.matchButton.TabIndex = 7;
            this.matchButton.Text = "Match UL1";
            this.matchButton.UseVisualStyleBackColor = true;
            this.matchButton.Click += new System.EventHandler(this.matchButton_Click);
            // 
            // matchUL2Button
            // 
            this.matchUL2Button.Location = new System.Drawing.Point(87, 19);
            this.matchUL2Button.Name = "matchUL2Button";
            this.matchUL2Button.Size = new System.Drawing.Size(75, 23);
            this.matchUL2Button.TabIndex = 8;
            this.matchUL2Button.Text = "Match UL2";
            this.matchUL2Button.UseVisualStyleBackColor = true;
            this.matchUL2Button.Click += new System.EventHandler(this.matchUL2Button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.findButton);
            this.groupBox2.Controls.Add(this.maximumButton);
            this.groupBox2.Controls.Add(this.heatMapButton);
            this.groupBox2.Controls.Add(this.formulaButton);
            this.groupBox2.Controls.Add(this.vectorButton);
            this.groupBox2.Controls.Add(this.matchUL2Button);
            this.groupBox2.Controls.Add(this.matchButton);
            this.groupBox2.Location = new System.Drawing.Point(277, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 153);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extras";
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(320, 106);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 12;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // maximumButton
            // 
            this.maximumButton.Location = new System.Drawing.Point(87, 77);
            this.maximumButton.Name = "maximumButton";
            this.maximumButton.Size = new System.Drawing.Size(75, 23);
            this.maximumButton.TabIndex = 11;
            this.maximumButton.Text = "Maximum";
            this.maximumButton.UseVisualStyleBackColor = true;
            this.maximumButton.Click += new System.EventHandler(this.maximumButton_Click);
            // 
            // heatMapButton
            // 
            this.heatMapButton.Location = new System.Drawing.Point(6, 106);
            this.heatMapButton.Name = "heatMapButton";
            this.heatMapButton.Size = new System.Drawing.Size(75, 23);
            this.heatMapButton.TabIndex = 10;
            this.heatMapButton.Text = "Heatmap";
            this.heatMapButton.UseVisualStyleBackColor = true;
            this.heatMapButton.Click += new System.EventHandler(this.heatMapButton_Click);
            // 
            // formulaButton
            // 
            this.formulaButton.Location = new System.Drawing.Point(6, 77);
            this.formulaButton.Name = "formulaButton";
            this.formulaButton.Size = new System.Drawing.Size(75, 23);
            this.formulaButton.TabIndex = 9;
            this.formulaButton.Text = "Formula";
            this.formulaButton.UseVisualStyleBackColor = true;
            this.formulaButton.Click += new System.EventHandler(this.formulaButton_Click);
            // 
            // vectorButton
            // 
            this.vectorButton.Location = new System.Drawing.Point(6, 48);
            this.vectorButton.Name = "vectorButton";
            this.vectorButton.Size = new System.Drawing.Size(75, 23);
            this.vectorButton.TabIndex = 0;
            this.vectorButton.Text = "Vector";
            this.vectorButton.UseVisualStyleBackColor = true;
            this.vectorButton.Click += new System.EventHandler(this.vectorButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 521);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoRa Logger";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addEntryButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox floorsComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button matchButton;
        private System.Windows.Forms.Button matchUL2Button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button vectorButton;
        private System.Windows.Forms.Button formulaButton;
        private System.Windows.Forms.Button heatMapButton;
        private System.Windows.Forms.Button maximumButton;
        private System.Windows.Forms.Button findButton;
    }
}

