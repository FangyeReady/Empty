using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructAndEnum
{
    class Program
    {

        static void CheckState(Student stu)
        {
            if ((int)Friuts.Apple == (int)Student.GIRLS)
            {
                return;
            }

            if ( (int)stu == 9 )
            {
                return;
            }


            switch (stu)
            {
                case Student.BOYS://处理boys的逻辑代码
                    break;
                case Student.GIRLS:
                    break;
                case Student.BigBoys:
                    break;
                case Student.BigGirls:
                    break;
                case Student.Childs:
                    break;
                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            //结构体是值类型: 存储在栈内存中
            Equipment sward;
            sward.Attack = 1;
            sward.Defence = 10;
            sward.Name = "剑!";
            //Console.WriteLine(sward.Defence);

            //系统默认的构造: 值类型会被赋予默认值, 引用类型仍然没有初始化
            Equipment eq2 = new Equipment();
            eq2.Print();
            Console.WriteLine(eq2.Array[0]);

            //自定义的构造: 赋什么就是什么值
            Equipment eq1 = new Equipment("装备1", 1001, 10, 10, null);//null可以赋值给引用类型
            eq1.Print();


            Equipment[] equipmentArray = new Equipment[10];






            Student stu;
            stu = Student.BigBoys;

            //不可修改枚举的值
            //Student.BigBoys = 1;


            ConstTest abc = new ConstTest(99);

            //编译时常量只能用类名访问
            //ConstTest.val = 2;

            //运行时常量用对象名访问
            //abc.val2 = 5;

            //实例化MyClass1
            MyClass1 mc1 = new MyClass1();
            mc1.a = 10;

            //引用类型的数组: 此时仅开辟了一个连续的空间, 里面理应存没有class1的地址, 但此时没有存地址
            MyClass1[] mc1Array = new MyClass1[10];
            //对数组的第0个元素赋值:实例化一个MyClass1并返回其在堆内存中的地址给数组中第0个元素
            mc1Array[0] = new MyClass1();
            //访问数组中第0个元素所指向的堆内存,并修改其中的值
            mc1Array[0].a = 100;

            Console.ReadKey();
        }

     












    }


   
}
