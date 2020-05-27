using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace Test.Tests
{
    class CalenderType
    {
        public int type_year { get; set; }
        public int type_month { get; set; }
        public int type_day { get; set; }

        public string result;

        public bool InputIllegal()
        {   //日份范围
            if (type_day > 31 || type_day < 1)
            {
                return true;
            }//小月最大值
            else if (type_day == 31)
            {
                switch (type_month)
                {
                    case 2:
                        return true;
                    case 4:
                        return true;
                    case 6:
                        return true;
                    case 9:
                        return true;
                    case 11:
                        return true;
                }
            }//闰年判断
            else if (type_month == 2 && type_day == 29)
            {
               int  four = type_year % 4;
               int  hundred = type_year % 100;
               int both = type_year % 400;
                if (four==0 && hundred!=0)
                {
                    return false;
                }
                else if (both==0)
                {
                    return false;
                }
                return true;
            }//月份范围
            else if (type_month > 12 || type_month < 1)
            {
                return true;
            }

            return false;   
        }
        public string TheNextDay()
        {
            
            int result_year = type_year;
            int result_month = type_month;
            int result_day = type_day + 1;
            bool illegal = InputIllegal();
            //判断输入是否合法
            if(illegal){
                result = "您的输入非法";
                return result;
            }
            //根据日来判断日和月
            if (type_day == 31)
            {
                result_month += 1;
                result_day = 1;

            }
            else  if (type_day == 30)
            {
                switch (type_month)
                {
                    case 4:
                        result_month = type_month + 1;
                        result_day = 1;
                        break;
                    case 6:
                        result_month = type_month + 1;
                        result_day = 1;
                        break;
                    case 9:
                        result_month = type_month + 1;
                        result_day = 1;
                        break;
                    case 11:
                        result_month = type_month + 1;
                        result_day = 1;
                        break;
                }
            }
           else if (type_month == 2)
            {
                switch (type_day)
                {
                    case 29:
                        result_month =type_month+ 1;
                        result_day = 1;
                        break;
                    case 28:
                        result_month = type_month + 1;
                        result_day = 1;
                        break;

                }

            }

            //根据月来判断月和年
           else if (type_day == 31 && type_month == 12)
            {
                result_day = 1;
                result_month = 1;
                result_year= type_year + 1;

            }

            result = Convert.ToString(result_year) +"."+ Convert.ToString(result_month) + "." + Convert.ToString(result_day);

            return result;
        }
    }



    public class CalenderBoundaryTest : Test
    {
        private static string BOUNDARY_TEST_FILE = "../../mydata/Calender/Calender_Boundary_Testcase.json";
        private static string BOUNDARY_TEST_RESULT = "../../mydata/Calender/Calender_Boundary_Result.json";
        private static string BOUNDARY_EXPEXTED_TEST_RESULT = "../../mydata/Calender/Calender_Boundary_Expected_Result.json";

        private static string EquaValCla_TEST_FILE = "../../mydata/Calender/Calender_EquaValCla_Testcase.json";
        private static string EquaValCla_TEST_RESULT = "../../mydata/Calender/Calender_EquaValCla_Result.json";
        private static string EquaValCla_EXPEXTED_TEST_RESULT = "../../mydata/Calender/Calender_EquaValCla_Expected_Result.json";

        private Dictionary<string, CalenderType> ReadCaseJsonFile(String testFile)
        {
            using (StreamReader r = new StreamReader(testFile))
            {
                string json = r.ReadToEnd();
                if (json == null)
                {
                    return null;
                }
                Dictionary<string, CalenderType> CalenderTypeDic = JsonConvert.DeserializeObject<Dictionary<string, CalenderType>>(json);
                return CalenderTypeDic;
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
                Dictionary<string, CalenderType> CalenderTypeDictionary = ReadCaseJsonFile(testFile);
                String expectedResult = ReadExpectedResultJsonFile(expectedResFile);
                Dictionary<string, string> resultDictionary = new Dictionary<string, string>();
                foreach (KeyValuePair<string, CalenderType> kvp in CalenderTypeDictionary)
                {
                    resultDictionary.Add(kvp.Key, kvp.Value.TheNextDay());
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