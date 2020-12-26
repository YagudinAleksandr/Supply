
namespace Supply_Admin
{
    partial class OrdersManager
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
            this.DG_View_Orders = new System.Windows.Forms.DataGridView();
            this.COL_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Human = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Hostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Rent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Benifit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Edited = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_OrderNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.TB_OrderStart = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Orders)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_Orders
            // 
            this.DG_View_Orders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_Orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_Orders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_Id,
            this.COL_Human,
            this.COL_Room,
            this.COL_Hostel,
            this.COL_Rent,
            this.COL_StartDate,
            this.COL_EndDate,
            this.COL_Benifit,
            this.COL_Edited});
            this.DG_View_Orders.Location = new System.Drawing.Point(13, 85);
            this.DG_View_Orders.Name = "DG_View_Orders";
            this.DG_View_Orders.RowHeadersWidth = 51;
            this.DG_View_Orders.RowTemplate.Height = 24;
            this.DG_View_Orders.Size = new System.Drawing.Size(1346, 539);
            this.DG_View_Orders.TabIndex = 0;
            // 
            // COL_Id
            // 
            this.COL_Id.HeaderText = "Номер договора";
            this.COL_Id.MinimumWidth = 6;
            this.COL_Id.Name = "COL_Id";
            this.COL_Id.ReadOnly = true;
            this.COL_Id.Width = 125;
            // 
            // COL_Human
            // 
            this.COL_Human.HeaderText = "Офромлен договора на";
            this.COL_Human.MinimumWidth = 6;
            this.COL_Human.Name = "COL_Human";
            this.COL_Human.ReadOnly = true;
            this.COL_Human.Width = 250;
            // 
            // COL_Room
            // 
            this.COL_Room.HeaderText = "Комната";
            this.COL_Room.MinimumWidth = 6;
            this.COL_Room.Name = "COL_Room";
            this.COL_Room.ReadOnly = true;
            this.COL_Room.Width = 125;
            // 
            // COL_Hostel
            // 
            this.COL_Hostel.HeaderText = "Общежитие ";
            this.COL_Hostel.MinimumWidth = 6;
            this.COL_Hostel.Name = "COL_Hostel";
            this.COL_Hostel.Width = 125;
            // 
            // COL_Rent
            // 
            this.COL_Rent.HeaderText = "На период";
            this.COL_Rent.MinimumWidth = 6;
            this.COL_Rent.Name = "COL_Rent";
            this.COL_Rent.ReadOnly = true;
            this.COL_Rent.Width = 125;
            // 
            // COL_StartDate
            // 
            this.COL_StartDate.HeaderText = "Дата начала договора";
            this.COL_StartDate.MinimumWidth = 6;
            this.COL_StartDate.Name = "COL_StartDate";
            this.COL_StartDate.ReadOnly = true;
            this.COL_StartDate.Width = 125;
            // 
            // COL_EndDate
            // 
            this.COL_EndDate.HeaderText = "Дата окончания договора";
            this.COL_EndDate.MinimumWidth = 6;
            this.COL_EndDate.Name = "COL_EndDate";
            this.COL_EndDate.ReadOnly = true;
            this.COL_EndDate.Width = 125;
            // 
            // COL_Benifit
            // 
            this.COL_Benifit.HeaderText = "Наличие льготы";
            this.COL_Benifit.MinimumWidth = 6;
            this.COL_Benifit.Name = "COL_Benifit";
            this.COL_Benifit.ReadOnly = true;
            this.COL_Benifit.Width = 125;
            // 
            // COL_Edited
            // 
            this.COL_Edited.HeaderText = "Имеются дополнения к договору";
            this.COL_Edited.MinimumWidth = 6;
            this.COL_Edited.Name = "COL_Edited";
            this.COL_Edited.ReadOnly = true;
            this.COL_Edited.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "№ Договора";
            // 
            // TB_OrderNumber
            // 
            this.TB_OrderNumber.Location = new System.Drawing.Point(109, 30);
            this.TB_OrderNumber.Name = "TB_OrderNumber";
            this.TB_OrderNumber.Size = new System.Drawing.Size(100, 22);
            this.TB_OrderNumber.TabIndex = 2;
            this.TB_OrderNumber.TextChanged += new System.EventHandler(this.TB_OrderNumber_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата заключения договора";
            // 
            // BTN_Create
            // 
            this.BTN_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Create.Location = new System.Drawing.Point(1136, 668);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(223, 32);
            this.BTN_Create.TabIndex = 5;
            this.BTN_Create.Text = "Сформировать договра";
            this.BTN_Create.UseVisualStyleBackColor = true;
            this.BTN_Create.Click += new System.EventHandler(this.BTN_Create_Click);
            // 
            // TB_OrderStart
            // 
            this.TB_OrderStart.Location = new System.Drawing.Point(425, 30);
            this.TB_OrderStart.Name = "TB_OrderStart";
            this.TB_OrderStart.Size = new System.Drawing.Size(100, 22);
            this.TB_OrderStart.TabIndex = 6;
            this.TB_OrderStart.TextChanged += new System.EventHandler(this.TB_OrderStart_TextChanged);
            // 
            // OrdersManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 743);
            this.Controls.Add(this.TB_OrderStart);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_OrderNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DG_View_Orders);
            this.Name = "OrdersManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список договоров";
            this.Shown += new System.EventHandler(this.OrdersManager_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Orders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_Orders;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Human;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Hostel;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Rent;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Benifit;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Edited;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_OrderNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_Create;
        private System.Windows.Forms.TextBox TB_OrderStart;
    }
}