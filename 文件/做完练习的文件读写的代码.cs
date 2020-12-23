using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace EncodingPractice
{
    class Program
    {
        static string filePath = @"D:\文档";// 单斜杠代表转义字符，此处添加@表示禁用字符串中的转义字符
        static string fileName = "MyText.txt";

        static string desPath = @"D:\文档\备课";

        static string[] data = {
            "床前明月光",
            "疑是地上霜",
            "举头望明月",
            "低头思故乡"
        };

        static void Main(string[] args)
        {
            string path = Path.Combine(filePath, fileName);
            Console.WriteLine("文件路径为：" + path);

            Encoding encoding = Encoding.UTF8;

            //Directory.CreateDirectory(filePath);
            //File.Create(path);

            //File.WriteAllLines(path, data);
            //File.AppendAllLines(path, data);

            //byte[] bytes =  File.ReadAllBytes(path);
            //string str = encoding.GetString(bytes);
            //Console.WriteLine(str);


            //byte[] bytes2 = encoding.GetBytes("李白想婆娘");
            //File.WriteAllBytes(path, bytes2);

            //File.Delete(path);

            string[]  fileNames =  Directory.GetFiles(filePath);
            Console.WriteLine("File路径：");
            for (int i = 0; i < fileNames.Length; i++)
            {
                string fileName = Path.GetFileName(fileNames[i]);
                //Console.WriteLine("路径：" + fileNames[i] + "    文件名: " + fileName + "    后缀：" + Path.GetExtension(fileNames[i]));
                //Console.WriteLine(Path.GetFileNameWithoutExtension(fileName));
                //Console.WriteLine(Path.GetDirectoryName(fileNames[i]));
                //Console.WriteLine(Path.GetFullPath(fileNames[i]));
            }

            fileNames = Directory.GetFiles(filePath, "*.txt", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < fileNames.Length; i++)
            {
                Console.WriteLine(fileNames[i]);
            }



            Console.WriteLine();

            string[] folderNames = Directory.GetDirectories(filePath);
            Console.WriteLine("Folder路径：");
            for (int i = 0; i < folderNames.Length; i++)
            {
                //Console.Write(folderNames[i] + "    ");
            }


            //将文件夹及其内所有文件移动到指定路径
            Directory.Move(path, Path.Combine(desPath, fileName));
            Directory.Move(Path.Combine(filePath, "Test"), Path.Combine(desPath, "Test"));

            

            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            string[] str = Directory.GetLogicalDrives();
            for (int i = 0; i < str.Length; i++)
            {
               // Console.WriteLine(str[i]);
            }


            string str2 = Directory.GetCurrentDirectory();
            //Console.WriteLine(str2);

            //读取文件流
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] bytes = new byte[1024];

                while (true)
                {
                    fs.Read(bytes, 0, 1024);
                    string str3 = encoding.GetString(bytes);
                    Console.WriteLine(str3);

                    string key = Console.ReadLine();
                    if (string.Equals(key, "Q"))
                    {
                        break;
                    }
                }

                //fs.Close();
            }

            //写入文件流
            using (FileStream fs = new FileStream(Path.Combine(desPath, fileName), FileMode.OpenOrCreate, FileAccess.Write))
            {
                while (true)
                {

                    string str3 = Console.ReadLine();
                    if (str3 == "Q") break;

                    byte[] bytes = encoding.GetBytes(str3);

                    fs.Write(bytes, 0, bytes.Length);
                    fs.Flush();//刷新缓存区，确保缓存区的全部写入，且不干扰下次写入
                }

                //fs.Close();
            }


            //StreamReader
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, encoding))
                {
                    while (true)
                    {
                        string str4 = Console.ReadLine();
                        if (str4 == "Q") break;

                        string data = sr.ReadLine();
                        Console.WriteLine(data);
                    }
                }
            }

            //StreamWriter
            using (FileStream fs = new FileStream(Path.Combine(desPath, fileName), FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, encoding))
                {
                    while (true)
                    {
                        string str4 = Console.ReadLine();
                        if (str4 == "Q") break;

                        sw.WriteLine(str4);
                        Console.WriteLine(str4);

                    }
                }
            }


            Console.ReadKey();
        }
    }
}
