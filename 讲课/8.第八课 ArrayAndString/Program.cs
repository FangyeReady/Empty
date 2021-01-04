using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArrayAndString
{
    class Program
    {

        static void Main(string[] args)
        {
            StudyArray sa = new StudyArray();
            sa.Study();

            Console.Clear();
            //String类 初始化
            string str = "saddasdasd";
            string str2 = str;
            string str3 = str + str2 + "AAAAAAAAA";

            //初始化一个空的字符串, 它指向堆内存中一个长度为0的地址
            string str4 = string.Empty;
            string str5 = "";
            //Console.WriteLine(str4 + "---" + str5 + "----");


            //str等于null并不会在内存中分配空间
            string str6 = null;
            string str7;



            //Format格式化:{0} 只能从0开始顺序添加,并且后面的内容需要和占位符 一 一 对应
            string str8 = "21班";
            string str9 = "21人";
            //可以传变量, 可以是表达式, 可以是常量字符串
            string str10 = string.Format("{0}一共有{1}!!!!{2}", str8, str9, "实到20人");
            //Console.WriteLine(str10);


            //string.IsNullOrWhiteSpace(string  str);
            //检测字符串是否为空串或null
            bool isNullOrEmpty = string.IsNullOrWhiteSpace("     ");
            Console.WriteLine("是否为空格： " + isNullOrEmpty);//TRUE
            //string.Concat(字符串1, 字符串2, 字符串3,....); 参数是可变参数,拼接多个字符串
            string str11 = string.Concat(str8, str9, "???", "AAA");
            string str12 = str8 + str9;

            //初始化字符串,在堆内存中开辟空间
            string str13 = "AAABBB";
            //丢弃原来的空间,从新在堆内存中开辟空间
            str13 = "CCCDDD";
            //和其它引用类型类似
            int[] arr1 = new int[10];
            arr1 = new int[10];



            //string.Join(string  分隔字符串,  params string[] str); 拼接多个字符串并用指定字符串分割
            string str14 = string.Join(",", str8, str9, str13, "AAA");
            Console.WriteLine("join:====>    " + str14);

            string str15 = string.Join("===九城===", str8, str9, str13, "AAA");
            Console.WriteLine("join:====>    " + str15);
            
            string str16 = str14 + "," + str15;


            //修改字符串String的内容
            //insert 插入: 在指定下标处插入一个字符串
            string str17 = "AAAAAAA";
            string str18 = str17.Insert(0, "XXXXX");//此处的0代表下标, 小标不能超过字符串的Length-1
            //Console.WriteLine(str18  + "  长度:" + str18.Length);

            //判断字符串是否以???开头或结尾
            if (str18.StartsWith("XXX"))
            {
                Console.WriteLine("字符串str18以XXX开头");
            }
            bool isEndsWith = str18.EndsWith("XXX");
            if (!isEndsWith)
            {
                Console.WriteLine("字符串str18不以XXX结尾");
            }


            //Substring截取
            string str19 = "ABCD1234567EFG";
            string str20 = str19.Substring(5);//从下标处开始截取字符串到字符串结尾
            Console.WriteLine("截取： " + str20);

            string str21 = str19.Substring(0, 2);
            Console.WriteLine("截取： " + str21);


            //Replace替换
            string str23 = "AAABBBCCC";
            string str22 = str23.Replace('A', 'B');//  把老的字符, 全部替换为新的字符
            //Console.WriteLine(str22);

            string str24 = str22.Replace("BBBBBB", "BBABBB");
            //Console.WriteLine("替换字符串后:" + str24);


            //Split分割
            string str25 = string.Join("|", "ABC", "123", "@#$", "789");
            Console.WriteLine(str25);

            string[] strArr = str25.Split('|');
            for (int i = 0; i < strArr.Length; i++)
            {
                Console.WriteLine(strArr[i]);
            }

            //技能书
            //ID       skill
            //10001    2001_5

            string skill = "2001_1";
            string[] skillInfo = skill.Split('_');
            //skillInfo[0];技能ID
            //skillInfo[1];技能等级

           

            //格式化的深入
            //C: 货币, 货币至少会保留两位小数
            string str27 = string.Format("C:  猪肉价:{0:C}, 牛肉价:{1:C2}, 羊肉价:{2:C3}", 20.12343f, 30.12341f, 40.12341f);
            //Console.WriteLine(str27);

            //D:表示十进制, 只能传整数
            string str28 = string.Format("D:   猪肉价:{0:D}, 羊肉价:{1:D}", -20, 30);
            Console.WriteLine(str28);

            //E:表示科学计数算法
            string str29 = string.Format("E:  猪肉价:{0:E}, 羊肉价:{1:E}", 20, 30);
            Console.WriteLine(str29);

            //G:常规,G和G2是同一个精度, 2以后精度依次递增
            string str30 = string.Format("G:  猪肉价:{0:G5}, 羊肉价:{1:G}", 20.12345, 30);
            Console.WriteLine(str30);


            //N:用分号隔开的数字: N表示默认留两位小数, N1表示默认留一位小数, 以此类推~~~~~N和N2一样
            string str31 = string.Format("N:  猪肉价:{0:N1}, 羊肉价:{1:N3}", 1000000.123, 3000);
            //Console.WriteLine(str31);

            //X:十六进制
            string str32 = string.Format("X:  猪肉价:0x{0:X}, 羊肉价:0x{1:X}", 100000, 3000);
            //Console.WriteLine(str32);


            //P:百分比
            string str33 = string.Format("P:  猪肉价:{0:P}, 羊肉价:{1:P}", 0.2354, 0.99);
            //Console.WriteLine(str33);






            //Console.Clear();

            //对时间的格式化
            //while (true)
            //{
            //    string str34 = string.Format("当前时间:{0:yyyy-MM-dd  H:mm:ss}", DateTime.Now);

            //    Console.WriteLine(str34);

            //    Console.ReadKey();
            //    Console.Clear();
            //}
           
            //转义字符
            string str35 = "   asd\"方野\nasda    ";
            //Console.WriteLine(str35);
            string str36 = @"   asd\方野\nasda    ";
            //Console.WriteLine(str36);


            //StringBuilder 初始化
            StringBuilder sb = new StringBuilder();
            sb.Append("ABC");
            //sb.Clear();
            sb.Append("XXX");

            sb.AppendFormat("追加格式化的一行 ： {0:yyyy/MM/dd  H:mm:ss}", DateTime.Now);

            sb.Replace('A', 'Q');

            sb.Remove(1, 2);
            sb.AppendLine("DEF");
            sb.Append("ABC");

            Console.WriteLine(sb.ToString());



            //Console.Clear();


            Console.WriteLine(string.Format("{0:yyyy/MM/dd  H:mm:ss}", DateTime.Now));

            DateTimeFormatInfo dateInfo = new DateTimeFormatInfo();
            
            for (int i = 0; i < dateInfo.MonthNames.Length; i++)
            {
                Console.WriteLine(dateInfo.MonthNames[i]);
            }



            Regex regex = new Regex("");

            Console.ReadKey();
        }


        public static void SendMessageToShopServer(string id)
        {
            //https://image.baidu.com
            //detail/shop/item?
            //productID={0}&userID={1}
            //https://image.baidu.com/detail/shop/item?productID={0}&userID={1}
            int userid = 1001;
            string str11 = "https://image.baidu.com/detail/shop/item?productID={0}&userID={1}";

            string str12 = string.Format(str11, id, userid);

            //发送协议.....
        }
    }
}
