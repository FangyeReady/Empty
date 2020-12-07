using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class StudyStack
    {
        public void Study()
        {
            //初始化一个栈集合
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Push(4);
            stack1.Push(5);
            stack1.Push(6);

            //Peek查看栈顶元素
            int val1 = stack1.Peek();
            Console.WriteLine(val1 + "  Count:" + stack1.Count);

            //Pop取出元素,并在集合中删除对应元素
            //int val2 = stack1.Pop();
            //Console.WriteLine(val2 + " ---- " + stack1.Peek());//此时Peek得到的是2, 3已经被移除

            //判断元素
            bool isContain = stack1.Contains(1);
            if (isContain)
            {
                Console.WriteLine("栈中存在元素:" + isContain);
            }

            //遍历
            foreach (var item in stack1)
            {
                Console.Write(item + "   ");
            }
        }


    }
}
