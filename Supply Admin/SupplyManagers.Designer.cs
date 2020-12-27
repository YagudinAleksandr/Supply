namespace Supply_Admin
{
    partial class SupplyManagers
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
            this.DGV_Supplies = new System.Windows.Forms.DataGridView();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.COL_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Hostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Surename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Patronimuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Proxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Supplies)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Supplies
            // 
            this.DGV_Supplies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Supplies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_Id,
            this.COL_Hostel,
            this.COL_Surename,
            this.COL_Name,
            this.COL_Patronimuc,
            this.COL_Proxy,
            this.COL_Start});
            this.DGV_Supplies.Location = new System.Drawing.Point(13, 48);
            this.DGV_Supplies.Name = "DGV_Supplies";
            this.DGV_Supplies.RowHeadersWidth = 51;
            this.DGV_Supplies.RowTemplate.Height = 24;
            this.DGV_Supplies.Size = new System.Drawing.Size(966, 368);
            this.DGV_Supplies.TabIndex = 6;
            // 
            // BTN_Create
            // 
            this.BTN_Create.Location = new System.Drawing.Point(13, 13);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(89, 29);
            this.BTN_Create.TabIndex = 0;
            this.BTN_Create.Text = "Добавить";
            this.BTN_Create.UseVisualStyleBackColor = true;
            this.BTN_Create.Click += new System.EventHandler(this.BTN_Create_Click);
            // 
            // COL_Id
            // 
            this.COL_Id.HeaderText = "Номер";
            this.COL_Id.MinimumWidth = 6;
            this.COL_Id.Name = "COL_Id";
            this.COL_Id.Width = 125;
            // 
            // COL_Hostel
            // 
            this.COL_Hostel.HeaderText = "Общежитие";
            this.COL_Hostel.MinimumWidth = 6;
            this.COL_Hostel.Name = "COL_Hostel";
            this.COL_Hostel.Width = 125;
            // 
            // COL_Surename
            // 
            this.COL_Surename.HeaderText = "Фамилия";
            this.COL_Surename.MinimumWidth = 6;
            this.COL_Surename.Name = "COL_Surename";
            this.COL_Surename.Width = 125;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Имя";
            this.COL_Name.MinimumWidth = 6;
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.Width = 125;
            // 
            // COL_Patronimuc
            // 
            this.COL_Patronimuc.HeaderText = "Отчество";
            this.COL_Patronimuc.MinimumWidth = 6;
            this.COL_Patronimuc.Name = "COL_Patronimuc";
            this.COL_Patronimuc.Width = 125;
            // 
            // COL_Proxy
            // 
            this.COL_Proxy.HeaderText = "Доверенность";
            this.COL_Proxy.MinimumWidth = 6;
            this.COL_Proxy.Name = "COL_Proxy";
            this.COL_Proxy.Width = 125;
            // 
            // COL_Start
            // 
            this.COL_Start.HeaderText = "От";
            this.COL_Start.MinimumWidth = 6;
            this.COL_Start.Name = "COL_Start";
            this.COL_Start.Width = 125;
            // 
            // SupplyManagers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 428);
            this.Controls.Add(this.DGV_Supplies);
            this.Controls.Add(this.BTN_Create);
            this.Name = "SupplyManagers";
            this.Text = "Заведующие общежитиями";
            this.Load += new System.EventHandler(this.SupplyManagers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Supplies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DGV_Supplies;
        private System.Windows.Forms.Button BTN_Create;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Hostel;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Surename;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Patronimuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Proxy;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Start;
    }
}