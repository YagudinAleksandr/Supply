
namespace Supply_Admin
{
    partial class GarageManager
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
            this.DG_ViewGarage = new System.Windows.Forms.DataGridView();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Hostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_ViewGarage)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_ViewGarage
            // 
            this.DG_ViewGarage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_ViewGarage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_Name,
            this.COL_Number,
            this.COL_StartDate,
            this.COL_EndDate,
            this.COL_Room,
            this.COL_Hostel});
            this.DG_ViewGarage.Location = new System.Drawing.Point(16, 12);
            this.DG_ViewGarage.Name = "DG_ViewGarage";
            this.DG_ViewGarage.RowHeadersWidth = 51;
            this.DG_ViewGarage.RowTemplate.Height = 24;
            this.DG_ViewGarage.Size = new System.Drawing.Size(1210, 639);
            this.DG_ViewGarage.TabIndex = 5;
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(1025, 668);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(201, 40);
            this.BTN_Add.TabIndex = 6;
            this.BTN_Add.Text = "Добавить";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Название";
            this.COL_Name.MinimumWidth = 6;
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.ReadOnly = true;
            this.COL_Name.Width = 300;
            // 
            // COL_Number
            // 
            this.COL_Number.HeaderText = "Инвентарный номер";
            this.COL_Number.MinimumWidth = 6;
            this.COL_Number.Name = "COL_Number";
            this.COL_Number.ReadOnly = true;
            this.COL_Number.Width = 125;
            // 
            // COL_StartDate
            // 
            this.COL_StartDate.HeaderText = "Принят на учет";
            this.COL_StartDate.MinimumWidth = 6;
            this.COL_StartDate.Name = "COL_StartDate";
            this.COL_StartDate.ReadOnly = true;
            this.COL_StartDate.Width = 125;
            // 
            // COL_EndDate
            // 
            this.COL_EndDate.HeaderText = "Снят с учета";
            this.COL_EndDate.MinimumWidth = 6;
            this.COL_EndDate.Name = "COL_EndDate";
            this.COL_EndDate.ReadOnly = true;
            this.COL_EndDate.Width = 125;
            // 
            // COL_Room
            // 
            this.COL_Room.HeaderText = "Комната";
            this.COL_Room.MinimumWidth = 6;
            this.COL_Room.Name = "COL_Room";
            this.COL_Room.ReadOnly = true;
            this.COL_Room.Width = 125;
            // 
            // COL_Hostel
            // 
            this.COL_Hostel.HeaderText = "Общежитие";
            this.COL_Hostel.MinimumWidth = 6;
            this.COL_Hostel.Name = "COL_Hostel";
            this.COL_Hostel.ReadOnly = true;
            this.COL_Hostel.Width = 125;
            // 
            // GarageManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 743);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.DG_ViewGarage);
            this.Name = "GarageManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Инвентарные объекты общежитий";
            this.Shown += new System.EventHandler(this.GarageManager_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_ViewGarage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DG_ViewGarage;
        private System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Hostel;
    }
}