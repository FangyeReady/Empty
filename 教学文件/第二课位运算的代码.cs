using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    struct MyStruct
    {
        int a;
        int b;
        float c;
        char d;
        long e;
    }


    class MyClass
    {
        public const int ca = 1;
    
    }

    class Program
    {
        static void Main(string[] args)
        {
       



            //00000000 00000000 00000000 01100100
            int a = 100;
            //00000000 00000000 00000000 00000001
            int b = 1;

            //&同为1则为1
            int c = a & b;
            Console.WriteLine("&:" + c);

            //|有一个为1则为1
            c = a | b;
            Console.WriteLine("|:" + c);


            //^相同为0，不同为1
            c = a ^ b;
            Console.WriteLine("^:" + c);

            //~按位取反
            //00000000 00000000 00000000 10000000
            //~
            //11111111 11111111 11111111 01111111  得到取反后的数
            //~
            //00000000 00000000 00000000 10000000  得到原码
            //值+1
            //00000000 00000000 00000000 10000001  得到值
            //正变负， 负变正  即值的符号取相反
            //-00000000 00000000 00000000 10000001 得到正确的值

            int x = 10000000;
            c = ~x;
            Console.WriteLine("~:" + c);


            //<<左移
            c = b << 2; //00000000 00000000 00000000 00000100
            Console.WriteLine("~:" + c);

            //>>右移
            //10
            //00000000 00000000 00000000 00001010
            //>>
            //00000000 00000000 00000000 00000010
            c = 10 >> 2; 
            Console.WriteLine("~:" + c);


            Console.ReadKey();
            Console.Clear();
            Console.Beep();

            Console.ReadKey();
        }
    }
}
