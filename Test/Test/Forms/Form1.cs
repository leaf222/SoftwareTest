using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Test.Tests;


namespace Test
{
    public partial class Form1 : Form
    {
        //测试方法
        public int testMethod = 0;
        //边界值
        public int triangleBoundaryTestNum = 0;
        public int triangleBoundarySuccessNum = 0;
        public int calenderBoundaryTestNum = 0;
        public int calenderBoundarySuccessNum = 0;
        public int comissionBoundaryTestNum = 0;
        public int comissionBoundarySuccessNum = 0;
        //等价类
        public int triangleEquaValClaTestNum = 0;
        public int triangleEquaValClaSuccessNum = 0;
        public int calenderEquaValClaTestNum = 0;
        public int calenderEquaValClaSuccessNum = 0;
        public int comissionEquaValClaTestNum = 0;
        public int comissionEquaValClaSuccessNum = 0;
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
                return;
            }

            else if (TestMethod.SelectedItem.ToString().Equals("边界值"))
            {
                testMethod = 1;
            }
            else if (TestMethod.SelectedItem.ToString().Equals("等价类"))
            {
                testMethod = 2;
            }
            else
            {
                MessageBox.Show("错误");
                return;
            }
            if (TestName.SelectedItem.ToString().Equals("三角形"))
            {
                {
                    TriangleBoundaryTest t = new TriangleBoundaryTest();
                    Boolean result = t.StartTest(testMethod);
                    if (testMethod == 1)
                    {
                        triangleBoundaryTestNum++;
                        if (result)
                        {
                            triangleBoundarySuccessNum++;
                            MessageBox.Show("测试成功");
                        }
                        else
                        {
                            MessageBox.Show("测试失败");
                        }
                    }
                    else
                    {
                        triangleEquaValClaTestNum++;
                        if (result)
                        {
                            triangleEquaValClaSuccessNum++;
                            MessageBox.Show("测试成功");
                        }
                        else
                        {
                            MessageBox.Show("测试失败");
                        }
                    }

                }
            }
            else if (TestName.SelectedItem.ToString().Equals("万年历"))
            {
                CalenderBoundaryTest t = new CalenderBoundaryTest();
                Boolean result = t.StartTest(testMethod);
                if (testMethod == 1)
                {
                    calenderBoundaryTestNum++;
                    if (result)
                    {
                        calenderBoundarySuccessNum++;
                        MessageBox.Show("测试成功");
                    }
                    else
                    {
                        MessageBox.Show("测试失败");
                    }
                }
                else
                {
                    calenderEquaValClaTestNum++;
                    if (result)
                    {
                        calenderEquaValClaSuccessNum++;
                        MessageBox.Show("测试成功");
                    }
                    else
                    {
                        MessageBox.Show("测试失败");
                    }
                }
            }
            else if (TestName.SelectedItem.ToString().Equals("销售问题"))
            {
                ComissionBoundaryTest t = new ComissionBoundaryTest();
                Boolean result = t.StartTest(testMethod);

                if (testMethod == 1)
                {
                    comissionBoundaryTestNum++;
                    if (result)
                    {
                        comissionBoundarySuccessNum++;
                        MessageBox.Show("测试成功");
                    }
                    else
                    {
                        MessageBox.Show("测试失败");
                    }
                }
                else
                {
                    comissionEquaValClaTestNum++;
                    if (result)
                    {
                        comissionEquaValClaSuccessNum++;
                        MessageBox.Show("测试成功");
                    }
                    else
                    {
                        MessageBox.Show("测试失败");
                    }
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
