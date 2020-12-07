using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第六课_面向对象三大特性
{
    class Friuts
    {
        string _name;
        public string Name { get { return _name; } }

        public Friuts(string str)
        {
            _name = str;
        }


        public virtual void PrintInfo()
        { 
            
        }
    }

    class Apple : Friuts
    {
        public Apple(string str) : base(str)
        {
          
        }


        public override void PrintInfo()
        {
            //base.PrintInfo(); //可以通过base关键字访问父类成员


            Console.WriteLine("我是 " + base.Name);
        }


        public override string ToString()
        {
            return "这是一个苹果类";
        }

    }
}
