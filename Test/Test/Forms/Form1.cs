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
        private Test.Tests.Test[,,] t;

        enum MyTestName { 万年历 = 0, 三角形 = 1, 佣金问题_第二题 = 2, 销售问题_第八题 = 3, 电话系统_第七题 = 4};
        enum MyTestMethod { 边界值 = 0, 等价类 = 1, 路径测试 = 2, 分支测试 = 3, 简单条件测试 = 4, 分支条件测试 = 5, 复杂条件测试 = 6, 综合测试 = 7};
        enum MyTestVersion { 版本一 = 0, 版本二 = 1};


        public Form1()
        {
            InitializeComponent();
            t = new Test.Tests.Test[5,8,2];
        }
        
        private void TestLoad()
        {
            t[0, 0, 0] = new CalenderBoundaryTest();
            t[0, 0, 1] = new CalenderBoundaryTest2();
            t[0, 1, 0] = new CalenderEquivalentTest();
            t[0, 1, 1] = new CalenderEquivalentTest2();
            t[1, 0, 0] = new TriangleBoundaryTest();
            t[1, 0, 1] = new TriangleBoundaryTest2();
            t[1, 1, 0] = new TriangleEquivalentTest();
            t[1, 1, 1] = new TriangleEquivalentTest2();
            t[2, 0, 0] = new ComissionBoundaryTest();
            t[2, 0, 1] = new ComissionBoundaryTest2();
            t[3, 2, 0] = new SaleSystemStatementTest();
            t[3, 3, 0] = new SaleSystemBranchTest();
            t[3, 4, 0] = new SaleSystemSimpleConditionTest();
            t[3, 5, 0] = new SaleSystemDicisionConditionTest();
            t[3, 6, 0] = new SaleSystemMultipleConditionTest();
            t[4, 7, 0] = new PhoneSystemBranchTest();
        }

        //为两个下拉框添加内容
        private void ComboBoxLoad()
        {
            TestName.Items.Add("万年历");
            TestName.Items.Add("三角形");
            TestName.Items.Add("佣金问题_第二题");
            TestName.Items.Add("电话系统_第七题");
            TestName.Items.Add("销售问题_第八题");
            TestVersion.Items.Add("版本一");
            TestVersion.Items.Add("版本二");
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
                TestVersion.Items.Add("版本一");
                TestVersion.Items.Add("版本二");
            }
            if (TestName.SelectedItem.ToString().Equals("万年历"))
            {
                TestMethod.Items.Clear();
                TestMethod.Items.Add("边界值");
                TestMethod.Items.Add("等价类");
                TestVersion.Items.Clear();
                TestVersion.Items.Add("版本一");
                TestVersion.Items.Add("版本二");
            }
            if (TestName.SelectedItem.ToString().Equals("佣金问题_第二题"))
            {
                TestMethod.Items.Clear();
                TestMethod.Items.Add("边界值");
                TestVersion.Items.Clear();
                TestVersion.Items.Add("版本一");
                TestVersion.Items.Add("版本二");
            }
            if (TestName.SelectedItem.ToString().Equals("销售问题_第八题"))
            {
                TestMethod.Items.Clear();
                TestMethod.Items.Add("路径测试");
                TestMethod.Items.Add("分支测试");
                TestMethod.Items.Add("简单条件测试");
                TestMethod.Items.Add("分支条件测试");
                TestMethod.Items.Add("复杂条件测试");
                TestVersion.Items.Clear();
                TestVersion.Items.Add("版本一");
            }
            if (TestName.SelectedItem.ToString().Equals("电话系统_第七题"))
            {
                TestMethod.Items.Clear();
                TestMethod.Items.Add("综合测试");
                TestVersion.Items.Clear();
                TestVersion.Items.Add("版本一");
            }
        }

        private void TestMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboBoxLoad();
            TestLoad();
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

        private void TestTheTest(Test.Tests.Test _test)
        {
            _test.StartTest();
            MessageBox.Show("测试已经完成");
            SetChart(_test);
        }

        private Test.Tests.Test GetTestClass(string _testName, string _testMethod, string _testVersion)
        {
            MyTestName myTestName = (MyTestName)Enum.Parse(typeof(MyTestName), _testName);
            MyTestMethod myTestMethod = (MyTestMethod)Enum.Parse(typeof(MyTestMethod), _testMethod);
            MyTestVersion myTestVersion = (MyTestVersion)Enum.Parse(typeof(MyTestVersion), _testVersion);
            Test.Tests.Test resultTest = t[(int)myTestName, (int)myTestMethod, (int)myTestVersion];
            return resultTest;
        }

        //点击开始测试按钮，根据问题和方法选定测试类进行测试
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (TestName.SelectedItem == null || TestMethod.SelectedItem == null || TestVersion.SelectedItem == null)
            {
                MessageBox.Show("请选择测试类和测试方法以及测试版本");
            }
            else
            {
                TestTheTest(GetTestClass(TestName.SelectedItem.ToString(), TestMethod.SelectedItem.ToString(), TestVersion.SelectedItem.ToString()));
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
