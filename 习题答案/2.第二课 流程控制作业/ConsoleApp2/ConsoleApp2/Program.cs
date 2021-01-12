using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 教学测试
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintMap();
            //PrintMap2();
            PrintMap3();
            //JieCheng(5);
            //GetMaxValue(1, 2, 3);
            //OutPutChengFaBiao();
            //PrintOuShu();
            //SwitchTest(99);
            Console.ReadKey();
        }


        /// <summary>
        /// 输出直角三角形的图形
        /// </summary>
        static void PrintMap()
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write('@');
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 输出倒直角三角形的图形
        /// </summary>
        static void PrintMap2()
        {
            for (int i = 6; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write('@');
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 输出中心处地点
        /// </summary>
        static void PrintMap3()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    //if (i > 0 && i < 5 && j > 0 && j < 5)
                    //{
                    //    Console.Write('@');
                    //}
                    //else
                    //{
                    //    Console.Write('A');
                    //}

                    if (i == 0 || i == 5 || j == 0 || j == 5)
                    {
                        Console.Write('A');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// 阶乘
        /// </summary>
        /// <param name="val"></param>
        static void JieCheng(int val)
        {
            int result = 1;
            for (int i = 1; i <= val; i++)
            {
                result *= i;
            }
            Console.WriteLine("阶乘的值时：" + result);
        }

        /// <summary>
        /// 取得最大值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        static int GetMaxValue(int a, int b, int c)
        {
            int max = a > b ? a : b;

            max = max > c ? max : c;

            Console.WriteLine("最大值是：" + max);
            return max;
        }

        /// <summary>
        /// 输出九九乘法表
        /// </summary>
        static void OutPutChengFaBiao()
        {
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < i + 1; j++)
                {
                    Console.Write(j.ToString() + " * " + i.ToString() + " = " + i * j + "  ");
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// 输出奇数偶数的和
        /// </summary>
        static void PrintOuShu()
        {
            int resultOuShu = 0;
            int resultjiShu = 0;
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    resultOuShu += i;
                }
                else
                {
                    resultjiShu += i;
                }
            }
            Console.WriteLine("偶数和：" + resultOuShu);
            Console.WriteLine("奇数和：" + resultjiShu);
        }

        /// <summary>
        /// 学生分数,输出成绩
        /// </summary>
        static void SwitchTest(int score)
        {
            int result = 0;
            if (score >= 0 && score < 60)
            {
                result = 0;
            }

            if (score >= 60 && score < 80)
            {
                result = 1;
            }

            if (score >= 80 && score < 90)
            {
                result = 2;
            }

            if (score >= 90 && score <= 100)
            {
                result = 3;
            }


            switch (result)
            {
                case 0:
                    {
                        Console.WriteLine("不及格！");
                    }
                    break;
                case 1:
                    {
                        Console.WriteLine("一般！");
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("良好！");
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("优秀！");
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
