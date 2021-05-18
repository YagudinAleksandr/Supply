
namespace Supply
{
    partial class AdminUsersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminUsersForm));
            this.DG_Users = new System.Windows.Forms.DataGridView();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_OpenUserAddForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Users)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_Users
            // 
            this.DG_Users.AllowUserToAddRows = false;
            this.DG_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Users.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Name,
            this.COL_Login,
            this.COL_Role});
            this.DG_Users.Location = new System.Drawing.Point(13, 13);
            this.DG_Users.Name = "DG_Users";
            this.DG_Users.Size = new System.Drawing.Size(775, 379);
            this.DG_Users.TabIndex = 0;
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Ф.И.О";
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.ReadOnly = true;
            this.COL_Name.Width = 280;
            // 
            // COL_Login
            // 
            this.COL_Login.HeaderText = "Логин";
            this.COL_Login.Name = "COL_Login";
            this.COL_Login.ReadOnly = true;
            // 
            // COL_Role
            // 
            this.COL_Role.HeaderText = "Роль";
            this.COL_Role.Name = "COL_Role";
            this.COL_Role.ReadOnly = true;
            // 
            // BTN_OpenUserAddForm
            // 
            this.BTN_OpenUserAddForm.Location = new System.Drawing.Point(713, 415);
            this.BTN_OpenUserAddForm.Name = "BTN_OpenUserAddForm";
            this.BTN_OpenUserAddForm.Size = new System.Drawing.Size(75, 23);
            this.BTN_OpenUserAddForm.TabIndex = 1;
            this.BTN_OpenUserAddForm.Text = "Добавить";
            this.BTN_OpenUserAddForm.UseVisualStyleBackColor = true;
            this.BTN_OpenUserAddForm.Click += new System.EventHandler(this.BTN_OpenUserAddForm_Click);
            // 
            // AdminUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_OpenUserAddForm);
            this.Controls.Add(this.DG_Users);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminUsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи";
            this.Shown += new System.EventHandler(this.AdminUsersForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Users)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_Users;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Role;
        private System.Windows.Forms.Button BTN_OpenUserAddForm;
    }
}