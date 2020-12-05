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
            this.BTN_Create = new System.Windows.Forms.Button();
            this.LB_Name = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.LB_Hostel = new System.Windows.Forms.Label();
            this.CB_Hostel = new System.Windows.Forms.ComboBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.DGV_Supplies = new System.Windows.Forms.DataGridView();
            this.COL_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Hostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Supplies)).BeginInit();
            this.SuspendLayout();
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
            // LB_Name
            // 
            this.LB_Name.AutoSize = true;
            this.LB_Name.Location = new System.Drawing.Point(12, 59);
            this.LB_Name.Name = "LB_Name";
            this.LB_Name.Size = new System.Drawing.Size(42, 17);
            this.LB_Name.TabIndex = 1;
            this.LB_Name.Text = "ФИО";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(61, 59);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(278, 22);
            this.TB_Name.TabIndex = 2;
            // 
            // LB_Hostel
            // 
            this.LB_Hostel.AutoSize = true;
            this.LB_Hostel.Location = new System.Drawing.Point(353, 60);
            this.LB_Hostel.Name = "LB_Hostel";
            this.LB_Hostel.Size = new System.Drawing.Size(86, 17);
            this.LB_Hostel.TabIndex = 3;
            this.LB_Hostel.Text = "Общежитие";
            // 
            // CB_Hostel
            // 
            this.CB_Hostel.FormattingEnabled = true;
            this.CB_Hostel.Location = new System.Drawing.Point(452, 57);
            this.CB_Hostel.Name = "CB_Hostel";
            this.CB_Hostel.Size = new System.Drawing.Size(148, 24);
            this.CB_Hostel.TabIndex = 4;
            this.CB_Hostel.SelectedIndexChanged += new System.EventHandler(this.CB_Hostel_SelectedIndexChanged);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(622, 56);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(118, 25);
            this.BTN_Save.TabIndex = 5;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // DGV_Supplies
            // 
            this.DGV_Supplies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Supplies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_Id,
            this.COL_Name,
            this.COL_Hostel});
            this.DGV_Supplies.Location = new System.Drawing.Point(13, 99);
            this.DGV_Supplies.Name = "DGV_Supplies";
            this.DGV_Supplies.RowHeadersWidth = 51;
            this.DGV_Supplies.RowTemplate.Height = 24;
            this.DGV_Supplies.Size = new System.Drawing.Size(727, 317);
            this.DGV_Supplies.TabIndex = 6;
            // 
            // COL_Id
            // 
            this.COL_Id.HeaderText = "Номер";
            this.COL_Id.MinimumWidth = 6;
            this.COL_Id.Name = "COL_Id";
            this.COL_Id.Width = 125;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "ФИО";
            this.COL_Name.MinimumWidth = 6;
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.Width = 125;
            // 
            // COL_Hostel
            // 
            this.COL_Hostel.HeaderText = "Общежитие";
            this.COL_Hostel.MinimumWidth = 6;
            this.COL_Hostel.Name = "COL_Hostel";
            this.COL_Hostel.Width = 125;
            // 
            // SupplyManagers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 428);
            this.Controls.Add(this.DGV_Supplies);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.CB_Hostel);
            this.Controls.Add(this.LB_Hostel);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.LB_Name);
            this.Controls.Add(this.BTN_Create);
            this.Name = "SupplyManagers";
            this.Text = "Заведующие общежитиями";
            this.Load += new System.EventHandler(this.SupplyManagers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Supplies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Create;
        private System.Windows.Forms.Label LB_Name;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.Label LB_Hostel;
        private System.Windows.Forms.ComboBox CB_Hostel;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.DataGridView DGV_Supplies;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Hostel;
    }
}