using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TPCOMMGER.Framework.Helper;

namespace TPCOMMGER
{
    public partial class formLabelCollection : Form
    {
        public formLabelCollection()
        {
            InitializeComponent();
        }
        private void InitData()
        {
            var cols = BaseIniHelper.ReadKeys(PathHelper.PTLabel, SectionHelper.SLabel);
            DataTable dataTable = new DataTable();
            var column = new DataGridViewColumn()
            {
                Name = ControlHelper.DFLabelTName,
                HeaderText = ControlHelper.DFLabelLText,
                DataPropertyName = ControlHelper.DFLabelTName,
                CellTemplate = new DataGridViewTextBoxCell(),
            };
            dataGridView1.Columns.Add(column);
            dataTable.Columns.Add(ControlHelper.DFLabelTName);
            foreach (var col in cols)
            {
                var des = BaseIniHelper.Read(PathHelper.PTLabel, SectionHelper.SLabel, col);
                dataGridView1.Columns.Add(new DataGridViewColumn()
                {
                    Name = col,
                    HeaderText = des,
                    DataPropertyName = col,
                    CellTemplate = new DataGridViewTextBoxCell(),
                });
                dataTable.Columns.Add(col);
            }
            var keys = BaseIniHelper.ReadKeys(PathHelper.PTLabelData, SectionHelper.SLabelData);
            if (keys == null || keys.Count == 0) return;
            foreach (var key in keys)
            {
                var json = BaseIniHelper.Read(PathHelper.PTLabelData, SectionHelper.SLabelData, key);
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                DataRow row = dataTable.NewRow();
                foreach (var dk in dic.Keys)
                {
                    row[dk] = dic[dk];
                }
                dataTable.Rows.Add(row);
            }
            dataGridView1.DataSource = dataTable;
        }

        private void formLabelCollection_Load(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
