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
            var edge1 = float.Parse(side1);
            var edge2 = float.Parse(side2);
            var edge3 = float.Parse(side3);
            float[] Numbers = new float[] { edge1, edge2, edge3 };
            float max = Numbers.Max();
            if (CheckTriangle(edge1, edge2, edge3))
            {
                //三角形
                result["等边"] = CheckEquicrural(edge1, edge2, edge3) ? 1 : 0;
                result["等腰"] = CheckEquilateral(edge1, edge2, edge3) ? 1 : 0;
                string resultTip = (result["等腰"] == 1 && result["等边"] == 0) ? "等腰" : "";
                resultTip += result["等边"] == 1 ? "等边" : "";
                resultTip += (result["等腰"] == 0 && result["等边"] == 0) ? "普通" : "";
                resultTip += "三角形";
                return resultTip;
            }
            else
            {
                //构不成三角形。
                return "您输入的三边构不成三角形！";
            }
        }

        private bool CheckEquicrural(float e1, float e2, float e3)
        {
            return (e1 == e2 && e2 == e3) ? true : false;
        }

        private bool CheckEquilateral(float e1, float e2, float e3)
        {
            return (e1 == e2 || e2 == e3 || e3 == e1) ? true : false;
        }

        private bool CheckTriangle(float edge1, float edge2, float edge3)
        {
            float[] edges = new float[] { edge1, edge2, edge3 };
            float sum = edges[0] + edges[1] + edges[2];
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
