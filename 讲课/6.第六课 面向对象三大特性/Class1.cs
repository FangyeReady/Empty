using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第六课_面向对象三大特性
{
    class Class1
    {
        int a;
        public Class1(int val)
        {
            this.a = val;
            Console.WriteLine("调用了父类的构造方法~");
        }
        public void Test()
        {
            Console.WriteLine("父类的Test");
        }
    }


    class Class2 : Class1
    {

        public Class2(int val) : base(val)
        {
            Console.WriteLine("调用了子类的构造方法~");
        }


        public void Test2()
        {
            Console.WriteLine("子类的Test2");
        }
    }



    class Animal
    {
        //子类无法访问父类的私有成员
        private string Name;

        //受保护的成员, 不能再外部访问, 但是可以被子类访问
        protected string food;

        //既可以被外部访问, 也可以被子类访问
        public string Data;

        public string voice;

        public Animal(string str)
        {
            voice = str;
        }

        public virtual void Voice()
        {
            Console.WriteLine(voice);
        }
    }

    class Cat : Animal
    {


        public Cat(string str) : base(str)
        {
            base.food = "";
            
        }

        public void CatSp()
        { 
        
        }

        public override void Voice()
        {
            // base.Voice();
            Console.WriteLine("猫子类的叫声方法:" + voice);
        }

    }

    class Dog : Animal
    {
        public Dog(string str) : base(str)
        {

        }

        public override void Voice()
        {
            // base.Voice();
            Console.WriteLine("狗子类的叫声方法:" + voice);
        }
    }


    class JinMaoDog : Dog
    {
        string sex;
        public JinMaoDog(string sex, string str) : base(str)
        {
            this.sex = sex;
        }
    }


}
