using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第四课方法作业
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = GetUpperLowerString("AAAaaa===---12312````1`@@BBB%bbb");
            Console.WriteLine( str );

            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //DaLuanShuZu(array);
            int jishu, oushu;
            GetJiShuAndOuShuArray(array, out jishu, out oushu);

            //Console.WriteLine(jishu + "---" + oushu);
            //Add(1 + 2 + 3);

            Console.WriteLine((char)(65));

            Console.ReadKey();
        }

        //====================重载==================
        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Add(int c, int d, int e)
        {
            return c + d + c;
        }

        static int Add(int c, int d, float e)
        {
            return c + d + c;
        }

        static int Add(params int[] datas)
        {
            int result = 0;
            for (int i = 0; i < datas.Length; i++)
            {
                result += datas[i];
            }

            return result;
        }
        //=============比较大小关系==================
        static void CalcEquals(int a, int b)
        {
            string str;

            if (a > b)
            {
                str = "大于";
            }
            else if(a < b)
            {
                str = "小于";
            }
            else
            {
                str = "等于";
            }

            Console.WriteLine("a " + str + " b");
        }

        //=============修改一个数组中的值=============
        static void ChangArrayValue(int[] array, int index, int value)
        {
            //if (index >= array.Length  || index < 0)
            //{
            //    Console.WriteLine("传入的数组长度有误！");
            //    //return;

            //}

            if (index >= array.Length)
            {
                index = array.Length - 1;
            }
            if (index < 0 )
            {
                index = 0;
            }

            array[index] = value;
        }
        //=============交换两个整数数据================
        static void ExChangeData( ref int vala, ref int valb)
        {
            int temp = vala;
            vala = valb;
            valb = temp;
        }

        //=============求数组平均数====================
        static float GetAverge(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            float resultAv = (sum + 0.0f) / array.Length;

            return resultAv;
        }
        //=============字符串大小写转换=================
        static string GetUpperLowerString(string data)
        {
            char ch = 'a';
            ch = 'b';
            //ch += 32;

            ch = (char)(ch + 32);



            string str = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
  
                int number = data[i];

                if (data[i] >= 'A' && number <= 'Z')
                {
                    number += 32;

                    //data[i] = (char)(data[i] +  32);  //string的所引起未提供set操作
                }
                else if (data[i] >= 'a' && number <= 'z')
                {
                    number -= 32;
                }

                str = str +  (char)number;
            }
            return str;
        }
        //=============最大公约数：如果数a能被数b整除，a就叫做b的倍数，b就叫做a的约数======================
        //如果数a能被数b整除，a就叫做b的倍数，b就叫做a的约数； 

        //最大公约数就是同时能被两个数整除的数里面最大的那个
        //比如， 4可以被4，2，1整除，   6可以被6，3，2，1整除，由此可以发现，4和6都能被2和1整除，2和1就是数4，数6的公约数
        //因此可以得出，最大公约数就是公约数中最大的那个，因此此处2就是4，6的最大公约数

        //最小公倍数，就是能够分别整除这两个数中的数里最小的那个， 
        //比如  4，2这两个数， 都能被4整除，也都能被6整除，能同时整除这两个数的数就是公倍数，而公倍数中最小的就是最小公倍数
        static int GetMaxGongYueShu(int a, int b)
        {
            int result = a % b;
            while (result != 0)
            {
                a = b;
                b = result;
                result = a % b;
            }

            return b;
        }
        //=============最小公倍数:  若干数的乘积除以其最大公约数  ======================
        static int GetMinGongBeiShu(int a, int b)
        {
            int maxGongyueShu = GetMaxGongYueShu(a, b);

            int minGongBeiShu = a * b / maxGongyueShu;

            return minGongBeiShu;
        }
        //=============打乱一个数组======================
        static void DaLuanShuZu(int[] array)
        {
            int length = array.Length;
            while ( length > 0 )
            {
                Random random = new Random((int)DateTime.Now.Ticks);
                int index = random.Next() % length;
                length--;
                //挑了一个随机下标的数放在最后面，以此类推
                int tempData = array[index];
                array[index] = array[length];
                array[length] = tempData; 
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
        }



        //=============求奇数偶数的和,并返回======================
        static void GetJiShuAndOuShuArray(int[] dataArray, out int jishuResult, out int oushuResult)
        {
            int jishuSum = 0;
            int oushuSum = 0;
            for (int i = 0; i < dataArray.Length; i++)
            {
                if (dataArray[i] % 2 == 0)
                {
                    oushuSum += dataArray[i];
                }
                else
                {
                    jishuSum += dataArray[i];
                }
            }

            jishuResult = jishuSum;
            oushuResult = oushuSum;
        }

    }
}
