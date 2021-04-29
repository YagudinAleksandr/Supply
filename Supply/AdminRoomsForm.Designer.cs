
namespace Supply
{
    partial class AdminRoomsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminRoomsForm));
            this.DG_Rooms = new System.Windows.Forms.DataGridView();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Flat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Enterance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Places = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_OpenRoomAddForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Rooms)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_Rooms
            // 
            this.DG_Rooms.AllowUserToAddRows = false;
            this.DG_Rooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Rooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Name,
            this.COL_Flat,
            this.COL_Enterance,
            this.COL_Places,
            this.COL_Type});
            this.DG_Rooms.Location = new System.Drawing.Point(13, 13);
            this.DG_Rooms.Name = "DG_Rooms";
            this.DG_Rooms.Size = new System.Drawing.Size(775, 386);
            this.DG_Rooms.TabIndex = 0;
            this.DG_Rooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_Rooms_CellClick);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Название";
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.ReadOnly = true;
            // 
            // COL_Flat
            // 
            this.COL_Flat.HeaderText = "Этаж";
            this.COL_Flat.Name = "COL_Flat";
            // 
            // COL_Enterance
            // 
            this.COL_Enterance.HeaderText = "Подъезд";
            this.COL_Enterance.Name = "COL_Enterance";
            // 
            // COL_Places
            // 
            this.COL_Places.HeaderText = "Кол-во мест";
            this.COL_Places.Name = "COL_Places";
            this.COL_Places.ReadOnly = true;
            // 
            // COL_Type
            // 
            this.COL_Type.HeaderText = "Тип комнаты";
            this.COL_Type.Name = "COL_Type";
            this.COL_Type.ReadOnly = true;
            // 
            // BTN_OpenRoomAddForm
            // 
            this.BTN_OpenRoomAddForm.Location = new System.Drawing.Point(713, 415);
            this.BTN_OpenRoomAddForm.Name = "BTN_OpenRoomAddForm";
            this.BTN_OpenRoomAddForm.Size = new System.Drawing.Size(75, 23);
            this.BTN_OpenRoomAddForm.TabIndex = 1;
            this.BTN_OpenRoomAddForm.Text = "Добавить";
            this.BTN_OpenRoomAddForm.UseVisualStyleBackColor = true;
            this.BTN_OpenRoomAddForm.Click += new System.EventHandler(this.BTN_OpenRoomAddForm_Click);
            // 
            // AdminRoomsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_OpenRoomAddForm);
            this.Controls.Add(this.DG_Rooms);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminRoomsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Комнаты";
            this.Shown += new System.EventHandler(this.AdminRoomsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Rooms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_Rooms;
        private System.Windows.Forms.Button BTN_OpenRoomAddForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Flat;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Enterance;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Places;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Type;
    }
}