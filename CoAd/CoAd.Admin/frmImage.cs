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
    public partial class frmImage : Form
    {
        public frmImage()
        {
            InitializeComponent();
        }
        public frmImage(byte[] img)
        {
            InitializeComponent();

            pictureEdit.EditValue = img;
        }

        private void sbtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
