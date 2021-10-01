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
    public partial class ucSync : UserControl
    {
        public ucSync()
        {
            InitializeComponent();
            gcServerList.DataSource = Base.db.ClientServers;
        }

        /// <summary>
        /// Обнвить данные выбранного сервера
        /// </summary>
        public void LoadCurrentServer()
        {
            var CurrentServerRow = (ClientServers)gridView1.GetFocusedRow();
            if(CurrentServerRow == null)
            {
                labelStores.Text = string.Format("Магазины {0}", "");
                labelDevices.Text = string.Format("Устройства {0}", "");
                labelGroupDevices.Text = string.Format("Группы касс {0}", "");
                return;
            }

            //TODO Показать статус синхронизации

            labelStores.Text = string.Format("Магазины {0}", "");
            labelDevices.Text = string.Format("Устройства {0}", "");
            labelGroupDevices.Text = string.Format("Группы касс {0}", "");
        }
    }

    
}
