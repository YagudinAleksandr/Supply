
namespace Supply
{
    partial class TenantContinueOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenantContinueOrder));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_OrderContinueDate = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_Licenses = new System.Windows.Forms.ComboBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.LB_OrderNumber = new System.Windows.Forms.Label();
            this.LB_Tenant = new System.Windows.Forms.Label();
            this.LB_OrderEndDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ф.И.О:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Договор №";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата окончания договора";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата продления";
            // 
            // TB_OrderContinueDate
            // 
            this.TB_OrderContinueDate.Location = new System.Drawing.Point(520, 48);
            this.TB_OrderContinueDate.Mask = "00/00/0000";
            this.TB_OrderContinueDate.Name = "TB_OrderContinueDate";
            this.TB_OrderContinueDate.Size = new System.Drawing.Size(100, 22);
            this.TB_OrderContinueDate.TabIndex = 4;
            this.TB_OrderContinueDate.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ответственное лицо:";
            // 
            // CB_Licenses
            // 
            this.CB_Licenses.FormattingEnabled = true;
            this.CB_Licenses.Location = new System.Drawing.Point(171, 86);
            this.CB_Licenses.Name = "CB_Licenses";
            this.CB_Licenses.Size = new System.Drawing.Size(449, 24);
            this.CB_Licenses.TabIndex = 6;
            this.CB_Licenses.SelectedIndexChanged += new System.EventHandler(this.CB_Licenses_SelectedIndexChanged);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(520, 160);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(100, 33);
            this.BTN_Save.TabIndex = 7;
            this.BTN_Save.Text = "Добавить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // LB_OrderNumber
            // 
            this.LB_OrderNumber.AutoSize = true;
            this.LB_OrderNumber.Location = new System.Drawing.Point(485, 13);
            this.LB_OrderNumber.Name = "LB_OrderNumber";
            this.LB_OrderNumber.Size = new System.Drawing.Size(46, 17);
            this.LB_OrderNumber.TabIndex = 8;
            this.LB_OrderNumber.Text = "label6";
            // 
            // LB_Tenant
            // 
            this.LB_Tenant.AutoSize = true;
            this.LB_Tenant.Location = new System.Drawing.Point(73, 13);
            this.LB_Tenant.Name = "LB_Tenant";
            this.LB_Tenant.Size = new System.Drawing.Size(46, 17);
            this.LB_Tenant.TabIndex = 9;
            this.LB_Tenant.Text = "label6";
            // 
            // LB_OrderEndDate
            // 
            this.LB_OrderEndDate.AutoSize = true;
            this.LB_OrderEndDate.Location = new System.Drawing.Point(199, 48);
            this.LB_OrderEndDate.Name = "LB_OrderEndDate";
            this.LB_OrderEndDate.Size = new System.Drawing.Size(46, 17);
            this.LB_OrderEndDate.TabIndex = 10;
            this.LB_OrderEndDate.Text = "label6";
            // 
            // TenantContinueOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 218);
            this.Controls.Add(this.LB_OrderEndDate);
            this.Controls.Add(this.LB_Tenant);
            this.Controls.Add(this.LB_OrderNumber);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.CB_Licenses);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_OrderContinueDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TenantContinueOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Продление договора";
            this.Load += new System.EventHandler(this.TenantContinueOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox TB_OrderContinueDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CB_Licenses;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Label LB_OrderNumber;
        private System.Windows.Forms.Label LB_Tenant;
        private System.Windows.Forms.Label LB_OrderEndDate;
    }
}