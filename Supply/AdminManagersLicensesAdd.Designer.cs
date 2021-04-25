
namespace Supply
{
    partial class AdminManagersLicensesAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminManagersLicensesAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Types = new System.Windows.Forms.ComboBox();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.TB_StartDate = new System.Windows.Forms.MaskedTextBox();
            this.TB_EndDate = new System.Windows.Forms.MaskedTextBox();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Начало";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(511, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Окончание";
            // 
            // CB_Types
            // 
            this.CB_Types.FormattingEnabled = true;
            this.CB_Types.Items.AddRange(new object[] {
            "Лицензия",
            "Доверенность"});
            this.CB_Types.Location = new System.Drawing.Point(45, 10);
            this.CB_Types.Name = "CB_Types";
            this.CB_Types.Size = new System.Drawing.Size(115, 21);
            this.CB_Types.TabIndex = 4;
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(229, 10);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(108, 20);
            this.TB_Name.TabIndex = 5;
            // 
            // TB_StartDate
            // 
            this.TB_StartDate.Location = new System.Drawing.Point(406, 10);
            this.TB_StartDate.Mask = "00/00/0000";
            this.TB_StartDate.Name = "TB_StartDate";
            this.TB_StartDate.Size = new System.Drawing.Size(68, 20);
            this.TB_StartDate.TabIndex = 6;
            this.TB_StartDate.ValidatingType = typeof(System.DateTime);
            // 
            // TB_EndDate
            // 
            this.TB_EndDate.Location = new System.Drawing.Point(579, 10);
            this.TB_EndDate.Mask = "00/00/0000";
            this.TB_EndDate.Name = "TB_EndDate";
            this.TB_EndDate.Size = new System.Drawing.Size(67, 20);
            this.TB_EndDate.TabIndex = 7;
            this.TB_EndDate.ValidatingType = typeof(System.DateTime);
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(571, 68);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(75, 23);
            this.BTN_Add.TabIndex = 8;
            this.BTN_Add.Text = "Добавить";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // AdminManagersLicensesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 103);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.TB_EndDate);
            this.Controls.Add(this.TB_StartDate);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.CB_Types);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminManagersLicensesAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление лицензии";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_Types;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.MaskedTextBox TB_StartDate;
        private System.Windows.Forms.MaskedTextBox TB_EndDate;
        private System.Windows.Forms.Button BTN_Add;
    }
}