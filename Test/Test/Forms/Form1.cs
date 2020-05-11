using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //为两个下拉框添加内容
        private void ComboBoxLoad()
        {
            TestName.Items.Add("万年历");
            TestName.Items.Add("三角形");
            TestMethod.Items.Add("边界值");
            TestMethod.Items.Add("等价类");
        }

        private void TestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void TestMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboBoxLoad();
        }
    }
}
