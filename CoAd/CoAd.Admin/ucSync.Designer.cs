namespace CoAd.Admin
{
    partial class ucSync
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
            this.gcServerList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.identifierGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.configurationGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statusGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelStores = new DevExpress.XtraEditors.LabelControl();
            this.labelDevices = new DevExpress.XtraEditors.LabelControl();
            this.labelGroupDevices = new DevExpress.XtraEditors.LabelControl();
            this.btnSyncCurrent = new DevExpress.XtraEditors.SimpleButton();
            this.btnSyncAll = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcServerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcServerList
            // 
            this.gcServerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcServerList.Location = new System.Drawing.Point(3, 3);
            this.gcServerList.MainView = this.gridView1;
            this.gcServerList.Name = "gcServerList";
            this.gcServerList.Size = new System.Drawing.Size(726, 211);
            this.gcServerList.TabIndex = 2;
            this.gcServerList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idGridColumn,
            this.identifierGridColumn,
            this.nameGridColumn,
            this.configurationGridColumn,
            this.statusGridColumn});
            this.gridView1.GridControl = this.gcServerList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // idGridColumn
            // 
            this.idGridColumn.Caption = "Id";
            this.idGridColumn.FieldName = "id";
            this.idGridColumn.Name = "idGridColumn";
            this.idGridColumn.Visible = true;
            this.idGridColumn.VisibleIndex = 0;
            // 
            // identifierGridColumn
            // 
            this.identifierGridColumn.Caption = "Identifier";
            this.identifierGridColumn.FieldName = "identifier";
            this.identifierGridColumn.Name = "identifierGridColumn";
            this.identifierGridColumn.Visible = true;
            this.identifierGridColumn.VisibleIndex = 1;
            // 
            // nameGridColumn
            // 
            this.nameGridColumn.Caption = "Name";
            this.nameGridColumn.FieldName = "name";
            this.nameGridColumn.Name = "nameGridColumn";
            this.nameGridColumn.Visible = true;
            this.nameGridColumn.VisibleIndex = 2;
            // 
            // configurationGridColumn
            // 
            this.configurationGridColumn.Caption = "Configuration";
            this.configurationGridColumn.FieldName = "configuration";
            this.configurationGridColumn.Name = "configurationGridColumn";
            this.configurationGridColumn.Visible = true;
            this.configurationGridColumn.VisibleIndex = 3;
            // 
            // statusGridColumn
            // 
            this.statusGridColumn.Caption = "Status";
            this.statusGridColumn.FieldName = "status";
            this.statusGridColumn.Name = "statusGridColumn";
            this.statusGridColumn.Visible = true;
            this.statusGridColumn.VisibleIndex = 4;
            // 
            // labelStores
            // 
            this.labelStores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStores.Location = new System.Drawing.Point(9, 233);
            this.labelStores.Name = "labelStores";
            this.labelStores.Size = new System.Drawing.Size(50, 13);
            this.labelStores.TabIndex = 3;
            this.labelStores.Text = "Магазины";
            // 
            // labelDevices
            // 
            this.labelDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDevices.Location = new System.Drawing.Point(9, 252);
            this.labelDevices.Name = "labelDevices";
            this.labelDevices.Size = new System.Drawing.Size(59, 13);
            this.labelDevices.TabIndex = 4;
            this.labelDevices.Text = "Устройства";
            // 
            // labelGroupDevices
            // 
            this.labelGroupDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelGroupDevices.Location = new System.Drawing.Point(9, 271);
            this.labelGroupDevices.Name = "labelGroupDevices";
            this.labelGroupDevices.Size = new System.Drawing.Size(63, 13);
            this.labelGroupDevices.TabIndex = 5;
            this.labelGroupDevices.Text = "Группы касс";
            // 
            // btnSyncCurrent
            // 
            this.btnSyncCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSyncCurrent.Location = new System.Drawing.Point(9, 302);
            this.btnSyncCurrent.Name = "btnSyncCurrent";
            this.btnSyncCurrent.Size = new System.Drawing.Size(244, 23);
            this.btnSyncCurrent.TabIndex = 6;
            this.btnSyncCurrent.Text = "Синхронизировать данные сервера";
            // 
            // btnSyncAll
            // 
            this.btnSyncAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSyncAll.Location = new System.Drawing.Point(9, 331);
            this.btnSyncAll.Name = "btnSyncAll";
            this.btnSyncAll.Size = new System.Drawing.Size(244, 23);
            this.btnSyncAll.TabIndex = 7;
            this.btnSyncAll.Text = "Синхронизировать данные всех серверов";
            // 
            // ucSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSyncAll);
            this.Controls.Add(this.btnSyncCurrent);
            this.Controls.Add(this.labelGroupDevices);
            this.Controls.Add(this.labelDevices);
            this.Controls.Add(this.labelStores);
            this.Controls.Add(this.gcServerList);
            this.Name = "ucSync";
            this.Size = new System.Drawing.Size(732, 512);
            ((System.ComponentModel.ISupportInitialize)(this.gcServerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcServerList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn idGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn identifierGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn nameGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn configurationGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn statusGridColumn;
        private DevExpress.XtraEditors.LabelControl labelStores;
        private DevExpress.XtraEditors.LabelControl labelDevices;
        private DevExpress.XtraEditors.LabelControl labelGroupDevices;
        private DevExpress.XtraEditors.SimpleButton btnSyncCurrent;
        private DevExpress.XtraEditors.SimpleButton btnSyncAll;
    }
}
