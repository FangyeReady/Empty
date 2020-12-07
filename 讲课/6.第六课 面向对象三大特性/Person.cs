using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第六课_面向对象三大特性
{
    abstract class Person
    {
        public string Name;
        abstract public void Print();//static不能和override, virtual, abstract同时使用

        public virtual void Test()
        { 
        
        }
    }

    class Men : Person
    {
        public override void Print()
        {
            Console.WriteLine(Name);
        }

        public new void Test()//隐藏父类的虚方法
        { 
            
        }
    }

    class Men1 : Men
    {
        //public override void Test()
        //{
        //    base.Test();
        //}
    }




}
