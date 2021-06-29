namespace Supply
{
    partial class TenantElectricityAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenantElectricityAccount));
            this.BTN_Add = new System.Windows.Forms.Button();
            this.LB_TotalSum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_Payment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_AccountingEndDate = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_AccountingStartDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LB_TenantName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(335, 121);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(75, 23);
            this.BTN_Add.TabIndex = 21;
            this.BTN_Add.Text = "Внести";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // LB_TotalSum
            // 
            this.LB_TotalSum.AutoSize = true;
            this.LB_TotalSum.Location = new System.Drawing.Point(324, 87);
            this.LB_TotalSum.Name = "LB_TotalSum";
            this.LB_TotalSum.Size = new System.Drawing.Size(20, 13);
            this.LB_TotalSum.TabIndex = 20;
            this.LB_TotalSum.Text = "LB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Задолжность по оплате:";
            // 
            // TB_Payment
            // 
            this.TB_Payment.Location = new System.Drawing.Point(65, 84);
            this.TB_Payment.Name = "TB_Payment";
            this.TB_Payment.Size = new System.Drawing.Size(100, 20);
            this.TB_Payment.TabIndex = 18;
            this.TB_Payment.TextChanged += new System.EventHandler(this.TB_Payment_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Сумма:";
            // 
            // TB_AccountingEndDate
            // 
            this.TB_AccountingEndDate.Location = new System.Drawing.Point(249, 48);
            this.TB_AccountingEndDate.Mask = "00/00/0000";
            this.TB_AccountingEndDate.Name = "TB_AccountingEndDate";
            this.TB_AccountingEndDate.Size = new System.Drawing.Size(100, 20);
            this.TB_AccountingEndDate.TabIndex = 16;
            this.TB_AccountingEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "по:";
            // 
            // TB_AccountingStartDate
            // 
            this.TB_AccountingStartDate.Location = new System.Drawing.Point(115, 48);
            this.TB_AccountingStartDate.Mask = "00/00/0000";
            this.TB_AccountingStartDate.Name = "TB_AccountingStartDate";
            this.TB_AccountingStartDate.Size = new System.Drawing.Size(100, 20);
            this.TB_AccountingStartDate.TabIndex = 14;
            this.TB_AccountingStartDate.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Период оплаты с:";
            // 
            // LB_TenantName
            // 
            this.LB_TenantName.AutoSize = true;
            this.LB_TenantName.Location = new System.Drawing.Point(141, 15);
            this.LB_TenantName.Name = "LB_TenantName";
            this.LB_TenantName.Size = new System.Drawing.Size(35, 13);
            this.LB_TenantName.TabIndex = 12;
            this.LB_TenantName.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ФИО прживающего:";
            // 
            // TenantElectricityAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 153);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.LB_TotalSum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TB_Payment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_AccountingEndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_AccountingStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LB_TenantName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TenantElectricityAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оплата за электроэнергию";
            this.Shown += new System.EventHandler(this.TenantElectricityAccount_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.Label LB_TotalSum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_Payment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox TB_AccountingEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox TB_AccountingStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LB_TenantName;
        private System.Windows.Forms.Label label1;
    }
}