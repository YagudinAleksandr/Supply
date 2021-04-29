
namespace Supply
{
    partial class AdminPaymentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPaymentsForm));
            this.DG_Payments = new System.Windows.Forms.DataGridView();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Hostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_TenantType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_UpdatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Payments)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_Payments
            // 
            this.DG_Payments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Payments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Name,
            this.COL_Hostel,
            this.COL_RoomType,
            this.COL_TenantType,
            this.COL_UpdatedAt,
            this.COL_Status,
            this.COL_Manager});
            this.DG_Payments.Location = new System.Drawing.Point(13, 13);
            this.DG_Payments.Name = "DG_Payments";
            this.DG_Payments.Size = new System.Drawing.Size(775, 382);
            this.DG_Payments.TabIndex = 0;
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(713, 415);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(75, 23);
            this.BTN_Add.TabIndex = 1;
            this.BTN_Add.Text = "Добавить";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
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
            this.COL_Name.Width = 250;
            // 
            // COL_Hostel
            // 
            this.COL_Hostel.HeaderText = "Общежитие";
            this.COL_Hostel.Name = "COL_Hostel";
            this.COL_Hostel.ReadOnly = true;
            // 
            // COL_RoomType
            // 
            this.COL_RoomType.HeaderText = "Тип комнаты";
            this.COL_RoomType.Name = "COL_RoomType";
            this.COL_RoomType.ReadOnly = true;
            // 
            // COL_TenantType
            // 
            this.COL_TenantType.HeaderText = "Тип проживающего";
            this.COL_TenantType.Name = "COL_TenantType";
            this.COL_TenantType.ReadOnly = true;
            // 
            // COL_UpdatedAt
            // 
            this.COL_UpdatedAt.HeaderText = "Изменен";
            this.COL_UpdatedAt.Name = "COL_UpdatedAt";
            this.COL_UpdatedAt.ReadOnly = true;
            // 
            // COL_Status
            // 
            this.COL_Status.HeaderText = "Статус";
            this.COL_Status.Name = "COL_Status";
            this.COL_Status.ReadOnly = true;
            // 
            // COL_Manager
            // 
            this.COL_Manager.HeaderText = "Кем изменен";
            this.COL_Manager.Name = "COL_Manager";
            this.COL_Manager.ReadOnly = true;
            // 
            // AdminPaymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.DG_Payments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminPaymentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тарифные планы";
            this.Load += new System.EventHandler(this.AdminPaymentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Payments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_Payments;
        private System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Hostel;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_TenantType;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_UpdatedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Manager;
    }
}