using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tests
{
    class Triangle
    {
        public float side1 { get; set; }
        public float side2 { get; set; }
        public float side3 { get; set; }
        public string CheckTriangle()
        {
            if(side1 == side2 && side2 ==side3)
            {
                return "是等边三角形";
            }
            else if(side1 == side2 || side1 == side3 || side2 == side3)
            {
                return "是等腰三角形";
            }
            else if(side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
            {
                return "不是三角形";
            }
            return "是三角形";
        }
    }

    public class TriangleBoundaryTest : Test
    {
        private static string TEST_FILE = "../../mydata/Triangle/Triangle_Boundary_Testcase.json";
        private static string TEST_RESULT = "../../mydata/Triangle/Triangle_Boundary_Result.json";
        private static string EXPEXTED_TEST_RESULT = "../../mydata/Triangle/Triangle_Boundary_Expected_Result.json";
        FileInfo file = new FileInfo("../../mydata/Triangle/Triangle_Boundary_Expected_Result.json");

        private Dictionary<string, Triangle> ReadCaseJsonFile()
        {
            using (StreamReader r = new StreamReader(TEST_FILE))
            {
                string json = r.ReadToEnd();
                Dictionary<string, Triangle> triangleDic = JsonConvert.DeserializeObject<Dictionary<string, Triangle>>(json);
                return triangleDic;
            }
        }

        private String ReadExpectedResultJsonFile()
        {
            FileInfo file = new FileInfo("../../mydata/Calender/Calender_Boundary_Expected_Result.json");
            if (!file.Exists)
            {
                return null;
            }
            using (StreamReader r = new StreamReader(EXPEXTED_TEST_RESULT))
            {
                string json = r.ReadToEnd();
                return json;
            }
        }

        public override Boolean StartTest()
        {
            Dictionary<string, Triangle> triangleDictionary = ReadCaseJsonFile();
            String expectedResult = ReadExpectedResultJsonFile();
            Dictionary<string, string> resultDictionary = new Dictionary<string, string>();
            foreach(KeyValuePair<string, Triangle> kvp in triangleDictionary)
            {
                resultDictionary.Add(kvp.Key, kvp.Value.CheckTriangle());
            }
            string result = JsonConvert.SerializeObject(resultDictionary);
            using (StreamWriter w = new StreamWriter(TEST_RESULT))
            {
                w.WriteLine(result);
            }
            if (expectedResult == null || !expectedResult.Equals(result))
            {
                return false;
            }
            return true;
        }
    }
}
