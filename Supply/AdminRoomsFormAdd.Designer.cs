
namespace Supply
{
    partial class AdminRoomsFormAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminRoomsFormAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.TB_Places = new System.Windows.Forms.TextBox();
            this.CB_RoomType = new System.Windows.Forms.ComboBox();
            this.CB_Enterances = new System.Windows.Forms.ComboBox();
            this.CB_Flat = new System.Windows.Forms.ComboBox();
            this.BTN_Save = new System.Windows.Forms.Button();
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
            this.label2.Location = new System.Drawing.Point(151, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Кол-во мест";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тип жилого помещения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Подъезд";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Этаж";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(76, 10);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(65, 20);
            this.TB_Name.TabIndex = 5;
            // 
            // TB_Places
            // 
            this.TB_Places.Location = new System.Drawing.Point(226, 10);
            this.TB_Places.Name = "TB_Places";
            this.TB_Places.Size = new System.Drawing.Size(65, 20);
            this.TB_Places.TabIndex = 6;
            // 
            // CB_RoomType
            // 
            this.CB_RoomType.FormattingEnabled = true;
            this.CB_RoomType.Location = new System.Drawing.Point(148, 39);
            this.CB_RoomType.Name = "CB_RoomType";
            this.CB_RoomType.Size = new System.Drawing.Size(143, 21);
            this.CB_RoomType.TabIndex = 7;
            this.CB_RoomType.SelectedIndexChanged += new System.EventHandler(this.CB_RoomType_SelectedIndexChanged);
            // 
            // CB_Enterances
            // 
            this.CB_Enterances.FormattingEnabled = true;
            this.CB_Enterances.Location = new System.Drawing.Point(76, 66);
            this.CB_Enterances.Name = "CB_Enterances";
            this.CB_Enterances.Size = new System.Drawing.Size(69, 21);
            this.CB_Enterances.TabIndex = 8;
            this.CB_Enterances.SelectedIndexChanged += new System.EventHandler(this.CB_Enterances_SelectedIndexChanged);
            // 
            // CB_Flat
            // 
            this.CB_Flat.FormattingEnabled = true;
            this.CB_Flat.Location = new System.Drawing.Point(190, 66);
            this.CB_Flat.Name = "CB_Flat";
            this.CB_Flat.Size = new System.Drawing.Size(69, 21);
            this.CB_Flat.TabIndex = 9;
            this.CB_Flat.SelectedIndexChanged += new System.EventHandler(this.CB_Flat_SelectedIndexChanged);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(216, 107);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save.TabIndex = 10;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // AdminRoomsFormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 143);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.CB_Flat);
            this.Controls.Add(this.CB_Enterances);
            this.Controls.Add(this.CB_RoomType);
            this.Controls.Add(this.TB_Places);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminRoomsFormAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление комнаты";
            this.Shown += new System.EventHandler(this.AdminRoomsFormAdd_Shown);
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
        private System.Windows.Forms.TextBox TB_Places;
        private System.Windows.Forms.ComboBox CB_RoomType;
        private System.Windows.Forms.ComboBox CB_Enterances;
        private System.Windows.Forms.ComboBox CB_Flat;
        private System.Windows.Forms.Button BTN_Save;
    }
}