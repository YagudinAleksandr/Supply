
namespace Supply_Admin
{
    partial class SupplyAdd
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
            this.BTN_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Surename = new System.Windows.Forms.TextBox();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.TB_Patronimic = new System.Windows.Forms.TextBox();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.TB_Proxy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_ProxyDate = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(317, 218);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(100, 34);
            this.BTN_Save.TabIndex = 0;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Общежитие";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Доверенность";
            // 
            // TB_Surename
            // 
            this.TB_Surename.Location = new System.Drawing.Point(127, 13);
            this.TB_Surename.Name = "TB_Surename";
            this.TB_Surename.Size = new System.Drawing.Size(153, 22);
            this.TB_Surename.TabIndex = 6;
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(127, 50);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(153, 22);
            this.TB_Name.TabIndex = 7;
            // 
            // TB_Patronimic
            // 
            this.TB_Patronimic.Location = new System.Drawing.Point(127, 88);
            this.TB_Patronimic.Name = "TB_Patronimic";
            this.TB_Patronimic.Size = new System.Drawing.Size(153, 22);
            this.TB_Patronimic.TabIndex = 8;
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(127, 131);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(153, 24);
            this.CB_Hostels.TabIndex = 9;
            // 
            // TB_Proxy
            // 
            this.TB_Proxy.Location = new System.Drawing.Point(127, 175);
            this.TB_Proxy.Name = "TB_Proxy";
            this.TB_Proxy.Size = new System.Drawing.Size(153, 22);
            this.TB_Proxy.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "от";
            // 
            // TB_ProxyDate
            // 
            this.TB_ProxyDate.Location = new System.Drawing.Point(317, 177);
            this.TB_ProxyDate.Mask = "00/00/0000";
            this.TB_ProxyDate.Name = "TB_ProxyDate";
            this.TB_ProxyDate.Size = new System.Drawing.Size(100, 22);
            this.TB_ProxyDate.TabIndex = 12;
            this.TB_ProxyDate.ValidatingType = typeof(System.DateTime);
            // 
            // SupplyAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 260);
            this.Controls.Add(this.TB_ProxyDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TB_Proxy);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.TB_Patronimic);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.TB_Surename);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_Save);
            this.Name = "SupplyAdd";
            this.Text = "Добавление заведующего общежитием";
            this.Load += new System.EventHandler(this.SupplyAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_Surename;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.TextBox TB_Patronimic;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.TextBox TB_Proxy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox TB_ProxyDate;
    }
}