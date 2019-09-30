using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StudentManager
{
    public class RegexUtil
    {
        /// <summary>
        /// 检测是否为数字类型
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool isInteger(string txt)
        {
            Regex regex = new Regex(@"^[1-9]\d*$");
            return regex.IsMatch(txt);
        }
    }
}
