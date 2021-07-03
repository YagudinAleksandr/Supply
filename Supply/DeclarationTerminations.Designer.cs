namespace Supply
{
    partial class DeclarationTerminations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationTerminations));
            this.DG_View_Terminations = new System.Windows.Forms.DataGridView();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Orer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Tenant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_CreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_UpdatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Terminations)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_Terminations
            // 
            this.DG_View_Terminations.AllowUserToAddRows = false;
            this.DG_View_Terminations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_Terminations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_Terminations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Orer,
            this.COL_Tenant,
            this.COL_Date,
            this.COL_Status,
            this.COL_CreatedAt,
            this.COL_UpdatedAt});
            this.DG_View_Terminations.Location = new System.Drawing.Point(13, 13);
            this.DG_View_Terminations.Name = "DG_View_Terminations";
            this.DG_View_Terminations.Size = new System.Drawing.Size(775, 373);
            this.DG_View_Terminations.TabIndex = 0;
            this.DG_View_Terminations.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG_View_Terminations_CellMouseClick);
            // 
            // BTN_Create
            // 
            this.BTN_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Create.Location = new System.Drawing.Point(713, 415);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(75, 23);
            this.BTN_Create.TabIndex = 1;
            this.BTN_Create.Text = "Создать";
            this.BTN_Create.UseVisualStyleBackColor = true;
            this.BTN_Create.Click += new System.EventHandler(this.BTN_Create_Click);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            // 
            // COL_Orer
            // 
            this.COL_Orer.HeaderText = "Договор";
            this.COL_Orer.Name = "COL_Orer";
            this.COL_Orer.ReadOnly = true;
            // 
            // COL_Tenant
            // 
            this.COL_Tenant.HeaderText = "Жилец";
            this.COL_Tenant.Name = "COL_Tenant";
            this.COL_Tenant.ReadOnly = true;
            // 
            // COL_Date
            // 
            this.COL_Date.HeaderText = "Дата расторжения";
            this.COL_Date.Name = "COL_Date";
            this.COL_Date.ReadOnly = true;
            // 
            // COL_Status
            // 
            this.COL_Status.HeaderText = "Статус";
            this.COL_Status.Name = "COL_Status";
            this.COL_Status.ReadOnly = true;
            // 
            // COL_CreatedAt
            // 
            this.COL_CreatedAt.HeaderText = "Дата создания";
            this.COL_CreatedAt.Name = "COL_CreatedAt";
            this.COL_CreatedAt.ReadOnly = true;
            // 
            // COL_UpdatedAt
            // 
            this.COL_UpdatedAt.HeaderText = "Дата изменения";
            this.COL_UpdatedAt.Name = "COL_UpdatedAt";
            this.COL_UpdatedAt.ReadOnly = true;
            // 
            // DeclarationTerminations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.DG_View_Terminations);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationTerminations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расторжение договоров";
            this.Shown += new System.EventHandler(this.DeclarationTerminations_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Terminations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_Terminations;
        private System.Windows.Forms.Button BTN_Create;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Orer;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Tenant;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_CreatedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_UpdatedAt;
    }
}