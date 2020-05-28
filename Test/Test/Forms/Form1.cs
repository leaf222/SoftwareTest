using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Controller;
using Test.Tests;


namespace Test
{
    public partial class Form1 : Form
    {
        //问题名称
        Dictionary<string, int> testNameMap = new Dictionary<string, int>();
        //问题方法
        Dictionary<string, int> testMethodMap = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
        }
        
        //为两个下拉框添加内容
        private void ComboBoxLoad()
        {
            TestName.Items.Add("万年历");
            TestName.Items.Add("三角形");
            TestName.Items.Add("销售问题");
            testNameMap.Add("万年历", 1);
            testNameMap.Add("三角形", 2);
            testNameMap.Add("销售问题", 3);

            TestMethod.Items.Add("边界值");
            TestMethod.Items.Add("等价类");
            testMethodMap.Add("边界值", 1);
            testMethodMap.Add("等价类",2);
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

        //点击开始测试按钮，根据问题和方法选定测试类进行测试
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (TestName.SelectedItem == null || TestMethod.SelectedItem == null)
            {
                MessageBox.Show("请选择测试类和测试方法");
                return;
            }
            int testName = testNameMap[TestName.SelectedItem.ToString()];
            int testMethod = testMethodMap[TestMethod.SelectedItem.ToString()];
            TestController testController = new TestController();
            double result=testController.test(testName, testMethod);
            MessageBox.Show(result.ToString());
        }
    }
}
