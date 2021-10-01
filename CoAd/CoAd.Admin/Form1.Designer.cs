namespace CoAd.Admin
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.clientsNavBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.serverListNavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.structureNavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.manageNavBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.storesNavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.devicesNavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.devGroupNavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.centralizationNavBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.cashGroupNavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.synchronizationNavBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.syncNavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barSubItem2,
            this.barSubItem3,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Главное меню";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Главное меню";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Приложение";
            this.barSubItem1.Id = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Настройки";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Сервис";
            this.barSubItem2.Id = 1;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Управление службой";
            this.barButtonItem2.Id = 4;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Справка";
            this.barSubItem3.Id = 2;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "О программе";
            this.barButtonItem3.Id = 5;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // bar3
            // 
            this.bar3.BarName = "Строка состояния";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Строка состояния";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(800, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 592);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 570);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 22);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 570);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.clientsNavBarGroup;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.clientsNavBarGroup,
            this.manageNavBarGroup,
            this.centralizationNavBarGroup,
            this.synchronizationNavBarGroup});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.serverListNavBarItem,
            this.structureNavBarItem,
            this.storesNavBarItem,
            this.devicesNavBarItem,
            this.devGroupNavBarItem,
            this.cashGroupNavBarItem,
            this.syncNavBarItem});
            this.navBarControl1.Location = new System.Drawing.Point(0, 22);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl1.Size = new System.Drawing.Size(140, 570);
            this.navBarControl1.TabIndex = 5;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // clientsNavBarGroup
            // 
            this.clientsNavBarGroup.Caption = "Клиенты";
            this.clientsNavBarGroup.Expanded = true;
            this.clientsNavBarGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.serverListNavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.structureNavBarItem)});
            this.clientsNavBarGroup.Name = "clientsNavBarGroup";
            // 
            // serverListNavBarItem
            // 
            this.serverListNavBarItem.Caption = "Список серверов";
            this.serverListNavBarItem.Name = "serverListNavBarItem";
            this.serverListNavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.serverListNavBarItem_LinkClicked);
            // 
            // structureNavBarItem
            // 
            this.structureNavBarItem.Caption = "Структура";
            this.structureNavBarItem.Name = "structureNavBarItem";
            this.structureNavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.structureNavBarItem_LinkClicked);
            // 
            // manageNavBarGroup
            // 
            this.manageNavBarGroup.Caption = "Управление";
            this.manageNavBarGroup.Expanded = true;
            this.manageNavBarGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.storesNavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.devicesNavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.devGroupNavBarItem)});
            this.manageNavBarGroup.Name = "manageNavBarGroup";
            // 
            // storesNavBarItem
            // 
            this.storesNavBarItem.Caption = "Магазины";
            this.storesNavBarItem.Name = "storesNavBarItem";
            this.storesNavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.storesNavBarItem_LinkClicked);
            // 
            // devicesNavBarItem
            // 
            this.devicesNavBarItem.Caption = "Устройства";
            this.devicesNavBarItem.Name = "devicesNavBarItem";
            this.devicesNavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.devicesNavBarItem_LinkClicked);
            // 
            // devGroupNavBarItem
            // 
            this.devGroupNavBarItem.Caption = "Группа касс";
            this.devGroupNavBarItem.Name = "devGroupNavBarItem";
            this.devGroupNavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.devGroupNavBarItem_LinkClicked);
            // 
            // centralizationNavBarGroup
            // 
            this.centralizationNavBarGroup.Caption = "Централизация";
            this.centralizationNavBarGroup.Expanded = true;
            this.centralizationNavBarGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.cashGroupNavBarItem)});
            this.centralizationNavBarGroup.Name = "centralizationNavBarGroup";
            // 
            // cashGroupNavBarItem
            // 
            this.cashGroupNavBarItem.Caption = "Группа касс";
            this.cashGroupNavBarItem.Name = "cashGroupNavBarItem";
            this.cashGroupNavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.cashGroupNavBarItem_LinkClicked);
            // 
            // synchronizationNavBarGroup
            // 
            this.synchronizationNavBarGroup.Caption = "Синхронизация";
            this.synchronizationNavBarGroup.Expanded = true;
            this.synchronizationNavBarGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.syncNavBarItem)});
            this.synchronizationNavBarGroup.Name = "synchronizationNavBarGroup";
            // 
            // syncNavBarItem
            // 
            this.syncNavBarItem.Caption = "Синхронизация";
            this.syncNavBarItem.Name = "syncNavBarItem";
            this.syncNavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.syncNavBarItem_LinkClicked);
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(140, 22);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(660, 570);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Наименование раздела";
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 20);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(656, 548);
            this.panelControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 615);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Центр администрирования DKlink FO";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup clientsNavBarGroup;
        private DevExpress.XtraNavBar.NavBarItem serverListNavBarItem;
        private DevExpress.XtraNavBar.NavBarItem structureNavBarItem;
        private DevExpress.XtraNavBar.NavBarGroup manageNavBarGroup;
        private DevExpress.XtraNavBar.NavBarItem storesNavBarItem;
        private DevExpress.XtraNavBar.NavBarItem devicesNavBarItem;
        private DevExpress.XtraNavBar.NavBarItem devGroupNavBarItem;
        private DevExpress.XtraNavBar.NavBarGroup centralizationNavBarGroup;
        private DevExpress.XtraNavBar.NavBarItem cashGroupNavBarItem;
        private DevExpress.XtraNavBar.NavBarGroup synchronizationNavBarGroup;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraNavBar.NavBarItem syncNavBarItem;
    }
}

