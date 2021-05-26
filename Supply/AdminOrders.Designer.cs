
namespace Supply
{
    partial class AdminOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminOrders));
            this.DG_View_Orders = new System.Windows.Forms.DataGridView();
            this.BTN_CreateExcel = new System.Windows.Forms.Button();
            this.COL_OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Tenant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Hostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Benefit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_TenantType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_OrderEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_CreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Orders)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_Orders
            // 
            this.DG_View_Orders.AllowUserToAddRows = false;
            this.DG_View_Orders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_Orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_Orders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_OrderNumber,
            this.COL_Tenant,
            this.COL_Room,
            this.COL_Hostel,
            this.COL_Benefit,
            this.COL_TenantType,
            this.COL_Payment,
            this.COL_StartOrder,
            this.COL_OrderEnd,
            this.COL_CreatedAt});
            this.DG_View_Orders.Location = new System.Drawing.Point(13, 13);
            this.DG_View_Orders.Name = "DG_View_Orders";
            this.DG_View_Orders.Size = new System.Drawing.Size(775, 380);
            this.DG_View_Orders.TabIndex = 0;
            // 
            // BTN_CreateExcel
            // 
            this.BTN_CreateExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_CreateExcel.Location = new System.Drawing.Point(713, 415);
            this.BTN_CreateExcel.Name = "BTN_CreateExcel";
            this.BTN_CreateExcel.Size = new System.Drawing.Size(75, 23);
            this.BTN_CreateExcel.TabIndex = 1;
            this.BTN_CreateExcel.Text = "В Excel";
            this.BTN_CreateExcel.UseVisualStyleBackColor = true;
            this.BTN_CreateExcel.Click += new System.EventHandler(this.BTN_CreateExcel_Click);
            // 
            // COL_OrderNumber
            // 
            this.COL_OrderNumber.HeaderText = "№ договора";
            this.COL_OrderNumber.Name = "COL_OrderNumber";
            this.COL_OrderNumber.ReadOnly = true;
            // 
            // COL_Tenant
            // 
            this.COL_Tenant.HeaderText = "Жилец";
            this.COL_Tenant.Name = "COL_Tenant";
            this.COL_Tenant.ReadOnly = true;
            // 
            // COL_Room
            // 
            this.COL_Room.HeaderText = "Комната";
            this.COL_Room.Name = "COL_Room";
            this.COL_Room.ReadOnly = true;
            // 
            // COL_Hostel
            // 
            this.COL_Hostel.HeaderText = "Общежитие";
            this.COL_Hostel.Name = "COL_Hostel";
            this.COL_Hostel.ReadOnly = true;
            // 
            // COL_Benefit
            // 
            this.COL_Benefit.HeaderText = "Льгота";
            this.COL_Benefit.Name = "COL_Benefit";
            this.COL_Benefit.ReadOnly = true;
            // 
            // COL_TenantType
            // 
            this.COL_TenantType.HeaderText = "Тип жильца";
            this.COL_TenantType.Name = "COL_TenantType";
            this.COL_TenantType.ReadOnly = true;
            // 
            // COL_Payment
            // 
            this.COL_Payment.HeaderText = "Тарифный план";
            this.COL_Payment.Name = "COL_Payment";
            this.COL_Payment.ReadOnly = true;
            // 
            // COL_StartOrder
            // 
            this.COL_StartOrder.HeaderText = "Начало действия договора";
            this.COL_StartOrder.Name = "COL_StartOrder";
            this.COL_StartOrder.ReadOnly = true;
            // 
            // COL_OrderEnd
            // 
            this.COL_OrderEnd.HeaderText = "Дата окончания договора";
            this.COL_OrderEnd.Name = "COL_OrderEnd";
            this.COL_OrderEnd.ReadOnly = true;
            // 
            // COL_CreatedAt
            // 
            this.COL_CreatedAt.HeaderText = "Дата создания";
            this.COL_CreatedAt.Name = "COL_CreatedAt";
            this.COL_CreatedAt.ReadOnly = true;
            // 
            // AdminOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_CreateExcel);
            this.Controls.Add(this.DG_View_Orders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Договра";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Orders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_Orders;
        private System.Windows.Forms.Button BTN_CreateExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Tenant;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Hostel;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Benefit;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_TenantType;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_OrderEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_CreatedAt;
    }
}