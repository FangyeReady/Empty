using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第六课_面向对象三大特性
{
    class Program
    {
        static void PrintVoice(Animal ani)
        {
            ani.Voice();
        }

        static void Main(string[] args)
        {

            Class2 c2 = new Class2(1);
            //c2.Test();
            //c2.Test2();


            //Class1 c1 = new Class1(1);
            //c1.Test();


            Cat cat = new Cat("喵~~~~");
           // cat.Voice();

            Dog dog = new Dog("汪汪~~~~");
            //dog.Voice();

            //PrintVoice(cat);
            //PrintVoice(dog);


            //子类隐式转换成父类
            object cat2 = new Cat("");


            Animal animal = new Cat("喵");
            animal.Voice();
            
            //animal.CatSp();

            Cat cat3 = (Cat)animal;
            cat3.CatSp();

            //错误的转换方式
            //Animal animal1 = new Animal("动物父类");
            //Cat cat4 = (Cat)animal1;
            //cat4.Voice();
            //cat4.CatSp();

            Animal animal2 = new Animal("动物父类");
            Cat cat5 = animal2 as Cat;//如果转换失败, 返回null
            if (cat5 != null)
            {
                cat5.Voice();
            }


            bool isAnimal = dog is Animal;//返回true 或者 false
            if (isAnimal)
            {
                Console.WriteLine("dog是Animal");
            }


            Console.Clear();

            Apple ap = new Apple("苹果");
            ap.PrintInfo();
            Console.WriteLine(ap.ToString());

            Console.Clear();

            //Person per = new Person();


            //利用多态的特性打印
            Animal[] animals = { cat, dog };
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].Voice();
            }


            Console.ReadKey();
        }
    }
}
