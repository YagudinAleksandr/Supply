
namespace Supply
{
    partial class DeclarationContinueOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationContinueOrders));
            this.DG_View_ContinueOrders = new System.Windows.Forms.DataGridView();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Tenant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_OrderEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_ContinueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_ContinueOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_ContinueOrders
            // 
            this.DG_View_ContinueOrders.AllowUserToAddRows = false;
            this.DG_View_ContinueOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_ContinueOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_ContinueOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_OrderNumber,
            this.COL_Tenant,
            this.COL_OrderEndDate,
            this.COL_ContinueDate});
            this.DG_View_ContinueOrders.Location = new System.Drawing.Point(13, 13);
            this.DG_View_ContinueOrders.Name = "DG_View_ContinueOrders";
            this.DG_View_ContinueOrders.RowHeadersWidth = 51;
            this.DG_View_ContinueOrders.RowTemplate.Height = 24;
            this.DG_View_ContinueOrders.Size = new System.Drawing.Size(1120, 491);
            this.DG_View_ContinueOrders.TabIndex = 0;
            this.DG_View_ContinueOrders.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG_View_ContinueOrders_CellMouseClick);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.MinimumWidth = 6;
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            this.COL_ID.Width = 125;
            // 
            // COL_OrderNumber
            // 
            this.COL_OrderNumber.HeaderText = "№ договора";
            this.COL_OrderNumber.MinimumWidth = 6;
            this.COL_OrderNumber.Name = "COL_OrderNumber";
            this.COL_OrderNumber.ReadOnly = true;
            this.COL_OrderNumber.Width = 125;
            // 
            // COL_Tenant
            // 
            this.COL_Tenant.HeaderText = "Жилец";
            this.COL_Tenant.MinimumWidth = 6;
            this.COL_Tenant.Name = "COL_Tenant";
            this.COL_Tenant.ReadOnly = true;
            this.COL_Tenant.Width = 125;
            // 
            // COL_OrderEndDate
            // 
            this.COL_OrderEndDate.HeaderText = "Дата окончания договора";
            this.COL_OrderEndDate.MinimumWidth = 6;
            this.COL_OrderEndDate.Name = "COL_OrderEndDate";
            this.COL_OrderEndDate.ReadOnly = true;
            this.COL_OrderEndDate.Width = 125;
            // 
            // COL_ContinueDate
            // 
            this.COL_ContinueDate.HeaderText = "Дата продления договора";
            this.COL_ContinueDate.MinimumWidth = 6;
            this.COL_ContinueDate.Name = "COL_ContinueDate";
            this.COL_ContinueDate.ReadOnly = true;
            this.COL_ContinueDate.Width = 125;
            // 
            // DeclarationContinueOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 516);
            this.Controls.Add(this.DG_View_ContinueOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationContinueOrders";
            this.Text = "Продление договоров";
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_ContinueOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_ContinueOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Tenant;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_OrderEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ContinueDate;
    }
}