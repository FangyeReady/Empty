using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace 流读取写入其它文件
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"F:\";
            string fileName = "data.flv";
            string path = Path.Combine(filePath, fileName);

            byte[] data = new byte[1024 * 1024 * 71];

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                
                byte[] tempData = new byte[256];

                int readCount = 0;
                
                while (true)
                {
                    if (readCount > 0 )
                    {
                        tempData.CopyTo(data, fs.Position - 256);
                    }
                    
                    readCount = fs.Read(tempData, 0, tempData.Length);


                    if (readCount <= 0)
                    {
                        break;
                    }

                    Thread.Sleep(1);
                }
            }

            Console.WriteLine("按任意键继续!");
            Console.ReadKey();

            path = Path.Combine(filePath, "new视频.flv");
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                int index = 0;
                while (index < data.Length)
                {
                    fs.WriteByte(data[index++]);
                }
            }


            Console.WriteLine("写入结束!");
            Console.ReadKey();
        }
    }
}
