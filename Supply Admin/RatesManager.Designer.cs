namespace Supply_Admin
{
    partial class RatesManager
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
            this.DGV_Rates = new System.Windows.Forms.DataGridView();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.COL_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Rent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Hostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Taks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_TaksPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Rates)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Rates
            // 
            this.DGV_Rates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Rates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Rates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_Id,
            this.COL_Description,
            this.COL_Name,
            this.COL_Price,
            this.COL_Rent,
            this.COL_Hostel,
            this.COL_Taks,
            this.COL_TaksPercent});
            this.DGV_Rates.Location = new System.Drawing.Point(13, 70);
            this.DGV_Rates.Name = "DGV_Rates";
            this.DGV_Rates.RowHeadersWidth = 51;
            this.DGV_Rates.RowTemplate.Height = 24;
            this.DGV_Rates.Size = new System.Drawing.Size(1050, 504);
            this.DGV_Rates.TabIndex = 0;
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(13, 13);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(131, 34);
            this.BTN_Add.TabIndex = 1;
            this.BTN_Add.Text = "Добавить";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // COL_Id
            // 
            this.COL_Id.HeaderText = "ID";
            this.COL_Id.MinimumWidth = 6;
            this.COL_Id.Name = "COL_Id";
            this.COL_Id.ReadOnly = true;
            this.COL_Id.Width = 125;
            // 
            // COL_Description
            // 
            this.COL_Description.HeaderText = "Описание";
            this.COL_Description.MinimumWidth = 6;
            this.COL_Description.Name = "COL_Description";
            this.COL_Description.ReadOnly = true;
            this.COL_Description.Width = 125;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Название";
            this.COL_Name.MinimumWidth = 6;
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.ReadOnly = true;
            this.COL_Name.Width = 125;
            // 
            // COL_Price
            // 
            this.COL_Price.HeaderText = "Цена";
            this.COL_Price.MinimumWidth = 6;
            this.COL_Price.Name = "COL_Price";
            this.COL_Price.ReadOnly = true;
            this.COL_Price.Width = 125;
            // 
            // COL_Rent
            // 
            this.COL_Rent.HeaderText = "На период";
            this.COL_Rent.MinimumWidth = 6;
            this.COL_Rent.Name = "COL_Rent";
            this.COL_Rent.ReadOnly = true;
            this.COL_Rent.Width = 125;
            // 
            // COL_Hostel
            // 
            this.COL_Hostel.HeaderText = "Общежитие";
            this.COL_Hostel.MinimumWidth = 6;
            this.COL_Hostel.Name = "COL_Hostel";
            this.COL_Hostel.ReadOnly = true;
            this.COL_Hostel.Width = 125;
            // 
            // COL_Taks
            // 
            this.COL_Taks.HeaderText = "НДС";
            this.COL_Taks.MinimumWidth = 6;
            this.COL_Taks.Name = "COL_Taks";
            this.COL_Taks.ReadOnly = true;
            this.COL_Taks.Width = 125;
            // 
            // COL_TaksPercent
            // 
            this.COL_TaksPercent.HeaderText = "НДС %";
            this.COL_TaksPercent.MinimumWidth = 6;
            this.COL_TaksPercent.Name = "COL_TaksPercent";
            this.COL_TaksPercent.ReadOnly = true;
            this.COL_TaksPercent.Width = 125;
            // 
            // RatesManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 586);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.DGV_Rates);
            this.Name = "RatesManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тарифы для проживания";
            this.Shown += new System.EventHandler(this.RatesManager_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Rates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Rates;
        private System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Rent;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Hostel;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Taks;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_TaksPercent;
    }
}