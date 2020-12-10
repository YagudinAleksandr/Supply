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
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(92, 13);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(327, 22);
            this.TB_Name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
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
            this.CB_Type.Location = new System.Drawing.Point(52, 65);
            this.CB_Type.Name = "CB_Type";
            this.CB_Type.Size = new System.Drawing.Size(121, 24);
            this.CB_Type.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество мест";
            // 
            // TB_Places
            // 
            this.TB_Places.Location = new System.Drawing.Point(328, 67);
            this.TB_Places.Name = "TB_Places";
            this.TB_Places.Size = new System.Drawing.Size(52, 22);
            this.TB_Places.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Общежитие";
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(106, 131);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(121, 24);
            this.CB_Hostels.TabIndex = 7;
            this.CB_Hostels.SelectedIndexChanged += new System.EventHandler(this.CB_Hostels_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Этаж";
            // 
            // CB_Flats
            // 
            this.CB_Flats.FormattingEnabled = true;
            this.CB_Flats.Location = new System.Drawing.Point(460, 129);
            this.CB_Flats.Name = "CB_Flats";
            this.CB_Flats.Size = new System.Drawing.Size(76, 24);
            this.CB_Flats.TabIndex = 9;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(298, 181);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(121, 33);
            this.BTN_Save.TabIndex = 10;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Подъезд";
            // 
            // CB_Enterance
            // 
            this.CB_Enterance.FormattingEnabled = true;
            this.CB_Enterance.Location = new System.Drawing.Point(308, 130);
            this.CB_Enterance.Name = "CB_Enterance";
            this.CB_Enterance.Size = new System.Drawing.Size(98, 24);
            this.CB_Enterance.TabIndex = 12;
            this.CB_Enterance.SelectedIndexChanged += new System.EventHandler(this.CB_Enterance_SelectedIndexChanged);
            // 
            // RoomsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 237);
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