namespace ado.Net.Froms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGridViewElement = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AddRowButton = new System.Windows.Forms.Button();
            this.SortBy = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TypeDesc = new System.Windows.Forms.Button();
            this.IdAsc = new System.Windows.Forms.Button();
            this.IdDesc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ShowRamDB = new System.Windows.Forms.Button();
            this.PrevPage = new System.Windows.Forms.Button();
            this.NextPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewElement)).BeginInit();
            this.SortBy.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridViewElement
            // 
            this.DataGridViewElement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewElement.Location = new System.Drawing.Point(12, 12);
            this.DataGridViewElement.Name = "DataGridViewElement";
            this.DataGridViewElement.Size = new System.Drawing.Size(670, 426);
            this.DataGridViewElement.TabIndex = 0;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(688, 69);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 51);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(688, 126);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 51);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddRowButton
            // 
            this.AddRowButton.Location = new System.Drawing.Point(688, 12);
            this.AddRowButton.Name = "AddRowButton";
            this.AddRowButton.Size = new System.Drawing.Size(100, 51);
            this.AddRowButton.TabIndex = 4;
            this.AddRowButton.Text = "Add";
            this.AddRowButton.UseVisualStyleBackColor = true;
            this.AddRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // SortBy
            // 
            this.SortBy.Controls.Add(this.button1);
            this.SortBy.Controls.Add(this.TypeDesc);
            this.SortBy.Controls.Add(this.IdAsc);
            this.SortBy.Controls.Add(this.IdDesc);
            this.SortBy.Location = new System.Drawing.Point(688, 183);
            this.SortBy.Name = "SortBy";
            this.SortBy.Size = new System.Drawing.Size(100, 137);
            this.SortBy.TabIndex = 5;
            this.SortBy.TabStop = false;
            this.SortBy.Text = "Sort By";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Type asc";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TypeDesc
            // 
            this.TypeDesc.Location = new System.Drawing.Point(7, 107);
            this.TypeDesc.Name = "TypeDesc";
            this.TypeDesc.Size = new System.Drawing.Size(87, 23);
            this.TypeDesc.TabIndex = 2;
            this.TypeDesc.Text = "Type desc";
            this.TypeDesc.UseVisualStyleBackColor = true;
            this.TypeDesc.Click += new System.EventHandler(this.TypeDesc_Click);
            // 
            // IdAsc
            // 
            this.IdAsc.Location = new System.Drawing.Point(6, 20);
            this.IdAsc.Name = "IdAsc";
            this.IdAsc.Size = new System.Drawing.Size(87, 23);
            this.IdAsc.TabIndex = 1;
            this.IdAsc.Text = "Id asc";
            this.IdAsc.UseVisualStyleBackColor = true;
            this.IdAsc.Click += new System.EventHandler(this.IdAsc_Click);
            // 
            // IdDesc
            // 
            this.IdDesc.Location = new System.Drawing.Point(6, 49);
            this.IdDesc.Name = "IdDesc";
            this.IdDesc.Size = new System.Drawing.Size(87, 23);
            this.IdDesc.TabIndex = 0;
            this.IdDesc.Text = "Id desc";
            this.IdDesc.UseVisualStyleBackColor = true;
            this.IdDesc.Click += new System.EventHandler(this.IdDesc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.ShowRamDB);
            this.groupBox1.Location = new System.Drawing.Point(689, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 76);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "ShowComputer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ShowComputerDB_Click);
            // 
            // ShowRamDB
            // 
            this.ShowRamDB.Location = new System.Drawing.Point(5, 19);
            this.ShowRamDB.Name = "ShowRamDB";
            this.ShowRamDB.Size = new System.Drawing.Size(87, 23);
            this.ShowRamDB.TabIndex = 5;
            this.ShowRamDB.Text = "ShowRamDB";
            this.ShowRamDB.UseVisualStyleBackColor = true;
            this.ShowRamDB.Click += new System.EventHandler(this.ShowRamDB_Click);
            // 
            // PrevPage
            // 
            this.PrevPage.Location = new System.Drawing.Point(295, 455);
            this.PrevPage.Name = "PrevPage";
            this.PrevPage.Size = new System.Drawing.Size(75, 23);
            this.PrevPage.TabIndex = 7;
            this.PrevPage.Text = "Prev page";
            this.PrevPage.UseVisualStyleBackColor = true;
            this.PrevPage.Click += new System.EventHandler(this.PrevPage_Click);
            // 
            // NextPage
            // 
            this.NextPage.Location = new System.Drawing.Point(376, 455);
            this.NextPage.Name = "NextPage";
            this.NextPage.Size = new System.Drawing.Size(75, 23);
            this.NextPage.TabIndex = 8;
            this.NextPage.Text = "Next page";
            this.NextPage.UseVisualStyleBackColor = true;
            this.NextPage.Click += new System.EventHandler(this.NextPage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 512);
            this.Controls.Add(this.NextPage);
            this.Controls.Add(this.PrevPage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SortBy);
            this.Controls.Add(this.AddRowButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.DataGridViewElement);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewElement)).EndInit();
            this.SortBy.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewElement;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button AddRowButton;
        private System.Windows.Forms.GroupBox SortBy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button TypeDesc;
        private System.Windows.Forms.Button IdAsc;
        private System.Windows.Forms.Button IdDesc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ShowRamDB;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button PrevPage;
        private System.Windows.Forms.Button NextPage;
    }
}

