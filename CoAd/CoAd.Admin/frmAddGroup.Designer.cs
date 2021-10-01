namespace CoAd.Admin
{
    partial class frmAddGroup
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
            this.gcGroups = new DevExpress.XtraGrid.GridControl();
            this.gvGroups = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
            this.nameGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // gcGroups
            // 
            this.gcGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcGroups.Location = new System.Drawing.Point(12, 12);
            this.gcGroups.MainView = this.gvGroups;
            this.gcGroups.Name = "gcGroups";
            this.gcGroups.Size = new System.Drawing.Size(436, 395);
            this.gcGroups.TabIndex = 0;
            this.gcGroups.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGroups});
            // 
            // gvGroups
            // 
            this.gvGroups.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nameGridColumn,
            this.idGridColumn});
            this.gvGroups.GridControl = this.gcGroups;
            this.gvGroups.Name = "gvGroups";
            this.gvGroups.OptionsView.ShowDetailButtons = false;
            this.gvGroups.OptionsView.ShowGroupPanel = false;
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sbtnCancel.Location = new System.Drawing.Point(240, 413);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 16;
            this.sbtnCancel.Text = "Отмена";
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnOk
            // 
            this.sbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sbtnOk.CausesValidation = false;
            this.sbtnOk.Location = new System.Drawing.Point(146, 413);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 15;
            this.sbtnOk.Text = "OK";
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // nameGridColumn
            // 
            this.nameGridColumn.Caption = "Имя";
            this.nameGridColumn.FieldName = "name";
            this.nameGridColumn.Name = "nameGridColumn";
            this.nameGridColumn.Visible = true;
            this.nameGridColumn.VisibleIndex = 0;
            // 
            // idGridColumn
            // 
            this.idGridColumn.Caption = "Id";
            this.idGridColumn.FieldName = "id";
            this.idGridColumn.Name = "idGridColumn";
            // 
            // frmAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 450);
            this.ControlBox = false;
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.gcGroups);
            this.Name = "frmAddGroup";
            this.Text = "Выберите группу";
            ((System.ComponentModel.ISupportInitialize)(this.gcGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gcGroups;
        public DevExpress.XtraGrid.Views.Grid.GridView gvGroups;
        public DevExpress.XtraEditors.SimpleButton sbtnCancel;
        public DevExpress.XtraEditors.SimpleButton sbtnOk;
        private DevExpress.XtraGrid.Columns.GridColumn nameGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn idGridColumn;
    }
}