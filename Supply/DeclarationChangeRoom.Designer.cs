
namespace Supply
{
    partial class DeclarationChangeRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationChangeRoom));
            this.DG_View_ChangeRooms = new System.Windows.Forms.DataGridView();
            this.BTN_CreateChangeRoomOrders = new System.Windows.Forms.Button();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Tenant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_OldRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_NewRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_ChangeRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_ChangeRooms
            // 
            this.DG_View_ChangeRooms.AllowUserToAddRows = false;
            this.DG_View_ChangeRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_ChangeRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_ChangeRooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Tenant,
            this.COL_Order,
            this.COL_OldRoom,
            this.COL_NewRoom,
            this.COL_StartDate,
            this.COL_Status});
            this.DG_View_ChangeRooms.Location = new System.Drawing.Point(17, 16);
            this.DG_View_ChangeRooms.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DG_View_ChangeRooms.Name = "DG_View_ChangeRooms";
            this.DG_View_ChangeRooms.RowHeadersWidth = 51;
            this.DG_View_ChangeRooms.Size = new System.Drawing.Size(1033, 481);
            this.DG_View_ChangeRooms.TabIndex = 0;
            this.DG_View_ChangeRooms.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG_View_ChangeRooms_CellMouseClick);
            // 
            // BTN_CreateChangeRoomOrders
            // 
            this.BTN_CreateChangeRoomOrders.Location = new System.Drawing.Point(844, 511);
            this.BTN_CreateChangeRoomOrders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_CreateChangeRoomOrders.Name = "BTN_CreateChangeRoomOrders";
            this.BTN_CreateChangeRoomOrders.Size = new System.Drawing.Size(207, 28);
            this.BTN_CreateChangeRoomOrders.TabIndex = 1;
            this.BTN_CreateChangeRoomOrders.Text = "Сформировать документы";
            this.BTN_CreateChangeRoomOrders.UseVisualStyleBackColor = true;
            this.BTN_CreateChangeRoomOrders.Click += new System.EventHandler(this.BTN_CreateChangeRoomOrders_Click);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "#";
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
            this.COL_Tenant.Width = 200;
            // 
            // COL_Order
            // 
            this.COL_Order.HeaderText = "Договор";
            this.COL_Order.MinimumWidth = 6;
            this.COL_Order.Name = "COL_Order";
            this.COL_Order.ReadOnly = true;
            this.COL_Order.Width = 125;
            // 
            // COL_OldRoom
            // 
            this.COL_OldRoom.HeaderText = "Старая комната";
            this.COL_OldRoom.MinimumWidth = 6;
            this.COL_OldRoom.Name = "COL_OldRoom";
            this.COL_OldRoom.ReadOnly = true;
            this.COL_OldRoom.Width = 200;
            // 
            // COL_NewRoom
            // 
            this.COL_NewRoom.HeaderText = "Новая комната";
            this.COL_NewRoom.MinimumWidth = 6;
            this.COL_NewRoom.Name = "COL_NewRoom";
            this.COL_NewRoom.ReadOnly = true;
            this.COL_NewRoom.Width = 200;
            // 
            // COL_StartDate
            // 
            this.COL_StartDate.HeaderText = "Дата переезда";
            this.COL_StartDate.MinimumWidth = 6;
            this.COL_StartDate.Name = "COL_StartDate";
            this.COL_StartDate.ReadOnly = true;
            this.COL_StartDate.Width = 125;
            // 
            // COL_Status
            // 
            this.COL_Status.HeaderText = "Статус";
            this.COL_Status.MinimumWidth = 6;
            this.COL_Status.Name = "COL_Status";
            this.COL_Status.ReadOnly = true;
            this.COL_Status.Width = 125;
            // 
            // DeclarationChangeRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.BTN_CreateChangeRoomOrders);
            this.Controls.Add(this.DG_View_ChangeRooms);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DeclarationChangeRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет по сменам комнат";
            this.Load += new System.EventHandler(this.DeclarationChangeRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_ChangeRooms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_ChangeRooms;
        private System.Windows.Forms.Button BTN_CreateChangeRoomOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Tenant;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_OldRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_NewRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Status;
    }
}