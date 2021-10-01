using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraVerticalGrid.Rows;
using System.Collections;

namespace CoAd.Admin
{
    public partial class ucDeviceGroupsC : UserControl
    {
        public ucDeviceGroupsC()
        {
            InitializeComponent();
            gcDeviceGroups.DataSource = Base.db.ClientDeviceGroup.Where(dg => !dg.fo_id_group.HasValue);
        }

        /// <summary>
        /// Загрузить данные выбранной группы
        /// </summary>
        private void LoadCurrentGroup()
        {
            var CurrentDeviceGroupRow = (ClientDeviceGroup)gvDeviceGroups.GetFocusedRow();
            if (CurrentDeviceGroupRow == null)
            {
                labelType.Text = string.Format("Тип группы: {0}", "");
                tbName.Text = "";
                labelStatus.Text = string.Format("Статус синхронизации: {0}", "");
                labelDate.Text = string.Format("Дата синхронизации: {0}", "");
                return;
            }
            labelType.Text = string.Format("Тип группы: {0}", CurrentDeviceGroupRow.fo_id_group.HasValue ? "клиентская" : "ЦАС");
            tbName.Text = CurrentDeviceGroupRow.name;
            labelStatus.Text = string.Format("Статус синхронизации: {0}", CurrentDeviceGroupRow.state);
            labelDate.Text = string.Format("Дата синхронизации: {0}", CurrentDeviceGroupRow.dateOfChange);

            //Заполнение параметров группы
            FillCashParams(CurrentDeviceGroupRow.id);
            //Заполнение зависимостей
            gcDependency.DataSource = Base.db.DeviceGroupDependency.Where(gd => gd.id_primary_group == CurrentDeviceGroupRow.id)
                .Join(Base.db.ClientDeviceGroup, dp => dp.id_secondary_group, dg => dg.id, (dp, dg) => dg);

        }

        /// <summary>
        /// Заполняет кассовые параметры для указанной группы
        /// </summary>
        private void FillCashParams(int group_id)
        {
            var focusedRow = -1;
            if (vgCashParams.FocusedRow != null)
            {
                focusedRow = vgCashParams.FocusedRow.Index;
            }
            
            // Создадим новую таблицу
            DataTable dt = new DataTable();
            try
            {
                // Очищаем таблицу со может быть устаревшим отображением параметров и значений
                vgCashParams.DataSource = null;
                vgCashParams.Rows.Clear();
            }
            catch
            {

            }

            // Создаем массив, который будет содержать значения параметров
            List<object> strList = new List<object>();
            dt.Rows.Add(strList.ToArray());
            vgCashParams.DataSource = dt;
            // Перебираем кассовые параметры данного устройства
            foreach (var dr in Base.db.DeviceGroupParams.Where(gp=>gp.id_group == group_id))
            {
                AddEditorRow(dr);
            }
 
            SortByCategory(vgCashParams);
            if (focusedRow != -1)
            {
                vgCashParams.FocusedRow = vgCashParams.Rows[focusedRow];
            }

        }

        /// <summary>
        /// Добавить строку редактора для параметра
        /// </summary>
        public void AddEditorRow(DeviceGroupParams dr)
        {
            try
            {
                // Для текущего параметра получаем описание параметра
                var nameStrCashParam = dr.TypeParams.mnem_param;
                var typeParam = dr.TypeParams.type_param;

                // value_param будет отображать представление параметра в строке
                object valueParam = dr.value.ToString();
                // value_blob - непосредственно значение в параметре
                string valueBlob = dr.value;

                EditorRow editorRow = new EditorRow(nameStrCashParam) { Name = nameStrCashParam };
                editorRow.Properties.FieldName = nameStrCashParam;
                editorRow.Properties.Caption = dr.TypeParams.name;

                // В большинстве случаев тип - строка, поэтому вынесли ее в начало
                Type type = typeof(string);
                // В зависимости от типа параметра необходимо делать различное отображение параметра
                switch (typeParam)
                {
                    case 1: //логический тип параметра
                        var repCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        repCheck.CheckedChanged += (sender, e) => { dr.value = (bool)vgCashParams.FocusedRow.Grid.EditingValue ? "1" : "0"; };
                        editorRow.Properties.RowEdit = repCheck;
                        type = typeof(bool);
                        valueParam = valueParam.Equals("1"); 
                        break;
                    case 2: //числовой тип параметра
                        var repCalc = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
                        {
                            EditMask = "f0",
                            Precision = 0,
                        };
                        repCalc.EditValueChanged += (sender, e) =>
                        {
                            dr.value = vgCashParams.FocusedRow.Grid.EditingValue.ToString();
                        };
                        editorRow.Properties.RowEdit = repCalc;
                        valueParam = string.IsNullOrWhiteSpace(valueBlob) ? (object)0 : valueBlob;
                        type = typeof(int);
                        break;
                    default:
                    case 3: //текстовая строка
                        var repText = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        repText.EditValueChanged += (sender, e) =>
                        {
                            dr.value = vgCashParams.FocusedRow.Grid.EditingValue.ToString();
                        };
                        editorRow.Properties.RowEdit = repText;
                        valueParam = valueBlob.Replace("\r", @"\r").Replace("\n", @"\n");
                        break;
                    case 4: //XML или многострочный текст параметр
                        var repButton = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
                        {
                            TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor,
                        };
                        repButton.ButtonClick += (sender, e) =>
                        {
                            using (frmBlob form = new frmBlob())
                            {
                                form.memFormat.Text = dr.value;
                                if (form.ShowDialog() != DialogResult.OK)
                                    return;
                                dr.value = form.memFormat.Text;
                            }
                        };

                        editorRow.Properties.RowEdit = repButton;
                        valueParam = "XML";
                        break;
                    case 5://Тип банковской авторизации, не используется
                        var repLue = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                        repLue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        repLue.EditValueChanged += (sender, e) =>
                        {
                            dr.value = vgCashParams.FocusedRow.Grid.EditingValue.ToString();
                        };
                        editorRow.Properties.RowEdit = repLue;
                        valueParam = valueBlob;
                        break;
                    case 6: // регулярное выражение
                        var repRegEx = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                        repRegEx.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        repRegEx.ButtonClick += (sender, e) =>
                        {
                            if (e.Button.Index == 0)
                            {
                                using (frmRegEx form = new frmRegEx())
                                {
                                    form.RegExValue = dr.value;
                                    if (form.ShowDialog() != DialogResult.OK)
                                    {
                                        return;
                                    }
                                    // А теперь берем из формы регулярное выражение
                                    dr.value = form.RegExValue;
                                    editorRow.Properties.Value = dr.value;
                                }
                            }
                        };
                        editorRow.Properties.RowEdit = repRegEx;

                        valueParam = valueBlob;
                        break;
                    case 7: //изображение
                        var repImageEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                        
                        repImageEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        repImageEdit.ButtonClick += (sender, e) =>
                        {
                            if (e.Button.Index != 0) return;

                            var s64 = dr.value;
                            byte[] buf = null;
                            if (s64 != "0") buf = Convert.FromBase64String(s64);
                            using (frmImage form = new frmImage(buf))
                            {
                                if (form.ShowDialog() != DialogResult.OK)
                                    return;
                                dr.value = Convert.ToBase64String(form.pictureEdit.EditValue != null
                                                                             ? (byte[])form.pictureEdit.EditValue
                                                                             : new byte[] { 0 });
                            }
                        };
                        editorRow.Properties.RowEdit = repImageEdit;
                        valueParam = "Изображение";
                        break;
                    case 8: // выбор цвета
                        var repColorEdit = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
                        repColorEdit.EditValueChanged += (sender, e) =>
                        {
                            dr.value = ((Color)vgCashParams.FocusedRow.Grid.EditingValue).ToArgb().ToString();
                        };
                        editorRow.Properties.RowEdit = repColorEdit;
                        type = typeof(Color);
                        valueParam = Color.FromArgb(Convert.ToInt32(valueBlob));
                        break;
                    /* Прочие типы на перспективу
                    case 9:
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                        //type = Type.GetType("System.Int32");
                        //valueParam = Convert.ToInt32(valueBlob);
                        valueParam = valueBlob;
                        break;
                    case 10: //выпадалочка параметра "действие карты продавца"
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                        //type = Type.GetType("System.Int32");
                        //valueParam = Convert.ToInt32(valueBlob);
                        valueParam = valueBlob;
                        break;
                    case 11: //выпадалочка параметра "Контроль продажи отрицательных остатков"
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                        valueParam = valueBlob;
                        break;
                    case 12: //выпадалочка параметра "Поведение при МРЦ > розничной цены"
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                        valueParam = valueBlob;
                        break;
                    case 13:
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
                        valueParam = valueBlob;
                        break;
                    case 14://выпадалочка параметра 'Момент округления при расчете НДС'
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                        valueParam = valueBlob;
                        break;
                    case 15://выбор типа округления
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                        switch (valueBlob)
                        {
                            case "0":
                                valueParam = '\u2193' + "В меньшую сторону ";
                                break;
                            case "1":
                                valueParam = '\u2191' + "В большую сторону";
                                break;
                            case "2":
                                valueParam = "Стандартное арифметическое ";
                                break;
                        }
                        break;
                    case 16://Сочетаемость дисконтных карт
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                        valueParam = valueBlob;
                        break;
                    case 17:
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                        valueParam = valueBlob;
                        break;
                    case 18://параметры, для которых требуется редактировать несколько значений одновременно(например мин. и макс. значение)
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                        valueParam = valueBlob;
                        break;
                    case 19:
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                        valueParam = valueBlob;
                        break;
                    case 20:
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                        valueParam = valueBlob;
                        break;
                    case 21:
                        editorRow.Properties.RowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                        valueParam = valueBlob;
                        break;
                    
                    default:
                        //Unknown
                        break;*/
                }
                // Добавляем в таблицу созданную строку
                var dt = (DataTable)vgCashParams.DataSource;
                vgCashParams.Rows.Add(editorRow);
                if (nameStrCashParam != null)
                {
                    // а в таблицу добавляем колонку с названием параметра и необходимым типом
                    dt.Columns.Add(new DataColumn(nameStrCashParam, type));
                }
                // записываем значение параметра
                 dt.Rows[0].SetField(nameStrCashParam, valueParam);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Отсортировывает строки в алфавитном порядке
        /// </summary>
        /// <param name="control"></param>
        public static void SortByCategory(DevExpress.XtraVerticalGrid.VGridControl control)
        {
            // Отсортируем в алфавитном порядке
            SortedList sortedList = new SortedList();
            foreach (BaseRow gridRow in
                control.Rows.Cast<BaseRow>().Where(gridRow => gridRow.Properties.RowHandle != -1))
            {
                sortedList.Add(gridRow.Properties.Caption, gridRow.Name);
            }

            sortedList.TrimToSize();

            for (int i = 0; i < sortedList.Count; i++)
            {
                control.Rows[sortedList.GetByIndex(i).ToString()].Index = i;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadCurrentGroup();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            LoadCurrentGroup();
        }

        /// <summary>
        /// Добавить параметр
        /// </summary>
        private void addParamButton_Click(object sender, EventArgs e)
        {
            var dialog = new frmSelectParam();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var CurrentDeviceGroupRow = (ClientDeviceGroup)gvDeviceGroups.GetFocusedRow();
                if (CurrentDeviceGroupRow == null)
                {
                    return;
                }
                if (Base.db.DeviceGroupParams.Where(dg=>dg.id_group == CurrentDeviceGroupRow.id && dg.id_type == dialog.CashParamId).Count() == 0)
                {
                   //Добавляем новый параметр со значением по-умолчанию
                    var dr = new DeviceGroupParams()
                    {
                        id_group = CurrentDeviceGroupRow.id,
                        id_type = dialog.CashParamId,
                        value = "0",
                        state = 0,
                        TypeParams = Base.db.TypeParams.FirstOrDefault(tp=>tp.id_type== dialog.CashParamId),
                    };
                    //И строку редактора для него
                    AddEditorRow(dr);

                    SortByCategory(vgCashParams);
                 }
            }
        }

        /// <summary>
        /// Добавление группы устройств
        /// </summary>
        private void addGroupButton_Click(object sender, EventArgs e)
        {
             var newDeviceGroup = new ClientDeviceGroup()
            {
                //id_server = CurrentServer.id,
                name = "Кассы торгового зала",
                state = 0,
            };
            Base.db.ClientDeviceGroup.InsertOnSubmit(newDeviceGroup);
            (gvDeviceGroups.DataSource as BindingList<ClientDeviceGroup>).Add(newDeviceGroup);
        }

        /// <summary>
        /// Удаление группы устройств
        /// </summary>
        private void delGroupButton_Click(object sender, EventArgs e)
        {
            var CurrentDeviceGroupRow = (ClientDeviceGroup)gvDeviceGroups.GetFocusedRow();
            if (CurrentDeviceGroupRow == null)
            {
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить группу? Будут удалены все связанные с ней данные и параметры!!!", "Удаление группы", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var rowtodel = Base.db.ClientDeviceGroup.Where(dg => dg.id == CurrentDeviceGroupRow.id).FirstOrDefault();
                if (rowtodel != null)
                {
                    //В базе должно быть настроено каскадное уделение по fk
                    Base.db.ClientDeviceGroup.DeleteOnSubmit(rowtodel);
                }
                gvDeviceGroups.DeleteSelectedRows();
            }
        }

        /// <summary>
        /// Удаление параметра из группы
        /// </summary>
        private void delParamButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить параметр?", "Удаление параметра", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var CurrentDeviceGroupRow = (ClientDeviceGroup)gvDeviceGroups.GetFocusedRow();
                var CurrentParamRow = Base.db.DeviceGroupParams.First(gp => gp.id_group == CurrentDeviceGroupRow.id && gp.TypeParams.mnem_param == vgCashParams.FocusedRow.Properties.FieldName);

                Base.db.DeviceGroupParams.DeleteOnSubmit(CurrentParamRow);
                vgCashParams.Rows.RemoveAt(vgCashParams.FocusedRow.Index);
            }
        }

        /// <summary>
        /// Сохранить изменения в группе
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            var CurrentDeviceGroupRow = (ClientDeviceGroup)gvDeviceGroups.GetFocusedRow();
            if (CurrentDeviceGroupRow == null)
            {
                return;
            }
            CurrentDeviceGroupRow.name = tbName.Text;
            if (CurrentDeviceGroupRow.state < 2) CurrentDeviceGroupRow.state++;
            // Применить изменения в БД
            Base.db.SubmitChanges();
        }

        private void addDependencyButton_Click(object sender, EventArgs e)
        {
            var CurrentDeviceGroupRow = (ClientDeviceGroup)gvDeviceGroups.GetFocusedRow();
            if (CurrentDeviceGroupRow == null)
            {
                return;
            }
            using (var dialog = new frmAddGroup())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var SecondaryDeviceGroupRow = (ClientDeviceGroup)dialog.gvGroups.GetFocusedRow();
                    if (SecondaryDeviceGroupRow != null)
                    {
                        //Добавим зависимость в БД, а в грид название добавленной группы
                        Base.db.DeviceGroupDependency.InsertOnSubmit(new DeviceGroupDependency()
                        {
                            id_primary_group = CurrentDeviceGroupRow.id,
                            id_secondary_group = SecondaryDeviceGroupRow.id,
                        });
                        var depend = (gvDependency.DataSource as BindingList<ClientDeviceGroup>).AddNew();
                        depend.name = SecondaryDeviceGroupRow.name;
                    }
                }
            }
        }

        private void delDependencyButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить зависимость?", "Удаление привязки", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var CurrentDeviceGroupRow = (ClientDeviceGroup)gvDeviceGroups.GetFocusedRow();
                var CurrentDependencyRow = (ClientDeviceGroup)gvDependency.GetFocusedRow();
                if (CurrentDependencyRow == null || CurrentDeviceGroupRow == null)
                {
                    return;
                }
                var Dependency = Base.db.DeviceGroupDependency.FirstOrDefault(d => d.id_primary_group == CurrentDeviceGroupRow.id && d.id_secondary_group == CurrentDependencyRow.id);
                if (Dependency != null) Base.db.DeviceGroupDependency.DeleteOnSubmit(Dependency);
                gvDependency.DeleteSelectedRows();
            }
        }
    }
}
