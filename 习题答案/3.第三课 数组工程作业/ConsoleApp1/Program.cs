using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {



            int a = 1;
            switch (a)
            {
                case 0: { }break;
                case 1:
                case 2: { }break;
                default:
                    break;
            }














            //SetArray();
            //MaoPaoSort1();
            //MaoPaoSort2();
            //XuanZhePaiXu();
            //GetArraySum();
            //JiaoHuanArray();
            //ContactArray();
            //GetMaxAndMin();
            //Reverse();
            //int[] array = new int[14] { 0, 3, 1, 2, 4, 7, 6, 5, 8, 9 , 10, 99, 66, 6};
            //QuickSort(array, 0, array.Length - 1);

            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.Write(array[i] + "  ");
            //}

            Console.ReadKey();

        }


        /// <summary>
        /// 课堂练习：定义并输出一个二维数组
        /// </summary>
        static void SetArray()
        {
            int[,] arrayA = new int[3, 3];
            for (int i = 0; i < arrayA.GetLength(0); i++)
            {
                for (int j = 0; j < arrayA.GetLength(1); j++)
                {
                    arrayA[i, j] = i * j;
                }
            }


            for (int i = 0; i < arrayA.GetLength(0); i++)
            {
                for (int j = 0; j < arrayA.GetLength(1); j++)
                {
                    Console.Write(arrayA[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// 冒泡排序1
        /// </summary>
        static void MaoPaoSort1()
        {
            int[] arrayA = new int[] { 0, 9, 2, 1, 3, 4, 7, 5, 6, 8};


            for (int i = 0; i < arrayA.Length - 1; i++)
            {
                for (int j = 0; j < arrayA.Length - 1 - i; j++)
                {
                    if (arrayA[j] > arrayA[j + 1])
                    {
                        int temp = arrayA[j];
                        arrayA[j] = arrayA[j + 1];
                        arrayA[j + 1] = temp;
                        PrintArray(arrayA);
                    }
                }
            }

            
            Console.WriteLine("========================冒泡排序1：===========================");
            for (int i = 0; i < arrayA.Length; i++)
            {
                Console.Write(arrayA[i] + "  ");
            }
            Console.WriteLine();
        }

        static void PrintArray(int[] arry)
        {
            for (int i = 0; i < arry.Length; i++)
            {
                Console.Write(arry[i] + "  ");
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
        }

        /// <summary>
        /// 冒泡排序2
        /// </summary>
        static void MaoPaoSort2()
        {
            int[] arrayA = new int[] { 0, 9, 2, 1, 3, 4, 7, 5, 6, 8, 22, 13, 55, 90, 43};

            for (int i = 0; i < arrayA.Length - 1; i++)
            {
                for (int j = i + 1; j < arrayA.Length; j++)
                {
                    if (arrayA[i] > arrayA[j])
                    {
                        int temp = arrayA[i];
                        arrayA[i] = arrayA[j];
                        arrayA[j] = temp;
                    }
                }
            }


            Console.WriteLine("========================冒泡排序2：===========================");
            for (int i = 0; i < arrayA.Length; i++)
            {
                Console.Write(arrayA[i] + "  ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        static void XuanZhePaiXu()
        {
            int[] arrayA = new int[] { 0, 9, 2, 1, 13, 15, 31, 51 , 5, 6, 8, 22, 14, 55, 90, 43 };

            for (int i = 0; i < arrayA.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arrayA.Length; j++)
                {
                    if (arrayA[minIndex] > arrayA[j])
                    {
                        minIndex = j;
                    }
                }

                int temp = arrayA[i];
                arrayA[i] = arrayA[minIndex];
                arrayA[minIndex] = temp;
            }


            Console.WriteLine("========================选择排序：===========================");
            for (int i = 0; i < arrayA.Length; i++)
            {
                Console.Write(arrayA[i] + "  ");
            }
            Console.WriteLine();

        }


        //=================================================家庭作业=================================================
        //第一题:定义有10个元素的int数组,输入10个整数得到总和
        static void GetArraySum()
        {
            int[] arrayA = new int[10];

            int count = 0;
            while ( count < arrayA.Length )
            {
                Console.WriteLine("请输入第" + count + "个整数：");
                string str = Console.ReadLine();
                int data;
                bool isRealValue = int.TryParse(str, out data);
                if (isRealValue)
                {
                    arrayA[count] = data;
                    ++count;
                }
                else
                {
                    Console.WriteLine("输入数据不是一个整型！！请重新输入");
                    Console.ReadKey();
                    //Console.Clear();
                }

            }


            int result = 0;
            for (int i = 0; i < arrayA.Length; i++)
            {
                result += arrayA[i];
            }
            Console.WriteLine("数组的和为：" + result);
        }

        /// <summary>
        /// 第二题： 定义2个有5个元素的int数组,输入10个整数到2个数组中,交换2个数组的数据
        /// </summary>
        static void JiaoHuanArray()
        {
            int[] arrayA = new int[5];
            int[] arrayB = new int[5];

            int count = 0;
            int index2 = 0;
            while (count < 10)
            {
                Console.WriteLine("请输入第" + count + "个整数：");
                string str = Console.ReadLine();
                int data;
                bool isRealValue = int.TryParse(str, out data);
                if (isRealValue)
                {
                    if (count < 5)
                    {
                        arrayA[count] = data;
                    }
                    else
                    {
                        arrayB[index2++] = data;
                    }
                    ++count;
                }
                else
                {
                    Console.WriteLine("输入数据不是一个整型！！请重新输入");
                    Console.ReadKey();
                    //Console.Clear();
                }

            }

            //交换数组
            for (int i = 0; i < 5; i++)
            {
                int temp = arrayA[i];
                arrayA[i] = arrayB[i];
                arrayB[i] = temp;
            }



            Console.WriteLine("交换数组后：");
            Console.WriteLine("第一个数组中的元素为：");
            for (int i = 0; i < arrayA.Length; i++)
            {
                Console.Write(arrayA[i] + "  ");
            }
            Console.WriteLine();
            Console.WriteLine("第二个数组中的元素为：");
            for (int i = 0; i < arrayB.Length; i++)
            {
                Console.Write(arrayB[i] + "  ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// 第三题：定义有两个数组，将两个数组合并为一个数组，并去除其中重复的元素
        /// </summary>
        static void ContactArray()
        {
            int[] arrayA = new int[] {1,2,3,4,5 };
            int[] arrayB = new int[] { 6,7,8,9,10,11 };


            int[] arrayC = new int[arrayA.Length + arrayB.Length];

            int index1 = 0;
            int index2 = 0;
            int count = 0;
            while ( index1 < arrayA.Length && index2 < arrayB.Length)
            {

                int data1 = arrayA[index1++];
                int data2 = arrayB[index2++];
               
                arrayC[count++] = data1;
                arrayC[count++] = data2;
            }

            //判断哪一个数组先走完, 得到未走完的数组
            int[] arrayAgain = index1 == arrayA.Length  ? arrayB : arrayA;
            int index = arrayAgain == arrayA  ? index1 : index2;

            //对第二个数组进行处理
            for (int i = index; i < arrayAgain.Length; i++)
            {
                arrayC[count++] = arrayAgain[i];
            }


            Console.WriteLine("合并后的数组：");
            for (int i = 0; i < arrayC.Length; i++)
            {
                Console.Write(arrayC[i] + "  ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// 第四题：定义有10个元素的int数组,得到数组中最大值、最小值
        /// </summary>
        static void GetMaxAndMin()
        {
            int[] arrayA = new int[] { 6, 7, 8, 9, 10, 11 , 3, 2, 4, 5, 1};

            int max = arrayA[0];
            int min = arrayA[0];

            for (int i = 0; i < arrayA.Length; i++)
            {
                if (max < arrayA[i])
                {
                    max = arrayA[i];
                }

                if (min > arrayA[i])
                {
                    min = arrayA[i];
                }

            }

            Console.WriteLine("最大值为：" + max + "   最小值为:" + min);
        }

        /// <summary>
        /// 第五题：定义有10个元素的int数组,输入10个整数进行逆序
        /// </summary>
        static void Reverse()
        {
            int[] arrayA = new int[11];
            int count = 0;
            while (count < arrayA.Length)
            {
                string str = Console.ReadLine();
                int data = int.Parse(str);
                arrayA[count++] = data;
            }

            //逆序
            for (int i = 0; i < arrayA.Length / 2; i++)
            {
                int temp = arrayA[arrayA.Length - i - 1];
                arrayA[arrayA.Length - i - 1] = arrayA[i];
                arrayA[i] = temp;

            }


            for (int i = 0; i < arrayA.Length; i++)
            {
                Console.Write(arrayA[i] + "  ");
            }
            Console.WriteLine();
        }


        //快速排序
        static void QuickSort(int[] resArray, int left, int right)
        {
            if (left < right)
            {
                int leftIndex = left;
                int rightIndex = right;
                int flagValue = resArray[leftIndex];
                while (leftIndex < rightIndex)
                {
                    //从右向左找，直到遇到一个小于目标值的值
                    while (leftIndex < rightIndex && resArray[rightIndex] > flagValue)
                    {
                        rightIndex--;
                    }
                    if (leftIndex < rightIndex)
                    {
                        resArray[leftIndex++] = resArray[rightIndex];
                    }


                    //从左往右找，直到遇到大于目标值的值
                    while (leftIndex < rightIndex && resArray[leftIndex] < flagValue)
                    {
                        leftIndex++;
                    }
                    if (leftIndex < rightIndex)
                    {
                        resArray[rightIndex--] = resArray[leftIndex];
                    }
                }

                resArray[leftIndex] = flagValue;

                QuickSort(resArray, left, leftIndex - 1);
                QuickSort(resArray, leftIndex + 1, right);
            }
        
        }
    }
}
