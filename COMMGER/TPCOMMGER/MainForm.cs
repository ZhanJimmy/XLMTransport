using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using TPCOMMGER.Framework.Model;
using TPCOMMGER.Framework.CusEnum;
using TPCOMMGER.Framework.Helper;
using TPCOMMGER.Framework;

namespace TPCOMMGER
{
    public partial class MainForm : Form
    {
        int SelectedRowIndex = -1;
        List<ListItemModel> lsSeries = new List<ListItemModel>();
        public MainForm()
        {
            InitializeComponent();
        }

        #region
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
            this.Activate();
        }

        private void 开启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
            this.Activate();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitBox();
            InitData();
            InitDefault();          
        }

        #region 加载 默认
        private void InitDefault()
        {
            InitDefaultCoil();
            InitDefaultLabel();
        }
        private void InitBox()
        {
            var arr = Enum.GetValues(typeof(DefaultSeries));
            foreach (var name in arr)
            {
                var field = typeof(DefaultSeries).GetField(name.ToString());
                DescriptionAttribute ds = (DescriptionAttribute)System.Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
                lsSeries.Add(new ListItemModel() { Value = field.Name, Display = ds.Description });
            }
        }
        private void InitData()
        {
            var keys = BaseIniHelper.ReadKeys(PathHelper.PTPlcData, SectionHelper.SPlc);
            DataTable dataTable = new DataTable();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dataTable.Columns.Add(col.Name);
            }
            foreach (var key in keys)
            {
                var json = BaseIniHelper.Read(PathHelper.PTPlcData, SectionHelper.SPlc, key);
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                var newRow = dataTable.NewRow();
                foreach (var dk in dic.Keys)
                {
                    if (dataTable.Columns.Contains(dk) == false) continue;
                    if (dk != "Series")
                        newRow[dk] = dic[dk];
                    else
                        newRow[dk] = lsSeries?.FirstOrDefault(t => t.Value == dic[dk].ToString())?.Display;
                }
                dataTable.Rows.Add(newRow);
            }
            dataGridView1.DataSource = dataTable;
            if (dataTable.Rows.Count > 0) SelectedRowIndex = 0;
        }
        private void InitDefaultCoil()
        {
            if (!File.Exists(PathHelper.PTCoil))
            {
                var arr = Enum.GetValues(typeof(DefaultCoilType));
                foreach (var name in arr)
                {
                    var field = typeof(DefaultCoilType).GetField(name.ToString());
                    DescriptionAttribute ds = (DescriptionAttribute)System.Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
                    BaseIniHelper.Write(PathHelper.PTCoil, SectionHelper.SCoil, field.Name, ds.Description);
                }
            }
        }
        private void InitDefaultLabel()
        {
            if (!File.Exists(PathHelper.PTLabel))
            {
                var arr = Enum.GetValues(typeof(DefaultLabelType));
                foreach (var name in arr)
                {
                    var field = typeof(DefaultLabelType).GetField(name.ToString());
                    DescriptionAttribute ds = (DescriptionAttribute)System.Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
                    BaseIniHelper.Write(PathHelper.PTLabel, SectionHelper.SLabel, field.Name, ds.Description);
                }
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            formLabel form = new formLabel();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formLabelCollection form = new formLabelCollection();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            formAbout form = new formAbout();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formPlc form = new formPlc();
            form.Show();
            form.FormClosed += Form_FormClosed;
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            InitData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (SelectedRowIndex == -1)
            {
                MessageBox.Show("请先选择行数据");
                return;
            }
            var srow = dataGridView1.Rows[SelectedRowIndex];
            DynamicEntity entity = new DynamicEntity();
            foreach (DataGridViewCell cell in srow.Cells)
            {
                var name = dataGridView1.Columns[cell.ColumnIndex].Name;
                entity[name] = cell.Value;
            }
            formPlcConfiguration form = new formPlcConfiguration(entity);
            form.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRowIndex = e.RowIndex;
        }
    }
}
