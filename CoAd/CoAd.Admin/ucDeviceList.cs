using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoAd.Admin
{
    public partial class ucDeviceList : UserControl
    {
        public ucDeviceList()
        {
            InitializeComponent();
            lueServers.Properties.DataSource = Base.db.ClientServers;
            lueServers.Properties.DisplayMember = "name";
            lueServers.Properties.NullText = @"<не выбрано>";
        }

        private void lueServers_EditValueChanged(object sender, EventArgs e)
        {
            var CurrentServer = (ClientServers)lueServers.GetSelectedDataRow();
            gcDevices.DataSource = CurrentServer.ClientDevices;
        }

        /// <summary>
        /// Загрузить данные выбранного устройства
        /// </summary>
        private void LoadCurrentDevice()
        {
            var CurrentDevivceRow = (ClientDevices)gridView1.GetFocusedRow();
            if (CurrentDevivceRow == null)
            {
                labelId.Text = string.Format("Идентификатор устройства: {0}", "");
                labelType.Text = string.Format("Тип устройства: {0}", "");
                tbName.Text = "";
                labelStatus.Text = string.Format("Статус синхронизации: {0}", "");
                labelDate.Text = string.Format("Дата синхронизации: {0}", "");
                listStores.DataSource = null;
                listGroupDevices.DataSource = null;
                return;
            }
            labelId.Text = string.Format("Идентификатор устройства: {0}", CurrentDevivceRow.fo_id_device);
            labelType.Text = string.Format("Тип устройства: {0}", CurrentDevivceRow.type_device == 1 ? "Касса" : "Сервер");
            tbName.Text = CurrentDevivceRow.name;
            labelStatus.Text = string.Format("Статус синхронизации: {0}", CurrentDevivceRow.state);
            labelDate.Text = string.Format("Дата синхронизации: {0}", CurrentDevivceRow.dateOfChange);//?

            listStores.DataSource = Base.db.ClientStores.Where(cs => cs.id_server == CurrentDevivceRow.id_server).Distinct();
            listStores.DisplayMember = "name";

            listGroupDevices.DataSource = Base.db.ClientDeviceGroup.Where(cdg => cdg.id == CurrentDevivceRow.id_group);
            listGroupDevices.DisplayMember = "name";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadCurrentDevice();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            LoadCurrentDevice();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //Перерисуем текст в колонках грида для наглядности
            if(e.Value != null) switch (e.Column.Name)
            {
                case "typeGridColumn":
                    e.DisplayText = e.Value.ToString() == "1" ? "Касса" : "Сервер";
                    break;
                case "groupGridColumn":
                    e.DisplayText = (Base.db.ClientDeviceGroup.FirstOrDefault(cdg => cdg.id == (int)e.Value) ?? new ClientDeviceGroup()).name;
                    break;
            }
        }
    }
}
