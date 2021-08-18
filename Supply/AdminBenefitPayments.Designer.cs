
namespace Supply
{
    partial class AdminBenefitPayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminBenefitPayments));
            this.DG_View_BenefitPayments = new System.Windows.Forms.DataGridView();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_BenefitType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Hostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_BenefitPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_BenefitPayments
            // 
            this.DG_View_BenefitPayments.AllowUserToAddRows = false;
            this.DG_View_BenefitPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_BenefitPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_BenefitPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_BenefitType,
            this.COL_Status,
            this.COL_Price,
            this.COL_Hostel});
            this.DG_View_BenefitPayments.Location = new System.Drawing.Point(13, 13);
            this.DG_View_BenefitPayments.Name = "DG_View_BenefitPayments";
            this.DG_View_BenefitPayments.RowHeadersWidth = 51;
            this.DG_View_BenefitPayments.RowTemplate.Height = 24;
            this.DG_View_BenefitPayments.Size = new System.Drawing.Size(991, 374);
            this.DG_View_BenefitPayments.TabIndex = 0;
            this.DG_View_BenefitPayments.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG_View_BenefitPayments_CellMouseClick);
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(907, 406);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(97, 32);
            this.BTN_Add.TabIndex = 1;
            this.BTN_Add.Text = "Добавить";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.MinimumWidth = 6;
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            this.COL_ID.Width = 125;
            // 
            // COL_BenefitType
            // 
            this.COL_BenefitType.HeaderText = "Тип";
            this.COL_BenefitType.MinimumWidth = 6;
            this.COL_BenefitType.Name = "COL_BenefitType";
            this.COL_BenefitType.ReadOnly = true;
            this.COL_BenefitType.Width = 125;
            // 
            // COL_Status
            // 
            this.COL_Status.HeaderText = "Статус";
            this.COL_Status.MinimumWidth = 6;
            this.COL_Status.Name = "COL_Status";
            this.COL_Status.ReadOnly = true;
            this.COL_Status.Width = 125;
            // 
            // COL_Price
            // 
            this.COL_Price.HeaderText = "Цена";
            this.COL_Price.MinimumWidth = 6;
            this.COL_Price.Name = "COL_Price";
            this.COL_Price.ReadOnly = true;
            this.COL_Price.Width = 125;
            // 
            // COL_Hostel
            // 
            this.COL_Hostel.HeaderText = "Общежитие";
            this.COL_Hostel.MinimumWidth = 6;
            this.COL_Hostel.Name = "COL_Hostel";
            this.COL_Hostel.ReadOnly = true;
            this.COL_Hostel.Width = 125;
            // 
            // AdminBenefitPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 450);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.DG_View_BenefitPayments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminBenefitPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тарифы для льгот";
            this.Shown += new System.EventHandler(this.AdminBenefitPayments_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_BenefitPayments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_BenefitPayments;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_BenefitType;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Hostel;
        private System.Windows.Forms.Button BTN_Add;
    }
}