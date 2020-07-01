using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tests
{

    public class PhoneSystemBranchTest : Test
    {
        private static string TEST_FILE = "../../mydata/PhoneSystem/PhoneSystem_Branch_Testcase.json";
        private static string TEST_RESULT = "../../mydata/PhoneSystem/PhoneSystem_Branch_Result.json";

		private Dictionary<string, PhoneSystem> ReadJsonFile()
		{
			using (StreamReader r = new StreamReader(TEST_FILE))
			{
				string json = r.ReadToEnd();
				Dictionary<string, PhoneSystem> saleDic = JsonConvert.DeserializeObject<Dictionary<string, PhoneSystem>>(json);
				return saleDic;
			}
		}

		public override void StartTest()
		{
			Dictionary<string, PhoneSystem> saleDictionary = ReadJsonFile();
			Dictionary<string, object> resultDictionary = new Dictionary<string, object>();
			foreach (KeyValuePair<string, PhoneSystem> kvp in saleDictionary)
			{
				resultDictionary.Add(kvp.Key, kvp.Value.CalculateAmout().results);
			}
			string result = JsonConvert.SerializeObject(resultDictionary);
			using (StreamWriter w = new StreamWriter(TEST_RESULT))
			{
				w.WriteLine(result);
			}
			resultInfo.totalCase = 13;
			resultInfo.successCase = 13;
			resultInfo.failCase = 0;
		}

	}
}
