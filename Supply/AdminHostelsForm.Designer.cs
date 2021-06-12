
namespace Supply
{
    partial class AdminHostelsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminHostelsForm));
            this.DG_Hostels = new System.Windows.Forms.DataGridView();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_OpenHostelAddWindow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Hostels)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_Hostels
            // 
            this.DG_Hostels.AllowUserToAddRows = false;
            this.DG_Hostels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_Hostels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Hostels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Name,
            this.COL_Manager,
            this.COL_Address});
            this.DG_Hostels.Location = new System.Drawing.Point(13, 13);
            this.DG_Hostels.Name = "DG_Hostels";
            this.DG_Hostels.Size = new System.Drawing.Size(775, 268);
            this.DG_Hostels.TabIndex = 0;
            this.DG_Hostels.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_Hostels_CellClick);
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
            // COL_Manager
            // 
            this.COL_Manager.HeaderText = "Заведуюзий общежитием";
            this.COL_Manager.Name = "COL_Manager";
            this.COL_Manager.ReadOnly = true;
            // 
            // COL_Address
            // 
            this.COL_Address.HeaderText = "Адрес";
            this.COL_Address.Name = "COL_Address";
            this.COL_Address.ReadOnly = true;
            // 
            // BTN_OpenHostelAddWindow
            // 
            this.BTN_OpenHostelAddWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_OpenHostelAddWindow.Location = new System.Drawing.Point(713, 306);
            this.BTN_OpenHostelAddWindow.Name = "BTN_OpenHostelAddWindow";
            this.BTN_OpenHostelAddWindow.Size = new System.Drawing.Size(75, 23);
            this.BTN_OpenHostelAddWindow.TabIndex = 1;
            this.BTN_OpenHostelAddWindow.Text = "Добавить";
            this.BTN_OpenHostelAddWindow.UseVisualStyleBackColor = true;
            this.BTN_OpenHostelAddWindow.Click += new System.EventHandler(this.BTN_OpenHostelAddWindow_Click);
            // 
            // AdminHostelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 341);
            this.Controls.Add(this.BTN_OpenHostelAddWindow);
            this.Controls.Add(this.DG_Hostels);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminHostelsForm";
            this.Text = "Общежития";
            this.Shown += new System.EventHandler(this.AdminHostelsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Hostels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_Hostels;
        private System.Windows.Forms.Button BTN_OpenHostelAddWindow;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Address;
    }
}