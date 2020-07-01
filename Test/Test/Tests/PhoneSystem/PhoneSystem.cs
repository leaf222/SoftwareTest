using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tests
{
    public class Result
    {
        public bool state = false;
        public object results;
    }
    public class PhoneSystem
    {
        public PhoneSystem(double _t, int _n)
        {
            t = _t;
            n = _n;
        }
        public double t { get; set; }
        public int n { get; set; }

        public Result CalculateAmout()
        {
            if (t <= 0 || t > 31 * 24 * 60)
            {
                return new Result { state = false, results = "无效的通话时间" };
            }
            if (n < 0 || n > 11)
            {
                return new Result { state = false, results = "无效的延时缴费次数" };
            }
            double discount = 0.0;
            if (t <= 60 && n <= 1)
            {
                discount = 0.01;
            }
            else if (t <= 120 && n <= 2)
            {
                discount = 0.015;
            }
            else if (t <= 180 && n <= 3)
            {
                discount = 0.02;
            }
            else if (t <= 300 && n <= 3)
            {
                discount = 0.025;
            }
            else if (n <= 6)
            {
                discount = 0.03;
            }

            return new Result { state = true, results = 25 + 0.15 * t * (1 - discount) };
        }

/*        static void Main(string[] args)
        {
            Console.WriteLine(new PhoneSystem(31 * 24 * 60, 12).CalculateAmout().results);
        }*/
    }
}
