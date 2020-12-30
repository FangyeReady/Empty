using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 第八课数组类和String类作业
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("是回文" + IsHuiWen("abccba"));


            GetMaxCountChar("abccccxxa");

            Console.WriteLine(SubStringToMaxLength("asdasdasdfadsfAAAAA", 10));


            Loading();
            Console.ReadKey();
        }


        /// <summary>
        /// 判断回文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static bool IsHuiWen(string str)
        {
            char[] charArray = str.ToCharArray();
            for (int i = 0; i < charArray.Length / 2; i++)
            {
                if (charArray[i] != charArray[charArray.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 替换字符串中的指定字符为新的字符
        /// </summary>
        /// <param name="des"></param>
        /// <param name="old"></param>
        /// <param name="newVal"></param>
        /// <returns></returns>
        static string ReplaceStr(string des, char old, char newVal)
        {
            return des.Replace(old, newVal);
        }


        /// <summary>
        /// 统计字符串中出现次数最多的字符
        /// </summary>
        /// <param name="str"></param>
        static void GetMaxCountChar(string str)
        {
            int maxCount = 1;
            int index = 0;
            char maxChar = str[0];
            while (true)
            {
                string newStr = str.Replace(str[index].ToString(), "");

                int count = str.Length - newStr.Length;

                if (count > maxCount)
                {
                    maxCount = count;
                    maxChar = str[index];
                }

                if ( ++index >= str.Length )
                {
                    break;
                }
            }


            Console.WriteLine("出现字符最多的字符是：" + maxChar + " 一共出现了 " + maxCount + "次");
             
           


        }

        /// <summary>
        /// 截取字符串，并附加 ...
        /// </summary>
        /// <param name="str"></param>
        static string SubStringToMaxLength(string str, int maxLength)
        {
            string result = str;
            if (str.Length > maxLength)
            {
                result = str.Substring(0, maxLength) + "...";
            }
            return result;
        }

        /// <summary>
        /// Loading...
        /// </summary>
        static void Loading()
        {
            int index = 0;
            while (true)
            {
                Console.Clear();
                string add = "";
                switch (index)
                {
                    case 0: add = ".";break;
                    case 1: add = "..";break;
                    case 2: add = "..."; index = -1; break;
                    default:
                        break;
                }
                Console.WriteLine("Loading" + add);
                ++index;
                Thread.Sleep(500);
            }
        }
    }
}
