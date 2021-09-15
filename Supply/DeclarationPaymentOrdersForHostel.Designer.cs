
namespace Supply
{
    partial class DeclarationPaymentOrdersForHostel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationPaymentOrdersForHostel));
            this.DG_View_PaymentActiveOrders = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.COL_Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Tenant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Faculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Organization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EndOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_PaymentActiveOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_PaymentActiveOrders
            // 
            this.DG_View_PaymentActiveOrders.AllowUserToAddRows = false;
            this.DG_View_PaymentActiveOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_PaymentActiveOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_PaymentActiveOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_Check,
            this.COL_ID,
            this.COL_Tenant,
            this.COL_Room,
            this.COL_Faculty,
            this.COL_Organization,
            this.COL_Order,
            this.COL_StartDate,
            this.COL_EndOrder});
            this.DG_View_PaymentActiveOrders.Location = new System.Drawing.Point(16, 59);
            this.DG_View_PaymentActiveOrders.Name = "DG_View_PaymentActiveOrders";
            this.DG_View_PaymentActiveOrders.RowHeadersWidth = 51;
            this.DG_View_PaymentActiveOrders.RowTemplate.Height = 24;
            this.DG_View_PaymentActiveOrders.Size = new System.Drawing.Size(1450, 424);
            this.DG_View_PaymentActiveOrders.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Выбрать все";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // COL_Check
            // 
            this.COL_Check.HeaderText = "Выбор";
            this.COL_Check.MinimumWidth = 6;
            this.COL_Check.Name = "COL_Check";
            this.COL_Check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COL_Check.Width = 125;
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.MinimumWidth = 6;
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            this.COL_ID.Width = 125;
            // 
            // COL_Tenant
            // 
            this.COL_Tenant.HeaderText = "Жилец";
            this.COL_Tenant.MinimumWidth = 6;
            this.COL_Tenant.Name = "COL_Tenant";
            this.COL_Tenant.ReadOnly = true;
            this.COL_Tenant.Width = 350;
            // 
            // COL_Room
            // 
            this.COL_Room.HeaderText = "Комната";
            this.COL_Room.MinimumWidth = 6;
            this.COL_Room.Name = "COL_Room";
            this.COL_Room.ReadOnly = true;
            this.COL_Room.Width = 125;
            // 
            // COL_Faculty
            // 
            this.COL_Faculty.HeaderText = "Факультет";
            this.COL_Faculty.MinimumWidth = 6;
            this.COL_Faculty.Name = "COL_Faculty";
            this.COL_Faculty.ReadOnly = true;
            this.COL_Faculty.Width = 125;
            // 
            // COL_Organization
            // 
            this.COL_Organization.HeaderText = "Организация";
            this.COL_Organization.MinimumWidth = 6;
            this.COL_Organization.Name = "COL_Organization";
            this.COL_Organization.ReadOnly = true;
            this.COL_Organization.Width = 125;
            // 
            // COL_Order
            // 
            this.COL_Order.HeaderText = "Договор";
            this.COL_Order.MinimumWidth = 6;
            this.COL_Order.Name = "COL_Order";
            this.COL_Order.ReadOnly = true;
            this.COL_Order.Width = 125;
            // 
            // COL_StartDate
            // 
            this.COL_StartDate.HeaderText = "Начало договора";
            this.COL_StartDate.MinimumWidth = 6;
            this.COL_StartDate.Name = "COL_StartDate";
            this.COL_StartDate.ReadOnly = true;
            this.COL_StartDate.Width = 125;
            // 
            // COL_EndOrder
            // 
            this.COL_EndOrder.HeaderText = "Окончание договора";
            this.COL_EndOrder.MinimumWidth = 6;
            this.COL_EndOrder.Name = "COL_EndOrder";
            this.COL_EndOrder.ReadOnly = true;
            this.COL_EndOrder.Width = 125;
            // 
            // DeclarationPaymentOrdersForHostel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DG_View_PaymentActiveOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationPaymentOrdersForHostel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Направления на оплату по общежитию";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.DeclarationPaymentOrdersForHostel_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_PaymentActiveOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DG_View_PaymentActiveOrders;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COL_Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Tenant;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Faculty;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Organization;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EndOrder;
    }
}