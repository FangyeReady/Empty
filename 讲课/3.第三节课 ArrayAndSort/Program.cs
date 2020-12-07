using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //==================数组的定义并赋值==================
            int[] array1 = new int[20];
            int[] array2 = new int[3] { 1, 2, 3 };

            array1 = new int[5];


            //数组赋值
            //array1[0] = 1;
            //array1[1] = 2;
            //...
            //array1[19] = 19;

            //Console.WriteLine(array1[0]);//不能访问未赋值的对象(内存区)

            Console.WriteLine("数组的长度: " + array1.Length);

            //循环赋值
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = i;
            }


            //使用数组里的值对其它变量赋值
            int a1 = array1[0];

            //修改数组的值
            array1[0] = 1;

            //并不会修改数组内的值
            a1 = 2;

            Console.WriteLine(array1[0] + "---" + a1);



            //二维数组: 定义一个四行四列的二维数组
            int[,] array3 = new int[4, 4];

            //定义一个四行四列的二维数组, 并初始化
            int[,] array4 = new int[2, 3] {
                { 1,0,0 },
                { 2,0,0 },
            };


            int a2 = array4[ 0, 0 ];

            //访问二维数组:
            for (int i = 0; i < array4.GetLength(0); i++)
            {
                for (int j = 0; j < array4.GetLength(1); j++)
                {
                    Console.Write(array4[i, j] + "  ");
                }
                Console.WriteLine();
            }


            Console.Clear();
            //======================冒泡排序======================

            int[] array = new int[] { 9, 0, 1, 2, 5, 3, 6, 4, 7, 8, 88, 66, 22, 77 };
            for (int i = 0; i < array.Length - 1; i++)       //循环次数：总长度减1
            {
                Console.WriteLine("------第" + i + "次循环------");
                //比较次数：总长度 - 1 - 已经循环的次数
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    //如果 a 比 b 大，则交换顺序， 这种比法为升序排序，降序则恰好相反
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];    //用一个临时变量存储 a 的数据
                        array[j] = array[j + 1];//将 b 赋值给 a
                        array[j + 1] = temp;   //再将刚刚 a 的数据赋值给 b
                    }
                    PrintArray1(array, j);
                }
            }


            Console.WriteLine("======================冒泡排序后的结果=======================");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }

            Console.Clear();
            //======================选择排序======================
            array = new int[] { 9, 0, 1, 2, 5, 3, 6, 4, 7, 8, 88, 66, 22, 77 };
            //遍历每一个数 
            for (int i = 0; i < array.Length - 1; i++)
            {
                //先假定最小数的下标为当前下标i
                int minIndex = i;
                //把当前最小下标的数和它后面的每一个数进行比对
                for (int j = i + 1; j < array.Length; j++)
                {
                    //如果这个下标值大于后面的数，重新赋值下标为较小的那个数的下标
                    if (array[minIndex] > array[j])
                    {
                        minIndex = j;
                    }
                }
                //最后一定会得到一个最小值的下标，和当前值进行交换
                //如果当前值就是最小数,则可以不进行交换
                if (i != minIndex)
                {
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
               
                PrintArray2(array, minIndex);
            }

            Console.WriteLine("======================选择排序后的结果=======================");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }


            //随机数
            Random random = new Random((int)DateTime.Now.Ticks);
            int x = random.Next(0, 100);
            int y = random.Next(0, 100);




            Console.ReadKey();
        }


        static void PrintArray1(int[] array, int index)
        {
            Console.Write("j为" + index + ":   ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine();
        }

        static void PrintArray2(int[] array, int index)
        {
            Console.Write("被交换的下标为" + index + ":   ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine();
        }

    }
}
