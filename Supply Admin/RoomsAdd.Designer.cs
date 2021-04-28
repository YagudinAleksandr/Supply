namespace Supply_Admin
{
    partial class RoomsAdd
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
            this.CB_Type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Places = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_Flats = new System.Windows.Forms.ComboBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_Enterance = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(69, 11);
            this.TB_Name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(246, 20);
            this.TB_Name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип";
            // 
            // CB_Type
            // 
            this.CB_Type.FormattingEnabled = true;
            this.CB_Type.Items.AddRange(new object[] {
            "стандартный",
            "улучшенный",
            "улучшенный+",
            "уют"});
            this.CB_Type.Location = new System.Drawing.Point(39, 53);
            this.CB_Type.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CB_Type.Name = "CB_Type";
            this.CB_Type.Size = new System.Drawing.Size(92, 21);
            this.CB_Type.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество мест";
            // 
            // TB_Places
            // 
            this.TB_Places.Location = new System.Drawing.Point(246, 54);
            this.TB_Places.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TB_Places.Name = "TB_Places";
            this.TB_Places.Size = new System.Drawing.Size(40, 20);
            this.TB_Places.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Общежитие";
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(80, 106);
            this.CB_Hostels.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(92, 21);
            this.CB_Hostels.TabIndex = 7;
            this.CB_Hostels.SelectedIndexChanged += new System.EventHandler(this.CB_Hostels_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Этаж";
            // 
            // CB_Flats
            // 
            this.CB_Flats.FormattingEnabled = true;
            this.CB_Flats.Location = new System.Drawing.Point(345, 105);
            this.CB_Flats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CB_Flats.Name = "CB_Flats";
            this.CB_Flats.Size = new System.Drawing.Size(58, 21);
            this.CB_Flats.TabIndex = 9;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(224, 147);
            this.BTN_Save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(91, 27);
            this.BTN_Save.TabIndex = 10;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 108);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Подъезд";
            // 
            // CB_Enterance
            // 
            this.CB_Enterance.FormattingEnabled = true;
            this.CB_Enterance.Location = new System.Drawing.Point(231, 106);
            this.CB_Enterance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CB_Enterance.Name = "CB_Enterance";
            this.CB_Enterance.Size = new System.Drawing.Size(74, 21);
            this.CB_Enterance.TabIndex = 12;
            this.CB_Enterance.SelectedIndexChanged += new System.EventHandler(this.CB_Enterance_SelectedIndexChanged);
            // 
            // RoomsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 193);
            this.Controls.Add(this.CB_Enterance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.CB_Flats);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Places);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CB_Type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RoomsAdd";
            this.Text = "RoomsAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_Type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Places;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CB_Flats;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CB_Enterance;
    }
}