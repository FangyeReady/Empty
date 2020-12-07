using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace IO_HomeWork
{
    static  class IOClass
    {

        private static Encoding UTF8 = Encoding.UTF8;
        private static Encoding GB2312 = Encoding.GetEncoding("GB2312");

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static bool IsExitsFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("输入的路径错误！===》" + path);
                return false;
            }

            bool isExits = File.Exists(path);
            if (!isExits)
            {
                string dir = Path.GetDirectoryName(path);
                IsExitsDirectory(dir);

                File.Create(path);
                Console.WriteLine("创建文件成功！" + path);
            }

            return isExits;
        }

        /// <summary>
        /// 目录是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static bool IsExitsDirectory(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("输入的路径错误！===》" + path);
                return false;
            }

            bool isExits = Directory.Exists(path);
            if (!isExits)
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("创建目录成功！" + path);
            }

            return isExits;
        }


        /// <summary>
        /// 读取文件 File
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("输入的路径错误！===》" + path);
                return "";
            }

            if (!IsExitsFile(path))
            {
                Console.WriteLine("文件不存在！");
                return "";
            }


            string data = File.ReadAllText(path);
            //Print(data);
            Console.WriteLine("读取成功!");
            return data;
        }

        /// <summary>
        /// 读取文件 FileStream
        /// </summary>
        /// <param name="path"></param>
        /// <param name="mode"></param>
        /// <param name="access"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ReadFile(string path, FileMode mode, FileAccess access, Encoding encoding)
        {
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("输入的路径错误！===》" + path);
                return "";
            }
            if (!IsExitsFile(path))
            {
                Console.WriteLine("文件不存在！");
                return "";
            }
            StringBuilder sb = new StringBuilder();
            using (FileStream fs = new FileStream(path, mode, access))
            {
                using (StreamReader sr = new StreamReader(fs, encoding))
                {
                    string line = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        sb.AppendLine(line);
                        line = sr.ReadLine();
                    }
                }
            }
            Console.WriteLine("读取成功！");
            return sb.ToString();
        }

        /// <summary>
        /// 写入文件File
        /// </summary>
        /// <param name="desPath"></param>
        /// <param name="dataPath"></param>
        static public void WriteFile(string desPath, string dataPath)
        {
            if (string.IsNullOrEmpty(desPath)  || string.IsNullOrEmpty(dataPath))
            {
                Console.WriteLine("输入的路径错误!");
                return;
            }

            bool isExits = File.Exists(desPath);
            if (!isExits)
            {
                string dir = Path.GetDirectoryName(desPath);
                IsExitsDirectory(dir);

                FileStream fs = File.Create(desPath);
                fs.Close();
                Console.WriteLine("创建文件成功！" + desPath);

            }

            string data = ReadFile(dataPath);
         
            File.WriteAllText(desPath, data);

            Console.WriteLine("写入成功！");
        }

        static public void WriteFile(string desPath, string data, Encoding encoding)
        {
            if (string.IsNullOrEmpty(desPath))
            {
                Console.WriteLine("输入的路径错误!");
                return;
            }
            bool isExits = File.Exists(desPath);
            if (!isExits)
            {
                string dir = Path.GetDirectoryName(desPath);
                IsExitsDirectory(dir);

                FileStream fs = File.Create(desPath);
                fs.Close();
                Console.WriteLine("创建文件成功！" + desPath);
            }
            File.WriteAllText(desPath, data, encoding);
        }

        /// <summary>
        /// 写入文件 FileStream
        /// </summary>
        /// <param name="desPath"></param>
        /// <param name="dataPath"></param>
        /// <param name="mode"></param>
        /// <param name="access"></param>
        /// <param name="encoding"></param>
        public static void WriteFile(string desPath, string dataPath, FileMode mode, FileAccess access, Encoding encoding)
        {
            if (string.IsNullOrEmpty(desPath) || string.IsNullOrEmpty(dataPath))
            {
                Console.WriteLine("输入的路径错误!");
                return;
            }

            bool isExits = File.Exists(desPath);
            if (!isExits)
            {
                string dir = Path.GetDirectoryName(desPath);
                IsExitsDirectory(dir);

                FileStream fs = File.Create(desPath);
                fs.Close();
                Console.WriteLine("创建文件成功！" + desPath);
            }

            string data = ReadFile(dataPath, mode, access, encoding);
            //string[] dataArray = data.Split('\n');
           // Console.WriteLine("数组长度：" + dataArray.Length);
            using (FileStream fs = new FileStream(desPath, mode, access))
            {
                using (StreamWriter sw = new StreamWriter(fs, encoding))
                {
                    sw.Write(data);         
                }
            }

            Console.WriteLine("写入成功！");
        }

        static void Print(string str)
        {
            Console.WriteLine(str);
        }

        static void Print(string[] strArray)
        {
            for (int i = 0; i < strArray.Length; i++)
            {
                Print(strArray[i]);
            }
        }

    }
}
