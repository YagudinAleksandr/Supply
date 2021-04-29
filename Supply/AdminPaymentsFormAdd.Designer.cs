
namespace Supply
{
    partial class AdminPaymentsFormAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPaymentsFormAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.TB_Description = new System.Windows.Forms.TextBox();
            this.TB_Coast = new System.Windows.Forms.TextBox();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.CB_RoomTypes = new System.Windows.Forms.ComboBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_TenantTypes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Описание";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Сумма";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Общежитие";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Тип комнаты";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(86, 10);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(454, 20);
            this.TB_Name.TabIndex = 5;
            // 
            // TB_Description
            // 
            this.TB_Description.Location = new System.Drawing.Point(86, 49);
            this.TB_Description.Name = "TB_Description";
            this.TB_Description.Size = new System.Drawing.Size(454, 20);
            this.TB_Description.TabIndex = 6;
            // 
            // TB_Coast
            // 
            this.TB_Coast.Location = new System.Drawing.Point(86, 91);
            this.TB_Coast.Name = "TB_Coast";
            this.TB_Coast.Size = new System.Drawing.Size(112, 20);
            this.TB_Coast.TabIndex = 7;
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(86, 136);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(98, 21);
            this.CB_Hostels.TabIndex = 8;
            this.CB_Hostels.SelectedIndexChanged += new System.EventHandler(this.CB_Hostels_SelectedIndexChanged);
            // 
            // CB_RoomTypes
            // 
            this.CB_RoomTypes.FormattingEnabled = true;
            this.CB_RoomTypes.Location = new System.Drawing.Point(271, 136);
            this.CB_RoomTypes.Name = "CB_RoomTypes";
            this.CB_RoomTypes.Size = new System.Drawing.Size(148, 21);
            this.CB_RoomTypes.TabIndex = 9;
            this.CB_RoomTypes.SelectedIndexChanged += new System.EventHandler(this.CB_RoomTypes_SelectedIndexChanged);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(465, 177);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save.TabIndex = 10;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Тип проживающего";
            // 
            // CB_TenantTypes
            // 
            this.CB_TenantTypes.FormattingEnabled = true;
            this.CB_TenantTypes.Location = new System.Drawing.Point(331, 90);
            this.CB_TenantTypes.Name = "CB_TenantTypes";
            this.CB_TenantTypes.Size = new System.Drawing.Size(209, 21);
            this.CB_TenantTypes.TabIndex = 12;
            this.CB_TenantTypes.SelectedIndexChanged += new System.EventHandler(this.CB_TenantTypes_SelectedIndexChanged);
            // 
            // AdminPaymentsFormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 212);
            this.Controls.Add(this.CB_TenantTypes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.CB_RoomTypes);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.TB_Coast);
            this.Controls.Add(this.TB_Description);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminPaymentsFormAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тарифный план";
            this.Load += new System.EventHandler(this.AdminPaymentsFormAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.TextBox TB_Description;
        private System.Windows.Forms.TextBox TB_Coast;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.ComboBox CB_RoomTypes;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CB_TenantTypes;
    }
}