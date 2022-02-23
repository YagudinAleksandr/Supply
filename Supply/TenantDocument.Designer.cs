
namespace Supply
{
    partial class TenantDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenantDocument));
            this.cbDocuments = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStartDate = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEndDate = new System.Windows.Forms.MaskedTextBox();
            this.BTNAdd = new System.Windows.Forms.Button();
            this.DG_View_Documents = new System.Windows.Forms.DataGridView();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Documents)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDocuments
            // 
            this.cbDocuments.FormattingEnabled = true;
            this.cbDocuments.Items.AddRange(new object[] {
            "Мед.обследование",
            "Пропуск",
            "Эл.пропуск"});
            this.cbDocuments.Location = new System.Drawing.Point(13, 13);
            this.cbDocuments.Name = "cbDocuments";
            this.cbDocuments.Size = new System.Drawing.Size(121, 21);
            this.cbDocuments.TabIndex = 0;
            this.cbDocuments.SelectedValueChanged += new System.EventHandler(this.CbDocuments_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Действителен с: ";
            // 
            // tbStartDate
            // 
            this.tbStartDate.Location = new System.Drawing.Point(232, 14);
            this.tbStartDate.Mask = "00/00/0000";
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.Size = new System.Drawing.Size(100, 20);
            this.tbStartDate.TabIndex = 2;
            this.tbStartDate.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "по:";
            // 
            // tbEndDate
            // 
            this.tbEndDate.Location = new System.Drawing.Point(365, 14);
            this.tbEndDate.Mask = "00/00/0000";
            this.tbEndDate.Name = "tbEndDate";
            this.tbEndDate.Size = new System.Drawing.Size(100, 20);
            this.tbEndDate.TabIndex = 4;
            this.tbEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // BTNAdd
            // 
            this.BTNAdd.Location = new System.Drawing.Point(471, 13);
            this.BTNAdd.Name = "BTNAdd";
            this.BTNAdd.Size = new System.Drawing.Size(75, 23);
            this.BTNAdd.TabIndex = 5;
            this.BTNAdd.Text = "Внести";
            this.BTNAdd.UseVisualStyleBackColor = true;
            this.BTNAdd.Click += new System.EventHandler(this.BTNAdd_Click);
            // 
            // DG_View_Documents
            // 
            this.DG_View_Documents.AllowUserToAddRows = false;
            this.DG_View_Documents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_Documents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Type,
            this.COL_StartDate,
            this.COL_EndDate,
            this.COL_Status});
            this.DG_View_Documents.Location = new System.Drawing.Point(13, 50);
            this.DG_View_Documents.Name = "DG_View_Documents";
            this.DG_View_Documents.Size = new System.Drawing.Size(775, 267);
            this.DG_View_Documents.TabIndex = 6;
            this.DG_View_Documents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_View_Documents_CellContentClick);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            // 
            // COL_Type
            // 
            this.COL_Type.HeaderText = "Тип документа";
            this.COL_Type.Name = "COL_Type";
            this.COL_Type.ReadOnly = true;
            // 
            // COL_StartDate
            // 
            this.COL_StartDate.HeaderText = "Дата начала";
            this.COL_StartDate.Name = "COL_StartDate";
            this.COL_StartDate.ReadOnly = true;
            // 
            // COL_EndDate
            // 
            this.COL_EndDate.HeaderText = "Дата окончания";
            this.COL_EndDate.Name = "COL_EndDate";
            this.COL_EndDate.ReadOnly = true;
            // 
            // COL_Status
            // 
            this.COL_Status.HeaderText = "Статус";
            this.COL_Status.Name = "COL_Status";
            this.COL_Status.ReadOnly = true;
            // 
            // TenantDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 332);
            this.Controls.Add(this.DG_View_Documents);
            this.Controls.Add(this.BTNAdd);
            this.Controls.Add(this.tbEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbStartDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDocuments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TenantDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дополнительные документы";
            this.Load += new System.EventHandler(this.TenantDocument_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Documents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDocuments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox tbStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbEndDate;
        private System.Windows.Forms.Button BTNAdd;
        private System.Windows.Forms.DataGridView DG_View_Documents;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Status;
    }
}