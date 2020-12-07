using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructAndEnum
{
    interface IFly
    {
        void Fly();
    }

    interface IRun
    {
        void Run();
    }

    struct MyStruct : IFly, IRun
    {
        int a;

        public void Fly()
        {
            
        }

        public void Run()
        {
           
        }
    }

    struct Equipment
    {
        public string Name;
        public int ID;
        public int Attack;
        public int Defence;
        public int[] Array;


        public Equipment(string name, int ID, int attack, int defence, int[] array)
        {
            Name = name;
            this.ID = ID;
            Attack = attack;
            Defence = defence;
            Array = array;

            Console.WriteLine("自定义的构造方法~~~~");
        }


        public void Print()
        {
            Console.WriteLine("名字:" + Name + "   攻击力:" + Attack + "  防御力:" + Defence + " 数组:" + Array);
        }
    }

    class MyClass1
    {
        public int a;
    }
  
}
