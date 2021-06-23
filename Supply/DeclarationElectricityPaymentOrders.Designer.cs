namespace Supply
{
    partial class DeclarationElectricityPaymentOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationElectricityPaymentOrders));
            this.DG_View_ElectricityOrders = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_ElectricityOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View_ElectricityOrders
            // 
            this.DG_View_ElectricityOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_ElectricityOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_ElectricityOrders.Location = new System.Drawing.Point(13, 13);
            this.DG_View_ElectricityOrders.Name = "DG_View_ElectricityOrders";
            this.DG_View_ElectricityOrders.Size = new System.Drawing.Size(775, 396);
            this.DG_View_ElectricityOrders.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(649, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сформировать";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DeclarationElectricityPaymentOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DG_View_ElectricityOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationElectricityPaymentOrders";
            this.Text = "Договора оплаты электроэнергии";
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_ElectricityOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View_ElectricityOrders;
        private System.Windows.Forms.Button button1;
    }
}