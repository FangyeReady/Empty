using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructAndEnum
{
    class ConstTest
    {
        //const修饰的变量即为常量
        public const int val = 1;

        //readonly修饰为运行时常量
        public readonly int val2;

        public ConstTest(int data)
        {
            val2 = data;
        }


    }
}
