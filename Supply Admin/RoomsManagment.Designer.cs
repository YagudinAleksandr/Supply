namespace Supply_Admin
{
    partial class RoomsManagment
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
            this.BTN_AddRooms = new System.Windows.Forms.Button();
            this.DG_View_Rooms = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_HostelNumber = new System.Windows.Forms.ComboBox();
            this.TL_WaitingLoad = new System.Windows.Forms.Label();
            this.DGV_RoomNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_Places = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_HostelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Rooms)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_AddRooms
            // 
            this.BTN_AddRooms.Location = new System.Drawing.Point(197, 12);
            this.BTN_AddRooms.Name = "BTN_AddRooms";
            this.BTN_AddRooms.Size = new System.Drawing.Size(100, 31);
            this.BTN_AddRooms.TabIndex = 0;
            this.BTN_AddRooms.Text = "Добавить";
            this.BTN_AddRooms.UseVisualStyleBackColor = true;
            this.BTN_AddRooms.Click += new System.EventHandler(this.BTN_AddRooms_Click);
            // 
            // DG_View_Rooms
            // 
            this.DG_View_Rooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_Rooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_Rooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGV_RoomNum,
            this.DGV_RoomType,
            this.DGV_Places,
            this.DGV_HostelName});
            this.DG_View_Rooms.Location = new System.Drawing.Point(13, 99);
            this.DG_View_Rooms.Name = "DG_View_Rooms";
            this.DG_View_Rooms.RowHeadersWidth = 51;
            this.DG_View_Rooms.RowTemplate.Height = 24;
            this.DG_View_Rooms.Size = new System.Drawing.Size(775, 386);
            this.DG_View_Rooms.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Общежитие №";
            // 
            // CB_HostelNumber
            // 
            this.CB_HostelNumber.FormattingEnabled = true;
            this.CB_HostelNumber.Location = new System.Drawing.Point(122, 16);
            this.CB_HostelNumber.Name = "CB_HostelNumber";
            this.CB_HostelNumber.Size = new System.Drawing.Size(59, 24);
            this.CB_HostelNumber.TabIndex = 3;
            this.CB_HostelNumber.SelectedIndexChanged += new System.EventHandler(this.CB_HostelNumber_SelectedIndexChanged);
            // 
            // TL_WaitingLoad
            // 
            this.TL_WaitingLoad.AutoSize = true;
            this.TL_WaitingLoad.Location = new System.Drawing.Point(15, 61);
            this.TL_WaitingLoad.Name = "TL_WaitingLoad";
            this.TL_WaitingLoad.Size = new System.Drawing.Size(229, 17);
            this.TL_WaitingLoad.TabIndex = 4;
            this.TL_WaitingLoad.Text = "Данные добавляются! Ожидайте!";
            // 
            // DGV_RoomNum
            // 
            this.DGV_RoomNum.HeaderText = "Номер комнаты";
            this.DGV_RoomNum.MinimumWidth = 6;
            this.DGV_RoomNum.Name = "DGV_RoomNum";
            this.DGV_RoomNum.Width = 125;
            // 
            // DGV_RoomType
            // 
            this.DGV_RoomType.HeaderText = "Тип комнаты";
            this.DGV_RoomType.MinimumWidth = 6;
            this.DGV_RoomType.Name = "DGV_RoomType";
            this.DGV_RoomType.Width = 125;
            // 
            // DGV_Places
            // 
            this.DGV_Places.HeaderText = "Количество мест";
            this.DGV_Places.MinimumWidth = 6;
            this.DGV_Places.Name = "DGV_Places";
            this.DGV_Places.Width = 125;
            // 
            // DGV_HostelName
            // 
            this.DGV_HostelName.HeaderText = "Общежитие №";
            this.DGV_HostelName.MinimumWidth = 6;
            this.DGV_HostelName.Name = "DGV_HostelName";
            this.DGV_HostelName.Width = 125;
            // 
            // RoomsManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.TL_WaitingLoad);
            this.Controls.Add(this.CB_HostelNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DG_View_Rooms);
            this.Controls.Add(this.BTN_AddRooms);
            this.Name = "RoomsManagment";
            this.Text = "RoomsManagment";
            this.Shown += new System.EventHandler(this.RoomsManagment_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Rooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_AddRooms;
        private System.Windows.Forms.DataGridView DG_View_Rooms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_HostelNumber;
        private System.Windows.Forms.Label TL_WaitingLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_RoomNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_Places;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_HostelName;
    }
}