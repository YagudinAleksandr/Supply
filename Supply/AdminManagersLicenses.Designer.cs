
namespace Supply
{
    partial class AdminManagersLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminManagersLicenses));
            this.label1 = new System.Windows.Forms.Label();
            this.LB_Manager = new System.Windows.Forms.Label();
            this.DG_Licenses = new System.Windows.Forms.DataGridView();
            this.BTN_OpenAddWindow = new System.Windows.Forms.Button();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Licenses)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Лицензии менеджера: ";
            // 
            // LB_Manager
            // 
            this.LB_Manager.AutoSize = true;
            this.LB_Manager.Location = new System.Drawing.Point(143, 13);
            this.LB_Manager.Name = "LB_Manager";
            this.LB_Manager.Size = new System.Drawing.Size(35, 13);
            this.LB_Manager.TabIndex = 1;
            this.LB_Manager.Text = "label2";
            // 
            // DG_Licenses
            // 
            this.DG_Licenses.AllowUserToAddRows = false;
            this.DG_Licenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Licenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Type,
            this.COL_Name,
            this.COL_StartDate,
            this.COL_EndDate});
            this.DG_Licenses.Location = new System.Drawing.Point(16, 42);
            this.DG_Licenses.Name = "DG_Licenses";
            this.DG_Licenses.Size = new System.Drawing.Size(772, 150);
            this.DG_Licenses.TabIndex = 2;
            this.DG_Licenses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_Licenses_CellClick);
            // 
            // BTN_OpenAddWindow
            // 
            this.BTN_OpenAddWindow.Location = new System.Drawing.Point(702, 214);
            this.BTN_OpenAddWindow.Name = "BTN_OpenAddWindow";
            this.BTN_OpenAddWindow.Size = new System.Drawing.Size(86, 23);
            this.BTN_OpenAddWindow.TabIndex = 3;
            this.BTN_OpenAddWindow.Text = "Добавить";
            this.BTN_OpenAddWindow.UseVisualStyleBackColor = true;
            this.BTN_OpenAddWindow.Click += new System.EventHandler(this.BTN_OpenAddWindow_Click);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            // 
            // COL_Type
            // 
            this.COL_Type.HeaderText = "Тип";
            this.COL_Type.Name = "COL_Type";
            this.COL_Type.ReadOnly = true;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Название";
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.ReadOnly = true;
            // 
            // COL_StartDate
            // 
            this.COL_StartDate.HeaderText = "Начало действия";
            this.COL_StartDate.Name = "COL_StartDate";
            this.COL_StartDate.ReadOnly = true;
            // 
            // COL_EndDate
            // 
            this.COL_EndDate.HeaderText = "Окончание действия";
            this.COL_EndDate.Name = "COL_EndDate";
            this.COL_EndDate.ReadOnly = true;
            // 
            // AdminManagersLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 249);
            this.Controls.Add(this.BTN_OpenAddWindow);
            this.Controls.Add(this.DG_Licenses);
            this.Controls.Add(this.LB_Manager);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminManagersLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лицензии";
            this.Shown += new System.EventHandler(this.AdminManagersLicenses_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Licenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_Manager;
        private System.Windows.Forms.DataGridView DG_Licenses;
        private System.Windows.Forms.Button BTN_OpenAddWindow;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EndDate;
    }
}