using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoAd.Admin
{
    public partial class FrmServer : Form
    {
        //Добавление нового сервера
        public FrmServer()
        {
            InitializeComponent();
            CurrentServer = new Server()
            {
                Identifier = Guid.NewGuid().ToString(),
                Status = 0,
            };
            Text = "Добавление нового сервера";
            idLabel.Visible = false;
            tbConfig.Visible = false;
        }
        //Редактирование существующего сервера
        public FrmServer(Server server)
        {
            InitializeComponent();
            CurrentServer = server;
            Text = "Редактирование параметров";
            idLabel.Text = string.Format("Идентификатор: {0}", server.Identifier);
            tbName.Text = server.Name;
            tbConfig.Text = server.Configuration;
        }
        public static Server CurrentServer { get; set; }

        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbtnOk_Click(object sender, EventArgs e)
        {
            CurrentServer.Name = tbName.Text;
            CurrentServer.Configuration = tbConfig.Text;
            
            rowtosave = Base.db.ClientServers.Where(cs => cs.id == CurrentServer.Id).FirstOrDefault();
            if(rowtosave == null)
            {
                rowtosave = new ClientServers();
                Base.db.ClientServers.InsertOnSubmit(rowtosave);
            }
            rowtosave.identifier = CurrentServer.Identifier;
            rowtosave.name = CurrentServer.Name;
            rowtosave.configuration = CurrentServer.Configuration;
            rowtosave.status = CurrentServer.Status;
            //Base.db.SubmitChanges();
           
            DialogResult = DialogResult.OK;
            Close();
        }

        public ClientServers rowtosave { get; set; }
    }

    /// <summary>
    /// Представление сервера
    /// </summary>
    public class Server
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Configuration { get; set; }
        public int Status { get; set; }
    }
}
