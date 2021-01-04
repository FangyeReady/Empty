using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndString
{
    class MyClass
    {
        public int a;
        public void PrintA()
        {
            Console.WriteLine("a的值:" + a);
        }
    }

    class StudyArray
    {
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "  ");
            }

            Console.WriteLine();
        }

        public void Study()
        {
            //初始化一个数组
            int[] array = new int[3] { 1, 2, 3 };

            //对于值类型数组, get和set会发生装箱和拆箱操作
            //设置下标索引处的值
            array.SetValue(99, 0);
            //取得下标索引处的值
            int data = (int)array.GetValue(0);
            Console.WriteLine(data + "   用下标访问 ： " + array[0]);
            
            int[] arr2 = new int[3];
            //从目标索引处开始接收源数组的内容, 0代表从第0位开始
            array.CopyTo(arr2, 0);
            bool isEquale = Object.ReferenceEquals(array, arr2);
            Console.WriteLine("拷贝：" + isEquale);

            //
            int[] arr3 = arr2;

            isEquale = Object.ReferenceEquals(arr3, arr2);
            Console.WriteLine("赋值：" + isEquale);

            //ToString返回当前对象的类型的字符串
            //Console.WriteLine(arr3.ToString());

            //Array

            //克隆一个值类型的数组
            //克隆一个数组, 返回新的数组地址, 需要强转
            //PrintArray(arr3);

            Console.WriteLine("-------------------------");
            int[] arr4 = (int[])arr3.Clone();
            arr4[0] = 1;

            //PrintArray(arr4);
            isEquale = Object.ReferenceEquals(arr3, arr4);
            Console.WriteLine("克隆：" + isEquale);
           

            //克隆一个引用类型的数组
            MyClass[] arr5 = new MyClass[2];
            arr5[0] = new MyClass();
            arr5[0].a = 100;

            arr5[1] = new MyClass();
            arr5[1].a = 88;

            //引用类型的克隆会修改同一片内存区
            //MyClass[] arr6 = (MyClass[])arr5.Clone();
            //arr6[0].a = 99;
            //Console.WriteLine(arr5[0].a);


            //静态方法Sort
            //升序排序
            //Array.Sort(array);
            //逆序
            int[] arr7 = new int[] { 1, 8, 3, 2, 5, 6, 9, 0 };
            Array.Reverse(arr7);
            PrintArray(arr7);


           

            //Find, 根据条件查找
            var mc1 = Array.Find(arr5, (item) => { return item.a == 100; });
            if (mc1 != null)
            {
                mc1.PrintA();
            }
            else
            {
                Console.WriteLine("未找到");
            }


            //Array.Clear(arr7, 1, 3);

            int[] arr8 = new int[arr7.Length];
            Array.Copy(arr7, arr8, 5);
            PrintArray(arr8);
            //Console.ReadKey();
        }

    }
}
