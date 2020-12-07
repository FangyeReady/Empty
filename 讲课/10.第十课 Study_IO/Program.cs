using System;
using System.Collections.Generic;
using System.IO;//引用读写文件的命名空间;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_IO
{
    class Program
    {
        static string filePath = @"E:\FY-备课\Students\讲课";//@是禁用转义
        static string fileName = "IOTest.txt";
        static string dirName = "DirTest";

        static string[] datas = {
            "床前明月光",
            "疑是地上霜",
            "举头望明月",
            "低头思故乡"
        };

        /// <summary>
        ///  判断是否有文件
        /// </summary>
        /// <param name="path"></param>
        static bool IsExitsFile(string path)
        {
            bool isExits = File.Exists(path);
            if (isExits)
            {
                Console.WriteLine("存在文件: " + fileName);
            }
            else
            {
                Console.WriteLine("不存在文件: " + fileName);
            }

            return isExits;
        }

        /// <summary>
        /// 创建一个文件
        /// </summary>
        /// <param name="path"></param>
        static void CreateFile(string path)
        {
            File.Create(path);
            Console.WriteLine("创建File成功!");
        }

        /// <summary>
        /// 是否存在目录
        /// </summary>
        /// <param name="path"></param>
        static bool IsExitxDirectory(string path)
        {
            bool isExits = Directory.Exists(path);
            if (isExits)
            {
                Console.WriteLine("存在目录: " + dirName);
            }
            else
            {
                Console.WriteLine("不存在目录: " + dirName);
            }

            return isExits;
        }



        static void Main(string[] args)
        {
            string path = Path.Combine(filePath, fileName);
            Encoding myEncoding = Encoding.UTF8;

            //判断是否存在文件
            //if (!IsExitsFile(path))
            //{
            //    CreateFile(path);
            //}
            string data = "撒士大夫士大夫士大夫发生\ntryasdeadadf";

            //写入文件内容
            //File.WriteAllText(path, data);


            //追加文件内容
            //File.AppendAllText(path, "新添加的内容");


            //写入所有行
            //string txt = File.ReadAllText(path);
            //File.WriteAllLines(path, datas);

            //读取所有行
            //string[] txts = File.ReadAllLines(path, Encoding.UTF8);

            //for (int i = 0; i < txts.Length; i++)
            //{
            //    Console.WriteLine(txts[i]);
            //}

            //写入所有字节数组
            // Byte[] bytes = myEncoding.GetBytes(data);
            //  File.WriteAllBytes(path, bytes);

            //读取内容，并转化为字节数组保存
            //Byte[] bytes = File.ReadAllBytes(path);
            //string txt =  myEncoding.GetString(bytes);//将字节转化为字符串
            //Console.WriteLine(txt);

            //File.Delete(path);



            //-----------------------------------目录的操作-------------------------------
            string dirPath = Path.Combine(filePath, dirName);
            bool isExits = IsExitxDirectory(dirPath);
            if (!isExits)
            {
               //Directory.CreateDirectory(dirPath);
            }

            //获取文件夹内的文件的绝对路径
           string[] dirFiles =  Directory.GetFiles(dirPath);
           for (int i = 0; i < dirFiles.Length; i++)
            {
                string realPath = dirFiles[i];
                //string name = Path.GetFileName(realPath);
                string name = Path.GetFileNameWithoutExtension(realPath);
                //Console.WriteLine(name);

                string extention = Path.GetExtension(realPath);
               // Console.WriteLine(extention);
            }

            //获取所有目录的文件夹
          //  string[] dirs = Directory.GetDirectories(dirPath);
         //   for (int i = 0; i < dirs.Length; i++)
            {
                //Console.WriteLine(dirs[i]);
            }

            //获取当前文件夹路径
          //  string curDir = Directory.GetCurrentDirectory();
            //Console.WriteLine(curDir);


            //获取硬盘信息
           // string[] yingpanDir = Directory.GetLogicalDrives();
           // for (int i = 0; i < yingpanDir.Length; i++)
            {
                //Console.WriteLine(yingpanDir[i]);
            }


            //移动目录及其子目录和文件
            string desPath = @"E:\FY-备课\Students\DirTest";
            //Directory.Move(dirPath, desPath);
           // Directory.Move(desPath, dirPath);

            //删除目录
            //Directory.Delete(dirPath);


            //----------Path, 路径类的操作----------------------------
            //连接路径,自动判断有没有斜杠需要添加
            string path2 = Path.Combine(filePath, fileName);
            //Console.WriteLine(path2);

            //得到文件名称,带后缀
            //string name = Path.GetFileName(realPath);

            //得到文件名称, 无后缀
            //string name = Path.GetFileNameWithoutExtension(realPath);

            //得到文件后缀
            //string extention = Path.GetExtension(realPath);



            //----------FileStream 文件流读取-----------------------------------------
            //读取文件
            Console.WriteLine("Path:" + path);
            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                //声明一个字节数组作为读取数据的存储
                Byte[] bytes = new Byte[1024];

                while (true)
                {
                    //读取内容,填充到bytes中
                    fs.Read(bytes, 0, bytes.Length);

                    //解码, 转换成string
                    string str1 = myEncoding.GetString(bytes);
                    Console.WriteLine(str1);

                    //等待一次输入,若为Q则退出当前循环; 反之继续读取
                    string input = Console.ReadLine();
                    bool isEquals = string.Equals(input, "Q");
                    if (isEquals)
                    {
                        break;
                    }
                }

            }

            //写入文件
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                //开启一个循环写入
                while (true)
                {
                    //控制台读取用户输入的一行
                    string str = Console.ReadLine();

                    //str为Q就跳出循环
                    bool isEquals = string.Equals(str, "Q");
                    if (isEquals)
                    {
                        break;
                    }
                    //将内容转化成字符串
                    Byte[] bytes = myEncoding.GetBytes(str);

                    //写入文本文件
                    fs.Write(bytes, 0, bytes.Length);

                    //刷新缓冲区
                    fs.Flush();
                }
            }

            //----------------------StreamReader, StreamWriter-------------------------------
            //创建流
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                //创建读取器
                using (StreamReader sr = new StreamReader(fs, myEncoding))
                {
                    //循环读取
                    while (true)
                    {
                        string input = Console.ReadLine();
                        bool isQuit = string.Equals(input, "Q");
                        if (isQuit)
                        {
                            break;
                        }
                        string str = sr.ReadLine();
                        Console.WriteLine(str);
                    }
                }
            }
            //写入器:写入
            //创建流
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                //创建写入器
                using (StreamWriter sw = new StreamWriter(fs, myEncoding) )
                {
                    //循环写入
                    while (true)
                    {
                        string input = Console.ReadLine();
                        bool isQuit = string.Equals(input, "Q");
                        if (isQuit)
                        {
                            break;
                        }

                        sw.WriteLine(input);
                    }
                }
            }


            Console.ReadKey();
        }
    }
}
