
namespace Supply
{
    partial class AdminManagersFormAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminManagersFormAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Surename = new System.Windows.Forms.TextBox();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.TB_Patronymic = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отчество";
            // 
            // TB_Surename
            // 
            this.TB_Surename.Location = new System.Drawing.Point(75, 10);
            this.TB_Surename.Name = "TB_Surename";
            this.TB_Surename.Size = new System.Drawing.Size(175, 20);
            this.TB_Surename.TabIndex = 3;
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(75, 45);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(175, 20);
            this.TB_Name.TabIndex = 4;
            // 
            // TB_Patronymic
            // 
            this.TB_Patronymic.Location = new System.Drawing.Point(73, 80);
            this.TB_Patronymic.Name = "TB_Patronymic";
            this.TB_Patronymic.Size = new System.Drawing.Size(175, 20);
            this.TB_Patronymic.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(9, 8);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(173, 125);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(75, 23);
            this.BTN_Add.TabIndex = 7;
            this.BTN_Add.Text = "Добавить";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // AdminManagersFormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 169);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TB_Patronymic);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.TB_Surename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminManagersFormAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление менеджера";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Surename;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.TextBox TB_Patronymic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BTN_Add;
    }
}