
namespace Supply
{
    partial class AdminPaymentsDeclarations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPaymentsDeclarations));
            this.label1 = new System.Windows.Forms.Label();
            this.DG_View_PaymentDeclarations = new System.Windows.Forms.DataGridView();
            this.BTN_SelectAll = new System.Windows.Forms.Button();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_CreateDeclaration = new System.Windows.Forms.Button();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.BTN_Delete = new System.Windows.Forms.Button();
            this.COL_Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Tenant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Organization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Faculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Debt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_CreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_PaymentDeclarations)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(526, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ВНИМАНИЕ! Здесь отображены только не оплаченные платежные поручения";
            // 
            // DG_View_PaymentDeclarations
            // 
            this.DG_View_PaymentDeclarations.AllowUserToAddRows = false;
            this.DG_View_PaymentDeclarations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_PaymentDeclarations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_PaymentDeclarations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_Check,
            this.COL_ID,
            this.COL_Tenant,
            this.COL_Organization,
            this.COL_Faculty,
            this.COL_StartDate,
            this.COL_EndDate,
            this.COL_Debt,
            this.COL_Payment,
            this.COL_CreatedAt});
            this.DG_View_PaymentDeclarations.Location = new System.Drawing.Point(16, 94);
            this.DG_View_PaymentDeclarations.Name = "DG_View_PaymentDeclarations";
            this.DG_View_PaymentDeclarations.RowHeadersWidth = 51;
            this.DG_View_PaymentDeclarations.RowTemplate.Height = 24;
            this.DG_View_PaymentDeclarations.Size = new System.Drawing.Size(1348, 285);
            this.DG_View_PaymentDeclarations.TabIndex = 1;
            // 
            // BTN_SelectAll
            // 
            this.BTN_SelectAll.Location = new System.Drawing.Point(16, 45);
            this.BTN_SelectAll.Name = "BTN_SelectAll";
            this.BTN_SelectAll.Size = new System.Drawing.Size(121, 37);
            this.BTN_SelectAll.TabIndex = 2;
            this.BTN_SelectAll.Text = "Выбрать все";
            this.BTN_SelectAll.UseVisualStyleBackColor = true;
            this.BTN_SelectAll.Click += new System.EventHandler(this.BTN_SelectAll_Click);
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(1243, 13);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(121, 24);
            this.CB_Hostels.TabIndex = 3;
            this.CB_Hostels.SelectionChangeCommitted += new System.EventHandler(this.CB_Hostels_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1151, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Общежитие";
            // 
            // BTN_CreateDeclaration
            // 
            this.BTN_CreateDeclaration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_CreateDeclaration.Location = new System.Drawing.Point(1243, 396);
            this.BTN_CreateDeclaration.Name = "BTN_CreateDeclaration";
            this.BTN_CreateDeclaration.Size = new System.Drawing.Size(121, 31);
            this.BTN_CreateDeclaration.TabIndex = 5;
            this.BTN_CreateDeclaration.Text = "Отчет";
            this.BTN_CreateDeclaration.UseVisualStyleBackColor = true;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Save.Location = new System.Drawing.Point(1116, 396);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(121, 31);
            this.BTN_Save.TabIndex = 6;
            this.BTN_Save.Text = "Внесни";
            this.BTN_Save.UseVisualStyleBackColor = true;
            // 
            // BTN_Delete
            // 
            this.BTN_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Delete.Location = new System.Drawing.Point(989, 396);
            this.BTN_Delete.Name = "BTN_Delete";
            this.BTN_Delete.Size = new System.Drawing.Size(121, 31);
            this.BTN_Delete.TabIndex = 7;
            this.BTN_Delete.Text = "Удалить";
            this.BTN_Delete.UseVisualStyleBackColor = true;
            this.BTN_Delete.Click += new System.EventHandler(this.BTN_Delete_Click);
            // 
            // COL_Check
            // 
            this.COL_Check.HeaderText = "Выбор";
            this.COL_Check.MinimumWidth = 6;
            this.COL_Check.Name = "COL_Check";
            this.COL_Check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COL_Check.Width = 125;
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.MinimumWidth = 6;
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            this.COL_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_ID.Width = 125;
            // 
            // COL_Tenant
            // 
            this.COL_Tenant.HeaderText = "Жилец";
            this.COL_Tenant.MinimumWidth = 6;
            this.COL_Tenant.Name = "COL_Tenant";
            this.COL_Tenant.ReadOnly = true;
            this.COL_Tenant.Width = 350;
            // 
            // COL_Organization
            // 
            this.COL_Organization.HeaderText = "Организация";
            this.COL_Organization.MinimumWidth = 6;
            this.COL_Organization.Name = "COL_Organization";
            this.COL_Organization.ReadOnly = true;
            this.COL_Organization.Width = 125;
            // 
            // COL_Faculty
            // 
            this.COL_Faculty.HeaderText = "Факультет";
            this.COL_Faculty.MinimumWidth = 6;
            this.COL_Faculty.Name = "COL_Faculty";
            this.COL_Faculty.ReadOnly = true;
            this.COL_Faculty.Width = 125;
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
            // COL_Debt
            // 
            this.COL_Debt.HeaderText = "Задолженность";
            this.COL_Debt.MinimumWidth = 6;
            this.COL_Debt.Name = "COL_Debt";
            this.COL_Debt.ReadOnly = true;
            this.COL_Debt.Width = 125;
            // 
            // COL_Payment
            // 
            this.COL_Payment.HeaderText = "Внесение средств";
            this.COL_Payment.MinimumWidth = 6;
            this.COL_Payment.Name = "COL_Payment";
            this.COL_Payment.Width = 125;
            // 
            // COL_CreatedAt
            // 
            this.COL_CreatedAt.HeaderText = "Создано платежное поручение";
            this.COL_CreatedAt.MinimumWidth = 6;
            this.COL_CreatedAt.Name = "COL_CreatedAt";
            this.COL_CreatedAt.ReadOnly = true;
            this.COL_CreatedAt.Width = 125;
            // 
            // AdminPaymentsDeclarations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 450);
            this.Controls.Add(this.BTN_Delete);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.BTN_CreateDeclaration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.BTN_SelectAll);
            this.Controls.Add(this.DG_View_PaymentDeclarations);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminPaymentsDeclarations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Платежные поручения";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminPaymentsDeclarations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_PaymentDeclarations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DG_View_PaymentDeclarations;
        private System.Windows.Forms.Button BTN_SelectAll;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_CreateDeclaration;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Button BTN_Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COL_Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Tenant;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Organization;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Faculty;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Debt;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_CreatedAt;
    }
}