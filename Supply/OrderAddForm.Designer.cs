
namespace Supply
{
    partial class OrderAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderAddForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_OrderNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_StartDate = new System.Windows.Forms.MaskedTextBox();
            this.TB_EndDate = new System.Windows.Forms.MaskedTextBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Managers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер договора";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата начала договора";
            // 
            // TB_OrderNumber
            // 
            this.TB_OrderNumber.Location = new System.Drawing.Point(249, 12);
            this.TB_OrderNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_OrderNumber.Name = "TB_OrderNumber";
            this.TB_OrderNumber.Size = new System.Drawing.Size(132, 22);
            this.TB_OrderNumber.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Дата окончания договора";
            // 
            // TB_StartDate
            // 
            this.TB_StartDate.Location = new System.Drawing.Point(249, 46);
            this.TB_StartDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_StartDate.Mask = "00/00/0000";
            this.TB_StartDate.Name = "TB_StartDate";
            this.TB_StartDate.Size = new System.Drawing.Size(132, 22);
            this.TB_StartDate.TabIndex = 4;
            this.TB_StartDate.ValidatingType = typeof(System.DateTime);
            // 
            // TB_EndDate
            // 
            this.TB_EndDate.Location = new System.Drawing.Point(249, 79);
            this.TB_EndDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_EndDate.Mask = "00/00/0000";
            this.TB_EndDate.Name = "TB_EndDate";
            this.TB_EndDate.Size = new System.Drawing.Size(132, 22);
            this.TB_EndDate.TabIndex = 5;
            this.TB_EndDate.ValidatingType = typeof(System.DateTime);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(480, 180);
            this.BTN_Save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(133, 28);
            this.BTN_Save.TabIndex = 6;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ответственное лицо";
            // 
            // CB_Managers
            // 
            this.CB_Managers.FormattingEnabled = true;
            this.CB_Managers.Location = new System.Drawing.Point(249, 112);
            this.CB_Managers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_Managers.Name = "CB_Managers";
            this.CB_Managers.Size = new System.Drawing.Size(363, 24);
            this.CB_Managers.TabIndex = 8;
            this.CB_Managers.SelectedIndexChanged += new System.EventHandler(this.CB_Managers_SelectedIndexChanged);
            // 
            // OrderAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 223);
            this.Controls.Add(this.CB_Managers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.TB_EndDate);
            this.Controls.Add(this.TB_StartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_OrderNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OrderAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание договора";
            this.Load += new System.EventHandler(this.OrderAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_OrderNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox TB_StartDate;
        private System.Windows.Forms.MaskedTextBox TB_EndDate;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_Managers;
    }
}