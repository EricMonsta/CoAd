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
    public partial class ucStoresList : UserControl
    {
        public ucStoresList()
        {
            InitializeComponent();
            lueServers.Properties.DataSource = Base.db.ClientServers;
            lueServers.Properties.DisplayMember = "name";
            lueServers.ItemIndex = 0;
            lueServers.Properties.NullText = @"<не выбрано>";
        }

        private void lueServers_EditValueChanged(object sender, EventArgs e)
        {
            var CurrentServer = (ClientServers)lueServers.GetSelectedDataRow();
            gcStores.DataSource = CurrentServer.ClientStores;
         }

        /// <summary>
        /// Загрузка данных магазина
        /// </summary>
        private void LoadCurrentStore()
        {
            var CurrentStoreRow = (ClientStores)gridView1.GetFocusedRow();
            if (CurrentStoreRow == null)
            {
                labelId.Text = string.Format("Идентификатор магазина: {0}", "");
                tbName.Text = "";
                labelStatus.Text = string.Format("Статус синхронизации: {0}", "");
                labelDate.Text = string.Format("Дата синхронизации: {0}", "");
                meEgais.Text = "";
                meOfd.Text = "";
                meBpa.Text = "";
                return;
            }
            labelId.Text = string.Format("Идентификатор магазина: {0}", CurrentStoreRow.fo_id_store);

            tbName.Text = CurrentStoreRow.name;
            labelStatus.Text = string.Format("Статус синхронизации: {0}", CurrentStoreRow.state);
            labelDate.Text = string.Format("Дата синхронизации: {0}", CurrentStoreRow.dateOfChange);//?

            meEgais.Text = CurrentStoreRow.egais_props;
            meOfd.Text = CurrentStoreRow.ofd_props;
            meBpa.Text = CurrentStoreRow.bpa_props;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {// Переключение на строку с другим индексом
            LoadCurrentStore();
        }
        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {// Изменение данных в строке с тем же индексом
            LoadCurrentStore();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var CurrentStoreRow = (ClientStores)gridView1.GetFocusedRow();
            if (CurrentStoreRow == null) return;
            CurrentStoreRow.name = tbName.Text;
            CurrentStoreRow.egais_props = meEgais.Text;
            CurrentStoreRow.ofd_props = meOfd.Text;
            CurrentStoreRow.bpa_props = meBpa.Text;
            if (CurrentStoreRow.state < 2) CurrentStoreRow.state++;
            labelStatus.Text = string.Format("Статус синхронизации: {0}", CurrentStoreRow.state);
            labelDate.Text = string.Format("Дата синхронизации: {0}", CurrentStoreRow.dateOfChange);//?
            Base.db.SubmitChanges();
        }

        
    }
}
