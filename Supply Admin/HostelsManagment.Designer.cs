namespace Supply_Admin
{
    partial class HostelsManagment
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
            this.BTN_Add_Hostels = new System.Windows.Forms.Button();
            this.DG_View_HostelsManage = new System.Windows.Forms.DataGridView();
            this.BTN_Update = new System.Windows.Forms.Button();
            this.DGView_IDHostels = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGView_NameHostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGView_FlatsHostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGView_SupplyHostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_HostelsManage)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Add_Hostels
            // 
            this.BTN_Add_Hostels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Add_Hostels.Location = new System.Drawing.Point(852, 12);
            this.BTN_Add_Hostels.Name = "BTN_Add_Hostels";
            this.BTN_Add_Hostels.Size = new System.Drawing.Size(99, 30);
            this.BTN_Add_Hostels.TabIndex = 0;
            this.BTN_Add_Hostels.Text = "Добавить ";
            this.BTN_Add_Hostels.UseVisualStyleBackColor = true;
            this.BTN_Add_Hostels.Click += new System.EventHandler(this.BTN_Add_Hostels_Click);
            // 
            // DG_View_HostelsManage
            // 
            this.DG_View_HostelsManage.AllowUserToAddRows = false;
            this.DG_View_HostelsManage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_HostelsManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_HostelsManage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGView_IDHostels,
            this.DGView_NameHostel,
            this.DGView_FlatsHostel,
            this.DGView_SupplyHostel,
            this.COL_Address});
            this.DG_View_HostelsManage.Location = new System.Drawing.Point(13, 48);
            this.DG_View_HostelsManage.Name = "DG_View_HostelsManage";
            this.DG_View_HostelsManage.ReadOnly = true;
            this.DG_View_HostelsManage.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.DG_View_HostelsManage.RowTemplate.Height = 24;
            this.DG_View_HostelsManage.Size = new System.Drawing.Size(938, 474);
            this.DG_View_HostelsManage.TabIndex = 1;
            // 
            // BTN_Update
            // 
            this.BTN_Update.Location = new System.Drawing.Point(13, 12);
            this.BTN_Update.Name = "BTN_Update";
            this.BTN_Update.Size = new System.Drawing.Size(183, 30);
            this.BTN_Update.TabIndex = 2;
            this.BTN_Update.Text = "Обновить таблицу";
            this.BTN_Update.UseVisualStyleBackColor = true;
            this.BTN_Update.Click += new System.EventHandler(this.BTN_Update_Click);
            // 
            // DGView_IDHostels
            // 
            this.DGView_IDHostels.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DGView_IDHostels.Frozen = true;
            this.DGView_IDHostels.HeaderText = "Действия";
            this.DGView_IDHostels.MinimumWidth = 6;
            this.DGView_IDHostels.Name = "DGView_IDHostels";
            this.DGView_IDHostels.ReadOnly = true;
            this.DGView_IDHostels.Width = 78;
            // 
            // DGView_NameHostel
            // 
            this.DGView_NameHostel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DGView_NameHostel.Frozen = true;
            this.DGView_NameHostel.HeaderText = "Название";
            this.DGView_NameHostel.MinimumWidth = 6;
            this.DGView_NameHostel.Name = "DGView_NameHostel";
            this.DGView_NameHostel.ReadOnly = true;
            this.DGView_NameHostel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGView_NameHostel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DGView_NameHostel.Width = 78;
            // 
            // DGView_FlatsHostel
            // 
            this.DGView_FlatsHostel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DGView_FlatsHostel.Frozen = true;
            this.DGView_FlatsHostel.HeaderText = "Кол-во этажей";
            this.DGView_FlatsHostel.MinimumWidth = 6;
            this.DGView_FlatsHostel.Name = "DGView_FlatsHostel";
            this.DGView_FlatsHostel.ReadOnly = true;
            this.DGView_FlatsHostel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGView_FlatsHostel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DGView_FlatsHostel.Width = 99;
            // 
            // DGView_SupplyHostel
            // 
            this.DGView_SupplyHostel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DGView_SupplyHostel.Frozen = true;
            this.DGView_SupplyHostel.HeaderText = "Зав.общежития";
            this.DGView_SupplyHostel.MinimumWidth = 400;
            this.DGView_SupplyHostel.Name = "DGView_SupplyHostel";
            this.DGView_SupplyHostel.ReadOnly = true;
            this.DGView_SupplyHostel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DGView_SupplyHostel.Width = 400;
            // 
            // COL_Address
            // 
            this.COL_Address.Frozen = true;
            this.COL_Address.HeaderText = "Адрес";
            this.COL_Address.MinimumWidth = 6;
            this.COL_Address.Name = "COL_Address";
            this.COL_Address.ReadOnly = true;
            this.COL_Address.Width = 400;
            // 
            // HostelsManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 571);
            this.Controls.Add(this.BTN_Update);
            this.Controls.Add(this.DG_View_HostelsManage);
            this.Controls.Add(this.BTN_Add_Hostels);
            this.Name = "HostelsManagment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление общежитиями";
            this.Shown += new System.EventHandler(this.HostelsManagment_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_HostelsManage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_Add_Hostels;
        private System.Windows.Forms.DataGridView DG_View_HostelsManage;
        private System.Windows.Forms.Button BTN_Update;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGView_IDHostels;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGView_NameHostel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGView_FlatsHostel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGView_SupplyHostel;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Address;
    }
}