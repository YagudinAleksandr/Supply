namespace Supply
{
    partial class DeclarationPaymentOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationPaymentOrder));
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_StartDate = new System.Windows.Forms.MaskedTextBox();
            this.TB_EndDate = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_Action = new System.Windows.Forms.MaskedTextBox();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Общежитие";
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(86, 10);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(121, 21);
            this.CB_Hostels.TabIndex = 1;
            this.CB_Hostels.SelectedIndexChanged += new System.EventHandler(this.CB_Hostels_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Период с:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "по:";
            // 
            // TB_StartDate
            // 
            this.TB_StartDate.Location = new System.Drawing.Point(269, 10);
            this.TB_StartDate.Mask = "00/00/0000";
            this.TB_StartDate.Name = "TB_StartDate";
            this.TB_StartDate.Size = new System.Drawing.Size(100, 20);
            this.TB_StartDate.TabIndex = 4;
            this.TB_StartDate.ValidatingType = typeof(System.DateTime);
            // 
            // TB_EndDate
            // 
            this.TB_EndDate.Location = new System.Drawing.Point(438, 10);
            this.TB_EndDate.Mask = "00/00/0000";
            this.TB_EndDate.Name = "TB_EndDate";
            this.TB_EndDate.Size = new System.Drawing.Size(100, 20);
            this.TB_EndDate.TabIndex = 5;
            this.TB_EndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Оплата до:";
            // 
            // TB_Action
            // 
            this.TB_Action.Location = new System.Drawing.Point(86, 44);
            this.TB_Action.Mask = "00/00/0000";
            this.TB_Action.Name = "TB_Action";
            this.TB_Action.Size = new System.Drawing.Size(100, 20);
            this.TB_Action.TabIndex = 7;
            this.TB_Action.ValidatingType = typeof(System.DateTime);
            // 
            // BTN_Create
            // 
            this.BTN_Create.Location = new System.Drawing.Point(463, 84);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(75, 23);
            this.BTN_Create.TabIndex = 8;
            this.BTN_Create.Text = "Создать";
            this.BTN_Create.UseVisualStyleBackColor = true;
            this.BTN_Create.Click += new System.EventHandler(this.BTN_Create_Click);
            // 
            // DeclarationPaymentOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 120);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.TB_Action);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_EndDate);
            this.Controls.Add(this.TB_StartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationPaymentOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание платежных поручений";
            this.Shown += new System.EventHandler(this.DeclarationPaymentOrder_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox TB_StartDate;
        private System.Windows.Forms.MaskedTextBox TB_EndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox TB_Action;
        private System.Windows.Forms.Button BTN_Create;
    }
}