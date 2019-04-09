namespace ItLab
{
    partial class Form2
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
            this.FirstCrit = new System.Windows.Forms.ComboBox();
            this.FirstSearchString = new System.Windows.Forms.TextBox();
            this.SecondSearchString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SecondCrit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // FirstCrit
            // 
            this.FirstCrit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.FirstCrit.FormattingEnabled = true;
            this.FirstCrit.Items.AddRange(new object[] {
            "Производитель процессора",
            "Модель процессора",
            "Производитель видеокарты",
            "Модель видеокарты",
            "Объем ОЗУ",
            "Объем жесткого диска"});
            this.FirstCrit.Location = new System.Drawing.Point(12, 41);
            this.FirstCrit.Name = "FirstCrit";
            this.FirstCrit.Size = new System.Drawing.Size(169, 21);
            this.FirstCrit.TabIndex = 0;
            this.FirstCrit.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // FirstSearchString
            // 
            this.FirstSearchString.Location = new System.Drawing.Point(187, 41);
            this.FirstSearchString.Name = "FirstSearchString";
            this.FirstSearchString.Size = new System.Drawing.Size(100, 20);
            this.FirstSearchString.TabIndex = 2;
            this.FirstSearchString.TextChanged += new System.EventHandler(this.FirstSearchString_TextChanged);
            // 
            // SecondSearchString
            // 
            this.SecondSearchString.Location = new System.Drawing.Point(187, 70);
            this.SecondSearchString.Name = "SecondSearchString";
            this.SecondSearchString.Size = new System.Drawing.Size(100, 20);
            this.SecondSearchString.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Критерий";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Поиск";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Искать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // SecondCrit
            // 
            this.SecondCrit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SecondCrit.FormattingEnabled = true;
            this.SecondCrit.Items.AddRange(new object[] {
            "Производитель процессора",
            "Модель процессора",
            "Производитель видеокарты",
            "Модель видеокарты",
            "Объем ОЗУ",
            "Объем жесткого диска"});
            this.SecondCrit.Location = new System.Drawing.Point(12, 69);
            this.SecondCrit.Name = "SecondCrit";
            this.SecondCrit.Size = new System.Drawing.Size(169, 21);
            this.SecondCrit.TabIndex = 7;
            this.SecondCrit.SelectedIndexChanged += new System.EventHandler(this.SecondCrit_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 168);
            this.Controls.Add(this.SecondCrit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SecondSearchString);
            this.Controls.Add(this.FirstSearchString);
            this.Controls.Add(this.FirstCrit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FirstCrit;
        private System.Windows.Forms.TextBox FirstSearchString;
        private System.Windows.Forms.TextBox SecondSearchString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox SecondCrit;
    }
}