
namespace Supply
{
    partial class AdminAddressesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminAddressesForm));
            this.DG_Addresses = new System.Windows.Forms.DataGridView();
            this.BNT_OpenAddForm = new System.Windows.Forms.Button();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_ZipCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_House = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Housing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Addresses)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_Addresses
            // 
            this.DG_Addresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_Addresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Addresses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_ZipCode,
            this.COL_Country,
            this.COL_Region,
            this.COL_Street,
            this.COL_City,
            this.COL_House,
            this.COL_Housing});
            this.DG_Addresses.Location = new System.Drawing.Point(13, 13);
            this.DG_Addresses.Name = "DG_Addresses";
            this.DG_Addresses.Size = new System.Drawing.Size(775, 369);
            this.DG_Addresses.TabIndex = 0;
            // 
            // BNT_OpenAddForm
            // 
            this.BNT_OpenAddForm.Location = new System.Drawing.Point(635, 393);
            this.BNT_OpenAddForm.Name = "BNT_OpenAddForm";
            this.BNT_OpenAddForm.Size = new System.Drawing.Size(153, 41);
            this.BNT_OpenAddForm.TabIndex = 1;
            this.BNT_OpenAddForm.Text = "Добавить";
            this.BNT_OpenAddForm.UseVisualStyleBackColor = true;
            this.BNT_OpenAddForm.Click += new System.EventHandler(this.BNT_OpenAddForm_Click);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "№";
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            // 
            // COL_ZipCode
            // 
            this.COL_ZipCode.HeaderText = "Код страны";
            this.COL_ZipCode.Name = "COL_ZipCode";
            this.COL_ZipCode.ReadOnly = true;
            // 
            // COL_Country
            // 
            this.COL_Country.HeaderText = "Страна";
            this.COL_Country.Name = "COL_Country";
            this.COL_Country.ReadOnly = true;
            // 
            // COL_Region
            // 
            this.COL_Region.HeaderText = "Регион/Область";
            this.COL_Region.Name = "COL_Region";
            this.COL_Region.ReadOnly = true;
            // 
            // COL_Street
            // 
            this.COL_Street.HeaderText = "Улица";
            this.COL_Street.Name = "COL_Street";
            this.COL_Street.ReadOnly = true;
            // 
            // COL_City
            // 
            this.COL_City.HeaderText = "Город/Населенный пункт";
            this.COL_City.Name = "COL_City";
            this.COL_City.ReadOnly = true;
            // 
            // COL_House
            // 
            this.COL_House.HeaderText = "Постройка";
            this.COL_House.Name = "COL_House";
            this.COL_House.ReadOnly = true;
            // 
            // COL_Housing
            // 
            this.COL_Housing.HeaderText = "Корпус";
            this.COL_Housing.Name = "COL_Housing";
            this.COL_Housing.ReadOnly = true;
            // 
            // AdminAddressesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 446);
            this.Controls.Add(this.BNT_OpenAddForm);
            this.Controls.Add(this.DG_Addresses);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminAddressesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Адреса";
            this.Shown += new System.EventHandler(this.AdminAddressesForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Addresses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_Addresses;
        private System.Windows.Forms.Button BNT_OpenAddForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ZipCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Region;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Street;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_City;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_House;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Housing;
    }
}