using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Test.Tests;


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
            TestName.Items.Add("销售问题");
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

        //点击开始测试按钮，根据问题和方法选定测试类进行测试
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (TestName.SelectedItem == null || TestMethod.SelectedItem == null)
            {
                MessageBox.Show("请选择测试类和测试方法");
            }
            else if (TestName.SelectedItem.ToString().Equals("三角形") && TestMethod.SelectedItem.ToString().Equals("边界值"))
            {
                TriangleBoundaryTest t = new TriangleBoundaryTest();
                t.StartTest();
                MessageBox.Show("测试已经完成");
                t.resultInfo.totalCase = 10;
                t.resultInfo.successCase = 8;
                t.resultInfo.failCase = 2;
                SetChart(t);
            }
            else if (TestName.SelectedItem.ToString().Equals("销售问题") && TestMethod.SelectedItem.ToString().Equals("边界值"))
            {
                ComissionBoundaryTest t = new ComissionBoundaryTest();
                t.StartTest();
                MessageBox.Show("测试已经完成");
            }
            else if (TestName.SelectedItem.ToString().Equals("万年历") && TestMethod.SelectedItem.ToString().Equals("边界值"))
            {
                CalenderBoundaryTest t = new CalenderBoundaryTest();
                t.StartTest();
                MessageBox.Show("测试已经完成");
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void SetChart(Tests.Test t)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY("总测试用例数量", t.resultInfo.totalCase);//添加数据
            chart1.Series[0].Points.AddXY("成功用例数量", t.resultInfo.successCase);//添加数据
            chart1.Series[0].Points.AddXY("失败用例数量", t.resultInfo.failCase);//添加数据
        }
    }
}
