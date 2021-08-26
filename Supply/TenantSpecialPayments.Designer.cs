
namespace Supply
{
    partial class TenantSpecialPayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenantSpecialPayments));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LB_Tenant = new System.Windows.Forms.Label();
            this.LB_Order = new System.Windows.Forms.Label();
            this.TB_CountBeds = new System.Windows.Forms.TextBox();
            this.TB_StartDate = new System.Windows.Forms.MaskedTextBox();
            this.TB_EndDate = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Договор:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Кол-во койко-мест для оплаты";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Начало действия оплаты";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(494, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Окончание";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(817, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LB_Tenant
            // 
            this.LB_Tenant.AutoSize = true;
            this.LB_Tenant.Location = new System.Drawing.Point(65, 25);
            this.LB_Tenant.Name = "LB_Tenant";
            this.LB_Tenant.Size = new System.Drawing.Size(46, 17);
            this.LB_Tenant.TabIndex = 6;
            this.LB_Tenant.Text = "label6";
            // 
            // LB_Order
            // 
            this.LB_Order.AutoSize = true;
            this.LB_Order.Location = new System.Drawing.Point(567, 25);
            this.LB_Order.Name = "LB_Order";
            this.LB_Order.Size = new System.Drawing.Size(46, 17);
            this.LB_Order.TabIndex = 7;
            this.LB_Order.Text = "label6";
            // 
            // TB_CountBeds
            // 
            this.TB_CountBeds.Location = new System.Drawing.Point(231, 61);
            this.TB_CountBeds.Name = "TB_CountBeds";
            this.TB_CountBeds.Size = new System.Drawing.Size(100, 22);
            this.TB_CountBeds.TabIndex = 8;
            // 
            // TB_StartDate
            // 
            this.TB_StartDate.Location = new System.Drawing.Point(195, 105);
            this.TB_StartDate.Mask = "00/00/0000";
            this.TB_StartDate.Name = "TB_StartDate";
            this.TB_StartDate.Size = new System.Drawing.Size(100, 22);
            this.TB_StartDate.TabIndex = 9;
            this.TB_StartDate.ValidatingType = typeof(System.DateTime);
            // 
            // TB_EndDate
            // 
            this.TB_EndDate.Location = new System.Drawing.Point(582, 105);
            this.TB_EndDate.Mask = "00/00/0000";
            this.TB_EndDate.Name = "TB_EndDate";
            this.TB_EndDate.Size = new System.Drawing.Size(100, 22);
            this.TB_EndDate.TabIndex = 10;
            this.TB_EndDate.ValidatingType = typeof(System.DateTime);
            // 
            // TenantSpecialPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 206);
            this.Controls.Add(this.TB_EndDate);
            this.Controls.Add(this.TB_StartDate);
            this.Controls.Add(this.TB_CountBeds);
            this.Controls.Add(this.LB_Order);
            this.Controls.Add(this.LB_Tenant);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TenantSpecialPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Условия специализированной оплаты";
            this.Shown += new System.EventHandler(this.TenantSpecialPayments_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LB_Tenant;
        private System.Windows.Forms.Label LB_Order;
        private System.Windows.Forms.TextBox TB_CountBeds;
        private System.Windows.Forms.MaskedTextBox TB_StartDate;
        private System.Windows.Forms.MaskedTextBox TB_EndDate;
    }
}