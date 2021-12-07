using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPCOMMGER.Framework;
using TPCOMMGER.Framework.CusEnum;
using TPCOMMGER.Framework.Helper;

namespace TPCOMMGER
{
    public partial class formPlcConfiguration : Form
    {
        List<string> lsFun = new List<string>();
        List<string> lsDevice = new List<string>();
        public formPlcConfiguration(DynamicEntity entity)
        {
            InitializeComponent();
            txtIP.Text = entity["IpAddress"]?.ToString();
            txtSeries.Text = entity["Series"]?.ToString();
            txtRemark.Text = entity["Description"]?.ToString();
            var seriesType = DefaultSeries.Delta;
            var arr = Enum.GetValues(typeof(DefaultSeries));
            foreach(var item in arr)
            {
                var field = typeof(DefaultSeries).GetField(item.ToString());
                DescriptionAttribute ds = (DescriptionAttribute)System.Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
                if(ds.Description == txtSeries.Text) seriesType = (DefaultSeries)Enum.Parse(typeof(DefaultSeries), field.Name);
            }
            var arr1 = Enum.GetValues(typeof(DefaultFunType));
            foreach(var item in arr1)
            {
                var field = typeof(DefaultFunType).GetField(item.ToString());
                SeriesDescriptionAttribute sd = (SeriesDescriptionAttribute)System.Attribute.GetCustomAttribute(field, typeof(SeriesDescriptionAttribute), false);
                if (sd.Default != seriesType) continue;
                lsFun.Add(field.Name);
            }
            var arr2 = Enum.GetValues(typeof(DefaultDeviceType));
            foreach (var item in arr2)
            {
                var field = typeof(DefaultDeviceType).GetField(item.ToString());
                SeriesDescriptionAttribute[] sd = (SeriesDescriptionAttribute[])System.Attribute.GetCustomAttributes(field, typeof(SeriesDescriptionAttribute), false);
                if (sd.ToList().Any(t => t.Default == seriesType) == false) continue;
                lsDevice.Add(field.Name);
            }
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
            int index = 0;
            foreach (var key in keys)
            {
                var json = BaseIniHelper.Read(PathHelper.PTPlcDetailData, txtIP.Text, key);
                Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                //var newRow = dataTable.NewRow();
                DataGridViewRow dr = new DataGridViewRow();
                //foreach (var dk in dic.Keys) newRow[dk] = dic[dk];
                foreach(var item in dataGridView1.Columns)
                {
                    var col = (DataGridViewColumn)item;
                    if(item is DataGridViewTextBoxColumn)
                    {
                        dr.Cells.Add(new DataGridViewTextBoxCell()
                        {
                            Value = dic[col.Name],                       
                        });
                    }else if(item is DataGridViewComboBoxCell)
                    {
                        dr.Cells.Add(new DataGridViewComboBoxCell()
                        {
                            //DataSource = 
                        });
                    }
                }
                dataGridView1.Rows.Add(dr);
                //dataTable.Rows.Add(newRow);
                index++;
            }
            //dataGridView1.DataSource = dataTable;
        }
    }
}
