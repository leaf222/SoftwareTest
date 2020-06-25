using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tests
{
    public struct chartInfo
    {
        public int totalCase;//总测试用例数量
        public int successCase;//成功数量
        public int failCase;//失败数量
        
    }

    //所有测试类的基类
    public abstract class Test
    {
        public chartInfo resultInfo;

        public abstract void StartTest();
    }
}
