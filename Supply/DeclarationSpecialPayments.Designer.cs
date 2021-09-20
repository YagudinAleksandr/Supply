
namespace Supply
{
    partial class DeclarationSpecialPayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationSpecialPayments));
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DG_View_SpecialPayments = new System.Windows.Forms.DataGridView();
            this.COL_Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Tenant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SpecialPaymentPlaces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_Deactivate = new System.Windows.Forms.Button();
            this.BTN_Delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_SpecialPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(1016, 12);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(121, 24);
            this.CB_Hostels.TabIndex = 0;
            this.CB_Hostels.SelectionChangeCommitted += new System.EventHandler(this.CB_Hostels_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(924, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Общежитие";
            // 
            // DG_View_SpecialPayments
            // 
            this.DG_View_SpecialPayments.AllowUserToAddRows = false;
            this.DG_View_SpecialPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_SpecialPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_SpecialPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_Check,
            this.COL_ID,
            this.COL_Tenant,
            this.COL_Room,
            this.COL_SpecialPaymentPlaces,
            this.COL_StartDate,
            this.COL_EndDate,
            this.COL_Status});
            this.DG_View_SpecialPayments.Location = new System.Drawing.Point(13, 43);
            this.DG_View_SpecialPayments.Name = "DG_View_SpecialPayments";
            this.DG_View_SpecialPayments.RowHeadersWidth = 51;
            this.DG_View_SpecialPayments.RowTemplate.Height = 24;
            this.DG_View_SpecialPayments.Size = new System.Drawing.Size(1124, 351);
            this.DG_View_SpecialPayments.TabIndex = 2;
            // 
            // COL_Check
            // 
            this.COL_Check.HeaderText = "Выбор";
            this.COL_Check.MinimumWidth = 6;
            this.COL_Check.Name = "COL_Check";
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
            this.COL_Tenant.Width = 125;
            // 
            // COL_Room
            // 
            this.COL_Room.HeaderText = "Комната";
            this.COL_Room.MinimumWidth = 6;
            this.COL_Room.Name = "COL_Room";
            this.COL_Room.ReadOnly = true;
            this.COL_Room.Width = 125;
            // 
            // COL_SpecialPaymentPlaces
            // 
            this.COL_SpecialPaymentPlaces.HeaderText = "Кол-во мест";
            this.COL_SpecialPaymentPlaces.MinimumWidth = 6;
            this.COL_SpecialPaymentPlaces.Name = "COL_SpecialPaymentPlaces";
            this.COL_SpecialPaymentPlaces.ReadOnly = true;
            this.COL_SpecialPaymentPlaces.Width = 125;
            // 
            // COL_StartDate
            // 
            this.COL_StartDate.HeaderText = "Начало";
            this.COL_StartDate.MinimumWidth = 6;
            this.COL_StartDate.Name = "COL_StartDate";
            this.COL_StartDate.ReadOnly = true;
            this.COL_StartDate.Width = 125;
            // 
            // COL_EndDate
            // 
            this.COL_EndDate.HeaderText = "Окончание";
            this.COL_EndDate.MinimumWidth = 6;
            this.COL_EndDate.Name = "COL_EndDate";
            this.COL_EndDate.ReadOnly = true;
            this.COL_EndDate.Width = 125;
            // 
            // COL_Status
            // 
            this.COL_Status.HeaderText = "Статус";
            this.COL_Status.MinimumWidth = 6;
            this.COL_Status.Name = "COL_Status";
            this.COL_Status.ReadOnly = true;
            this.COL_Status.Width = 125;
            // 
            // BTN_Deactivate
            // 
            this.BTN_Deactivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Deactivate.Location = new System.Drawing.Point(1036, 411);
            this.BTN_Deactivate.Name = "BTN_Deactivate";
            this.BTN_Deactivate.Size = new System.Drawing.Size(101, 27);
            this.BTN_Deactivate.TabIndex = 3;
            this.BTN_Deactivate.Text = "Отключить";
            this.BTN_Deactivate.UseVisualStyleBackColor = true;
            this.BTN_Deactivate.Click += new System.EventHandler(this.BTN_Deactivate_Click);
            // 
            // BTN_Delete
            // 
            this.BTN_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Delete.Location = new System.Drawing.Point(929, 411);
            this.BTN_Delete.Name = "BTN_Delete";
            this.BTN_Delete.Size = new System.Drawing.Size(101, 27);
            this.BTN_Delete.TabIndex = 4;
            this.BTN_Delete.Text = "Удалить";
            this.BTN_Delete.UseVisualStyleBackColor = true;
            this.BTN_Delete.Click += new System.EventHandler(this.BTN_Delete_Click);
            // 
            // DeclarationSpecialPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 450);
            this.Controls.Add(this.BTN_Delete);
            this.Controls.Add(this.BTN_Deactivate);
            this.Controls.Add(this.DG_View_SpecialPayments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_Hostels);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationSpecialPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Специализированные оплаты";
            this.Shown += new System.EventHandler(this.DeclarationSpecialPayments_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_SpecialPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DG_View_SpecialPayments;
        private System.Windows.Forms.Button BTN_Deactivate;
        private System.Windows.Forms.Button BTN_Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COL_Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Tenant;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_SpecialPaymentPlaces;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Status;
    }
}