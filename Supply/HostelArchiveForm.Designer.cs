﻿
namespace Supply
{
    partial class HostelArchiveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostelArchiveForm));
            this.DG_View_Tenants = new System.Windows.Forms.DataGridView();
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.BTN_Search = new System.Windows.Forms.Button();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Surename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Tenants)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_Tenants
            // 
            this.DG_View_Tenants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_Tenants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_Tenants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_Surename,
            this.COL_Name,
            this.COL_Patronymic,
            this.COL_DateOfBirth,
            this.COL_Order,
            this.COL_StartDate,
            this.COL_EndDate,
            this.COL_Room});
            this.DG_View_Tenants.Location = new System.Drawing.Point(12, 54);
            this.DG_View_Tenants.Name = "DG_View_Tenants";
            this.DG_View_Tenants.RowHeadersWidth = 51;
            this.DG_View_Tenants.RowTemplate.Height = 24;
            this.DG_View_Tenants.Size = new System.Drawing.Size(1235, 502);
            this.DG_View_Tenants.TabIndex = 0;
            // 
            // TB_Search
            // 
            this.TB_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Search.Location = new System.Drawing.Point(781, 13);
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.Size = new System.Drawing.Size(330, 22);
            this.TB_Search.TabIndex = 1;
            // 
            // BTN_Search
            // 
            this.BTN_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Search.Location = new System.Drawing.Point(1118, 12);
            this.BTN_Search.Name = "BTN_Search";
            this.BTN_Search.Size = new System.Drawing.Size(129, 24);
            this.BTN_Search.TabIndex = 2;
            this.BTN_Search.Text = "Поиск";
            this.BTN_Search.UseVisualStyleBackColor = true;
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.MinimumWidth = 6;
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            this.COL_ID.Width = 125;
            // 
            // COL_Surename
            // 
            this.COL_Surename.HeaderText = "Фамилия";
            this.COL_Surename.MinimumWidth = 6;
            this.COL_Surename.Name = "COL_Surename";
            this.COL_Surename.ReadOnly = true;
            this.COL_Surename.Width = 210;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Имя";
            this.COL_Name.MinimumWidth = 6;
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.ReadOnly = true;
            this.COL_Name.Width = 210;
            // 
            // COL_Patronymic
            // 
            this.COL_Patronymic.HeaderText = "Отчество";
            this.COL_Patronymic.MinimumWidth = 6;
            this.COL_Patronymic.Name = "COL_Patronymic";
            this.COL_Patronymic.ReadOnly = true;
            this.COL_Patronymic.Width = 210;
            // 
            // COL_DateOfBirth
            // 
            this.COL_DateOfBirth.HeaderText = "Дата рождения";
            this.COL_DateOfBirth.MinimumWidth = 6;
            this.COL_DateOfBirth.Name = "COL_DateOfBirth";
            this.COL_DateOfBirth.ReadOnly = true;
            this.COL_DateOfBirth.Width = 125;
            // 
            // COL_Order
            // 
            this.COL_Order.HeaderText = "Договор №";
            this.COL_Order.MinimumWidth = 6;
            this.COL_Order.Name = "COL_Order";
            this.COL_Order.ReadOnly = true;
            this.COL_Order.Width = 125;
            // 
            // COL_StartDate
            // 
            this.COL_StartDate.HeaderText = "Дата начала";
            this.COL_StartDate.MinimumWidth = 6;
            this.COL_StartDate.Name = "COL_StartDate";
            this.COL_StartDate.ReadOnly = true;
            this.COL_StartDate.Width = 125;
            // 
            // COL_EndDate
            // 
            this.COL_EndDate.HeaderText = "Окончание";
            this.COL_EndDate.MinimumWidth = 6;
            this.COL_EndDate.Name = "COL_EndDate";
            this.COL_EndDate.ReadOnly = true;
            this.COL_EndDate.Width = 125;
            // 
            // COL_Room
            // 
            this.COL_Room.HeaderText = "Комната";
            this.COL_Room.MinimumWidth = 6;
            this.COL_Room.Name = "COL_Room";
            this.COL_Room.ReadOnly = true;
            this.COL_Room.Width = 125;
            // 
            // HostelArchiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 597);
            this.Controls.Add(this.BTN_Search);
            this.Controls.Add(this.TB_Search);
            this.Controls.Add(this.DG_View_Tenants);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HostelArchiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Полный архив по общежитию";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.HostelArchiveForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Tenants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_Tenants;
        private System.Windows.Forms.TextBox TB_Search;
        private System.Windows.Forms.Button BTN_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Surename;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Room;
    }
}