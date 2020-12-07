using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObject
{
    //类名要以大驼峰命名规则
    class 大驼峰命名
    { 
    
    }

  

    class Program
    {
        static void Main(string[] args)
        {
            MyClass2 mc2 = new MyClass2(10);
            //调用索引指示器
            mc2[0] = 100;
            mc2.Print();

            Console.WriteLine();

            MyClass3.Print();

            //我们无法去实例化一个静态对象,因为它在程序运行之处就已经存在了,有且仅有这一份
            //MyClass4 mc4 = new MyClass4();


            MyClass5 myClass5 = new MyClass5();
            //Console.WriteLine("只有Set的属性:" + myClass5.Data);//此处报错

            Console.WriteLine("只有get的属性:" + myClass5.Data2);
            myClass5.Data3 = 1;

            Console.ReadKey();
        }
    }
}
