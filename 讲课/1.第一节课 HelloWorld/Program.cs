using System;//使用命名空间的名字
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 命名空间     空间名称
namespace HelloWorld
{
    //类      类名
    class Program
    {

        int ch;

        //入口方法
        static void Main(string[] args)
        {
            //================================控制台中的常用方法================================

            //输出一行内容并自动换行
            //Console.WriteLine("hello world~~~~~");

            ////等待下一次输入
            //Console.ReadKey();

            ////清空屏幕
            //Console.Clear();

            ////发出一个提示音
            //Console.Beep();


            string str = Console.ReadLine();
            Console.WriteLine(str);

            //================================数据类型======================================

            //整型   
            SByte sb = -1;
            Byte by = 2;

            short sh = -3;
            ushort us = 4;

            int a = -5;
            uint b = 6;

            long c = -1000000;
            ulong d = 100000000;


            //浮点数
            float e = 5.0f;
            double f = 3.1412312312312;
            decimal g = 5.41231231M;


            //布尔类型
            bool isX = true;
            bool isY = false;

            //字符类型
            char ch = '&';
            string str3 = "大大撒法沙发沙发";

            Console.WriteLine(ch);

            //================================变量命名================================
            //变量命名不能以数字开头
            //int 123a;

            //变量名不能以关键字作为名称
            //int int;

            //相同作用域不能重名
            //int ch;


            //======正确的命名======
            int _a123;
            int @a456;
            int player_health_value;
            int gongjili;

            //禁区:千万不要用中文命名变量
            //int 我是变量名;
            //int 生命值;
            //int 死亡特效;

            //不能使用未赋值的变量
            //int n = _a123 + @a456;


            //隐式转换
            int a1 = 1;
            float a2 = 2.0f;

            float fffff = a;
            //低范围的类型会自动转换为高范围类型
            double a3 = a1 + a2;

            //显示转换
            int aaa = (int)fffff;

            //系统提供的方法进行转换
            //int a8 = (int)str2;  //不能进行强制转换

            string str2 = "11111111111111111";
            ulong a4 = ulong.Parse(str2);

            Console.WriteLine("a4:" + a4);

            int a5 = 0;
            /// bool isSuccess = int.TryParse("99999", out a5);
            int.TryParse("99999", out a5);

           

            //Console.WriteLine("a5:" + a5 + "    是否转换成功?" + isSuccess);



            //等待下一次输入
            Console.ReadKey();
        }


        void Test()
        {
            ch = 'b';  
        }
    
    
    }
}
