﻿
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
            this.BTN_Save = new System.Windows.Forms.Button();
            this.LB_Tenant = new System.Windows.Forms.Label();
            this.LB_Order = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_Room_First = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_Room_First_Places = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Room_First_StartDate = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_Room_First_EndDate = new System.Windows.Forms.MaskedTextBox();
            this.TB_Room_Second_EndDate = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_Room_Second_StartDate = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_Room_Second_Places = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CB_Room_Second = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
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
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(740, 133);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(91, 27);
            this.BTN_Save.TabIndex = 5;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Комната:";
            // 
            // CB_Room_First
            // 
            this.CB_Room_First.FormattingEnabled = true;
            this.CB_Room_First.Location = new System.Drawing.Point(91, 57);
            this.CB_Room_First.Name = "CB_Room_First";
            this.CB_Room_First.Size = new System.Drawing.Size(121, 24);
            this.CB_Room_First.TabIndex = 9;
            this.CB_Room_First.SelectedIndexChanged += new System.EventHandler(this.CB_Room_First_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Кол-во занимаемых мест";
            // 
            // TB_Room_First_Places
            // 
            this.TB_Room_First_Places.Location = new System.Drawing.Point(406, 57);
            this.TB_Room_First_Places.Name = "TB_Room_First_Places";
            this.TB_Room_First_Places.Size = new System.Drawing.Size(100, 22);
            this.TB_Room_First_Places.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(512, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Период с:";
            // 
            // TB_Room_First_StartDate
            // 
            this.TB_Room_First_StartDate.Location = new System.Drawing.Point(591, 57);
            this.TB_Room_First_StartDate.Mask = "00/00/0000";
            this.TB_Room_First_StartDate.Name = "TB_Room_First_StartDate";
            this.TB_Room_First_StartDate.Size = new System.Drawing.Size(100, 22);
            this.TB_Room_First_StartDate.TabIndex = 13;
            this.TB_Room_First_StartDate.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(697, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "по:";
            // 
            // TB_Room_First_EndDate
            // 
            this.TB_Room_First_EndDate.Location = new System.Drawing.Point(731, 57);
            this.TB_Room_First_EndDate.Mask = "00/00/0000";
            this.TB_Room_First_EndDate.Name = "TB_Room_First_EndDate";
            this.TB_Room_First_EndDate.Size = new System.Drawing.Size(100, 22);
            this.TB_Room_First_EndDate.TabIndex = 15;
            this.TB_Room_First_EndDate.ValidatingType = typeof(System.DateTime);
            // 
            // TB_Room_Second_EndDate
            // 
            this.TB_Room_Second_EndDate.Location = new System.Drawing.Point(731, 90);
            this.TB_Room_Second_EndDate.Mask = "00/00/0000";
            this.TB_Room_Second_EndDate.Name = "TB_Room_Second_EndDate";
            this.TB_Room_Second_EndDate.Size = new System.Drawing.Size(100, 22);
            this.TB_Room_Second_EndDate.TabIndex = 23;
            this.TB_Room_Second_EndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(697, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "по:";
            // 
            // TB_Room_Second_StartDate
            // 
            this.TB_Room_Second_StartDate.Location = new System.Drawing.Point(591, 90);
            this.TB_Room_Second_StartDate.Mask = "00/00/0000";
            this.TB_Room_Second_StartDate.Name = "TB_Room_Second_StartDate";
            this.TB_Room_Second_StartDate.Size = new System.Drawing.Size(100, 22);
            this.TB_Room_Second_StartDate.TabIndex = 21;
            this.TB_Room_Second_StartDate.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(512, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Период с:";
            // 
            // TB_Room_Second_Places
            // 
            this.TB_Room_Second_Places.Location = new System.Drawing.Point(406, 90);
            this.TB_Room_Second_Places.Name = "TB_Room_Second_Places";
            this.TB_Room_Second_Places.Size = new System.Drawing.Size(100, 22);
            this.TB_Room_Second_Places.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(227, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Кол-во занимаемых мест";
            // 
            // CB_Room_Second
            // 
            this.CB_Room_Second.FormattingEnabled = true;
            this.CB_Room_Second.Location = new System.Drawing.Point(91, 90);
            this.CB_Room_Second.Name = "CB_Room_Second";
            this.CB_Room_Second.Size = new System.Drawing.Size(121, 24);
            this.CB_Room_Second.TabIndex = 17;
            this.CB_Room_Second.SelectedIndexChanged += new System.EventHandler(this.CB_Room_Second_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Комната:";
            // 
            // TenantSpecialPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 176);
            this.Controls.Add(this.TB_Room_Second_EndDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TB_Room_Second_StartDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TB_Room_Second_Places);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CB_Room_Second);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TB_Room_First_EndDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TB_Room_First_StartDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_Room_First_Places);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CB_Room_First);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LB_Order);
            this.Controls.Add(this.LB_Tenant);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TenantSpecialPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Условия специализированной оплаты";
            this.Load += new System.EventHandler(this.TenantSpecialPayments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Label LB_Tenant;
        private System.Windows.Forms.Label LB_Order;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Room_First;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_Room_First_Places;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox TB_Room_First_StartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox TB_Room_First_EndDate;
        private System.Windows.Forms.MaskedTextBox TB_Room_Second_EndDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox TB_Room_Second_StartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_Room_Second_Places;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CB_Room_Second;
        private System.Windows.Forms.Label label10;
    }
}