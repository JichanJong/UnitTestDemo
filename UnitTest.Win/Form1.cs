using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnitTest.Model;

namespace UnitTest.Win
{
    public partial class Form1 : Form
    {
        public object data { get; set; }

        public object data2 { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            data =  textBox1.Text;//comboBox1.SelectedValue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            List<ComboItem> lst = new List<ComboItem>()
            {
                new ComboItem(){Id = null,Name = "请选择"},
                new ComboItem(){Id = "1",Name = "张三"},
                new ComboItem(){Id = "2",Name = "李四"},
                new ComboItem(){Id = "3",Name = "王五"}

            };

            comboBox1.DataSource = lst;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data2 = comboBox1.SelectedItem;
        }
    }
}
