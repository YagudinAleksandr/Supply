
namespace Supply_Admin
{
    partial class GarageAdd
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
            this.TB_Number = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_StartDate = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_EndDate = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_Hostel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_Enterance = new System.Windows.Forms.ComboBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.CB_Flat = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_Room = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(103, 25);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(846, 22);
            this.TB_Name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Инвентарный номер";
            // 
            // TB_Number
            // 
            this.TB_Number.Location = new System.Drawing.Point(188, 87);
            this.TB_Number.Name = "TB_Number";
            this.TB_Number.Size = new System.Drawing.Size(220, 22);
            this.TB_Number.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Принят на учет";
            // 
            // TB_StartDate
            // 
            this.TB_StartDate.Location = new System.Drawing.Point(188, 144);
            this.TB_StartDate.Mask = "00/00/0000";
            this.TB_StartDate.Name = "TB_StartDate";
            this.TB_StartDate.Size = new System.Drawing.Size(131, 22);
            this.TB_StartDate.TabIndex = 5;
            this.TB_StartDate.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Снят с учета";
            // 
            // TB_EndDate
            // 
            this.TB_EndDate.Location = new System.Drawing.Point(489, 144);
            this.TB_EndDate.Mask = "00/00/0000";
            this.TB_EndDate.Name = "TB_EndDate";
            this.TB_EndDate.Size = new System.Drawing.Size(131, 22);
            this.TB_EndDate.TabIndex = 7;
            this.TB_EndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Общежитие";
            // 
            // CB_Hostel
            // 
            this.CB_Hostel.FormattingEnabled = true;
            this.CB_Hostel.Location = new System.Drawing.Point(116, 205);
            this.CB_Hostel.Name = "CB_Hostel";
            this.CB_Hostel.Size = new System.Drawing.Size(121, 24);
            this.CB_Hostel.TabIndex = 9;
            this.CB_Hostel.SelectedIndexChanged += new System.EventHandler(this.CB_Hostel_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Подъезд";
            // 
            // CB_Enterance
            // 
            this.CB_Enterance.FormattingEnabled = true;
            this.CB_Enterance.Location = new System.Drawing.Point(342, 205);
            this.CB_Enterance.Name = "CB_Enterance";
            this.CB_Enterance.Size = new System.Drawing.Size(121, 24);
            this.CB_Enterance.TabIndex = 11;
            this.CB_Enterance.SelectedIndexChanged += new System.EventHandler(this.CB_Enterance_SelectedIndexChanged);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(818, 263);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(131, 36);
            this.BTN_Save.TabIndex = 12;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // CB_Flat
            // 
            this.CB_Flat.FormattingEnabled = true;
            this.CB_Flat.Location = new System.Drawing.Point(544, 205);
            this.CB_Flat.Name = "CB_Flat";
            this.CB_Flat.Size = new System.Drawing.Size(121, 24);
            this.CB_Flat.TabIndex = 14;
            this.CB_Flat.SelectedIndexChanged += new System.EventHandler(this.CB_Flat_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(496, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Этаж";
            // 
            // CB_Room
            // 
            this.CB_Room.FormattingEnabled = true;
            this.CB_Room.Location = new System.Drawing.Point(761, 205);
            this.CB_Room.Name = "CB_Room";
            this.CB_Room.Size = new System.Drawing.Size(121, 24);
            this.CB_Room.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(690, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Комната";
            // 
            // GarageAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 311);
            this.Controls.Add(this.CB_Room);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CB_Flat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.CB_Enterance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CB_Hostel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_EndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_StartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_Number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label1);
            this.Name = "GarageAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление элемента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Number;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox TB_StartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox TB_EndDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CB_Hostel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CB_Enterance;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.ComboBox CB_Flat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CB_Room;
        private System.Windows.Forms.Label label8;
    }
}