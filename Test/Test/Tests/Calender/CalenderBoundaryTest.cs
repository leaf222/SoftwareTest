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
        {
            if (type_day > 31 || type_day < 1)
            {
                return true;
            }
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
            }
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
        private static string TEST_FILE = "../../mydata/Calender/Calender_Boundary_Testcase.json";
        private static string TEST_RESULT = "../../mydata/Calender/Calender_Boundary_Result.json";

        private Dictionary<string, CalenderType> ReadJsonFile()
        {
            using (StreamReader r = new StreamReader(TEST_FILE))
            {
                string json = r.ReadToEnd();
                Dictionary<string, CalenderType> CalenderTypeDic = JsonConvert.DeserializeObject<Dictionary<string, CalenderType>>(json);
                return CalenderTypeDic;
            }
        }

        public override void StartTest()
        {
            Dictionary<string, CalenderType> CalenderTypeDictionary = ReadJsonFile();
            Dictionary<string, string> resultDictionary = new Dictionary<string, string>();
            foreach (KeyValuePair<string, CalenderType> kvp in CalenderTypeDictionary)
            {
                resultDictionary.Add(kvp.Key, kvp.Value.TheNextDay());
            }
            string result = JsonConvert.SerializeObject(resultDictionary);
            using (StreamWriter w = new StreamWriter(TEST_RESULT))
            {
                w.WriteLine(result);
            }
        }
    }

}