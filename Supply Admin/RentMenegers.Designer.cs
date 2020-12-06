namespace Supply_Admin
{
    partial class RentMenegers
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
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.DGV_Rents = new System.Windows.Forms.DataGridView();
            this.COL_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Rents)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(92, 13);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(296, 22);
            this.TB_Name.TabIndex = 1;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(410, 9);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(110, 30);
            this.BTN_Save.TabIndex = 2;
            this.BTN_Save.Text = "Добавить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // DGV_Rents
            // 
            this.DGV_Rents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Rents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_Number,
            this.COL_Name});
            this.DGV_Rents.Location = new System.Drawing.Point(16, 59);
            this.DGV_Rents.Name = "DGV_Rents";
            this.DGV_Rents.RowHeadersWidth = 51;
            this.DGV_Rents.RowTemplate.Height = 24;
            this.DGV_Rents.Size = new System.Drawing.Size(504, 206);
            this.DGV_Rents.TabIndex = 3;
            // 
            // COL_Number
            // 
            this.COL_Number.HeaderText = "Номер";
            this.COL_Number.MinimumWidth = 6;
            this.COL_Number.Name = "COL_Number";
            this.COL_Number.Width = 125;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Название";
            this.COL_Name.MinimumWidth = 6;
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.Width = 125;
            // 
            // RentMenegers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 276);
            this.Controls.Add(this.DGV_Rents);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label1);
            this.Name = "RentMenegers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Типы проживания";
            this.Shown += new System.EventHandler(this.RentMenegers_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Rents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.DataGridView DGV_Rents;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
    }
}