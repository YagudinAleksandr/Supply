
namespace Supply
{
    partial class AdminManagersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminManagersForm));
            this.DG_Managers = new System.Windows.Forms.DataGridView();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Surename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_OpenManagersAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Managers)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_Managers
            // 
            this.DG_Managers.AllowUserToAddRows = false;
            this.DG_Managers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Managers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Surename,
            this.COL_Name,
            this.COL_Patronymic});
            this.DG_Managers.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DG_Managers.Location = new System.Drawing.Point(13, 13);
            this.DG_Managers.Name = "DG_Managers";
            this.DG_Managers.Size = new System.Drawing.Size(775, 374);
            this.DG_Managers.TabIndex = 0;
            this.DG_Managers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_Managers_CellClick);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            // 
            // COL_Surename
            // 
            this.COL_Surename.HeaderText = "Фамилия";
            this.COL_Surename.Name = "COL_Surename";
            this.COL_Surename.ReadOnly = true;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Имя";
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.ReadOnly = true;
            // 
            // COL_Patronymic
            // 
            this.COL_Patronymic.HeaderText = "Отчество";
            this.COL_Patronymic.Name = "COL_Patronymic";
            this.COL_Patronymic.ReadOnly = true;
            // 
            // BTN_OpenManagersAdd
            // 
            this.BTN_OpenManagersAdd.Location = new System.Drawing.Point(673, 408);
            this.BTN_OpenManagersAdd.Name = "BTN_OpenManagersAdd";
            this.BTN_OpenManagersAdd.Size = new System.Drawing.Size(115, 23);
            this.BTN_OpenManagersAdd.TabIndex = 1;
            this.BTN_OpenManagersAdd.Text = "Добавить";
            this.BTN_OpenManagersAdd.UseVisualStyleBackColor = true;
            this.BTN_OpenManagersAdd.Click += new System.EventHandler(this.BTN_OpenManagersAdd_Click);
            // 
            // AdminManagersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_OpenManagersAdd);
            this.Controls.Add(this.DG_Managers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminManagersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджеры";
            this.Shown += new System.EventHandler(this.AdminManagersForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Managers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_Managers;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Surename;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Patronymic;
        private System.Windows.Forms.Button BTN_OpenManagersAdd;
    }
}