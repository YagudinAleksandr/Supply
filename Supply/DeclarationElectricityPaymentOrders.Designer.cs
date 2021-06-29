namespace Supply
{
    partial class DeclarationElectricityPaymentOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationElectricityPaymentOrders));
            this.DG_View_ElectricityOrders = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Tenant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Hostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_ElectricityOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_ElectricityOrders
            // 
            this.DG_View_ElectricityOrders.AllowUserToAddRows = false;
            this.DG_View_ElectricityOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_ElectricityOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_ElectricityOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Tenant,
            this.COL_Hostel,
            this.COL_Room,
            this.COL_Status,
            this.COL_StartDate,
            this.COL_EndDate});
            this.DG_View_ElectricityOrders.Location = new System.Drawing.Point(13, 13);
            this.DG_View_ElectricityOrders.Name = "DG_View_ElectricityOrders";
            this.DG_View_ElectricityOrders.Size = new System.Drawing.Size(775, 396);
            this.DG_View_ElectricityOrders.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(649, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сформировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "#";
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            // 
            // COL_Tenant
            // 
            this.COL_Tenant.HeaderText = "Жилец";
            this.COL_Tenant.Name = "COL_Tenant";
            this.COL_Tenant.ReadOnly = true;
            this.COL_Tenant.Width = 250;
            // 
            // COL_Hostel
            // 
            this.COL_Hostel.HeaderText = "Общежитие";
            this.COL_Hostel.Name = "COL_Hostel";
            this.COL_Hostel.ReadOnly = true;
            // 
            // COL_Room
            // 
            this.COL_Room.HeaderText = "Комната";
            this.COL_Room.Name = "COL_Room";
            this.COL_Room.ReadOnly = true;
            // 
            // COL_Status
            // 
            this.COL_Status.HeaderText = "Статус";
            this.COL_Status.Name = "COL_Status";
            this.COL_Status.ReadOnly = true;
            // 
            // COL_StartDate
            // 
            this.COL_StartDate.HeaderText = "Дата заключения договора";
            this.COL_StartDate.Name = "COL_StartDate";
            this.COL_StartDate.ReadOnly = true;
            // 
            // COL_EndDate
            // 
            this.COL_EndDate.HeaderText = "Дата окончания договора";
            this.COL_EndDate.Name = "COL_EndDate";
            this.COL_EndDate.ReadOnly = true;
            // 
            // DeclarationElectricityPaymentOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DG_View_ElectricityOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationElectricityPaymentOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Договора оплаты электроэнергии";
            this.Shown += new System.EventHandler(this.DeclarationElectricityPaymentOrders_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_ElectricityOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_ElectricityOrders;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Tenant;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Hostel;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EndDate;
    }
}