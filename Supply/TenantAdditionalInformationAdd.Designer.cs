
namespace Supply
{
    partial class TenantAdditionalInformationAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenantAdditionalInformationAdd));
            this.BTN_Save = new System.Windows.Forms.Button();
            this.DG_ViewAdditionalInformation = new System.Windows.Forms.DataGridView();
            this.COL_Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.COL_Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_ViewAdditionalInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(713, 415);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save.TabIndex = 12;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // DG_ViewAdditionalInformation
            // 
            this.DG_ViewAdditionalInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_ViewAdditionalInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_Type,
            this.COL_Information,
            this.COL_DeleteButton});
            this.DG_ViewAdditionalInformation.Location = new System.Drawing.Point(13, 13);
            this.DG_ViewAdditionalInformation.Name = "DG_ViewAdditionalInformation";
            this.DG_ViewAdditionalInformation.Size = new System.Drawing.Size(775, 396);
            this.DG_ViewAdditionalInformation.TabIndex = 13;
            this.DG_ViewAdditionalInformation.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DG_ViewAdditionalInformation_UserAddedRow);
            // 
            // COL_Type
            // 
            this.COL_Type.HeaderText = "Тип данных";
            this.COL_Type.Name = "COL_Type";
            // 
            // COL_Information
            // 
            this.COL_Information.HeaderText = "Информация";
            this.COL_Information.Name = "COL_Information";
            this.COL_Information.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_Information.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_Information.Width = 500;
            // 
            // COL_DeleteButton
            // 
            this.COL_DeleteButton.HeaderText = "Удаление";
            this.COL_DeleteButton.Name = "COL_DeleteButton";
            this.COL_DeleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_DeleteButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TenantAdditionalInformationAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DG_ViewAdditionalInformation);
            this.Controls.Add(this.BTN_Save);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TenantAdditionalInformationAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дополнительная информация о жильце";
            this.Load += new System.EventHandler(this.TenantAdditionalInformationAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_ViewAdditionalInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.DataGridView DG_ViewAdditionalInformation;
        private System.Windows.Forms.DataGridViewComboBoxColumn COL_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Information;
        private System.Windows.Forms.DataGridViewButtonColumn COL_DeleteButton;
    }
}