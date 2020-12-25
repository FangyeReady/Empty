using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 用FileStream复制
            string path = @"F:\data.flv";
            byte[] desData = new byte[10240000];

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
              
                //byte[] buffer = new byte[256];
                //int readCount = 0;
                //int totalCount = 0;
                //while (true)
                //{
                //    readCount = fs.Read(buffer, 0, buffer.Length);
                //    if (readCount == 0)
                //    {
                //        break;
                //    }

             
                //    SetData(buffer, desData, ref totalCount);
                //}

                Console.WriteLine(desData.Length);

            }

            path = @"F:\newData.flv";
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                //fs.Write(desData, 0, desData.Length);
            }

            #endregion


            //复制
            File.Copy(path , @"F:\newData2.flv");
            //剪切
            File.Move(path, @"F:\FY-Teaching\newData2.flv");


            Console.ReadKey();
        }


        static void SetData(byte[] buffer, byte[] data ,ref int count )
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                data[count++] = buffer[i];
            }
        }
    }




}
