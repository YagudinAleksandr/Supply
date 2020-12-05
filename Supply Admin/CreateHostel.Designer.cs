namespace Supply_Admin
{
    partial class CreateHostel
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
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Flats = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Supply = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RTB_Address = new System.Windows.Forms.RichTextBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название общежития";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(171, 13);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(195, 22);
            this.TB_Name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество этажей";
            // 
            // TB_Flats
            // 
            this.TB_Flats.Location = new System.Drawing.Point(526, 12);
            this.TB_Flats.Name = "TB_Flats";
            this.TB_Flats.Size = new System.Drawing.Size(65, 22);
            this.TB_Flats.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Заведующий общежитием";
            // 
            // TB_Supply
            // 
            this.TB_Supply.Location = new System.Drawing.Point(202, 53);
            this.TB_Supply.Name = "TB_Supply";
            this.TB_Supply.Size = new System.Drawing.Size(389, 22);
            this.TB_Supply.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Адрес";
            // 
            // RTB_Address
            // 
            this.RTB_Address.Location = new System.Drawing.Point(19, 126);
            this.RTB_Address.Name = "RTB_Address";
            this.RTB_Address.Size = new System.Drawing.Size(572, 96);
            this.RTB_Address.TabIndex = 7;
            this.RTB_Address.Text = "";
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(492, 248);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(99, 33);
            this.BTN_Save.TabIndex = 8;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // CreateHostel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 293);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.RTB_Address);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Supply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_Flats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label1);
            this.Name = "CreateHostel";
            this.Text = "Создание общежития";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Flats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Supply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox RTB_Address;
        private System.Windows.Forms.Button BTN_Save;
    }
}