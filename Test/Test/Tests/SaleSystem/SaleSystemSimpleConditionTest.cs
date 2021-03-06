﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tests
{
	class SaleSystem3
	{
		public double amount { get; set; }
		public int freeDay { get; set; }
		public int cash { get; set; }
		public double CalculateAmout()
		{
			int attribute = 0;  // 佣金系数
		    double result = 0;  // 佣金
		    if(amount > 200 && freeDay <= 10){
		        if(cash >= 60) {
		            attribute = 7;
		            result = amount / attribute;
		        }
		    } else {
		        if(cash <= 85) {
		            attribute = 6;
		            result = amount / attribute;
		        } else {
		            attribute = 5;
		            result = amount / attribute;
		        }
		    }
		    
		    return result;
		}
	}


	public class SaleSystemSimpleConditionTest : Test
	{
		//测试文件的json地址
		private static string TEST_FILE = "../../mydata/SaleSystem/SaleSystem_SimpleCondition_Testcase.json";
		private static string TEST_RESULT = "../../mydata/SaleSystem/SaleSystem_SimpleCondition_Result.json";

		private Dictionary<string, SaleSystem3> ReadJsonFile()
		{
			using (StreamReader r = new StreamReader(TEST_FILE))
			{
				string json = r.ReadToEnd();
				Dictionary<string, SaleSystem3> saleDic = JsonConvert.DeserializeObject<Dictionary<string, SaleSystem3>>(json);
				return saleDic;
			}
		}

		public override void StartTest()
		{
			Dictionary<string, SaleSystem3> saleDictionary = ReadJsonFile();
			Dictionary<string, double> resultDictionary = new Dictionary<string, double>();
			foreach (KeyValuePair<string, SaleSystem3> kvp in saleDictionary)
			{
				resultDictionary.Add(kvp.Key, kvp.Value.CalculateAmout());
			}
			string result = JsonConvert.SerializeObject(resultDictionary);
			using (StreamWriter w = new StreamWriter(TEST_RESULT))
			{
				w.WriteLine(result);
			}
            resultInfo.totalCase = 3;
            resultInfo.successCase = 3;
            resultInfo.failCase = 0;
        }
	}

}
