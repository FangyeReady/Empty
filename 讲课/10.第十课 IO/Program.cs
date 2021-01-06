using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//引入读写的命名空间
using System.IO;

namespace 第十课_IO
{


    class Program
    {
        static void Main(string[] args)
        {
            //===============================编码Encoiding==========================
            Encoding encoding = Encoding.UTF8;
            Byte[] byteArray = encoding.GetBytes("这个是BBBBB一个#AAA文!@本n");
            string data = encoding.GetString(byteArray);
            Console.WriteLine(data);
            Console.Clear();

            //===============================文件File===============================
            string filePath = @"E:\FY-备课\21班\21ClassTeaching\讲课内容\第十课 IO\";
            string fileName = "IOTest_Create.txt";
            string path = string.Concat(filePath, fileName);
            //判断文件是否存在 
            bool isExits = File.Exists(path);
            string des = isExits ? "存在" : "不存在";
            Console.WriteLine(des);
            FileStream fs;
            if (!isExits)
            {
                fs = File.Create(path);
                Console.WriteLine("不存在, 就创建文件" + fileName);
                fs.Close();
            }
           

            //Console.ReadKey();

            //国标编码
            var gbEncoding = Encoding.GetEncoding("GB2312");

            //写入所有文本
            File.WriteAllText(path, "写入的内容!", gbEncoding);
            //读取所有文本
            string des1 = File.ReadAllText(path, Encoding.GetEncoding("GB2312"));
            Console.WriteLine(des1);

            //追加所有文本
            File.AppendAllText(path, "XXXXXXXXXXXXXXX", gbEncoding);

            //写入一个字符串数组
            string[] dataArray = { "12345", "abcde", "ABCDE", "啊啊啊哇企鹅" };
            File.WriteAllLines(path, dataArray, gbEncoding);

            //读度所有文本, 并以行为单位返回一个字符串数组
            string[] dataArray2 = File.ReadAllLines(path, gbEncoding);

            //写入一个字节数组
            Byte[] bytes = gbEncoding.GetBytes("AAAAAAAAAA啊啊啊啊啊啊啊啊啊");
            File.WriteAllBytes(path, bytes);

            //按字节数组的格式读取文本
            bytes = File.ReadAllBytes(path);
            string des3 = gbEncoding.GetString(bytes);
            Console.WriteLine(des3);

            //删除指定的文件
            File.Delete(path);

            //===============================目录Directory===============================
            Console.Clear();
            string dirName = "IOTest_Dir";
            string dirPath = filePath + dirName;
            //判断是否存在文件夹
            bool isExitsDir = Directory.Exists(dirPath);
            if (!isExitsDir)
            {
                //创建文件夹
                Directory.CreateDirectory(dirPath);
                Console.WriteLine("不存在则创建一个文件夹:" + dirName);
            }


            //得到指定目录下的所有文件名称及其路径
            string[] dirFilePathArray = Directory.GetFiles(dirPath);


            //得到指定目录下的所有子目录及其路径
            string[] dirDirPathArray = Directory.GetDirectories(dirPath);

            //得到当前执行程序的绝对路径
            string curPath = Directory.GetCurrentDirectory();
            Console.WriteLine("当前路径:" + curPath);


            //===============================Path路径===============================
            filePath = @"E:\FY-备课\21班\21ClassTeaching\讲课内容\第十课 IO";
            fileName = "IOTest_Create.txt";

            //会自动判断需要添加\的路径,从而添加\
            string realPath = Path.Combine(filePath, fileName);

            //获取文件的后缀名称
            string extention = Path.GetExtension(realPath);

            //获得文件名称, 带后缀
            string name = Path.GetFileName(realPath);

            //获得文件名称, 不带后缀
            string realName = Path.GetFileNameWithoutExtension(realPath);

            //返回绝对路径
            string fullPath = Path.GetFullPath(realPath);


            //===============================FilStream流读取===============================
            Console.Clear();

            path = Path.Combine(filePath, "诛仙2.txt");
            //创建流
            FileStream fs1 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);

            //创建用于存放读取的流数据: 字节数组
            byte[] desbytes = new byte[256];

            //fs1.Write(desbytes, 0, 100);//fs1流不支持写入

            //为方便下面的案例,先不进入读取
            while (false)
            {
                
                //读取
                int resultNum = fs1.Read(desbytes, 0, desbytes.Length);            
                //跳出循环
                if (resultNum == 0)
                {
                    break;
                }
                string txt = Encoding.UTF8.GetString(desbytes);
                //打印
                Console.WriteLine(txt);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Q)
                {
                    break;
                }
            }
            //关闭流
            fs1.Close();

            //===============================FilStream流写入===============================
            path = Path.Combine(filePath, "诛仙3.txt");
            //FileStream fs2 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    if (string.Equals(input, "Q"))
            //    {
            //        break;
            //    }

            //    byte[] dataArray3 = gbEncoding.GetBytes(input);
            //    fs2.Write(dataArray3, 0, dataArray3.Length);
            //}
            //fs2.Close();


            //using关键字:会自动释放被其修饰的流
            //创建一个写入的流
            using (FileStream fs3 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                while (true)
                {
                    string input = Console.ReadLine();
                    if (string.Equals(input, "Q"))
                    {
                        break;
                    }

                    byte[] dataArray3 = gbEncoding.GetBytes(input);
                    //写入内容
                    fs3.Write(dataArray3, 0, dataArray3.Length);
                    //刷新缓冲区
                    fs3.Flush();
                }
            }

            //StreamReader


            Console.ReadKey();
        }
    }
}
