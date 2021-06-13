
namespace Supply
{
    partial class AdminPaymentsElectricityElements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPaymentsElectricityElements));
            this.DG_View_Elements = new System.Windows.Forms.DataGridView();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Elements)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_Elements
            // 
            this.DG_View_Elements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_Elements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_Elements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Name,
            this.COL_Capacity,
            this.COL_Sum});
            this.DG_View_Elements.Location = new System.Drawing.Point(13, 13);
            this.DG_View_Elements.Name = "DG_View_Elements";
            this.DG_View_Elements.Size = new System.Drawing.Size(775, 389);
            this.DG_View_Elements.TabIndex = 0;
            this.DG_View_Elements.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG_View_Elements_CellMouseClick);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Save.Location = new System.Drawing.Point(713, 415);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save.TabIndex = 1;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Название";
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.Width = 200;
            // 
            // COL_Capacity
            // 
            this.COL_Capacity.HeaderText = "Кол-во";
            this.COL_Capacity.Name = "COL_Capacity";
            // 
            // COL_Sum
            // 
            this.COL_Sum.HeaderText = "Сумма за месяц";
            this.COL_Sum.Name = "COL_Sum";
            // 
            // AdminPaymentsElectricityElements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.DG_View_Elements);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminPaymentsElectricityElements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Элементы тарифного плана";
            this.Shown += new System.EventHandler(this.AdminPaymentsElectricityElements_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Elements)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_Elements;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Sum;
    }
}