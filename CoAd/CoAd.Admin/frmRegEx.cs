using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoAd.Admin
{
    public partial class frmRegEx : Form
    {
        private readonly DataTable _favregex = new DataTable();
        public frmRegEx()
        {
            InitializeComponent();
            _favregex.Columns.Add("regex", typeof(string));
            _favregex.Columns.Add("input", typeof(string));
            _favregex.Columns.Add("desc", typeof(string));

            _favregex.Rows.Add(@"^(\d+)", "4607066400872", "Штрих-код - любое число цифр больше одной");
            _favregex.Rows.Add(@"^(?<code>2[1-2]\d{5})(?<intPart>\d{2})(?<floatPart>\d{3})\d", "2112345678901", "Весовой штрих-код - весовые ШК, префикс 21, 22");
            _favregex.Rows.Add(@"^(?<code>2[1-2,5-7]\d{5})(?<intPart>\d{2})(?<floatPart>\d{3})\d", "2512345678901", "Весовой штрих-код - весовые ШК, префикс 21, 22, 25, 27");
            _favregex.Rows.Add(@"^;(\d+=\d+)", ";12345=1234567?", "Магнитные карты с префиксом \";\" и символом \"=\"");
            _favregex.Rows.Add(@"^;(\d+)", ";123456789?", "Магнитные карты с префиксом \";\"");
            _favregex.Rows.Add(@"[\s\S]*;([\d=]*)", @"VISA_SBERBANK234324234;33456653=355657876323435", "Track2 банковской карты");

            gcFavRegex.DataSource = _favregex;
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

        private void sbTest_Click(object sender, EventArgs e)
        {
            try
            {
                lbcResult.Items.Clear();

                Match m = Regex.Match(teTestValue.Text, teRegEx.Text);

                if (m.Success)
                {
                    if (m.Groups.Count == 1)
                    {
                        lbcResult.Items.Add("Выражение соответствует, групп нет");
                    }
                    else
                    {
                        for (int i = 1; i < m.Groups.Count; i++)
                        {
                            lbcResult.Items.Add(m.Groups[i].Value.ToString());
                        }
                    }
                }
                else
                {
                    lbcResult.Items.Add("Нет соответствия");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка парсера - " + ex.Message);
            }
        }

        public string RegExValue
        {
            get
            {
                return teRegEx.Text;
            }

            set
            {
                teRegEx.Text = value;
            }
        }

        private void teRegEx_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            pcFavoriteRegex.Visible = true;
        }

        private void gcFavRegex_DoubleClick(object sender, EventArgs e)
        {
            string s = gvFavRegex.GetFocusedDataRow()["regex"].ToString();

            if (s != string.Empty) teRegEx.Text = s;

            pcFavoriteRegex.Visible = false;
        }

        private void frmRegEx_MouseClick(object sender, MouseEventArgs e)
        {
            pcFavoriteRegex.Visible = false;
        }
    }
}
