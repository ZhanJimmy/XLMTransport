using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TPCOMMGER.Helper;
using Yankon.Framework.IniExtension;
using Yankon.Framework.Extension;
using Newtonsoft.Json;

namespace TPCOMMGER
{
    public partial class formLabelCollection : Form
    {
        public formLabelCollection()
        {
            InitializeComponent();
            InitData();
        }
        private void InitData()
        {
            var cols = BaseIniHelper.ReadKeys(PathHelper.PTLabel, SectionHelper.SLabel);
            DataTable dataTable = new DataTable(); 
            DataColumn ddc = new DataColumn()
            {
                ColumnName = "textBoxCode",
                Caption = "Code",
            };
            dataTable.Columns.Add(ControlHelper.DFLabelTName);
            foreach (var col in cols)
            {
                var des = BaseIniHelper.Read(PathHelper.PTLabel, SectionHelper.SLabel, col);
                DataColumn dc = new DataColumn()
                {
                    ColumnName = des,
                    Caption = col
                };
                dataTable.Columns.Add(col);
            }
            var keys = BaseIniHelper.ReadKeys(PathHelper.PTLabelData, SectionHelper.SLabelData);
            if (keys == null || keys.Count == 0) return;
            foreach (var key in keys)
            {
                var json = BaseIniHelper.Read(PathHelper.PTLabelData, SectionHelper.SLabelData, key);
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                DataRow row = dataTable.NewRow();
                foreach(var dk in dic.Keys)
                {
                    row[dk] = dic[dk];
                }
                dataTable.Rows.Add(row);
            }
            dataGridView1.DataSource = dataTable; 
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var a = e.Row;
        }
    }
}
