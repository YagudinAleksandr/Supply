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
            this.label4 = new System.Windows.Forms.Label();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.PB_Creation = new System.Windows.Forms.ProgressBar();
            this.TB_OrderStart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Период начала договра";
            // 
            // BTN_Create
            // 
            this.BTN_Create.Location = new System.Drawing.Point(659, 84);
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
            this.PB_Creation.Location = new System.Drawing.Point(19, 55);
            this.PB_Creation.Name = "PB_Creation";
            this.PB_Creation.Size = new System.Drawing.Size(769, 23);
            this.PB_Creation.TabIndex = 15;
            // 
            // TB_OrderStart
            // 
            this.TB_OrderStart.Location = new System.Drawing.Point(188, 27);
            this.TB_OrderStart.Name = "TB_OrderStart";
            this.TB_OrderStart.Size = new System.Drawing.Size(100, 22);
            this.TB_OrderStart.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Общежитие";
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(388, 26);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(60, 24);
            this.CB_Hostels.TabIndex = 18;
            // 
            // CreateWordDocumentOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 128);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_OrderStart);
            this.Controls.Add(this.PB_Creation);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.label4);
            this.Name = "CreateWordDocumentOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сформировать Word договра";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTN_Create;
        private System.Windows.Forms.ProgressBar PB_Creation;
        private System.Windows.Forms.TextBox TB_OrderStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Hostels;
    }
}