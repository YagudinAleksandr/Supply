
namespace Supply
{
    partial class DeclarationsBenefits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationsBenefits));
            this.DG_View_Benefits = new System.Windows.Forms.DataGridView();
            this.BTN_CreateBenefits = new System.Windows.Forms.Button();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_OrderNumb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_TenantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_BenefitType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Decree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Rent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Benefits)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_Benefits
            // 
            this.DG_View_Benefits.AllowUserToAddRows = false;
            this.DG_View_Benefits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_Benefits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_Benefits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_OrderNumb,
            this.COL_TenantName,
            this.COL_BenefitType,
            this.COL_Decree,
            this.COL_StartDate,
            this.COL_EndDate,
            this.COL_Rent,
            this.COL_Status});
            this.DG_View_Benefits.Location = new System.Drawing.Point(13, 13);
            this.DG_View_Benefits.Name = "DG_View_Benefits";
            this.DG_View_Benefits.Size = new System.Drawing.Size(775, 384);
            this.DG_View_Benefits.TabIndex = 0;
            this.DG_View_Benefits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_View_Benefits_CellContentClick);
            // 
            // BTN_CreateBenefits
            // 
            this.BTN_CreateBenefits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_CreateBenefits.Location = new System.Drawing.Point(627, 415);
            this.BTN_CreateBenefits.Name = "BTN_CreateBenefits";
            this.BTN_CreateBenefits.Size = new System.Drawing.Size(161, 23);
            this.BTN_CreateBenefits.TabIndex = 1;
            this.BTN_CreateBenefits.Text = "Сформировать документы";
            this.BTN_CreateBenefits.UseVisualStyleBackColor = true;
            this.BTN_CreateBenefits.Click += new System.EventHandler(this.BTN_CreateBenefits_Click);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "#";
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            // 
            // COL_OrderNumb
            // 
            this.COL_OrderNumb.HeaderText = "№ Договора";
            this.COL_OrderNumb.Name = "COL_OrderNumb";
            this.COL_OrderNumb.ReadOnly = true;
            // 
            // COL_TenantName
            // 
            this.COL_TenantName.HeaderText = "Имя жильца";
            this.COL_TenantName.Name = "COL_TenantName";
            this.COL_TenantName.ReadOnly = true;
            this.COL_TenantName.Width = 250;
            // 
            // COL_BenefitType
            // 
            this.COL_BenefitType.HeaderText = "Тип льготы";
            this.COL_BenefitType.Name = "COL_BenefitType";
            this.COL_BenefitType.ReadOnly = true;
            // 
            // COL_Decree
            // 
            this.COL_Decree.HeaderText = "Основание";
            this.COL_Decree.Name = "COL_Decree";
            this.COL_Decree.ReadOnly = true;
            this.COL_Decree.Width = 210;
            // 
            // COL_StartDate
            // 
            this.COL_StartDate.HeaderText = "Начало";
            this.COL_StartDate.Name = "COL_StartDate";
            this.COL_StartDate.ReadOnly = true;
            // 
            // COL_EndDate
            // 
            this.COL_EndDate.HeaderText = "Окончание";
            this.COL_EndDate.Name = "COL_EndDate";
            this.COL_EndDate.ReadOnly = true;
            // 
            // COL_Rent
            // 
            this.COL_Rent.HeaderText = "Оплата";
            this.COL_Rent.Name = "COL_Rent";
            this.COL_Rent.ReadOnly = true;
            // 
            // COL_Status
            // 
            this.COL_Status.HeaderText = "Статус";
            this.COL_Status.Name = "COL_Status";
            this.COL_Status.ReadOnly = true;
            // 
            // DeclarationsBenefits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_CreateBenefits);
            this.Controls.Add(this.DG_View_Benefits);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationsBenefits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Льготы";
            this.Shown += new System.EventHandler(this.DeclarationsBenefits_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Benefits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_Benefits;
        private System.Windows.Forms.Button BTN_CreateBenefits;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_OrderNumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_TenantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_BenefitType;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Decree;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Rent;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Status;
    }
}