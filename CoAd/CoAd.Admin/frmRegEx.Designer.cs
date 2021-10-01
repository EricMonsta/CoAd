namespace CoAd.Admin
{
    partial class frmRegEx
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pcFavoriteRegex = new DevExpress.XtraEditors.PanelControl();
            this.gcFavRegex = new DevExpress.XtraGrid.GridControl();
            this.gvFavRegex = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcInput = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRegex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.teRegEx = new DevExpress.XtraEditors.ButtonEdit();
            this.teTestValue = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbcResult = new DevExpress.XtraEditors.ListBoxControl();
            this.sbTest = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pcFavoriteRegex)).BeginInit();
            this.pcFavoriteRegex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFavRegex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFavRegex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRegEx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTestValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pcFavoriteRegex
            // 
            this.pcFavoriteRegex.Controls.Add(this.gcFavRegex);
            this.pcFavoriteRegex.Location = new System.Drawing.Point(12, 51);
            this.pcFavoriteRegex.Name = "pcFavoriteRegex";
            this.pcFavoriteRegex.Size = new System.Drawing.Size(336, 174);
            this.pcFavoriteRegex.TabIndex = 19;
            this.pcFavoriteRegex.Visible = false;
            // 
            // gcFavRegex
            // 
            this.gcFavRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcFavRegex.Location = new System.Drawing.Point(2, 2);
            this.gcFavRegex.MainView = this.gvFavRegex;
            this.gcFavRegex.Name = "gcFavRegex";
            this.gcFavRegex.Size = new System.Drawing.Size(332, 170);
            this.gcFavRegex.TabIndex = 0;
            this.gcFavRegex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFavRegex});
            this.gcFavRegex.DoubleClick += new System.EventHandler(this.gcFavRegex_DoubleClick);
            // 
            // gvFavRegex
            // 
            this.gvFavRegex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcInput,
            this.gcDesc,
            this.gcRegex});
            this.gvFavRegex.GridControl = this.gcFavRegex;
            this.gvFavRegex.Name = "gvFavRegex";
            this.gvFavRegex.OptionsBehavior.Editable = false;
            this.gvFavRegex.OptionsCustomization.AllowColumnMoving = false;
            this.gvFavRegex.OptionsCustomization.AllowColumnResizing = false;
            this.gvFavRegex.OptionsCustomization.AllowFilter = false;
            this.gvFavRegex.OptionsCustomization.AllowGroup = false;
            this.gvFavRegex.OptionsCustomization.AllowSort = false;
            this.gvFavRegex.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gvFavRegex.OptionsFilter.AllowFilterEditor = false;
            this.gvFavRegex.OptionsFilter.AllowMRUFilterList = false;
            this.gvFavRegex.OptionsMenu.EnableColumnMenu = false;
            this.gvFavRegex.OptionsMenu.EnableFooterMenu = false;
            this.gvFavRegex.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvFavRegex.OptionsView.EnableAppearanceEvenRow = true;
            this.gvFavRegex.OptionsView.EnableAppearanceOddRow = true;
            this.gvFavRegex.OptionsView.RowAutoHeight = true;
            this.gvFavRegex.OptionsView.ShowColumnHeaders = false;
            this.gvFavRegex.OptionsView.ShowDetailButtons = false;
            this.gvFavRegex.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvFavRegex.OptionsView.ShowGroupPanel = false;
            this.gvFavRegex.OptionsView.ShowIndicator = false;
            // 
            // gcInput
            // 
            this.gcInput.Caption = "Значение";
            this.gcInput.FieldName = "input";
            this.gcInput.Name = "gcInput";
            this.gcInput.Visible = true;
            this.gcInput.VisibleIndex = 0;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Описание";
            this.gcDesc.FieldName = "desc";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 1;
            // 
            // gcRegex
            // 
            this.gcRegex.Caption = "Регулярное выражение";
            this.gcRegex.FieldName = "regex";
            this.gcRegex.Name = "gcRegex";
            // 
            // teRegEx
            // 
            this.teRegEx.Location = new System.Drawing.Point(11, 29);
            this.teRegEx.Name = "teRegEx";
            this.teRegEx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Часто используемые регулярные выражения", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.teRegEx.Size = new System.Drawing.Size(337, 20);
            this.teRegEx.TabIndex = 18;
            this.teRegEx.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.teRegEx_ButtonClick);
            // 
            // teTestValue
            // 
            this.teTestValue.Location = new System.Drawing.Point(11, 65);
            this.teTestValue.Name = "teTestValue";
            this.teTestValue.Size = new System.Drawing.Size(263, 56);
            this.teTestValue.TabIndex = 17;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 108);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 13);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Результат";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(103, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Тестируемая строка";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(120, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Регулярное выражение";
            // 
            // lbcResult
            // 
            this.lbcResult.Location = new System.Drawing.Point(12, 130);
            this.lbcResult.Name = "lbcResult";
            this.lbcResult.Size = new System.Drawing.Size(336, 100);
            this.lbcResult.TabIndex = 13;
            // 
            // sbTest
            // 
            this.sbTest.Location = new System.Drawing.Point(280, 80);
            this.sbTest.Name = "sbTest";
            this.sbTest.Size = new System.Drawing.Size(70, 22);
            this.sbTest.TabIndex = 12;
            this.sbTest.Text = "Проверка";
            this.sbTest.Click += new System.EventHandler(this.sbTest_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sbtnCancel.Location = new System.Drawing.Point(189, 242);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 21;
            this.sbtnCancel.Text = "Отмена";
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnOk
            // 
            this.sbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sbtnOk.CausesValidation = false;
            this.sbtnOk.Location = new System.Drawing.Point(95, 242);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 20;
            this.sbtnOk.Text = "OK";
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // frmRegEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 277);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.pcFavoriteRegex);
            this.Controls.Add(this.teRegEx);
            this.Controls.Add(this.teTestValue);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lbcResult);
            this.Controls.Add(this.sbTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegEx";
            this.Text = "Регулярное выражение";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmRegEx_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pcFavoriteRegex)).EndInit();
            this.pcFavoriteRegex.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcFavRegex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFavRegex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRegEx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTestValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcFavoriteRegex;
        private DevExpress.XtraGrid.GridControl gcFavRegex;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFavRegex;
        private DevExpress.XtraGrid.Columns.GridColumn gcInput;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcRegex;
        private DevExpress.XtraEditors.ButtonEdit teRegEx;
        private DevExpress.XtraEditors.MemoEdit teTestValue;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ListBoxControl lbcResult;
        private DevExpress.XtraEditors.SimpleButton sbTest;
        public DevExpress.XtraEditors.SimpleButton sbtnCancel;
        public DevExpress.XtraEditors.SimpleButton sbtnOk;
    }
}