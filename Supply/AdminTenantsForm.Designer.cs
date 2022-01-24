
namespace Supply
{
    partial class AdminTenantsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminTenantsForm));
            this.DG_TenantsView = new System.Windows.Forms.DataGridView();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Surename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_DocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Series = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_DocNumb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EducationForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Faculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Institute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_CreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_UpdatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_TenantsView)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_TenantsView
            // 
            this.DG_TenantsView.AllowUserToAddRows = false;
            this.DG_TenantsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_TenantsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_TenantsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Surename,
            this.COL_Name,
            this.COL_Patronymic,
            this.COL_DocType,
            this.COL_Series,
            this.COL_DocNumb,
            this.COL_Order,
            this.COL_EducationForm,
            this.COL_Faculty,
            this.COL_Institute,
            this.COL_CreatedAt,
            this.COL_UpdatedAt,
            this.COL_Status});
            this.DG_TenantsView.Location = new System.Drawing.Point(13, 13);
            this.DG_TenantsView.Name = "DG_TenantsView";
            this.DG_TenantsView.RowHeadersWidth = 51;
            this.DG_TenantsView.Size = new System.Drawing.Size(775, 425);
            this.DG_TenantsView.TabIndex = 0;
            this.DG_TenantsView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_TenantsView_CellClick);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.MinimumWidth = 6;
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            this.COL_ID.Width = 125;
            // 
            // COL_Surename
            // 
            this.COL_Surename.HeaderText = "Фамилия";
            this.COL_Surename.MinimumWidth = 6;
            this.COL_Surename.Name = "COL_Surename";
            this.COL_Surename.ReadOnly = true;
            this.COL_Surename.Width = 125;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Имя";
            this.COL_Name.MinimumWidth = 6;
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.ReadOnly = true;
            this.COL_Name.Width = 125;
            // 
            // COL_Patronymic
            // 
            this.COL_Patronymic.HeaderText = "Отчество";
            this.COL_Patronymic.MinimumWidth = 6;
            this.COL_Patronymic.Name = "COL_Patronymic";
            this.COL_Patronymic.ReadOnly = true;
            this.COL_Patronymic.Width = 125;
            // 
            // COL_DocType
            // 
            this.COL_DocType.HeaderText = "Документ";
            this.COL_DocType.MinimumWidth = 6;
            this.COL_DocType.Name = "COL_DocType";
            this.COL_DocType.Width = 125;
            // 
            // COL_Series
            // 
            this.COL_Series.HeaderText = "Серия";
            this.COL_Series.MinimumWidth = 6;
            this.COL_Series.Name = "COL_Series";
            this.COL_Series.Width = 125;
            // 
            // COL_DocNumb
            // 
            this.COL_DocNumb.HeaderText = "Номер";
            this.COL_DocNumb.MinimumWidth = 6;
            this.COL_DocNumb.Name = "COL_DocNumb";
            this.COL_DocNumb.Width = 125;
            // 
            // COL_Order
            // 
            this.COL_Order.HeaderText = "Договор";
            this.COL_Order.MinimumWidth = 6;
            this.COL_Order.Name = "COL_Order";
            this.COL_Order.ReadOnly = true;
            this.COL_Order.Width = 125;
            // 
            // COL_EducationForm
            // 
            this.COL_EducationForm.HeaderText = "Форма обучения";
            this.COL_EducationForm.Name = "COL_EducationForm";
            this.COL_EducationForm.ReadOnly = true;
            // 
            // COL_Faculty
            // 
            this.COL_Faculty.HeaderText = "Факультет";
            this.COL_Faculty.MinimumWidth = 6;
            this.COL_Faculty.Name = "COL_Faculty";
            this.COL_Faculty.ReadOnly = true;
            this.COL_Faculty.Width = 125;
            // 
            // COL_Institute
            // 
            this.COL_Institute.HeaderText = "Учреждение";
            this.COL_Institute.MinimumWidth = 6;
            this.COL_Institute.Name = "COL_Institute";
            this.COL_Institute.ReadOnly = true;
            this.COL_Institute.Width = 125;
            // 
            // COL_CreatedAt
            // 
            this.COL_CreatedAt.HeaderText = "Создан";
            this.COL_CreatedAt.MinimumWidth = 6;
            this.COL_CreatedAt.Name = "COL_CreatedAt";
            this.COL_CreatedAt.ReadOnly = true;
            this.COL_CreatedAt.Width = 125;
            // 
            // COL_UpdatedAt
            // 
            this.COL_UpdatedAt.HeaderText = "Изменен";
            this.COL_UpdatedAt.MinimumWidth = 6;
            this.COL_UpdatedAt.Name = "COL_UpdatedAt";
            this.COL_UpdatedAt.ReadOnly = true;
            this.COL_UpdatedAt.Width = 125;
            // 
            // COL_Status
            // 
            this.COL_Status.HeaderText = "Статус";
            this.COL_Status.MinimumWidth = 6;
            this.COL_Status.Name = "COL_Status";
            this.COL_Status.ReadOnly = true;
            this.COL_Status.Width = 125;
            // 
            // AdminTenantsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DG_TenantsView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminTenantsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Жильцы";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminTenantsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_TenantsView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_TenantsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Surename;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_DocType;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Series;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_DocNumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EducationForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Faculty;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Institute;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_CreatedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_UpdatedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Status;
    }
}