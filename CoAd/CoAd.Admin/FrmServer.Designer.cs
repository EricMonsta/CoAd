namespace CoAd.Admin
{
    partial class FrmServer
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
            this.idLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbConfig = new System.Windows.Forms.RichTextBox();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(13, 13);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(90, 13);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "Идентификатор:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 46);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(83, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Наименование";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(125, 43);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(264, 20);
            this.tbName.TabIndex = 2;
            // 
            // tbConfig
            // 
            this.tbConfig.Location = new System.Drawing.Point(16, 72);
            this.tbConfig.Name = "tbConfig";
            this.tbConfig.Size = new System.Drawing.Size(373, 154);
            this.tbConfig.TabIndex = 3;
            this.tbConfig.Text = "";
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(209, 234);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 12;
            this.sbtnCancel.Text = "Отмена";
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnOk
            // 
            this.sbtnOk.CausesValidation = false;
            this.sbtnOk.Location = new System.Drawing.Point(115, 234);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 11;
            this.sbtnOk.Text = "OK";
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 269);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.tbConfig);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.idLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmServer";
            this.Text = "FrmServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.RichTextBox tbConfig;
        public DevExpress.XtraEditors.SimpleButton sbtnCancel;
        public DevExpress.XtraEditors.SimpleButton sbtnOk;
    }
}