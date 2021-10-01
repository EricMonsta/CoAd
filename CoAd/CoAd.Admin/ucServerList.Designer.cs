namespace CoAd.Admin
{
    partial class ucServerList
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucServerList));
            this.gcServerList = new DevExpress.XtraGrid.GridControl();
            this.gvServerList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.identifierGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.configurationGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statusGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.addButton = new DevExpress.XtraEditors.SimpleButton();
            this.delButton = new DevExpress.XtraEditors.SimpleButton();
            this.editButton = new DevExpress.XtraEditors.SimpleButton();
            this.treeButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcServerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvServerList)).BeginInit();
            this.SuspendLayout();
            // 
            // gcServerList
            // 
            this.gcServerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcServerList.Location = new System.Drawing.Point(4, 39);
            this.gcServerList.MainView = this.gvServerList;
            this.gcServerList.Name = "gcServerList";
            this.gcServerList.Size = new System.Drawing.Size(708, 367);
            this.gcServerList.TabIndex = 1;
            this.gcServerList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvServerList});
            // 
            // gvServerList
            // 
            this.gvServerList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idGridColumn,
            this.nameGridColumn,
            this.identifierGridColumn,
            this.configurationGridColumn,
            this.statusGridColumn});
            this.gvServerList.GridControl = this.gcServerList;
            this.gvServerList.Name = "gvServerList";
            this.gvServerList.OptionsBehavior.Editable = false;
            this.gvServerList.OptionsDetail.EnableMasterViewMode = false;
            this.gvServerList.OptionsView.ShowDetailButtons = false;
            // 
            // idGridColumn
            // 
            this.idGridColumn.Caption = "Id";
            this.idGridColumn.FieldName = "id";
            this.idGridColumn.Name = "idGridColumn";
            // 
            // nameGridColumn
            // 
            this.nameGridColumn.Caption = "Имя";
            this.nameGridColumn.FieldName = "name";
            this.nameGridColumn.Name = "nameGridColumn";
            this.nameGridColumn.Visible = true;
            this.nameGridColumn.VisibleIndex = 1;
            // 
            // identifierGridColumn
            // 
            this.identifierGridColumn.Caption = "Идентификатор";
            this.identifierGridColumn.FieldName = "identifier";
            this.identifierGridColumn.Name = "identifierGridColumn";
            this.identifierGridColumn.Visible = true;
            this.identifierGridColumn.VisibleIndex = 0;
            // 
            // configurationGridColumn
            // 
            this.configurationGridColumn.Caption = "Конфигурация";
            this.configurationGridColumn.FieldName = "configuration";
            this.configurationGridColumn.Name = "configurationGridColumn";
            this.configurationGridColumn.Visible = true;
            this.configurationGridColumn.VisibleIndex = 2;
            // 
            // statusGridColumn
            // 
            this.statusGridColumn.Caption = "Статус";
            this.statusGridColumn.FieldName = "status";
            this.statusGridColumn.Name = "statusGridColumn";
            this.statusGridColumn.Visible = true;
            this.statusGridColumn.VisibleIndex = 3;
            // 
            // addButton
            // 
            this.addButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("addButton.ImageOptions.Image")));
            this.addButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.addButton.Location = new System.Drawing.Point(4, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(32, 32);
            this.addButton.TabIndex = 2;
            this.addButton.ToolTip = "Добавить";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // delButton
            // 
            this.delButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("delButton.ImageOptions.Image")));
            this.delButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.delButton.Location = new System.Drawing.Point(42, 3);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(32, 32);
            this.delButton.TabIndex = 3;
            this.delButton.ToolTip = "Удалить";
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // editButton
            // 
            this.editButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("editButton.ImageOptions.Image")));
            this.editButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.editButton.Location = new System.Drawing.Point(80, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(32, 32);
            this.editButton.TabIndex = 4;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // treeButton
            // 
            this.treeButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("treeButton.ImageOptions.Image")));
            this.treeButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.treeButton.Location = new System.Drawing.Point(118, 3);
            this.treeButton.Name = "treeButton";
            this.treeButton.Size = new System.Drawing.Size(32, 32);
            this.treeButton.TabIndex = 5;
            // 
            // ucServerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.gcServerList);
            this.Name = "ucServerList";
            this.Size = new System.Drawing.Size(715, 409);
            ((System.ComponentModel.ISupportInitialize)(this.gcServerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvServerList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcServerList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvServerList;
        private DevExpress.XtraGrid.Columns.GridColumn idGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn identifierGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn nameGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn configurationGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn statusGridColumn;
        private DevExpress.XtraEditors.SimpleButton addButton;
        private DevExpress.XtraEditors.SimpleButton delButton;
        private DevExpress.XtraEditors.SimpleButton editButton;
        private DevExpress.XtraEditors.SimpleButton treeButton;
    }
}
