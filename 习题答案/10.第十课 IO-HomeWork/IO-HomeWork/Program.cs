using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_HomeWork
{
    class Program
    {
        static string path = @"E:\Students\评讲\IO";
        static string name = "Test.txt";
        static void Main(string[] args)
        {
            string realPath = Path.Combine(path, name);
            string dataPath = @"E:\Students\讲课\IOTest.txt";
            IOClass.WriteFile(realPath, dataPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, Encoding.UTF8);



            Console.ReadKey();
        }
    }
}
