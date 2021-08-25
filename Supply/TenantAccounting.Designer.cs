
namespace Supply
{
    partial class TenantAccounting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenantAccounting));
            this.label1 = new System.Windows.Forms.Label();
            this.LB_TenantName = new System.Windows.Forms.Label();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.DG_View_Accounting = new System.Windows.Forms.DataGridView();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Debt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Accounting)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО прживающего:";
            // 
            // LB_TenantName
            // 
            this.LB_TenantName.AutoSize = true;
            this.LB_TenantName.Location = new System.Drawing.Point(188, 21);
            this.LB_TenantName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_TenantName.Name = "LB_TenantName";
            this.LB_TenantName.Size = new System.Drawing.Size(46, 17);
            this.LB_TenantName.TabIndex = 1;
            this.LB_TenantName.Text = "label2";
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(888, 317);
            this.BTN_Add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(100, 28);
            this.BTN_Add.TabIndex = 10;
            this.BTN_Add.Text = "Внести";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // DG_View_Accounting
            // 
            this.DG_View_Accounting.AllowUserToAddRows = false;
            this.DG_View_Accounting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_Accounting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_StartDate,
            this.COL_EndDate,
            this.COL_Debt,
            this.COL_Cost});
            this.DG_View_Accounting.Location = new System.Drawing.Point(28, 54);
            this.DG_View_Accounting.Name = "DG_View_Accounting";
            this.DG_View_Accounting.RowHeadersWidth = 51;
            this.DG_View_Accounting.RowTemplate.Height = 24;
            this.DG_View_Accounting.Size = new System.Drawing.Size(960, 256);
            this.DG_View_Accounting.TabIndex = 11;
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.MinimumWidth = 6;
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            this.COL_ID.Width = 125;
            // 
            // COL_StartDate
            // 
            this.COL_StartDate.HeaderText = "Начало платежа";
            this.COL_StartDate.MinimumWidth = 6;
            this.COL_StartDate.Name = "COL_StartDate";
            this.COL_StartDate.ReadOnly = true;
            this.COL_StartDate.Width = 125;
            // 
            // COL_EndDate
            // 
            this.COL_EndDate.HeaderText = "Конец платежа";
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
            // COL_Cost
            // 
            this.COL_Cost.HeaderText = "Внесено";
            this.COL_Cost.MinimumWidth = 6;
            this.COL_Cost.Name = "COL_Cost";
            this.COL_Cost.Width = 125;
            // 
            // TenantAccounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 358);
            this.Controls.Add(this.DG_View_Accounting);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.LB_TenantName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TenantAccounting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Внесение оплаты";
            this.Load += new System.EventHandler(this.TenantAccounting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Accounting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_TenantName;
        private System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.DataGridView DG_View_Accounting;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Debt;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Cost;
    }
}