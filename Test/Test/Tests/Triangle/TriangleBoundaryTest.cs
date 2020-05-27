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
        private static string BOUNDARY_TEST_FILE = "../../mydata/Triangle/Triangle_Boundary_Testcase.json";
        private static string BOUNDARY_TEST_RESULT = "../../mydata/Triangle/Triangle_Boundary_Result.json";
        private static string BOUNDARY_EXPEXTED_TEST_RESULT = "../../mydata/Triangle/Triangle_Boundary_Expected_Result.json";

        private static string EquaValCla_TEST_FILE = "../../mydata/Triangle/Triangle_EquaValCla_Testcase.json";
        private static string EquaValCla_TEST_RESULT = "../../mydata/Triangle/Triangle_EquaValCla_Result.json";
        private static string EquaValCla_EXPEXTED_TEST_RESULT = "../../mydata/Triangle/Triangle_EquaValCla_Expected_Result.json";

        private Dictionary<string, Triangle> ReadCaseJsonFile(String testFile)
        {
            using (StreamReader r = new StreamReader(testFile))
            {
                string json = r.ReadToEnd();
                Dictionary<string, Triangle> triangleDic = JsonConvert.DeserializeObject<Dictionary<string, Triangle>>(json);
                return triangleDic;
            }
        }

        private String ReadExpectedResultJsonFile(String expectedResFile)
        {
            FileInfo file = new FileInfo(expectedResFile);
            if (!file.Exists)
            {
                return null;
            }
            using (StreamReader r = new StreamReader(expectedResFile))
            {
                string json = r.ReadToEnd();
                return json;
            }
        }

        public override Boolean StartTest(int method)
        {
            String testFile;
            String resFile;
            String expectedResFile;
            if (method == 1)
            {
                testFile = BOUNDARY_TEST_FILE;
                resFile = BOUNDARY_TEST_RESULT;
                expectedResFile = BOUNDARY_EXPEXTED_TEST_RESULT;
            }
            else
            {
                testFile = EquaValCla_TEST_FILE;
                resFile = EquaValCla_TEST_RESULT;
                expectedResFile = EquaValCla_EXPEXTED_TEST_RESULT;
            }
            Dictionary<string, Triangle> triangleDictionary = ReadCaseJsonFile(testFile);
            String expectedResult = ReadExpectedResultJsonFile(expectedResFile);
            Dictionary<string, string> resultDictionary = new Dictionary<string, string>();
            foreach(KeyValuePair<string, Triangle> kvp in triangleDictionary)
            {
                resultDictionary.Add(kvp.Key, kvp.Value.CheckTriangle());
            }
            string result = JsonConvert.SerializeObject(resultDictionary);
            using (StreamWriter w = new StreamWriter(resFile))
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
