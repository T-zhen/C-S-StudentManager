using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Common
{
    public class DataValidate
    {
        /// <summary>
        /// 验证电话号码
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool PhoneVerification(string text)
        {
            return Regex.IsMatch(text, @"^[1]+[3,5]+\d{9}");

        }
        /// <summary>
        /// 验证身份证号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsIDcard(string str)
        {
            
            return Regex.IsMatch(str, @"(^\d{18}$)|(^\d{15}$)");
        }
        /// <summary>
        /// 验证正整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInteger(string str)
        {
          return  Regex.IsMatch (str,@"(^[1-9]\d*$)");
           
        }
    }
}
