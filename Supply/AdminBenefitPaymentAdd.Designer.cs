
namespace Supply
{
    partial class AdminBenefitPaymentAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminBenefitPaymentAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.CB_BenefitType = new System.Windows.Forms.ComboBox();
            this.TB_Price = new System.Windows.Forms.TextBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.ChB_Status = new System.Windows.Forms.CheckBox();
            this.TB_House = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_Electricity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Service = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Общежитие";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Тип льготы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Койко-место";
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(79, 8);
            this.CB_Hostels.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(92, 21);
            this.CB_Hostels.TabIndex = 3;
            this.CB_Hostels.SelectedIndexChanged += new System.EventHandler(this.CB_Hostels_SelectedIndexChanged);
            // 
            // CB_BenefitType
            // 
            this.CB_BenefitType.FormattingEnabled = true;
            this.CB_BenefitType.Location = new System.Drawing.Point(320, 8);
            this.CB_BenefitType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CB_BenefitType.Name = "CB_BenefitType";
            this.CB_BenefitType.Size = new System.Drawing.Size(272, 21);
            this.CB_BenefitType.TabIndex = 4;
            this.CB_BenefitType.SelectedIndexChanged += new System.EventHandler(this.CB_BenefitType_SelectedIndexChanged);
            // 
            // TB_Price
            // 
            this.TB_Price.Location = new System.Drawing.Point(86, 55);
            this.TB_Price.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TB_Price.Name = "TB_Price";
            this.TB_Price.Size = new System.Drawing.Size(92, 20);
            this.TB_Price.TabIndex = 5;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(516, 197);
            this.BTN_Save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(76, 24);
            this.BTN_Save.TabIndex = 6;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // ChB_Status
            // 
            this.ChB_Status.AutoSize = true;
            this.ChB_Status.Location = new System.Drawing.Point(13, 145);
            this.ChB_Status.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChB_Status.Name = "ChB_Status";
            this.ChB_Status.Size = new System.Drawing.Size(68, 17);
            this.ChB_Status.TabIndex = 7;
            this.ChB_Status.Text = "Активен";
            this.ChB_Status.UseVisualStyleBackColor = true;
            // 
            // TB_House
            // 
            this.TB_House.Location = new System.Drawing.Point(370, 55);
            this.TB_House.Margin = new System.Windows.Forms.Padding(2);
            this.TB_House.Name = "TB_House";
            this.TB_House.Size = new System.Drawing.Size(92, 20);
            this.TB_House.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Содержание жилого помещения";
            // 
            // TB_Electricity
            // 
            this.TB_Electricity.Location = new System.Drawing.Point(262, 90);
            this.TB_Electricity.Margin = new System.Windows.Forms.Padding(2);
            this.TB_Electricity.Name = "TB_Electricity";
            this.TB_Electricity.Size = new System.Drawing.Size(92, 20);
            this.TB_Electricity.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 93);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Эл.энергия";
            // 
            // TB_Service
            // 
            this.TB_Service.Location = new System.Drawing.Point(86, 90);
            this.TB_Service.Margin = new System.Windows.Forms.Padding(2);
            this.TB_Service.Name = "TB_Service";
            this.TB_Service.Size = new System.Drawing.Size(92, 20);
            this.TB_Service.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 93);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ком.услуги";
            // 
            // AdminBenefitPaymentAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 232);
            this.Controls.Add(this.TB_Electricity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_Service);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TB_House);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ChB_Status);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.TB_Price);
            this.Controls.Add(this.CB_BenefitType);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdminBenefitPaymentAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление тарифа";
            this.Load += new System.EventHandler(this.AdminBenefitPaymentAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.ComboBox CB_BenefitType;
        private System.Windows.Forms.TextBox TB_Price;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.CheckBox ChB_Status;
        private System.Windows.Forms.TextBox TB_House;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_Electricity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_Service;
        private System.Windows.Forms.Label label6;
    }
}