namespace CoAd.Admin
{
    partial class frmSelectParam
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
            DevExpress.XtraTreeList.FilterCondition filterCondition1 = new DevExpress.XtraTreeList.FilterCondition();
            this.colname_str_cash_param = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.labDevGroup = new System.Windows.Forms.Label();
            this.edSearch = new DevExpress.XtraEditors.TextEdit();
            this.tlPosParams = new DevExpress.XtraTreeList.TreeList();
            this.tlcol_id = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcol_mnem = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcol_desc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlPosParams)).BeginInit();
            this.SuspendLayout();
            // 
            // colname_str_cash_param
            // 
            this.colname_str_cash_param.Caption = "Наименование";
            this.colname_str_cash_param.FieldName = "name";
            this.colname_str_cash_param.Name = "colname_str_cash_param";
            this.colname_str_cash_param.Visible = true;
            this.colname_str_cash_param.VisibleIndex = 0;
            this.colname_str_cash_param.Width = 65;
            // 
            // labDevGroup
            // 
            this.labDevGroup.AutoSize = true;
            this.labDevGroup.Location = new System.Drawing.Point(12, 9);
            this.labDevGroup.Name = "labDevGroup";
            this.labDevGroup.Size = new System.Drawing.Size(47, 13);
            this.labDevGroup.TabIndex = 8;
            this.labDevGroup.Text = "Фильтр";
            // 
            // edSearch
            // 
            this.edSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edSearch.Location = new System.Drawing.Point(65, 6);
            this.edSearch.Name = "edSearch";
            this.edSearch.Size = new System.Drawing.Size(393, 20);
            this.edSearch.TabIndex = 6;
            this.edSearch.EditValueChanged += new System.EventHandler(this.edSearch_EditValueChanged);
            // 
            // tlPosParams
            // 
            this.tlPosParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlPosParams.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow;
            this.tlPosParams.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tlPosParams.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.tlPosParams.Appearance.FocusedRow.Options.UseFont = true;
            this.tlPosParams.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tlPosParams.Appearance.Preview.ForeColor = System.Drawing.Color.White;
            this.tlPosParams.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colname_str_cash_param,
            this.tlcol_id,
            this.tlcol_mnem,
            this.tlcol_desc});
            this.tlPosParams.DataSource = null;
            filterCondition1.Column = this.colname_str_cash_param;
            filterCondition1.Condition = DevExpress.XtraTreeList.FilterConditionEnum.Like;
            filterCondition1.Value1 = "<Null>";
            filterCondition1.Visible = true;
            this.tlPosParams.FilterConditions.AddRange(new DevExpress.XtraTreeList.FilterCondition[] {
            filterCondition1});
            this.tlPosParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tlPosParams.KeyFieldName = "id_str_cash_param";
            this.tlPosParams.Location = new System.Drawing.Point(12, 32);
            this.tlPosParams.Name = "tlPosParams";
            this.tlPosParams.OptionsBehavior.AutoChangeParent = false;
            this.tlPosParams.OptionsBehavior.Editable = false;
            this.tlPosParams.OptionsMenu.EnableColumnMenu = false;
            this.tlPosParams.OptionsMenu.EnableFooterMenu = false;
            this.tlPosParams.OptionsView.AutoCalcPreviewLineCount = true;
            this.tlPosParams.OptionsView.ShowColumns = false;
            this.tlPosParams.OptionsView.ShowIndicator = false;
            this.tlPosParams.OptionsView.ShowPreview = true;
            this.tlPosParams.ParentFieldName = "parent";
            this.tlPosParams.PreviewFieldName = "description";
            this.tlPosParams.PreviewLineCount = 5;
            this.tlPosParams.Size = new System.Drawing.Size(446, 410);
            this.tlPosParams.TabIndex = 7;
            this.tlPosParams.DoubleClick += new System.EventHandler(this.tlPosParams_DoubleClick);
            // 
            // tlcol_id
            // 
            this.tlcol_id.Caption = "tlcol_id";
            this.tlcol_id.FieldName = "id_type";
            this.tlcol_id.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.tlcol_id.Name = "tlcol_id";
            // 
            // tlcol_mnem
            // 
            this.tlcol_mnem.FieldName = "mnem_param";
            this.tlcol_mnem.Name = "tlcol_mnem";
            // 
            // tlcol_desc
            // 
            this.tlcol_desc.FieldName = "description";
            this.tlcol_desc.Name = "tlcol_desc";
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(246, 449);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 14;
            this.sbtnCancel.Text = "Отмена";
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnOk
            // 
            this.sbtnOk.CausesValidation = false;
            this.sbtnOk.Location = new System.Drawing.Point(152, 449);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 13;
            this.sbtnOk.Text = "OK";
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // frmSelectParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 484);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.labDevGroup);
            this.Controls.Add(this.edSearch);
            this.Controls.Add(this.tlPosParams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSelectParam";
            this.Text = "Выберите параметр";
            ((System.ComponentModel.ISupportInitialize)(this.edSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlPosParams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labDevGroup;
        private DevExpress.XtraEditors.TextEdit edSearch;
        private DevExpress.XtraTreeList.TreeList tlPosParams;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colname_str_cash_param;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcol_id;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcol_mnem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcol_desc;
        public DevExpress.XtraEditors.SimpleButton sbtnCancel;
        public DevExpress.XtraEditors.SimpleButton sbtnOk;
    }
}