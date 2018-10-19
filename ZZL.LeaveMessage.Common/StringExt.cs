using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZZL.LeaveMessage.Common
{
    public static class StringExt
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsInt(this string str)
        {
            int temp;

            return int.TryParse(str, out temp);
        }

        public static bool IsDateTime(this string str)
        {
            DateTime dt;

            return DateTime.TryParse(str, out dt);
        }


        public static int TryToInt(this string str)
        {
            return IsInt(str) ? int.Parse(str) : -1;
        }

        public static DateTime TryToDateTime(this string str)
        {
            return IsDateTime(str) ? DateTime.Parse(str) : DateTime.MinValue;
        }


        /// <summary>
        /// 字符串MD5加密
        /// </summary>
        /// <param name="str">加密字符串</param>
        /// <param name="isToLower">加密字符串的显示样式(true=小写形式,false=大写形式)</param>
        /// <returns></returns>
        public static string CreateToMD5(this string str, bool isToLower = true)
        {
            using (MD5 md = MD5.Create())
            {
                byte[] byts = Encoding.UTF8.GetBytes(str);
                byte[] hashByts = md.ComputeHash(byts);
                StringBuilder builder = new StringBuilder(32);
                foreach (var item in hashByts)
                {
                    builder.Append(item.ToString(string.Format("{0}", isToLower ? "x" : "X2")));
                }

                return builder.ToString();
            }
        }

    }
}
