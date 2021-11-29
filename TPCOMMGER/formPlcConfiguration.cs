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
        public formPlcConfiguration()
        {
            InitializeComponent();
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
    }
}
