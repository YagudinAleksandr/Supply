namespace Supply_Admin
{
    partial class RoomsManager
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
            this.BTN_Add = new System.Windows.Forms.Button();
            this.DGV_Rooms = new System.Windows.Forms.DataGridView();
            this.COL_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_HostelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Enterance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_FlatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Places = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Rooms)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(13, 13);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(123, 38);
            this.BTN_Add.TabIndex = 0;
            this.BTN_Add.Text = "Добавить";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // DGV_Rooms
            // 
            this.DGV_Rooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Rooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Rooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_Id,
            this.COL_Name,
            this.COL_Type,
            this.COL_HostelId,
            this.COL_Enterance,
            this.COL_FlatId,
            this.COL_Places});
            this.DGV_Rooms.Location = new System.Drawing.Point(13, 68);
            this.DGV_Rooms.Name = "DGV_Rooms";
            this.DGV_Rooms.RowHeadersWidth = 51;
            this.DGV_Rooms.RowTemplate.Height = 24;
            this.DGV_Rooms.Size = new System.Drawing.Size(1003, 459);
            this.DGV_Rooms.TabIndex = 1;
            // 
            // COL_Id
            // 
            this.COL_Id.HeaderText = "ID";
            this.COL_Id.MinimumWidth = 6;
            this.COL_Id.Name = "COL_Id";
            this.COL_Id.ReadOnly = true;
            this.COL_Id.Width = 125;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Номер/Название";
            this.COL_Name.MinimumWidth = 6;
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.ReadOnly = true;
            this.COL_Name.Width = 125;
            // 
            // COL_Type
            // 
            this.COL_Type.HeaderText = "Тип помещения";
            this.COL_Type.MinimumWidth = 6;
            this.COL_Type.Name = "COL_Type";
            this.COL_Type.ReadOnly = true;
            this.COL_Type.Width = 125;
            // 
            // COL_HostelId
            // 
            this.COL_HostelId.HeaderText = "Общежитие";
            this.COL_HostelId.MinimumWidth = 6;
            this.COL_HostelId.Name = "COL_HostelId";
            this.COL_HostelId.ReadOnly = true;
            this.COL_HostelId.Width = 125;
            // 
            // COL_Enterance
            // 
            this.COL_Enterance.HeaderText = "Подъезд";
            this.COL_Enterance.MinimumWidth = 6;
            this.COL_Enterance.Name = "COL_Enterance";
            this.COL_Enterance.Width = 125;
            // 
            // COL_FlatId
            // 
            this.COL_FlatId.HeaderText = "Этаж";
            this.COL_FlatId.MinimumWidth = 6;
            this.COL_FlatId.Name = "COL_FlatId";
            this.COL_FlatId.ReadOnly = true;
            this.COL_FlatId.Width = 125;
            // 
            // COL_Places
            // 
            this.COL_Places.HeaderText = "Количество мест";
            this.COL_Places.MinimumWidth = 6;
            this.COL_Places.Name = "COL_Places";
            this.COL_Places.ReadOnly = true;
            this.COL_Places.Width = 125;
            // 
            // RoomsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 539);
            this.Controls.Add(this.DGV_Rooms);
            this.Controls.Add(this.BTN_Add);
            this.Name = "RoomsManager";
            this.Text = "Комнаты";
            this.Shown += new System.EventHandler(this.RoomsManager_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Rooms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.DataGridView DGV_Rooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_HostelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Enterance;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_FlatId;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Places;
    }
}