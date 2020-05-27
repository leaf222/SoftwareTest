using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tests
{
	class Comission
	{
		public int host { get; set; }
		public int monitor { get; set; }
		public int peripheral { get; set; }
		public double CalculateComission()
		{
			int saleroom = 0;
			int flag; // ???
			double commision = 0;
			if (host <= 0 || monitor <= 0 || peripheral <= 0)
			{
				flag = 0;
				// print("必须至少销售一台完整计算机")
			}

			//17.1;17.2;17.3
			else if (host > 70 || monitor > 80 || peripheral > 90)
			{
				commision = -1;
				flag = 0;
				// print("销售超过库存")
			}

			else
			{
				saleroom = host * 25 + monitor * 30 + peripheral * 45;
				flag = -1;
			}

			if (flag == -1)
			{
				if (saleroom <= 1000)
				{
					commision = saleroom * 0.1;
				}
				else if (saleroom <= 1800)
				{
					commision = saleroom * 0.15;
				}
				else
				{
					commision = saleroom * 0.2;
				}
			}

			return commision;
		}
	}


	public class ComissionBoundaryTest : Test
	{
		//测试文件的json地址
		private static string BOUNDARY_TEST_FILE = "../../mydata/Comission/Comission_Boundary_Testcase.json";
		private static string BOUNDARY_TEST_RESULT = "../../mydata/Comission/Comission_Boundary_Result.json";
        private static string BOUNDARY_EXPEXTED_TEST_RESULT = "../../mydata/Comission/Comission_Boundary_Expected_Result.json";

        private static string EquaValCla_TEST_FILE = "../../mydata/Comission/Comission_EquaValCla_Testcase.json";
        private static string EquaValCla_TEST_RESULT = "../../mydata/Comission/Comission_EquaValCla_Result.json";
        private static string EquaValCla_EXPEXTED_TEST_RESULT = "../../mydata/Comission/Comission_EquaValCla_Expected_Result.json";

        private Dictionary<string, Comission> ReadJsonFile(String testFile)
		{
			using (StreamReader r = new StreamReader(testFile))
			{
				string json = r.ReadToEnd();
				Dictionary<string, Comission> saleDic = JsonConvert.DeserializeObject<Dictionary<string, Comission>>(json);
				return saleDic;
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

        public override bool StartTest(int method)
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
            Dictionary<string, Comission> saleDictionary = ReadJsonFile(testFile);
            String expectedResult = ReadExpectedResultJsonFile(expectedResFile);
            Dictionary<string, double> resultDictionary = new Dictionary<string, double>();
			foreach (KeyValuePair<string, Comission> kvp in saleDictionary)
			{
				resultDictionary.Add(kvp.Key, kvp.Value.CalculateComission());
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
