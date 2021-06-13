
namespace Supply
{
    partial class TenantUpdateInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenantUpdateInformation));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Surename = new System.Windows.Forms.TextBox();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.TB_Patronymic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_DateOfBirth = new System.Windows.Forms.MaskedTextBox();
            this.CB_PaymentType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TB_Code = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.BTN_AdditionalInformation = new System.Windows.Forms.Button();
            this.CB_TenantType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TB_Address = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TB_Issued = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TB_GivenDate = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TB_DocNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TB_DocSeries = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_Cityzenship = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_DocType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ChB_Status = new System.Windows.Forms.CheckBox();
            this.BTN_OrderInformation = new System.Windows.Forms.Button();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отчество";
            // 
            // TB_Surename
            // 
            this.TB_Surename.Location = new System.Drawing.Point(75, 10);
            this.TB_Surename.Name = "TB_Surename";
            this.TB_Surename.Size = new System.Drawing.Size(145, 20);
            this.TB_Surename.TabIndex = 3;
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(261, 10);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(145, 20);
            this.TB_Name.TabIndex = 4;
            // 
            // TB_Patronymic
            // 
            this.TB_Patronymic.Location = new System.Drawing.Point(472, 10);
            this.TB_Patronymic.Name = "TB_Patronymic";
            this.TB_Patronymic.Size = new System.Drawing.Size(115, 20);
            this.TB_Patronymic.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата рождения";
            // 
            // TB_DateOfBirth
            // 
            this.TB_DateOfBirth.Location = new System.Drawing.Point(104, 49);
            this.TB_DateOfBirth.Mask = "00/00/0000";
            this.TB_DateOfBirth.Name = "TB_DateOfBirth";
            this.TB_DateOfBirth.Size = new System.Drawing.Size(100, 20);
            this.TB_DateOfBirth.TabIndex = 7;
            this.TB_DateOfBirth.ValidatingType = typeof(System.DateTime);
            // 
            // CB_PaymentType
            // 
            this.CB_PaymentType.FormattingEnabled = true;
            this.CB_PaymentType.Location = new System.Drawing.Point(144, 387);
            this.CB_PaymentType.Name = "CB_PaymentType";
            this.CB_PaymentType.Size = new System.Drawing.Size(441, 21);
            this.CB_PaymentType.TabIndex = 52;
            this.CB_PaymentType.SelectedIndexChanged += new System.EventHandler(this.CB_PaymentType_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 390);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 13);
            this.label15.TabIndex = 51;
            this.label15.Text = "Тип тарифного плана";
            // 
            // TB_Code
            // 
            this.TB_Code.Location = new System.Drawing.Point(487, 113);
            this.TB_Code.Name = "TB_Code";
            this.TB_Code.Size = new System.Drawing.Size(100, 20);
            this.TB_Code.TabIndex = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(455, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "Код";
            // 
            // BTN_AdditionalInformation
            // 
            this.BTN_AdditionalInformation.Location = new System.Drawing.Point(276, 338);
            this.BTN_AdditionalInformation.Name = "BTN_AdditionalInformation";
            this.BTN_AdditionalInformation.Size = new System.Drawing.Size(204, 23);
            this.BTN_AdditionalInformation.TabIndex = 48;
            this.BTN_AdditionalInformation.Text = "Дополнительная информация";
            this.BTN_AdditionalInformation.UseVisualStyleBackColor = true;
            this.BTN_AdditionalInformation.Click += new System.EventHandler(this.BTN_AdditionalInformation_Click);
            // 
            // CB_TenantType
            // 
            this.CB_TenantType.FormattingEnabled = true;
            this.CB_TenantType.Location = new System.Drawing.Point(111, 340);
            this.CB_TenantType.Name = "CB_TenantType";
            this.CB_TenantType.Size = new System.Drawing.Size(154, 21);
            this.CB_TenantType.TabIndex = 47;
            this.CB_TenantType.SelectedIndexChanged += new System.EventHandler(this.CB_TenantType_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 343);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 46;
            this.label13.Text = "Тип жильца";
            // 
            // TB_Address
            // 
            this.TB_Address.Location = new System.Drawing.Point(111, 275);
            this.TB_Address.Name = "TB_Address";
            this.TB_Address.Size = new System.Drawing.Size(474, 59);
            this.TB_Address.TabIndex = 45;
            this.TB_Address.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 278);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Адрес";
            // 
            // TB_Issued
            // 
            this.TB_Issued.Location = new System.Drawing.Point(111, 195);
            this.TB_Issued.Name = "TB_Issued";
            this.TB_Issued.Size = new System.Drawing.Size(474, 59);
            this.TB_Issued.TabIndex = 43;
            this.TB_Issued.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "Кем выдан";
            // 
            // TB_GivenDate
            // 
            this.TB_GivenDate.Location = new System.Drawing.Point(485, 153);
            this.TB_GivenDate.Mask = "00/00/0000";
            this.TB_GivenDate.Name = "TB_GivenDate";
            this.TB_GivenDate.Size = new System.Drawing.Size(100, 20);
            this.TB_GivenDate.TabIndex = 41;
            this.TB_GivenDate.ValidatingType = typeof(System.DateTime);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(407, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Дата выдачи";
            // 
            // TB_DocNumber
            // 
            this.TB_DocNumber.Location = new System.Drawing.Point(276, 153);
            this.TB_DocNumber.Name = "TB_DocNumber";
            this.TB_DocNumber.Size = new System.Drawing.Size(121, 20);
            this.TB_DocNumber.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(213, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Номер";
            // 
            // TB_DocSeries
            // 
            this.TB_DocSeries.Location = new System.Drawing.Point(72, 153);
            this.TB_DocSeries.Name = "TB_DocSeries";
            this.TB_DocSeries.Size = new System.Drawing.Size(121, 20);
            this.TB_DocSeries.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Серия";
            // 
            // TB_Cityzenship
            // 
            this.TB_Cityzenship.Location = new System.Drawing.Point(349, 113);
            this.TB_Cityzenship.Name = "TB_Cityzenship";
            this.TB_Cityzenship.Size = new System.Drawing.Size(100, 20);
            this.TB_Cityzenship.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Гражданство";
            // 
            // CB_DocType
            // 
            this.CB_DocType.FormattingEnabled = true;
            this.CB_DocType.Location = new System.Drawing.Point(111, 113);
            this.CB_DocType.Name = "CB_DocType";
            this.CB_DocType.Size = new System.Drawing.Size(121, 21);
            this.CB_DocType.TabIndex = 33;
            this.CB_DocType.SelectedIndexChanged += new System.EventHandler(this.CB_DocType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Тип документа";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(212, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 24);
            this.label5.TabIndex = 31;
            this.label5.Text = "Паспортные данные";
            // 
            // ChB_Status
            // 
            this.ChB_Status.AutoSize = true;
            this.ChB_Status.Location = new System.Drawing.Point(16, 429);
            this.ChB_Status.Name = "ChB_Status";
            this.ChB_Status.Size = new System.Drawing.Size(121, 17);
            this.ChB_Status.TabIndex = 53;
            this.ChB_Status.Text = "Статус активности";
            this.ChB_Status.UseVisualStyleBackColor = true;
            // 
            // BTN_OrderInformation
            // 
            this.BTN_OrderInformation.Location = new System.Drawing.Point(487, 338);
            this.BTN_OrderInformation.Name = "BTN_OrderInformation";
            this.BTN_OrderInformation.Size = new System.Drawing.Size(98, 23);
            this.BTN_OrderInformation.TabIndex = 54;
            this.BTN_OrderInformation.Text = "Договор";
            this.BTN_OrderInformation.UseVisualStyleBackColor = true;
            this.BTN_OrderInformation.Click += new System.EventHandler(this.BTN_OrderInformation_Click);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(512, 472);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save.TabIndex = 55;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // TenantUpdateInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 507);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.BTN_OrderInformation);
            this.Controls.Add(this.ChB_Status);
            this.Controls.Add(this.CB_PaymentType);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TB_Code);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.BTN_AdditionalInformation);
            this.Controls.Add(this.CB_TenantType);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TB_Address);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TB_Issued);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TB_GivenDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TB_DocNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TB_DocSeries);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TB_Cityzenship);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CB_DocType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_DateOfBirth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Patronymic);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.TB_Surename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TenantUpdateInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение информации о жильце";
            this.Load += new System.EventHandler(this.TenantUpdateInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Surename;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.TextBox TB_Patronymic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox TB_DateOfBirth;
        private System.Windows.Forms.ComboBox CB_PaymentType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TB_Code;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button BTN_AdditionalInformation;
        private System.Windows.Forms.ComboBox CB_TenantType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox TB_Address;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox TB_Issued;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox TB_GivenDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TB_DocNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TB_DocSeries;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_Cityzenship;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CB_DocType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ChB_Status;
        private System.Windows.Forms.Button BTN_OrderInformation;
        private System.Windows.Forms.Button BTN_Save;
    }
}