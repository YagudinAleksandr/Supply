
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Общежитие";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Тип льготы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Стоимость";
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(105, 10);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(121, 24);
            this.CB_Hostels.TabIndex = 3;
            this.CB_Hostels.SelectedIndexChanged += new System.EventHandler(this.CB_Hostels_SelectedIndexChanged);
            // 
            // CB_BenefitType
            // 
            this.CB_BenefitType.FormattingEnabled = true;
            this.CB_BenefitType.Location = new System.Drawing.Point(426, 10);
            this.CB_BenefitType.Name = "CB_BenefitType";
            this.CB_BenefitType.Size = new System.Drawing.Size(362, 24);
            this.CB_BenefitType.TabIndex = 4;
            this.CB_BenefitType.SelectedIndexChanged += new System.EventHandler(this.CB_BenefitType_SelectedIndexChanged);
            // 
            // TB_Price
            // 
            this.TB_Price.Location = new System.Drawing.Point(105, 69);
            this.TB_Price.Name = "TB_Price";
            this.TB_Price.Size = new System.Drawing.Size(121, 22);
            this.TB_Price.TabIndex = 5;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(686, 154);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(102, 30);
            this.BTN_Save.TabIndex = 6;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // ChB_Status
            // 
            this.ChB_Status.AutoSize = true;
            this.ChB_Status.Location = new System.Drawing.Point(341, 72);
            this.ChB_Status.Name = "ChB_Status";
            this.ChB_Status.Size = new System.Drawing.Size(84, 21);
            this.ChB_Status.TabIndex = 7;
            this.ChB_Status.Text = "Активен";
            this.ChB_Status.UseVisualStyleBackColor = true;
            // 
            // AdminBenefitPaymentAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 196);
            this.Controls.Add(this.ChB_Status);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.TB_Price);
            this.Controls.Add(this.CB_BenefitType);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}