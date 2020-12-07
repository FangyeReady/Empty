using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第九课_集合作业
{
    class Program
    {
        /// <summary>
        /// 合并两个list， 并去除其中重复部分
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <param name="list3"></param>
        static void CombineLists(List<int> list1, List<int> list2, out List<int> list3)
        {
            list3 = new List<int>();

            for (int i = 0; i < list1.Count; i++)
            {
                if (!list3.Contains(list1[i]))
                {
                    list3.Add(list1[i]);
                }
            }

            for (int i = 0; i < list2.Count; i++)
            {
                if (!list3.Contains(list2[i]))
                {
                    list3.Add(list2[i]);
                }
            }

        }


        static void Main(string[] args)
        {

            LoginManager.StartApp();


            //TODO:剩下的游戏逻辑


            Console.ReadKey();
        }
    }
}
