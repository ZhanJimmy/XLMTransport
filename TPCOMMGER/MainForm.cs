using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yankon.Framework.IniExtension;
using TPCOMMGER.Helper;
using TPCOMMGER.CusEnum;
using Newtonsoft.Json;

namespace TPCOMMGER
{
    public partial class MainForm : Form
    {
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
            if(this.WindowState == FormWindowState.Minimized)
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
            InitDefault();
            var keys = BaseIniHelper.ReadKeys(PathHelper.PTPlcData, SectionHelper.SPlc); 
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("PName");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("Model");
            foreach(var key in keys)
            {
                var json = BaseIniHelper.Read(PathHelper.PTPlcData, SectionHelper.SPlc, key);
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                var newRow = dataTable.NewRow();
                foreach(var dk in dic.Keys)
                {
                    if (dk == "PName" || dk == "Description" || dk == "Model")
                        newRow[dk] = dic[dk];
                }
                dataTable.Rows.Add(newRow);
            }
            dataGridView1.DataSource = dataTable;
        }

        #region 加载 默认
        private void InitDefault()
        {
            InitDefaultCoil();
            InitDefaultLabel();
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
        }
    }
}
