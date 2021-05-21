
namespace Supply
{
    partial class TenantBenefitAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenantBenefitAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.LB_TenantInf = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LB_OrderNumb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_ManagersLicenses = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_BenefitsTypes = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Создание льготы для:";
            // 
            // LB_TenantInf
            // 
            this.LB_TenantInf.AutoSize = true;
            this.LB_TenantInf.Location = new System.Drawing.Point(138, 13);
            this.LB_TenantInf.Name = "LB_TenantInf";
            this.LB_TenantInf.Size = new System.Drawing.Size(35, 13);
            this.LB_TenantInf.TabIndex = 1;
            this.LB_TenantInf.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Приложение к договору №";
            // 
            // LB_OrderNumb
            // 
            this.LB_OrderNumb.AutoSize = true;
            this.LB_OrderNumb.Location = new System.Drawing.Point(153, 42);
            this.LB_OrderNumb.Name = "LB_OrderNumb";
            this.LB_OrderNumb.Size = new System.Drawing.Size(35, 13);
            this.LB_OrderNumb.TabIndex = 3;
            this.LB_OrderNumb.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ответственное лицо";
            // 
            // CB_ManagersLicenses
            // 
            this.CB_ManagersLicenses.FormattingEnabled = true;
            this.CB_ManagersLicenses.Location = new System.Drawing.Point(133, 91);
            this.CB_ManagersLicenses.Name = "CB_ManagersLicenses";
            this.CB_ManagersLicenses.Size = new System.Drawing.Size(474, 21);
            this.CB_ManagersLicenses.TabIndex = 5;
            this.CB_ManagersLicenses.SelectedIndexChanged += new System.EventHandler(this.CB_ManagersLicenses_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Основание";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 126);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "от";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(302, 126);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 9;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(408, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "№";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(433, 126);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 20);
            this.textBox2.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Льготная категория";
            // 
            // CB_BenefitsTypes
            // 
            this.CB_BenefitsTypes.FormattingEnabled = true;
            this.CB_BenefitsTypes.Location = new System.Drawing.Point(128, 158);
            this.CB_BenefitsTypes.Name = "CB_BenefitsTypes";
            this.CB_BenefitsTypes.Size = new System.Drawing.Size(274, 21);
            this.CB_BenefitsTypes.TabIndex = 13;
            this.CB_BenefitsTypes.SelectedIndexChanged += new System.EventHandler(this.CB_BenefitsTypes_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Начало";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(65, 194);
            this.maskedTextBox2.Mask = "00/00/0000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(78, 20);
            this.maskedTextBox2.TabIndex = 15;
            this.maskedTextBox2.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Location = new System.Drawing.Point(217, 194);
            this.maskedTextBox3.Mask = "00/00/0000";
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(78, 20);
            this.maskedTextBox3.TabIndex = 17;
            this.maskedTextBox3.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(153, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Окончание";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(302, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(200, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Оплата за жилое помещение в месяц";
            // 
            // maskedTextBox4
            // 
            this.maskedTextBox4.Location = new System.Drawing.Point(507, 194);
            this.maskedTextBox4.Name = "maskedTextBox4";
            this.maskedTextBox4.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox4.TabIndex = 19;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(532, 267);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save.TabIndex = 20;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // TenantBenefitAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 302);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.maskedTextBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.maskedTextBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CB_BenefitsTypes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CB_ManagersLicenses);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LB_OrderNumb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LB_TenantInf);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TenantBenefitAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Льгота";
            this.Load += new System.EventHandler(this.TenantBenefitAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_TenantInf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LB_OrderNumb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_ManagersLicenses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CB_BenefitsTypes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox maskedTextBox4;
        private System.Windows.Forms.Button BTN_Save;
    }
}