
namespace Supply
{
    partial class AdminPropertiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPropertiesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.L_RoomNumber = new System.Windows.Forms.Label();
            this.DG_Properties = new System.Windows.Forms.DataGridView();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_OpenAddForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Комнат №";
            // 
            // L_RoomNumber
            // 
            this.L_RoomNumber.AutoSize = true;
            this.L_RoomNumber.Location = new System.Drawing.Point(79, 13);
            this.L_RoomNumber.Name = "L_RoomNumber";
            this.L_RoomNumber.Size = new System.Drawing.Size(35, 13);
            this.L_RoomNumber.TabIndex = 1;
            this.L_RoomNumber.Text = "label2";
            // 
            // DG_Properties
            // 
            this.DG_Properties.AllowUserToAddRows = false;
            this.DG_Properties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Properties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Name,
            this.COL_Count});
            this.DG_Properties.Location = new System.Drawing.Point(16, 41);
            this.DG_Properties.Name = "DG_Properties";
            this.DG_Properties.Size = new System.Drawing.Size(772, 214);
            this.DG_Properties.TabIndex = 2;
            this.DG_Properties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_Properties_CellClick);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            this.COL_ID.Width = 250;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Название";
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.ReadOnly = true;
            // 
            // COL_Count
            // 
            this.COL_Count.HeaderText = "Кол-во";
            this.COL_Count.Name = "COL_Count";
            this.COL_Count.ReadOnly = true;
            // 
            // BTN_OpenAddForm
            // 
            this.BTN_OpenAddForm.Location = new System.Drawing.Point(713, 279);
            this.BTN_OpenAddForm.Name = "BTN_OpenAddForm";
            this.BTN_OpenAddForm.Size = new System.Drawing.Size(75, 23);
            this.BTN_OpenAddForm.TabIndex = 3;
            this.BTN_OpenAddForm.Text = "Добавить";
            this.BTN_OpenAddForm.UseVisualStyleBackColor = true;
            this.BTN_OpenAddForm.Click += new System.EventHandler(this.BTN_OpenAddForm_Click);
            // 
            // AdminPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 314);
            this.Controls.Add(this.BTN_OpenAddForm);
            this.Controls.Add(this.DG_Properties);
            this.Controls.Add(this.L_RoomNumber);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminPropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Инвентаризация";
            this.Load += new System.EventHandler(this.AdminPropertiesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L_RoomNumber;
        private System.Windows.Forms.DataGridView DG_Properties;
        private System.Windows.Forms.Button BTN_OpenAddForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Count;
    }
}