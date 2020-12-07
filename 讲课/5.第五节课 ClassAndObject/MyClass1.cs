using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObject
{
    class MyClass1
    {
        //成员默认为private

        //公有字段
        public int b;

        //私有字段
        int a;
        //属性
        public int AAAA
        {
            set
            {
                if (value < 0)
                {
                    a = 0;
                }
                else
                {
                    a = value;
                }
            }

            get
            {


                //逻辑运算: + - * /
                return 99999;
            }
        }

        //构造方法1
        public MyClass1(int val1, int val2)
        {
            a = val1;
            b = val2;

            Console.WriteLine("调用了构造方法~~~1");
        }
        ////构造方法的重载
        public MyClass1(int val1, int val2, int val3)
        {
            a = val1;
            b = val2;

            Console.WriteLine("调用了构造方法~~~2");
        }

        //只能在类内部访问私有的构造方法
        private MyClass1(int val1)
        {
            a = val1;
        }

        //成员方法
        public void Print()
        {
            MyClass1 class1 = new MyClass1(999);
            Console.WriteLine("打印:" + GetValue(a));
        }
        //成员方法
        int GetValue(int temp)
        {
            b += temp;
            return b;
        }
    }

}
