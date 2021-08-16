namespace Supply
{
    partial class TenantTerminationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenantTerminationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.LB_OrderNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LB_Tenant = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Date = new System.Windows.Forms.MaskedTextBox();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Договор №:";
            // 
            // LB_OrderNumber
            // 
            this.LB_OrderNumber.AutoSize = true;
            this.LB_OrderNumber.Location = new System.Drawing.Point(117, 16);
            this.LB_OrderNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_OrderNumber.Name = "LB_OrderNumber";
            this.LB_OrderNumber.Size = new System.Drawing.Size(46, 17);
            this.LB_OrderNumber.TabIndex = 1;
            this.LB_OrderNumber.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Жилец:";
            // 
            // LB_Tenant
            // 
            this.LB_Tenant.AutoSize = true;
            this.LB_Tenant.Location = new System.Drawing.Point(383, 16);
            this.LB_Tenant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_Tenant.Name = "LB_Tenant";
            this.LB_Tenant.Size = new System.Drawing.Size(46, 17);
            this.LB_Tenant.TabIndex = 3;
            this.LB_Tenant.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата расторжения договора";
            // 
            // TB_Date
            // 
            this.TB_Date.Location = new System.Drawing.Point(240, 60);
            this.TB_Date.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Date.Mask = "00/00/0000";
            this.TB_Date.Name = "TB_Date";
            this.TB_Date.Size = new System.Drawing.Size(132, 22);
            this.TB_Date.TabIndex = 5;
            this.TB_Date.ValidatingType = typeof(System.DateTime);
            // 
            // BTN_Create
            // 
            this.BTN_Create.Location = new System.Drawing.Point(675, 156);
            this.BTN_Create.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(100, 28);
            this.BTN_Create.TabIndex = 6;
            this.BTN_Create.Text = "Создать";
            this.BTN_Create.UseVisualStyleBackColor = true;
            this.BTN_Create.Click += new System.EventHandler(this.BTN_Create_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ответственный за договор";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(240, 116);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(535, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TenantTerminationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 197);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.TB_Date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LB_Tenant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LB_OrderNumber);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TenantTerminationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расторжение договора";
            this.Shown += new System.EventHandler(this.TenantTerminationForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_OrderNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LB_Tenant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox TB_Date;
        private System.Windows.Forms.Button BTN_Create;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}