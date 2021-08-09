
namespace Supply
{
    partial class AdminFlatsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminFlatsForm));
            this.DG_View_Flats = new System.Windows.Forms.DataGridView();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Flats)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_Flats
            // 
            this.DG_View_Flats.AllowUserToAddRows = false;
            this.DG_View_Flats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_Flats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_Flats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Name});
            this.DG_View_Flats.Location = new System.Drawing.Point(13, 13);
            this.DG_View_Flats.Name = "DG_View_Flats";
            this.DG_View_Flats.RowHeadersWidth = 51;
            this.DG_View_Flats.RowTemplate.Height = 24;
            this.DG_View_Flats.Size = new System.Drawing.Size(775, 382);
            this.DG_View_Flats.TabIndex = 0;
            this.DG_View_Flats.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG_View_Flats_CellMouseClick);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.MinimumWidth = 6;
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            this.COL_ID.Width = 125;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Название";
            this.COL_Name.MinimumWidth = 6;
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.ReadOnly = true;
            this.COL_Name.Width = 125;
            // 
            // BTN_Add
            // 
            this.BTN_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Add.Location = new System.Drawing.Point(672, 401);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(115, 37);
            this.BTN_Add.TabIndex = 1;
            this.BTN_Add.Text = "Добавить";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // AdminFlatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.DG_View_Flats);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminFlatsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Этажи";
            this.Shown += new System.EventHandler(this.AdminFlatsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Flats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_Flats;
        private System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
    }
}