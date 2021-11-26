using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TPCOMMGER.Helper;
using Yankon.Framework.Extension;
using Yankon.Framework.IniExtension;

namespace TPCOMMGER
{
    public partial class formPlc : Form
    {
        public formPlc()
        {
            InitializeComponent();
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
            if (cbSeries.SelectedItem == null)
            {
                MessageBox.Show("系列不能为空！！！");
                return;
            }
            if (cbModel.SelectedItem == null)
            {
                MessageBox.Show("机种 不能为空！！！");
                return;
            }

            DynamicEntity entity = new DynamicEntity();
            entity["PName"] = txtName.Text;
            entity["IpAddress"] = txtIP.Text;
            entity["Port"] = txtPort.Text;
            entity["Description"] = txtRemark.Text;
            entity["Series"] = cbSeries.SelectedItem;
            entity["Model"] = cbModel.SelectedItem;
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
    }
}
