using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObject
{
    class MyClass2
    {
        private int[] datas;

        public MyClass2(int length)
        {
            datas = new int[length];
        }

        //索引器
        public int this[int index]
        {
            set {
                if (index < 0)
                {
                    index = 0;
                }
                if (index >= datas.Length )
                {
                    index = datas.Length - 1;
                }

                datas[index] = value;
            }
            get {
                if (index < 0)
                {
                    index = 0;
                }
                if (index >= datas.Length)
                {
                    index = datas.Length - 1;
                }

                return datas[index];
            }
        }


        public void Print()
        {
            for (int i = 0; i < datas.Length; i++)
            {
                Console.Write(datas[i] + "  ");
            }
        }
    }
}
