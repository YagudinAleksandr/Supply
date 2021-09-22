
namespace Supply
{
    partial class DeclarationMonthPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationMonthPayment));
            this.label1 = new System.Windows.Forms.Label();
            this.TB_StartDate = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_EndDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Период с:";
            // 
            // TB_StartDate
            // 
            this.TB_StartDate.Location = new System.Drawing.Point(92, 13);
            this.TB_StartDate.Mask = "00/00/0000";
            this.TB_StartDate.Name = "TB_StartDate";
            this.TB_StartDate.Size = new System.Drawing.Size(100, 22);
            this.TB_StartDate.TabIndex = 1;
            this.TB_StartDate.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "по:";
            // 
            // TB_EndDate
            // 
            this.TB_EndDate.Location = new System.Drawing.Point(233, 12);
            this.TB_EndDate.Mask = "00/00/0000";
            this.TB_EndDate.Name = "TB_EndDate";
            this.TB_EndDate.Size = new System.Drawing.Size(100, 22);
            this.TB_EndDate.TabIndex = 3;
            this.TB_EndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Общежитие";
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(105, 48);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(121, 24);
            this.CB_Hostels.TabIndex = 5;
            this.CB_Hostels.SelectionChangeCommitted += new System.EventHandler(this.CB_Hostels_SelectionChangeCommitted);
            // 
            // BTN_Create
            // 
            this.BTN_Create.Location = new System.Drawing.Point(366, 110);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(94, 25);
            this.BTN_Create.TabIndex = 6;
            this.BTN_Create.Text = "Создать";
            this.BTN_Create.UseVisualStyleBackColor = true;
            this.BTN_Create.Click += new System.EventHandler(this.BTN_Create_Click);
            // 
            // DeclarationMonthPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 147);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_EndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_StartDate);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationMonthPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет о начислении жильцам в период";
            this.Shown += new System.EventHandler(this.DeclarationMonthPayment_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox TB_StartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox TB_EndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.Button BTN_Create;
    }
}