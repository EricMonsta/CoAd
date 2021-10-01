using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace CoAd.Admin
{
    public partial class ucServerList : UserControl
    {
        

        public ucServerList()
        {
            InitializeComponent();
            gcServerList.DataSource = Base.db.ClientServers;
            treeButton.Visible = false;
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            var dialog = new FrmServer();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                (gvServerList.DataSource as BindingList<ClientServers>).Add(dialog.rowtosave);
                Base.db.SubmitChanges();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (gvServerList.SelectedRowsCount == 0) return;
 
            var srv = (ClientServers)gvServerList.GetFocusedRow();
            var dialog = new FrmServer(new Server() { Id = srv.id, Identifier = srv.identifier, Name = srv.name, Configuration = srv.configuration, Status = srv.status ?? 0 });
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                (gvServerList.DataSource as BindingList<ClientServers>)[gvServerList.FocusedRowHandle] = dialog.rowtosave;
                Base.db.SubmitChanges();
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (gvServerList.SelectedRowsCount == 0) return;
            var srv = (ClientServers)gvServerList.GetFocusedRow();
            if(MessageBox.Show("Вы действительно хотите удалить подключенный сервер? Будут удалены все связанные с ним данные и параметры!!!", "Удаление сервера", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var rowtodel = Base.db.ClientServers.Where(cs => cs.id == srv.id).FirstOrDefault();
                if (rowtodel != null)
                {
                    //В БД должно быть настроено каскадное удаление по fk
                    Base.db.ClientServers.DeleteOnSubmit(rowtodel);
                    gvServerList.DeleteSelectedRows();
                    Base.db.SubmitChanges();
                }
            }
        }
    }
}
