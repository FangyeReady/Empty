using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Father
    {
        public int b;

        public Father(int val)
        {
            b = val;
        }

        public void Print1()
        {
            Console.WriteLine("父类的方法~~~~~");
        }
    }


    class Child : Father
    {
        int a;
        public void Print2()
        {
            Console.WriteLine("子类的方法~~~~~" + a);
        }


        public Child(int val1, int val2) : base(val1)
        {
            a = val2;
        }
    }

    class Child2 : Child
    {
        public Child2(int val1, int val2) : base(val1, val2)
        { 
        
        }
    }


    abstract class Dady
    {
        abstract public void Print();
    }

    class DadyChild : Dady
    {
        public override void Print()
        {
           
        }
    }




    abstract class Class1
    {
        public abstract void Test();

        public void Print()
        {
            Test();
        }
    
    }






    class Program
    {

        struct Data5
        {
            public int a;
            public float b;
            public int[] array;
            public Data5(int a, int b, int length)
            {
                this.a = a;
                this.b = b;
                this.array = new int[length];
            }

            public int AAA
            {
                get { return a; }
            }

            public void Print()
            {
                Console.WriteLine(a + b);
            }
        }


        public struct Data2
        {
            public int a;

            public int[] array;
        }







        static void Main(string[] args)
        {
            //子类转父类： 隐式转
            //Father f = new Child();
            //f.Print1();

            ////父类转子类： ()强转
            //Father f2 = new Father();
            //Child ch = (Child)f2;  //此处为f则不会报错
            //ch.Print1();
            //ch.Print2();

            ////父类转子类： as强转
            //Father f3 = new Father();
            //Child ch2 = f3 as Child;// 此处为f则不会报错， as转换失败则返回null
            //ch2.Print1();
            //ch2.Print2();



            Data5 d = new Data5(1,2, 5);


            Data2 data2;
            data2.a = 1;
            data2.array = new int[] { 1, 2, 3 };

            ChangSruct(ref data2);
            Console.WriteLine( data2.a);


            for (int i = 0; i < data2.array.Length; i++)
            {
                Console.WriteLine(data2.array[i]);
            }

            Console.ReadKey();

        }


        public static void ChangSruct( ref Data2 data2)
        {
            data2.a = 5;
            data2.array = new int[] { 7, 8, 9, 10 };
        }
    }
}
