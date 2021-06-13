
namespace Supply
{
    partial class AdminPaymentsElectricityPaymentAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPaymentsElectricityPaymentAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.Lable1 = new System.Windows.Forms.Label();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.ChB_Status = new System.Windows.Forms.CheckBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(77, 13);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(488, 20);
            this.TB_Name.TabIndex = 1;
            // 
            // Lable1
            // 
            this.Lable1.AutoSize = true;
            this.Lable1.Location = new System.Drawing.Point(14, 53);
            this.Lable1.Name = "Lable1";
            this.Lable1.Size = new System.Drawing.Size(81, 13);
            this.Lable1.TabIndex = 2;
            this.Lable1.Text = "Общежитие №";
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(101, 50);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(161, 21);
            this.CB_Hostels.TabIndex = 3;
            this.CB_Hostels.SelectedIndexChanged += new System.EventHandler(this.CB_Hostels_SelectedIndexChanged);
            // 
            // ChB_Status
            // 
            this.ChB_Status.AutoSize = true;
            this.ChB_Status.Location = new System.Drawing.Point(17, 91);
            this.ChB_Status.Name = "ChB_Status";
            this.ChB_Status.Size = new System.Drawing.Size(121, 17);
            this.ChB_Status.TabIndex = 4;
            this.ChB_Status.Text = "Статус активности";
            this.ChB_Status.UseVisualStyleBackColor = true;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(484, 125);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save.TabIndex = 5;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // AdminPaymentsElectricityPaymentAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 158);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.ChB_Status);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.Lable1);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminPaymentsElectricityPaymentAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание тарифа эл.энергии";
            this.Shown += new System.EventHandler(this.AdminPaymentsElectricityPaymentAdd_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.Label Lable1;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.CheckBox ChB_Status;
        private System.Windows.Forms.Button BTN_Save;
    }
}