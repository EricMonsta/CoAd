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
    public partial class frmAddGroup : Form
    {
        public frmAddGroup()
        {
            InitializeComponent();
            gcGroups.DataSource = Base.db.ClientDeviceGroup.Where(dg => dg.fo_id_group.HasValue);
        }

        private void sbtnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
