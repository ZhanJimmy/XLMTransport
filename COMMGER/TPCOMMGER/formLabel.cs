using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Windows.Forms;
using TPCOMMGER.Framework;
using TPCOMMGER.Framework.Helper;

namespace TPCOMMGER
{
    public partial class formLabel : Form
    {
        public formLabel()
        {
            InitializeComponent();
            var keys = BaseIniHelper.ReadKeys(PathHelper.PTLabel, SectionHelper.SLabel);
            {
                Label label = new Label();
                label.Name = ControlHelper.DFLabelLName;
                label.Text = ControlHelper.DFLabelLText;
                label.ForeColor = Color.Red;
                label.Location = new Point(20, 20 + 0 * 30);
                panel1.Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Name = ControlHelper.DFLabelTName;
                textBox.Location = new Point(120, 20 + 0 * 30);
                panel1.Controls.Add(textBox);
            }
            int index = 1;
            foreach (var key in keys)
            {
                var labelName = BaseIniHelper.Read(PathHelper.PTLabel, SectionHelper.SLabel, key);
                Label label = new Label();
                label.Name = $"name{index}";
                label.Text = labelName;
                label.Location = new Point(20, 20 + index * 30);
                panel1.Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Name = key;
                textBox.Location = new Point(120, 20 + index * 30);
                panel1.Controls.Add(textBox);
                index++;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DynamicEntity entity = new DynamicEntity();
            foreach(Control ct in panel1.Controls)
            {
                if (ct is TextBox == false) continue;
                TextBox txt = (TextBox)ct;
                entity[txt.Name] = txt.Text;
            }
            var code = entity[ControlHelper.DFLabelTName];
            if(code == null || string.IsNullOrEmpty(code?.ToString()))
            {
                MessageBox.Show("标签Code 不能为空！！！", "警告");
                return;
            }
            var keys = BaseIniHelper.ReadKeys(PathHelper.PTLabelData, SectionHelper.SLabelData);
            if (keys.Contains(code.ToString()))
            {
                MessageBox.Show("标签Code 已存在，请重新输入！！！", "警告");
                return;
            }
            var json = JsonConvert.SerializeObject(entity.DynamicValues);
            BaseIniHelper.Write(PathHelper.PTLabelData, SectionHelper.SLabelData, code.ToString(), json);
            MessageBox.Show("添加成功!!!"); 
            foreach (Control ct in panel1.Controls)
            {
                if (ct is TextBox == false) continue;
                TextBox txt = (TextBox)ct;
                txt.Text = string.Empty;
            }
        }
    }
}
