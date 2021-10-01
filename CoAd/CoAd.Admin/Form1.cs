using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoAd.Model;

namespace CoAd.Admin
{
    public partial class Form1 : Form
    {
        protected string ConfigFilePath { get { return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Admin.cfg"); } }

        public Configurator<AdminConfiguration> Configurator { get; protected set; }

        public AdminConfiguration CurrentConfig { get; protected set; }

        public Form1()
        {
            InitializeComponent();

            Configurator = new Configurator<AdminConfiguration> { ObjectPath = ConfigFilePath };
            
            if (File.Exists(ConfigFilePath))
            {
                Configurator.Load();
                CurrentConfig = Configurator.Object;
            }
            else
            {
                CurrentConfig = Configurator.Object = AdminConfiguration.Default;
                Configurator.Save();
            }

            //*****************************************************
            //Сама база и параметры подключения будут потом в model
            //*****************************************************
            //Base.ConnectionString = @"Data Source=192.168.1.66\SQLEXPRESS,1433;Initial Catalog=coad_test;User ID=sa;Password=mssql";
            Base.ConnectionString = CurrentConfig.GetConnectionString();
            Base.Init();
        }

        private void serverListNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl1.Controls.Clear();
            var UcServerList = new ucServerList() { Dock = DockStyle.Fill,  };
            groupControl1.Text = "Список серверов";
           
            panelControl1.Controls.Add(UcServerList);
            
        }

        private void storesNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl1.Controls.Clear();
            var UcStoresList = new ucStoresList() { Dock = DockStyle.Fill, };
            groupControl1.Text = "Магазины";

            panelControl1.Controls.Add(UcStoresList);
        }

        private void devicesNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl1.Controls.Clear();
            var UcDeviceList = new ucDeviceList() { Dock = DockStyle.Fill, };
            groupControl1.Text = "Устройства";

            panelControl1.Controls.Add(UcDeviceList);
        }

        private void structureNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl1.Controls.Clear();
            var UcTree = new ucTree() { Dock = DockStyle.Fill, };
            groupControl1.Text = "Структура";

            panelControl1.Controls.Add(UcTree);
        }

        private void devGroupNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl1.Controls.Clear();
            var UcDeviceGroups = new ucDeviceGroups() { Dock = DockStyle.Fill, };
            groupControl1.Text = "Группы касс";

            panelControl1.Controls.Add(UcDeviceGroups);
        }

        private void cashGroupNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl1.Controls.Clear();
            var UcDeviceGroups = new ucDeviceGroupsC() { Dock = DockStyle.Fill, };
            groupControl1.Text = "Группы касс";

            panelControl1.Controls.Add(UcDeviceGroups);
        }

        private void syncNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl1.Controls.Clear();
            var UcSync = new ucSync() { Dock = DockStyle.Fill, };
            groupControl1.Text = "Синхронизация";

            panelControl1.Controls.Add(UcSync);
        }
    }

    /// <summary>
    /// Контекст БД
    /// </summary>
    public static class Base
    {
        public static string ConnectionString;
        public static dsCoAdDataContext db;

        public static void Init()
        {
            db = new dsCoAdDataContext(new System.Data.SqlClient.SqlConnection(ConnectionString));
            
        }   
     }
}
