using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructAndEnum
{
    enum Student
    { 
        BOYS,
        GIRLS,
        BigBoys,
        BigGirls,
        Childs,
    }


    enum Friuts
    {
       Apple = Student.Childs + 1,
       Orange = 100,
       Banana,
    }
}
