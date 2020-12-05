namespace Supply_Admin
{
    partial class CreateWordDocumentOrder
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
            this.TB_Surename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Patronymic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_StartOrder = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_EduType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_ToTime = new System.Windows.Forms.ComboBox();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.PB_Creation = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // TB_Surename
            // 
            this.TB_Surename.Location = new System.Drawing.Point(90, 24);
            this.TB_Surename.Name = "TB_Surename";
            this.TB_Surename.Size = new System.Drawing.Size(126, 22);
            this.TB_Surename.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(274, 23);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(115, 22);
            this.TB_Name.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Отчество";
            // 
            // TB_Patronymic
            // 
            this.TB_Patronymic.Location = new System.Drawing.Point(485, 24);
            this.TB_Patronymic.Name = "TB_Patronymic";
            this.TB_Patronymic.Size = new System.Drawing.Size(129, 22);
            this.TB_Patronymic.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Период начала договра";
            // 
            // TB_StartOrder
            // 
            this.TB_StartOrder.Location = new System.Drawing.Point(189, 68);
            this.TB_StartOrder.Mask = "00/00/0000";
            this.TB_StartOrder.Name = "TB_StartOrder";
            this.TB_StartOrder.Size = new System.Drawing.Size(100, 22);
            this.TB_StartOrder.TabIndex = 7;
            this.TB_StartOrder.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Форма обучения";
            // 
            // CB_EduType
            // 
            this.CB_EduType.FormattingEnabled = true;
            this.CB_EduType.Items.AddRange(new object[] {
            "очная",
            "заочная",
            "очно-заочная"});
            this.CB_EduType.Location = new System.Drawing.Point(141, 109);
            this.CB_EduType.Name = "CB_EduType";
            this.CB_EduType.Size = new System.Drawing.Size(121, 24);
            this.CB_EduType.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Договор заключен на время";
            // 
            // CB_ToTime
            // 
            this.CB_ToTime.FormattingEnabled = true;
            this.CB_ToTime.Items.AddRange(new object[] {
            "учебы",
            "работы"});
            this.CB_ToTime.Location = new System.Drawing.Point(218, 157);
            this.CB_ToTime.Name = "CB_ToTime";
            this.CB_ToTime.Size = new System.Drawing.Size(121, 24);
            this.CB_ToTime.TabIndex = 13;
            // 
            // BTN_Create
            // 
            this.BTN_Create.Location = new System.Drawing.Point(659, 227);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(129, 35);
            this.BTN_Create.TabIndex = 14;
            this.BTN_Create.Text = "Сформировать";
            this.BTN_Create.UseMnemonic = false;
            this.BTN_Create.UseVisualStyleBackColor = true;
            this.BTN_Create.Click += new System.EventHandler(this.BTN_Create_Click);
            // 
            // PB_Creation
            // 
            this.PB_Creation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_Creation.Location = new System.Drawing.Point(19, 198);
            this.PB_Creation.Name = "PB_Creation";
            this.PB_Creation.Size = new System.Drawing.Size(769, 23);
            this.PB_Creation.TabIndex = 15;
            // 
            // CreateWordDocumentOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 273);
            this.Controls.Add(this.PB_Creation);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.CB_ToTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CB_EduType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TB_StartOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Patronymic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Surename);
            this.Controls.Add(this.label1);
            this.Name = "CreateWordDocumentOrder";
            this.Text = "Сформировать Word договра";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Surename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Patronymic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox TB_StartOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CB_EduType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CB_ToTime;
        private System.Windows.Forms.Button BTN_Create;
        private System.Windows.Forms.ProgressBar PB_Creation;
    }
}