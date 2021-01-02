
namespace Supply_Admin
{
    partial class AddtionalServices
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
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.DG_View_Orders = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.COL_OrderId = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COL_OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Person = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Orders)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Общежитие №";
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(124, 18);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(62, 24);
            this.CB_Hostels.TabIndex = 7;
            this.CB_Hostels.SelectedIndexChanged += new System.EventHandler(this.CB_Hostels_SelectedIndexChanged);
            // 
            // DG_View_Orders
            // 
            this.DG_View_Orders.AllowUserToAddRows = false;
            this.DG_View_Orders.AllowUserToDeleteRows = false;
            this.DG_View_Orders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_Orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_Orders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_OrderId,
            this.COL_OrderNumber,
            this.COL_Person,
            this.COL_Room});
            this.DG_View_Orders.Location = new System.Drawing.Point(15, 55);
            this.DG_View_Orders.Name = "DG_View_Orders";
            this.DG_View_Orders.RowHeadersWidth = 51;
            this.DG_View_Orders.RowTemplate.Height = 24;
            this.DG_View_Orders.Size = new System.Drawing.Size(755, 452);
            this.DG_View_Orders.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(568, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 36);
            this.button1.TabIndex = 9;
            this.button1.Text = "Сформировать договора";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // COL_OrderId
            // 
            this.COL_OrderId.FalseValue = "false";
            this.COL_OrderId.HeaderText = "Выбор";
            this.COL_OrderId.MinimumWidth = 6;
            this.COL_OrderId.Name = "COL_OrderId";
            this.COL_OrderId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_OrderId.TrueValue = "true";
            this.COL_OrderId.Width = 125;
            // 
            // COL_OrderNumber
            // 
            this.COL_OrderNumber.HeaderText = "Номер договра";
            this.COL_OrderNumber.MinimumWidth = 6;
            this.COL_OrderNumber.Name = "COL_OrderNumber";
            this.COL_OrderNumber.ReadOnly = true;
            this.COL_OrderNumber.Width = 125;
            // 
            // COL_Person
            // 
            this.COL_Person.HeaderText = "Жилец";
            this.COL_Person.MinimumWidth = 6;
            this.COL_Person.Name = "COL_Person";
            this.COL_Person.ReadOnly = true;
            this.COL_Person.Width = 125;
            // 
            // COL_Room
            // 
            this.COL_Room.HeaderText = "Номер комнаты";
            this.COL_Room.MinimumWidth = 6;
            this.COL_Room.Name = "COL_Room";
            this.COL_Room.ReadOnly = true;
            this.COL_Room.Width = 125;
            // 
            // AddtionalServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DG_View_Orders);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.label4);
            this.Name = "AddtionalServices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дополнительные услуги";
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Orders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.DataGridView DG_View_Orders;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COL_OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Person;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Room;
    }
}