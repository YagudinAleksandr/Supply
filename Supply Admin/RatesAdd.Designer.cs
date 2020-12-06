namespace Supply_Admin
{
    partial class RatesAdd
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
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Rate = new System.Windows.Forms.TextBox();
            this.CB_Taks = new System.Windows.Forms.CheckBox();
            this.TB_TaksPercent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_RentId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RTB_Description = new System.Windows.Forms.RichTextBox();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_HostelId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название тарифа";
            // 
            // TB_Name
            // 
            this.TB_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Name.Location = new System.Drawing.Point(145, 19);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(744, 22);
            this.TB_Name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Стоимость";
            // 
            // TB_Rate
            // 
            this.TB_Rate.Location = new System.Drawing.Point(102, 67);
            this.TB_Rate.Name = "TB_Rate";
            this.TB_Rate.Size = new System.Drawing.Size(209, 22);
            this.TB_Rate.TabIndex = 3;
            // 
            // CB_Taks
            // 
            this.CB_Taks.AutoSize = true;
            this.CB_Taks.Location = new System.Drawing.Point(329, 67);
            this.CB_Taks.Name = "CB_Taks";
            this.CB_Taks.Size = new System.Drawing.Size(124, 21);
            this.CB_Taks.TabIndex = 4;
            this.CB_Taks.Text = "С учетом НДС";
            this.CB_Taks.UseVisualStyleBackColor = true;
            // 
            // TB_TaksPercent
            // 
            this.TB_TaksPercent.Location = new System.Drawing.Point(460, 66);
            this.TB_TaksPercent.Name = "TB_TaksPercent";
            this.TB_TaksPercent.Size = new System.Drawing.Size(100, 22);
            this.TB_TaksPercent.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "На период";
            // 
            // CB_RentId
            // 
            this.CB_RentId.FormattingEnabled = true;
            this.CB_RentId.Location = new System.Drawing.Point(101, 110);
            this.CB_RentId.Name = "CB_RentId";
            this.CB_RentId.Size = new System.Drawing.Size(206, 24);
            this.CB_RentId.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(567, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Описание";
            // 
            // RTB_Description
            // 
            this.RTB_Description.Location = new System.Drawing.Point(16, 181);
            this.RTB_Description.Name = "RTB_Description";
            this.RTB_Description.Size = new System.Drawing.Size(873, 96);
            this.RTB_Description.TabIndex = 10;
            this.RTB_Description.Text = "";
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(761, 292);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(128, 38);
            this.BTN_Add.TabIndex = 11;
            this.BTN_Add.Text = "Добавить";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Общежитие";
            // 
            // CB_HostelId
            // 
            this.CB_HostelId.FormattingEnabled = true;
            this.CB_HostelId.Location = new System.Drawing.Point(421, 110);
            this.CB_HostelId.Name = "CB_HostelId";
            this.CB_HostelId.Size = new System.Drawing.Size(121, 24);
            this.CB_HostelId.TabIndex = 13;
            // 
            // RatesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 342);
            this.Controls.Add(this.CB_HostelId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.RTB_Description);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CB_RentId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_TaksPercent);
            this.Controls.Add(this.CB_Taks);
            this.Controls.Add(this.TB_Rate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label1);
            this.Name = "RatesAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RatesAdd";
            this.Shown += new System.EventHandler(this.RatesAdd_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Rate;
        private System.Windows.Forms.CheckBox CB_Taks;
        private System.Windows.Forms.TextBox TB_TaksPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_RentId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox RTB_Description;
        private System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CB_HostelId;
    }
}