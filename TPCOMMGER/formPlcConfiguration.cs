using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Yankon.Framework.Extension;
using Yankon.Framework.IniExtension;
using TPCOMMGER.Helper;

namespace TPCOMMGER
{
    public partial class formPlcConfiguration : Form
    {
        public formPlcConfiguration(DynamicEntity entity)
        {
            InitializeComponent();
            txtIP.Text = entity["IpAddress"]?.ToString();
            txtSeries.Text = entity["Series"]?.ToString();
            txtRemark.Text = entity["Description"]?.ToString();
            Init();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var editRow = dataGridView1.Rows[e.RowIndex];
            DynamicEntity entity = new DynamicEntity();
            foreach(DataGridViewCell cell in editRow.Cells)
            {
                var name = dataGridView1.Columns[cell.ColumnIndex].Name;
                entity[name] = cell.Value;
            }
            var json = JsonConvert.SerializeObject(entity.DynamicValues);
            BaseIniHelper.Write(PathHelper.PTPlcDetailData, txtIP.Text, e.RowIndex.ToString(), json);
        }

        private void Init()
        {
            var keys = BaseIniHelper.ReadKeys(PathHelper.PTPlcDetailData, txtIP.Text);
            DataTable dataTable = new DataTable();
            foreach(DataGridViewColumn col in dataGridView1.Columns)
            {
                dataTable.Columns.Add(col.Name);
            }
            foreach (var key in keys)
            {
                var json = BaseIniHelper.Read(PathHelper.PTPlcDetailData, txtIP.Text, key);
                Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                var newRow = dataTable.NewRow();
                foreach (var dk in dic.Keys) newRow[dk] = dic[dk];
                dataTable.Rows.Add(newRow);
            }
            dataGridView1.DataSource = dataTable;
        }
    }
}
