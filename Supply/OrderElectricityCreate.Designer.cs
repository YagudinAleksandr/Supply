namespace Supply
{
    partial class OrderElectricityCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderElectricityCreate));
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_StartOrder = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_EndOrder = new System.Windows.Forms.MaskedTextBox();
            this.PB_Progress = new System.Windows.Forms.ProgressBar();
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
            this.CB_Hostels.Size = new System.Drawing.Size(73, 21);
            this.CB_Hostels.TabIndex = 1;
            this.CB_Hostels.SelectedIndexChanged += new System.EventHandler(this.CB_Hostels_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Период с:";
            // 
            // TB_StartOrder
            // 
            this.TB_StartOrder.Location = new System.Drawing.Point(263, 10);
            this.TB_StartOrder.Mask = "00/00/0000";
            this.TB_StartOrder.Name = "TB_StartOrder";
            this.TB_StartOrder.Size = new System.Drawing.Size(100, 20);
            this.TB_StartOrder.TabIndex = 3;
            this.TB_StartOrder.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "по:";
            // 
            // TB_EndOrder
            // 
            this.TB_EndOrder.Location = new System.Drawing.Point(397, 10);
            this.TB_EndOrder.Mask = "00/00/0000";
            this.TB_EndOrder.Name = "TB_EndOrder";
            this.TB_EndOrder.Size = new System.Drawing.Size(100, 20);
            this.TB_EndOrder.TabIndex = 5;
            this.TB_EndOrder.ValidatingType = typeof(System.DateTime);
            // 
            // PB_Progress
            // 
            this.PB_Progress.Location = new System.Drawing.Point(16, 46);
            this.PB_Progress.Name = "PB_Progress";
            this.PB_Progress.Size = new System.Drawing.Size(772, 23);
            this.PB_Progress.TabIndex = 6;
            // 
            // BTN_Create
            // 
            this.BTN_Create.Location = new System.Drawing.Point(713, 77);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(75, 23);
            this.BTN_Create.TabIndex = 7;
            this.BTN_Create.Text = "Создать";
            this.BTN_Create.UseVisualStyleBackColor = true;
            this.BTN_Create.Click += new System.EventHandler(this.BTN_Create_Click);
            // 
            // OrderElectricityCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 112);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.PB_Progress);
            this.Controls.Add(this.TB_EndOrder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_StartOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderElectricityCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание договоров на электроэнергию";
            this.Shown += new System.EventHandler(this.OrderElectricityCreate_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox TB_StartOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox TB_EndOrder;
        private System.Windows.Forms.ProgressBar PB_Progress;
        private System.Windows.Forms.Button BTN_Create;
    }
}