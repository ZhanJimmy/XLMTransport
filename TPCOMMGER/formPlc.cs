using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TPCOMMGER.CusEnum;
using TPCOMMGER.Helper;
using TPCOMMGER.Model;
using Yankon.Framework.Extension;
using Yankon.Framework.IniExtension;

namespace TPCOMMGER
{
    public partial class formPlc : Form
    {
        List<Tuple<string, string>> lsTupe = new List<Tuple<string, string>>();
        public formPlc()
        {
            InitializeComponent();
            InitCombox();
            var keys = BaseIniHelper.ReadKeys(PathHelper.PTLabelData, SectionHelper.SLabelData);
            foreach (var key in keys)
                cbLabel.Items.Add(key);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIP.Text))
            {
                MessageBox.Show("IP 地址不能为空！！！");
                return;
            }
            if (!IsIpAddress(txtIP.Text))
            {
                MessageBox.Show($"IP 地址验证失败！！！");
                return;
            }
            if (string.IsNullOrEmpty(txtPort.Text))
            {
                MessageBox.Show("端口 不能为空！！！");
                return;
            }
            if (cbSeries.SelectedValue == null)
            {
                MessageBox.Show("系列不能为空！！！");
                return;
            }
            if (cbModel.SelectedValue == null)
            {
                MessageBox.Show("机种 不能为空！！！");
                return;
            }
            DynamicEntity entity = new DynamicEntity();
            entity["PName"] = txtName.Text;
            entity["IpAddress"] = txtIP.Text;
            entity["Port"] = txtPort.Text;
            entity["Description"] = txtRemark.Text;
            entity["Series"] = cbSeries.SelectedValue;
            entity["Model"] = cbModel.SelectedValue;
            entity["Label"] = cbLabel.SelectedItem;
            if (rbYes.Checked)
                entity["OutMark"] = 1;
            else if (rbNo.Checked)
                entity["OutMark"] = 0;
            else if (rbYes.Checked == false && rbNo.Checked == false)
                entity["OutMark"] = -1;

            var json = JsonConvert.SerializeObject(entity.DynamicValues);
            BaseIniHelper.Write(PathHelper.PTPlcData, SectionHelper.SPlc, DateTime.Now.ToString("yyyyMMddHHmmss"), json);
            MessageBox.Show("添加成功！！！");
        }

        private bool IsIpAddress(string ip)
        {
            var reg = @"^((2[0-4]\d|25[0-5]|[1]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[1]?\d\d?)$";
            return Regex.IsMatch(ip, reg);
        }

        private void InitCombox()
        {
            {
                var arr = Enum.GetValues(typeof(DefaultModel));
                foreach(var name in arr)
                {
                    var field = typeof(DefaultModel).GetField(name.ToString());
                    DescriptionAttribute ds = (DescriptionAttribute)System.Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
                    lsTupe.Add(Tuple.Create(ds.Description, field.Name));
                }
            }
            {
                var arr = Enum.GetValues(typeof(DefaultSeries));
                List<ListItemModel> list1 = new List<ListItemModel>();
                foreach (var name in arr)
                {
                    var field = typeof(DefaultSeries).GetField(name.ToString());
                    DescriptionAttribute ds = (DescriptionAttribute)System.Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
                    list1.Add(new ListItemModel() { Value = field.Name, Display = ds.Description });
                }
                cbSeries.DisplayMember = "Display";
                cbSeries.ValueMember = "Value";
                cbSeries.DataSource = list1;
            }
        }

        private void cbSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.SelectedItem != null)
            {
                var item = (ListItemModel)box.SelectedItem;
                var whereResult = lsTupe.Where(t => t.Item1 == item.Value);
                if (whereResult == null) return;
                List<ListItemModel> list = new List<ListItemModel>();
                foreach(var im in whereResult)
                {
                    list.Add(new ListItemModel() { Value = im.Item2, Display = im.Item2 });
                }
                cbModel.DisplayMember = "Display";
                cbModel.ValueMember = "Value";
                cbModel.DataSource = list;
            }
        }
    }
}
