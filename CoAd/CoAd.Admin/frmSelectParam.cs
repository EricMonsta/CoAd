using DevExpress.XtraTreeList.Nodes;
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
    public partial class frmSelectParam : Form
    {
        public frmSelectParam()
        {
            InitializeComponent();
            tlPosParams.DataSource = Base.db.TypeParams;
        }

        /// <summary>
        /// Идентификатор параметра
        /// </summary>
        public int CashParamId
        {
            get
            {
                return int.TryParse(tlPosParams.FocusedNode.GetValue(1).ToString(), out int result) ? result : -1;
            }
        }

        /// <summary>
        /// Наименование параметра
        /// </summary>
        public string CashParamName
        {
            get
            {
                return tlPosParams.FocusedNode.GetDisplayText(0);
            }
        }

        /// <summary>
        /// Фильтр по названию параметра
        /// </summary>
        void CheckNodes(string text, TreeListNode node = null)
        {
            var Nodes = tlPosParams.Nodes;
            if (node != null) Nodes = node.Nodes;
            foreach (TreeListNode n in Nodes)
            {
                if (node != null)
                    node.Expanded = false;
            }
            foreach (TreeListNode n in Nodes)
            {
                //конечный элемент и удовлетворяет условию
                if (!n.HasChildren && n.GetValue(colname_str_cash_param).ToString().IndexOf(text, StringComparison.OrdinalIgnoreCase) != -1)//  ToLower().Contains(text.ToLower()))
                {
                    var nn = n;
                    while (nn.ParentNode != null)
                    {
                        nn.ParentNode.Visible = true;
                        nn = nn.ParentNode;
                    }
                    n.Visible = true;
                    if (nn.ParentNode == null) nn.ExpandAll();
                }//если есть дочерние элементы-проверяем их
                else if (n.HasChildren) { CheckNodes(text, n); }
                //скрываем только этот элемент
                else
                {
                    n.Visible = false;
                }
            }
            //после прохождения цикла скроем элементы-группы в которых нет ни одного элемента, удовлетворяющего условию
            foreach (TreeListNode n in Nodes)
            {
                if (n.HasChildren && !n.Expanded)
                {
                    n.Visible = false;
                }
            }
        }

        
        private void edSearch_EditValueChanged(object sender, EventArgs e)
        {
            CheckNodes(edSearch.Text);
            if (!string.IsNullOrEmpty(edSearch.Text))
            {
                
                tlPosParams.FocusedNode = tlPosParams.Nodes[0];
            }
            else
            {
                foreach (TreeListNode node in tlPosParams.Nodes)
                {
                    node.Expanded = false;
                }
            }
        }

        private void sbtnOk_Click(object sender, EventArgs e)
        {
            //На выходе из формы получим идентификатор в CashParamId
            DialogResult = DialogResult.OK;
            Close();
        }

        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tlPosParams_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
