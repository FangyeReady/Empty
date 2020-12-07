using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNeiCun
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a = 1;
            //int b = 1;
            //unsafe {

            //    var des= &a;

            //    var des2 = &b;

            //    Console.ReadKey();
            //}

            while (true)
            {
                Console.WriteLine("请输入两个数字， 分别作为number，pos:");
                int number = int.Parse(Console.ReadLine());
                int pos = int.Parse(Console.ReadLine());

                if (pos >= number)
                {
                    Console.WriteLine("pos应该小于number, 请重新输入");
                    Console.WriteLine();
                    continue;
                }

                string str = string.Empty;
                for (int i = 0; i < number; i++)
                {
                    if (i == pos)
                    {
                        str += "1";
                    }
                    else
                    {
                        str += "0";
                    }
                }

                Console.WriteLine(str);
                Console.ReadKey();
                Console.Clear();
            }
            


            Console.ReadKey();

        }
    }
}
