using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Test.Tests
{

    class Triangle
    {
        public string side1 { get; set; }
        public string side2 { get; set; }
        public string side3 { get; set; }
        public string CheckTriangle()
        {
            Dictionary<String, int> result = new Dictionary<String, int>();
            result.Add("等腰", 0);
            result.Add("等边", 0);
            result.Add("直角", 0);
            result.Add("钝角", 0);
            result.Add("锐角", 0);
            if (CheckInput(side1, side2, side3))
            {
                var edge1 = int.Parse(side1);
                var edge2 = int.Parse(side2);
                var edge3 = int.Parse(side3);
                int[] Numbers = new int[] { edge1, edge2, edge3 };
                double powSum = Math.Pow(edge1, 2) + Math.Pow(edge2, 2) + Math.Pow(edge3, 2);
                int max = Numbers.Max();
                if (CheckTriangle(edge1, edge2, edge3))
                {
                    //三角形
                    result["等边"] = CheckEquicrural(edge1, edge2, edge3) ? 1 : 0;
                    result["等腰"] = CheckEquilateral(edge1, edge2, edge3) ? 1 : 0;
                    result["直角"] = CheckRightAngle(powSum, max) ? 1 : 0;
                    result["钝角"] = CheckObtuseAngle(powSum, max) ? 1 : 0;
                    result["锐角"] = CheckAcuteAngle(powSum, max) ? 1 : 0;
                    string resultTip = (result["等腰"] == 1 && result["等边"] == 0) ? "等腰" : "";
                    resultTip += result["等边"] == 1 ? "等边" : "";
                    resultTip += result["直角"] == 1 ? "直角" : "";
                    resultTip += result["钝角"] == 1 ? "钝角" : "";
                    resultTip += result["锐角"] == 1 ? "锐角" : "";
                    resultTip += "三角形";
                    return resultTip;
                }
                else
                {
                    //构不成三角形。
                    return "您输入的三边构不成三角形！";
                }
            }
            else
            {
                //边长信息有误。
                return "您输入的边长信息有误！";
            }
        }
        private bool CheckAcuteAngle(double powSum, double max)
        {
            return (Math.Pow(max, 2) < powSum - Math.Pow(max, 2)) ? true : false;
        }

        private bool CheckObtuseAngle(double powSum, double max)
        {
            return (Math.Pow(max, 2) > powSum - Math.Pow(max, 2)) ? true : false;
        }

        private bool CheckRightAngle(double powSum, double max)
        {
            return (Math.Pow(max, 2) == powSum - Math.Pow(max, 2)) ? true : false;
        }

        private bool CheckEquicrural(double e1, double e2, double e3)
        {
            return (e1 == e2 && e2 == e3) ? true : false;
        }

        private bool CheckEquilateral(double e1, double e2, double e3)
        {
            return (e1 == e2 || e2 == e3 || e3 == e1) ? true : false;
        }

        private bool CheckTriangle(double edge1, double edge2, double edge3)
        {
            double[] edges = new double[] { edge1, edge2, edge3 };
            double sum = edges[0] + edges[1] + edges[2];
            int succFlag = 0;
            for (int i = 0; i < edges.Count(); i++)
            {
                if (edges[i] < sum - edges[i])
                {
                    succFlag++;
                }
            }
            if (succFlag == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckInput(string edge1, string edge2, string edge3)
        {
            bool result = false;
            Regex reg = new Regex("^[0-9]*$");
            if (reg.IsMatch(edge1) && reg.IsMatch(edge2) && reg.IsMatch(edge3))
            {
                try
                {
                    if (Int32.Parse(edge1) > 0 && Int32.Parse(edge2) > 0 && Int32.Parse(edge3) > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                catch
                {
                    //如果转换int型失败会返回false 这个字符串中含有非数字的字符 所以不能转换为int型
                    result = false;
                }
                
            }
            return result;
        }
    }

    public class TriangleBoundaryTest : Test
    {
        private static string TEST_FILE = "../../mydata/Triangle/Triangle_Boundary_Testcase.json";
        private static string TEST_RESULT = "../../mydata/Triangle/Triangle_Boundary_Result.json";

        private Dictionary<string, Triangle> ReadJsonFile()
        {
            using (StreamReader r = new StreamReader(TEST_FILE))
            {
                string json = r.ReadToEnd();
                Dictionary<string, Triangle> triangleDic = JsonConvert.DeserializeObject<Dictionary<string, Triangle>>(json);
                return triangleDic;
            }
        }

        public override void StartTest()
        {
            Dictionary<string, Triangle> triangleDictionary = ReadJsonFile();
            Dictionary<string, string> resultDictionary = new Dictionary<string, string>();
            foreach (KeyValuePair<string, Triangle> kvp in triangleDictionary)
            {
                resultDictionary.Add(kvp.Key, kvp.Value.CheckTriangle());
            }
            string result = JsonConvert.SerializeObject(resultDictionary);
            using (StreamWriter w = new StreamWriter(TEST_RESULT))
            {
                w.WriteLine(result);
            }
        }
    }
}
