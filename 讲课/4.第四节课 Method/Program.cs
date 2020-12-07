using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method
{
    class MyClassA
    {
        int a;

        public int b;
    }


    class Program
    {
        static int hp = 1;
        static void Main(string[] args)
        {
            //写代码的地方
            //Test(1);
            #region 第一天讲方法
            MyClassA myClassA = new MyClassA();
            myClassA.b = 1;

            NewNamespace.MyClassB myClassB = new NewNamespace.MyClassB();


            int temp = GetPlayerMaxHp();

            int temp2 = Add(1, 2, 2);
            //Console.WriteLine("1 + 2 + 2 = " + temp2);


            int temp3 = Add(1, 2);
            //Console.WriteLine("1 + 2  = " + temp3);


            int temp4 = Add(1, 2, 3, 4, 5, 6, 7, 8);
            int temp5 = Add(1, 2, new int[] { 3, 4, 5, 6, 7, 8 });

            //Console.WriteLine("Temp4:" + temp4);
            //Console.WriteLine("Temp5:" + temp5);

            #endregion


            int temp6 = 0;
            TestRef( ref temp6 );

            //Console.WriteLine(temp6);


            int temp7, temp8, temp9;
            TestOut(out temp7, out temp8, out temp9);
            //Console.WriteLine("Out修饰符:" + temp7);


            int[] array = { 0, 1, 2 };
            //SetArray( array );//值传递,引用类型


            //ChangeArray(array);
            TestRef(ref array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }

            Console.ReadKey();
        }

        //访问修饰符     返回值的数据类型    方法名               参数
        public             void             Test            (int val)
        {
            hp = 2;
            Console.WriteLine("方法Test中的打印");
        }
        #region 方法的重载和参数
        static int GetPlayerMaxHp()
        {
            return hp;
        }
        /// <summary>
        /// 加法运算
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        static int Add(int a, int b, int c = 0)
        {
            int result = a + b + c;
            return result;
        }

        static int Add(int d, int e, float f)
        {
            return d + e;
        }
        /// <summary>
        /// 默认参数后,后面的参数, 也必须有默认参数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        static int JianFa(int a = 1, int b = 2, int c = 3)
        {
            int result = a - b - c;
            return result;
        }
        /// <summary>
        /// 可变参数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="canshus"></param>
        /// <returns></returns>
        static int Add(int a, int b, params int[] canshus)
        {
            int result = a + b;
            for (int i = 0; i < canshus.Length; i++)
            {
                result += canshus[i];
            }

            return result;
        }
        #endregion

        #region 参数修饰符

        static public void SetArray(int[] tempArray)
        {
            tempArray[0] = 99;
        }

        static public void ChangeArray(int[] tempArray)
        {
            tempArray = new int[3];
            tempArray[0] = 1;
        }

        static public void SetInt(int val)
        {
            val = 99;
        }


        static public void TestRef(ref int val)// 值参数的引用传递
        {
            val = 1;
        }

        static public void TestRef(ref int[] tempArray)
        {
            tempArray = new int[5] { 99, 88, 77, 66, 55};
        }



        static public void TestOut(out int val1, out int val2, out int val3)
        {
            val1 = 1;
            val2 = 1;
            val3 = 1;
        }

        #endregion

    }
}
