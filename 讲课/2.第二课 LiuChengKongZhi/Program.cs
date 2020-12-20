using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiuChengKongZhi
{
    class Program
    {
        static void Main(string[] args)
        {

            //=========================sizeof
            int size = sizeof(int);
            Console.WriteLine(   "int的大小:" + size   );//要换行


            size = sizeof(double);
            Console.WriteLine("double的大小:" + size);


            string str = "size~~~";
            Console.WriteLine("size~~~" + size );


            //==========================Console.Write  不换行
            Console.Write("1111111111");
            Console.Write("22222222");


            //==========================ToString  得到一个和实例等效的字符串并返回
            //4;
            //"4";
            string str2 = size.ToString();
            Console.WriteLine( str2 );


            //==========================运算符==========================
            //加法
            int a = 1 + 2 + 3;  //常量相加
             
            int b = a + 1; //常量加变量

            int c = a + b;//变量加变量

            //减法
            int d = 1 - 2 - 3;

            int e = d - 1;

            int f = d - e;

            //乘法
            int g = 2 * 3;

            int h = g * 5;

            int k = g * h;


            //除法
            int x = 2;
            int y = 3;
            int m = 2 / 3;
            m = x / y;

            //如果用整型除法, 都应该把操作数转换为浮点数
            float n = x / (y + 0.0f);

            Console.WriteLine(n);


            //取模
            x = 2;
            y = 3;
            int z = 3 % 2;
            Console.WriteLine("3对2取模:   " + z);



            //+
            int a1 = +1; // a1 = 1 +;

            //++
            ++a1; // a1 = a1 + 1;
            //--
            --a1; //a1 = a1 - 1;

            a1++;
            a1--;
            Console.WriteLine(a1);
            

            int a2 = 1;

            //int a3 = ++a2;
            //Console.WriteLine(a3);

            int a4 = a2++;
            Console.WriteLine(a4);
            Console.WriteLine(a2);

            //==========================位运算符==========================

            //按位与&: 同为1则为1，反之为0
            int a5 = 1;
            //00000000 00000000 00000000 00000001
            int a6 = 100;
            //00000000 00000000 00000000 01100100
            //进行&运算
            //00000000 00000000 00000000 00000000

            int a7 = a5 & a6;
            Console.WriteLine("&运算: " + a7);



            //按位或 | : 有一个为1则为1，反之为0
            //00000000 00000000 00000000 00000001
            //00000000 00000000 00000000 01100100
            //进行或运算:
            //00000000 00000000 00000000 01100101

            int a8 = a5 | a6;
            Console.WriteLine("|运算: " + a8);


            //按位异或 ^ : 相同为0, 不同为1
            int a9 = 5;
            a6 = 100;
            //00000000 00000000 00000000 00000101
            //00000000 00000000 00000000 01100100
            //进行异或运算:
            //00000000 00000000 00000000 01100001
            int a10 = a9 ^ a6;
            Console.WriteLine("异或运算: " + a10);


            //按位取反~: 0变1, 1变0
            //00000000 00000000 00000000 00000001
            //按位取反~
            //11111111 11111111 11111111 11111110     原码
            //10000000 00000000 00000000 00000001     反码(对原码保留符号位,其余位取反)
            //10000000 00000000 00000000 00000010     +1得到补码
            //-0000000 00000000 00000000 00000010     真值（非内存中的值）
            //对于有符号类型左边的最高位: 0表示整数, 1表示负数


            int a11 = ~a5;
            Console.WriteLine("取反运算: " + a11);


            //左位移:  <<
            //1
            //00000000 00000000 00000000 00000001
            //左移3位
            //00000000 00000000 00000000 00001000

            //00000000 00000000 00000000 00000001  --图层1
            //00000000 00000000 00000000 00000010  --图层2
            int a12 = 1 << 3;
            Console.WriteLine("左移运算: " + a12);



            //右位移: >>
            //00000000 00000000 00000000 00000100
            //右移3位
            //00000000 00000000 00000000 00000001
            int a13 = 8 >> 4;
            Console.WriteLine("右移运算: " + a13);


            Console.Clear();
            //赋值运算符: += 
            int a14 = 5;
            a14 += 5;// a14 = a14 + 5;
            a14 += 9;
            Console.WriteLine("+=运算符: " + a14);


            //赋值运算符: -= 
            int a15 = 5;
            a15 -= 5;// a15 = a15 - 5;
            a15 -= 9;
            Console.WriteLine("+=运算符: " + a15);





            Console.Clear();
            //==========================逻辑运算符==========================
            int a16 = 10;
            int a17 = 11;
            bool A = a16 < a17;
            bool B = a16 == a17;

            //逻辑与运算符   &&:  只有同时满足了A,B条件才进入执行代码
            if (A && B)
            {
                Console.WriteLine("执行了代码~~逻辑与");
            }

            //逻辑或运算符 || : 只要满足了A,B任一条件就进入执行代码
            if (B || A)
            {
                Console.WriteLine("执行了代码~~逻辑或");
            }

            //逻辑非运算符 ! : 对原来的条件的真假取反
            if (!A)
            {
                Console.WriteLine("执行了代码~~逻辑非");
            }


            Console.Clear();
            //==========================关系运算符==========================
            a16 = 1;
            a17 = 2;
            if (a16 <= a17)
            {
                Console.WriteLine("a16小于等于a17");
            }


            a16 = a17 = 1;
            if (a16 == a17)
            {
                Console.WriteLine("a16等于a17");
            }





            a16 = 2;
            a17 = 1;
            bool isBigger = a16 > a17;
            if (isBigger)
            {
                Console.WriteLine("a16大于a17");
            }
            else
            {
                //..............
            }

            Console.Clear();
            //==========================三元运算符   ? :==========================
            a16 = 1;
            a17 = 1;
            bool isEquale = a16 == a17;

            string result = isEquale ? "相等" : "不相等";

            Console.WriteLine(result);


            string result2;
            if (isEquale)
            {
                result2 = "相等";
            }
            else
            {
                result2 = "不相等";
            }


            //优先级
            int a18 =( a15 -  (a16 + ++a17) )* a12;



            Console.Clear();
            //==========================流程控制==========================

            int b1 = 1;
            int b2 = 1;

            if (b1 > b2)
            {
                if (b1 == 1)
                {
                    //...
                }
                else
                {
                    if (b1 == 1)
                    {
                        if (b1 == 1)
                        { 
                            //.....
                        }
                    }
                    //.....
                }

                Console.WriteLine("b1大于b2");
            }
            else if (b1 < b2)
            {
                Console.WriteLine("b1小于b2");
            }
            else
            {
                Console.WriteLine("b1等于b2");
            }

            Console.Clear();
            //==========================流程控制========SWITCH==================
            int b3 = 10;
            switch (b3)
            {
                case 1: {
                        Console.WriteLine("b3等于1");
                    }break;
                case 2:
                    {
                        Console.WriteLine("b3等于1");
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("b3等于1");
                    }
                    break;
                case 10:
                    {
                        Console.WriteLine("b3等于10");
                    }
                    break;
                default: {
                        Console.WriteLine("没有找到适配项");
                    }break;
            }

            Console.Clear();
            //==========================循环==========================
            int count = 0;
            do
            {
                count++;
                Console.WriteLine("do while循环" + count + "次");
            } while (count < 10);


            Console.WriteLine("==================================================");
            count = 0;
            //满足某个条件就一直循环下去
            while (count < 5)
            {
                count++;
                Console.WriteLine("while循环" + count + "次");
            }

            Console.WriteLine("==================================================");
            //循环指定次数
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("while循环" + i + "次");
            }

            Console.Clear();
            //==========================循环嵌套==========================
            count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    count++;
                    Console.WriteLine("循环" + count + "次");
                }
            }
            Console.Clear();



            //==========================循环的终止==========================
            //break
            for (int i = 0; i < 10; i++)
            {
                //Console.Write(i + " ");
                if (i == 5)
                {
                    break;
                }
            }


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == 5)
                    {
                        break;
                    }
                   // Console.Write( j  + "   ");
                }

                //Console.WriteLine();
            }


            //Continue
            for (int i = 0; i < 10; i++)
            {
                if (i == 5  || i == 6 || i == 0)
                {
                    continue;
                }
               // Console.Write(i + " ");
            }


            //return
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " ");
                if (i == 4)
                {
                    //return;
                }
            }

            //int c = Test1();
            int c1 = Test2();
            int c2 = 1;
            int c3 = int.Parse("1");

            string str4 = c2.ToString();
            int c5 = int.Parse( "12"  + 1 );


            Console.WriteLine("循环已经终止");






            Console.Clear();













            int index = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Q")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }
               

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (index % 5 == j && index / 5 == i)
                        {
                            Console.Write("★");
                        }
                        else
                        {
                            Console.Write(" O");
                        }
                    }
                    Console.WriteLine();
                }

                ++index;


            }






            Console.ReadKey();

        }


        static void Test1()
        {
            return;
            Console.WriteLine();
        }

        static int Test2()
        {
            int a = 1;
            return a;
        }
    }
}
