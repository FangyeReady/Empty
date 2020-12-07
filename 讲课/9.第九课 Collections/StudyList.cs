using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class StudyList
    {
        private static void PrintList(List<int> list1)
        {
            //遍历访问集合中的元素
            for (int i = 0; i < list1.Count; i++)
            {
                Console.Write(list1[i] + "  ");
            }

            Console.WriteLine();
        }

        public void Study()
        {
            //List<T>  列表
            //初始化
            List<int> list1 = new List<int>();
            //向集合添加元素  
            for (int i = 0; i < 10; i++)
            {
                list1.Add(i);
            }

            //--------------------------注意点:------------------------------------
            //此时list中有十个元素
            //此处报错,因为第是个元素并不存在(未被添加),因此无法被赋值修改
            //list1[10] = 99;
            //---------------------------------------------------------------------

            list1[9] = 99;
            list1[8] = 88;
            //PrintList(list1);

            //移除list中的指定元素
            //list1.Remove(99);

            //通过下标移除数组元素
            list1.RemoveAt(list1.Count - 1);
            //PrintList(list1);
            list1.RemoveAt(3);
            //PrintList(list1);

            //在指定索引处插入一个元素
            list1.Insert(0, 11);
            //PrintList(list1);

            //在指定索引处插入一个范围(多个)的元素  此处是插入一个数组
            list1.InsertRange(6, new int[] { 9, 8, 7 });
            List<int> list2 = new List<int>(new int[] { 1, 2, 3 });

            //此处是插入List的集合
            list1.InsertRange(0, list2);

            //查找指定元素在集合中的下标(位置)
            int index = list1.IndexOf(88);

            //集合中是否包含某个元素
            bool isContain = list1.Contains(88);
            if (isContain)
            {
                Console.WriteLine("list中存在 : " + 88);
            }

            PrintList(list1);

            //清空list中的元素, 但list本身并未被回收
            list1.Clear();
            //清空后list中的元素数量为0
        }


    }
}
