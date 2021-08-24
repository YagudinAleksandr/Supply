
namespace Supply
{
    partial class AdminPaymentsFormAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPaymentsFormAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.TB_Description = new System.Windows.Forms.TextBox();
            this.TB_Coast = new System.Windows.Forms.TextBox();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.CB_RoomTypes = new System.Windows.Forms.ComboBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_TenantTypes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_PeriodOfPayment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_Service = new System.Windows.Forms.TextBox();
            this.ChB_Status = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TB_House = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Описание";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Сумма за койка-место";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 304);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Общежитие";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 304);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Тип комнаты";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(115, 12);
            this.TB_Name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(604, 22);
            this.TB_Name.TabIndex = 5;
            // 
            // TB_Description
            // 
            this.TB_Description.Location = new System.Drawing.Point(115, 60);
            this.TB_Description.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Description.Name = "TB_Description";
            this.TB_Description.Size = new System.Drawing.Size(604, 22);
            this.TB_Description.TabIndex = 6;
            // 
            // TB_Coast
            // 
            this.TB_Coast.Location = new System.Drawing.Point(189, 112);
            this.TB_Coast.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Coast.Name = "TB_Coast";
            this.TB_Coast.Size = new System.Drawing.Size(148, 22);
            this.TB_Coast.TabIndex = 7;
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(114, 301);
            this.CB_Hostels.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(129, 24);
            this.CB_Hostels.TabIndex = 8;
            this.CB_Hostels.SelectedIndexChanged += new System.EventHandler(this.CB_Hostels_SelectedIndexChanged);
            // 
            // CB_RoomTypes
            // 
            this.CB_RoomTypes.FormattingEnabled = true;
            this.CB_RoomTypes.Location = new System.Drawing.Point(360, 301);
            this.CB_RoomTypes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_RoomTypes.Name = "CB_RoomTypes";
            this.CB_RoomTypes.Size = new System.Drawing.Size(196, 24);
            this.CB_RoomTypes.TabIndex = 9;
            this.CB_RoomTypes.SelectedIndexChanged += new System.EventHandler(this.CB_RoomTypes_SelectedIndexChanged);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(615, 390);
            this.BTN_Save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(100, 28);
            this.BTN_Save.TabIndex = 10;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 255);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Тип проживающего";
            // 
            // CB_TenantTypes
            // 
            this.CB_TenantTypes.FormattingEnabled = true;
            this.CB_TenantTypes.Location = new System.Drawing.Point(164, 250);
            this.CB_TenantTypes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_TenantTypes.Name = "CB_TenantTypes";
            this.CB_TenantTypes.Size = new System.Drawing.Size(277, 24);
            this.CB_TenantTypes.TabIndex = 12;
            this.CB_TenantTypes.SelectedIndexChanged += new System.EventHandler(this.CB_TenantTypes_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 209);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Период оплаты";
            // 
            // CB_PeriodOfPayment
            // 
            this.CB_PeriodOfPayment.FormattingEnabled = true;
            this.CB_PeriodOfPayment.Items.AddRange(new object[] {
            "День",
            "Месяц",
            "Год"});
            this.CB_PeriodOfPayment.Location = new System.Drawing.Point(148, 206);
            this.CB_PeriodOfPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_PeriodOfPayment.Name = "CB_PeriodOfPayment";
            this.CB_PeriodOfPayment.Size = new System.Drawing.Size(307, 24);
            this.CB_PeriodOfPayment.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(361, 116);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Сумма за ком.услуги";
            // 
            // TB_Service
            // 
            this.TB_Service.Location = new System.Drawing.Point(523, 112);
            this.TB_Service.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Service.Name = "TB_Service";
            this.TB_Service.Size = new System.Drawing.Size(148, 22);
            this.TB_Service.TabIndex = 16;
            // 
            // ChB_Status
            // 
            this.ChB_Status.AutoSize = true;
            this.ChB_Status.Checked = true;
            this.ChB_Status.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChB_Status.Location = new System.Drawing.Point(17, 354);
            this.ChB_Status.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChB_Status.Name = "ChB_Status";
            this.ChB_Status.Size = new System.Drawing.Size(154, 21);
            this.ChB_Status.TabIndex = 17;
            this.ChB_Status.Text = "Статус активности";
            this.ChB_Status.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 158);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(283, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Сумма за содержание жилого помещения";
            // 
            // TB_House
            // 
            this.TB_House.Location = new System.Drawing.Point(330, 155);
            this.TB_House.Margin = new System.Windows.Forms.Padding(4);
            this.TB_House.Name = "TB_House";
            this.TB_House.Size = new System.Drawing.Size(148, 22);
            this.TB_House.TabIndex = 19;
            // 
            // AdminPaymentsFormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 429);
            this.Controls.Add(this.TB_House);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ChB_Status);
            this.Controls.Add(this.TB_Service);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CB_PeriodOfPayment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CB_TenantTypes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.CB_RoomTypes);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.TB_Coast);
            this.Controls.Add(this.TB_Description);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminPaymentsFormAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тарифный план";
            this.Load += new System.EventHandler(this.AdminPaymentsFormAdd_Load);
            this.Shown += new System.EventHandler(this.AdminPaymentsFormAdd_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.TextBox TB_Description;
        private System.Windows.Forms.TextBox TB_Coast;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.ComboBox CB_RoomTypes;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CB_TenantTypes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CB_PeriodOfPayment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_Service;
        private System.Windows.Forms.CheckBox ChB_Status;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TB_House;
    }
}