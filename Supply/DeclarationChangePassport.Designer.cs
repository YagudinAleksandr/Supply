
namespace Supply
{
    partial class DeclarationChangePassport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationChangePassport));
            this.DG_View_ChangePassport = new System.Windows.Forms.DataGridView();
            this.BTN_CreateOrdersChangePassport = new System.Windows.Forms.Button();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Tenant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_ChangePassport)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_ChangePassport
            // 
            this.DG_View_ChangePassport.AllowUserToAddRows = false;
            this.DG_View_ChangePassport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_ChangePassport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_ChangePassport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Tenant,
            this.COL_Order,
            this.COL_StartDate,
            this.COL_Status});
            this.DG_View_ChangePassport.Location = new System.Drawing.Point(13, 13);
            this.DG_View_ChangePassport.Name = "DG_View_ChangePassport";
            this.DG_View_ChangePassport.Size = new System.Drawing.Size(775, 394);
            this.DG_View_ChangePassport.TabIndex = 0;
            this.DG_View_ChangePassport.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG_View_ChangePassport_CellMouseClick);
            // 
            // BTN_CreateOrdersChangePassport
            // 
            this.BTN_CreateOrdersChangePassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_CreateOrdersChangePassport.Location = new System.Drawing.Point(615, 415);
            this.BTN_CreateOrdersChangePassport.Name = "BTN_CreateOrdersChangePassport";
            this.BTN_CreateOrdersChangePassport.Size = new System.Drawing.Size(173, 23);
            this.BTN_CreateOrdersChangePassport.TabIndex = 1;
            this.BTN_CreateOrdersChangePassport.Text = "Сформировать дополнения";
            this.BTN_CreateOrdersChangePassport.UseVisualStyleBackColor = true;
            this.BTN_CreateOrdersChangePassport.Click += new System.EventHandler(this.BTN_CreateOrdersChangePassport_Click);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "#";
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            // 
            // COL_Tenant
            // 
            this.COL_Tenant.HeaderText = "Жилец";
            this.COL_Tenant.Name = "COL_Tenant";
            this.COL_Tenant.ReadOnly = true;
            this.COL_Tenant.Width = 200;
            // 
            // COL_Order
            // 
            this.COL_Order.HeaderText = "Договор";
            this.COL_Order.Name = "COL_Order";
            this.COL_Order.ReadOnly = true;
            // 
            // COL_StartDate
            // 
            this.COL_StartDate.HeaderText = "Дата нового паспорта";
            this.COL_StartDate.Name = "COL_StartDate";
            this.COL_StartDate.ReadOnly = true;
            // 
            // COL_Status
            // 
            this.COL_Status.HeaderText = "Статус";
            this.COL_Status.Name = "COL_Status";
            this.COL_Status.ReadOnly = true;
            // 
            // DeclarationChangePassport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_CreateOrdersChangePassport);
            this.Controls.Add(this.DG_View_ChangePassport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationChangePassport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчеты по смене паспортов";
            this.Load += new System.EventHandler(this.DeclarationChangePassport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_ChangePassport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_ChangePassport;
        private System.Windows.Forms.Button BTN_CreateOrdersChangePassport;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Tenant;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Status;
    }
}