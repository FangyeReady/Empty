using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class StudyQueue
    {

        public void Study()
        {
            //初始化队列
            Queue<int> que = new Queue<int>();
            for (int i = 0; i < 5; i++)
            {
                que.Enqueue(i);
            }

            //取得队列头的元素, 不移除
            int val = que.Peek();
            //Console.WriteLine(val);


            //取得队列头的元素,并从队列头移除该元素
            //int val2 = que.Dequeue();
            //取得队列头的元素, 不移除
            val = que.Peek();
            //Console.WriteLine(val2 + "-----" + val);



            //遍历
            foreach (var item in que)
            {
                Console.Write(item + "   ");
            }
        }

    }
}
