using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Tests;

namespace Test.Controller
{
    class TestController
    {
        public double test(int testName,int testMethod)
        {
            if (testName == 1)
            {
                CalenderBoundaryTest t = new CalenderBoundaryTest();
                return(t.StartTest(testMethod));
            }else if (testName == 2)
            {
                TriangleBoundaryTest t = new TriangleBoundaryTest();
                return(t.StartTest(testMethod));
            }
            else
            {
                ComissionBoundaryTest t = new ComissionBoundaryTest();
                return(t.StartTest(testMethod));
            }

        }
    }
}
