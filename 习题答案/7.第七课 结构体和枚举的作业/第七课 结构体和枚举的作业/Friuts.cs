using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第七课_结构体和枚举的作业
{
    class FriutsManager
    {

        public void PrintFriuts(Fruits fr)
        {
            switch (fr)
            {
                case Fruits.Apple:
                    Console.WriteLine("苹果");
                    break;
                case Fruits.Orange:
                    Console.WriteLine("橘子");
                    break;
                case Fruits.Banana:
                    Console.WriteLine("香蕉");
                    break;
                default:
                    break;
            }
        }
    }
}
