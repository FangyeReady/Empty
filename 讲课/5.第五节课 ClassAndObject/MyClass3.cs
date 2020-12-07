using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObject
{
    class MyClass3
    {
        static int a;
        public static void Print()
        {
            int xxx = 0;
            //GetA(); //静态方法调用普通成员时,会报错, 因为普通成员的数据可能不存在
            Console.WriteLine("MyClass3.Print" + a);
        }


        public static void Print(int x)
        {
            //GetA(); //静态方法调用普通成员时,会报错, 因为普通成员的数据可能不存在
            Console.WriteLine("MyClass3.Print" + x);
        }

        public int GetA()
        {
            //普通方法调用静态成员是可以的, 因为静态成员一定存在
            Print();
            return a;
        }
    }
}
