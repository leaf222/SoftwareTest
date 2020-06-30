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
            TestName.Items.Add("佣金问题（第二题）");
            TestName.Items.Add("销售问题（第八题）");
            TestVersion.Items.Add("1.0版本");
            TestVersion.Items.Add("2.0版本");
            TestMethod.Items.Add("边界值");
            TestMethod.Items.Add("等价类");
        }

        private void TestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TestName.SelectedItem.ToString().Equals("三角形"))
            {
                TestMethod.Items.Clear();
                TestMethod.Items.Add("边界值");
                TestMethod.Items.Add("等价类");
                TestVersion.Items.Clear();
                TestVersion.Items.Add("1.0版本");
                TestVersion.Items.Add("2.0版本");
            }
            if (TestName.SelectedItem.ToString().Equals("万年历"))
            {
                TestMethod.Items.Clear();
                TestMethod.Items.Add("边界值");
                TestMethod.Items.Add("等价类");
                TestVersion.Items.Clear();
                TestVersion.Items.Add("1.0版本");
                TestVersion.Items.Add("2.0版本");
            }
            if (TestName.SelectedItem.ToString().Equals("佣金问题（第二题）"))
            {
                TestMethod.Items.Clear();
                TestMethod.Items.Add("边界值");
                TestVersion.Items.Clear();
                TestVersion.Items.Add("1.0版本");
                TestVersion.Items.Add("2.0版本");
            }
            if (TestName.SelectedItem.ToString().Equals("销售问题（第八题）"))
            {
                TestMethod.Items.Clear();
                TestMethod.Items.Add("路径测试");
                TestMethod.Items.Add("分支测试");
                TestMethod.Items.Add("简单条件测试");
                TestMethod.Items.Add("分支条件测试");
                TestMethod.Items.Add("复杂条件测试");
                TestVersion.Items.Clear();
                TestVersion.Items.Add("1.0版本");
            }
        }

        private void TestMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboBoxLoad();
        }

        //将测试与图表显示代码抽象为该函数
        //四个参数分别是总数量，成功数量，失败数量以及测试的类
        private void TestTheTest(int _totalCase, int _successCase, int _failCase, Test.Tests.Test _test)
        {
            _test.StartTest();
            MessageBox.Show("测试已经完成");
            _test.resultInfo.totalCase = _totalCase;
            _test.resultInfo.successCase = _successCase;
            _test.resultInfo.failCase = _failCase;
            SetChart(_test);
        }

        //点击开始测试按钮，根据问题和方法选定测试类进行测试
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (TestName.SelectedItem == null || TestMethod.SelectedItem == null || TestVersion.SelectedItem == null)
            {
                MessageBox.Show("请选择测试类和测试方法以及测试版本");
            }
            else if (TestName.SelectedItem.ToString().Equals("三角形") && TestMethod.SelectedItem.ToString().Equals("边界值") && TestVersion.SelectedItem.ToString().Equals("1.0版本"))
            {
                //待测-三角形边界值第一版
                TestTheTest(7, 7, 0, new TriangleBoundaryTest());
            }
            else if (TestName.SelectedItem.ToString().Equals("三角形") && TestMethod.SelectedItem.ToString().Equals("边界值") && TestVersion.SelectedItem.ToString().Equals("2.0版本"))
            {
                TestTheTest(7, 7, 0, new TriangleBoundaryTest2());
            }
            else if (TestName.SelectedItem.ToString().Equals("三角形") && TestMethod.SelectedItem.ToString().Equals("等价类") && TestVersion.SelectedItem.ToString().Equals("1.0版本"))
            {
                //待测-三角形等价类第一版
                TestTheTest(21, 21, 0, new TriangleEquivalentTest());
            }
            else if (TestName.SelectedItem.ToString().Equals("三角形") && TestMethod.SelectedItem.ToString().Equals("等价类") && TestVersion.SelectedItem.ToString().Equals("2.0版本"))
            {
                TestTheTest(21, 21, 0, new TriangleEquivalentTest2());
            }
            else if (TestName.SelectedItem.ToString().Equals("佣金问题（第二题）") && TestMethod.SelectedItem.ToString().Equals("边界值") && TestVersion.SelectedItem.ToString().Equals("1.0版本"))
            {
                TestTheTest(32, 28, 4, new ComissionBoundaryTest());
            }
            else if (TestName.SelectedItem.ToString().Equals("佣金问题（第二题）") && TestMethod.SelectedItem.ToString().Equals("边界值") && TestVersion.SelectedItem.ToString().Equals("2.0版本"))
            {
                //待测-佣金问题边界值第二版
                TestTheTest(32, 28, 4, new ComissionBoundaryTest2());
            }
            else if (TestName.SelectedItem.ToString().Equals("万年历") && TestMethod.SelectedItem.ToString().Equals("边界值") && TestVersion.SelectedItem.ToString().Equals("1.0版本"))
            {
                TestTheTest(28, 23, 5, new CalenderBoundaryTest());
            }
            else if (TestName.SelectedItem.ToString().Equals("万年历") && TestMethod.SelectedItem.ToString().Equals("边界值") && TestVersion.SelectedItem.ToString().Equals("2.0版本"))
            {
                //待测-万年历边界值第二版
                TestTheTest(28, 23, 5, new CalenderBoundaryTest2());
            }
            else if (TestName.SelectedItem.ToString().Equals("万年历") && TestMethod.SelectedItem.ToString().Equals("等价类") && TestVersion.SelectedItem.ToString().Equals("1.0版本"))
            {
                TestTheTest(60, 50, 10, new CalenderEquivalentTest());
            }
            else if (TestName.SelectedItem.ToString().Equals("万年历") && TestMethod.SelectedItem.ToString().Equals("等价类") && TestVersion.SelectedItem.ToString().Equals("2.0版本"))
            {
                //待测-万年历等价类第二版
                TestTheTest(60, 50, 10, new CalenderEquivalentTest2());
            }
            else if (TestName.SelectedItem.ToString().Equals("销售问题（第八题）") && TestMethod.SelectedItem.ToString().Equals("路径测试") && TestVersion.SelectedItem.ToString().Equals("1.0版本"))
            {
                //待测-第八题路径测试
                TestTheTest(10, 10, 10, new SaleSystemStatementTest());
            }
            else if (TestName.SelectedItem.ToString().Equals("销售问题（第八题）") && TestMethod.SelectedItem.ToString().Equals("分支测试") && TestVersion.SelectedItem.ToString().Equals("1.0版本"))
            {
                //待测-第八题分支测试
                TestTheTest(10, 10, 10, new SaleSystemBranchTest());
            }
            else if (TestName.SelectedItem.ToString().Equals("销售问题（第八题）") && TestMethod.SelectedItem.ToString().Equals("简单条件测试") && TestVersion.SelectedItem.ToString().Equals("1.0版本"))
            {
                //待测-第八题简单条件测试
                TestTheTest(10, 10, 10, new SaleSystemSimpleConditionTest());
            }
            else if (TestName.SelectedItem.ToString().Equals("销售问题（第八题）") && TestMethod.SelectedItem.ToString().Equals("分支条件测试") && TestVersion.SelectedItem.ToString().Equals("1.0版本"))
            {
                //待测-第八题分支条件测试
                TestTheTest(10, 10, 10, new SaleSystemDicisionConditionTest());
            }
            else if (TestName.SelectedItem.ToString().Equals("销售问题（第八题）") && TestMethod.SelectedItem.ToString().Equals("复杂条件测试") && TestVersion.SelectedItem.ToString().Equals("1.0版本"))
            {
                //待测-第八题复杂条件测试
                TestTheTest(10, 10, 10, new SaleSystemMultipleConditionTest());
            }
            else
            {
                MessageBox.Show("出错了！");
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
