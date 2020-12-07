using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//文件操作

namespace API_文件操作
{
    //File 类  操作文件
    class Program
    {
        static string path = @"D:\a.txt";


        // File.Exists();            //判断文件是否存在
        static void Main1(string[] args)
        {
            bool b = File.Exists(path);
            Console.WriteLine(b);
        }

        // File.ReadAllText();        //读取所有文本
        static void Main2(string[] args)
        {
            string str = File.ReadAllText(path);//默认使用UTF8解码
            Console.WriteLine(str);

            // string str1 = File.ReadAllText(path, Encoding.GetEncoding("GB2312"));
            // Console.WriteLine(str1);
        }


        // File.WriteAllText();        //写入所有文本
        static void Main3(string[] args)
        {
            File.WriteAllText(@"D:\b.txt", "春来不是读书天,夏日炎炎正好眠");
        }

        // File.AppendAllText();     //追加所有文本
        static void Main4(string[] args)
        {
            File.AppendAllText(@"D:\b.txt", "ABC\r\n");
        }

        // File.ReadAllLines();            //读取所有行返回字符串数组
        static void Main5(string[] args)
        {
            var arr = File.ReadAllLines(path);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
        // File.WriteAllLines()        //写入所有行
        static void Main6()
        {

            string[] arr =
            {
                "朝辞白帝彩云间",
                "千里江陵一日还",
                "两岸猿声啼不住",
                "轻舟已过万重山"
            };
            File.WriteAllLines(@"D:\c.txt", arr);
        }

        // File.Delete();                //删除
        static void Main7(string[] args)
        {
            string file = @"D:\c.txt";
            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }

        // File.ReadAllBytes();            //读取所有字节
        static void Main8(string[] args)
        {
            string file = @"D:\c.txt";
            byte[] arr = File.ReadAllBytes(file);//读取字节
            //看一下
            foreach (var item in arr)
            {
                string str = Convert.ToString(item, 2);
                Console.Write(str);
            }

            //对字节进行解码
            string text = Encoding.UTF8.GetString(arr);
            Console.WriteLine();
            Console.WriteLine(text);
        }

        // File.WriteAllBytes();             //写入所有字节
        static void Main10(string[] args)
        {
            string str = "窗前明月光,疑是地上霜";
            byte[] arr = Encoding.UTF8.GetBytes(str);//编码
            File.WriteAllBytes(path, arr);//写入
        }
    }

    //Dirctory 操作文件夹
    class MyClass1
    {
        static void Main1(string[] args)
        {

            ////创建目录
            //Directory.CreateDirectory(@"D:\ABC");

            //删除
            //Directory.Delete(@"D:\ABC");

            //目录是否存在
            // bool b=  Directory.Exists(@"D:\ABC");
            //  Console.WriteLine(b);

            // 获取所有文件
            // string[] files=  Directory.GetFiles(@"D:\ABC");
            // foreach (var item in files)
            // {
            //     Console.WriteLine(item);
            // }

            // //获取所有目录

            //string[] dirs= Directory.GetDirectories(@"D:\");
            //foreach (var item in dirs)
            //{
            //    Console.WriteLine(item);
            //}


            // //获取当前程序的工作目录
            //string dir = Directory.GetCurrentDirectory();
            //Console.WriteLine(dir);

            //  Directory.Move();            //移动目录和目录中的内容 (改名也是用移动)
            // Directory.Move(@"D:\ABC",@"D:\X\ABC");
            // Directory.Move(@"D:\X\ABC", @"D:\X\BCD");


            //获取电脑上的盘符信息   
            string[] drives = Directory.GetLogicalDrives();
            foreach (var item in drives)
            {
                Console.WriteLine(item);
            }
        }
    }

    //Path
    class MyClass2
    {
        static void Main1(string[] args)
        {
            //Path.Combine();                //连接
            string dir = @"D:\X\BCD";
            string fileName = "a.txt";

            string filePath = Path.Combine(dir, fileName);//自动判断要不要加斜杠
            Console.WriteLine(filePath);



            //Path.GetExtension();        //获取扩展名
            string filePath1 = @"C:\Users\Administrator\Desktop\新建文本文档 (3).txt";
            Console.WriteLine(Path.GetExtension(filePath1));


            //Path.GetFileName();            //获取文件名
            Console.WriteLine(Path.GetFileName(filePath1));

            //Path.GetFileNameWithoutExtension();    //获取没有扩展名的文件名
            Console.WriteLine(Path.GetFileNameWithoutExtension(filePath1));

            //Path.GetFullPath();            //获取完整路径         
            Console.WriteLine(File.ReadAllText(@"A\x.txt"));
            Console.WriteLine(Path.GetFullPath(@"A\x.txt"));
        }

    }

    //FileStream 文件流,用来一点一点的读取文件
    class MyClass3
    {
        //使用文件流读取
        static void Main1(string[] args)
        {
            Encoding GB2312 = Encoding.GetEncoding("GB2312");

            using (FileStream fs = new FileStream(@"D:\诛仙.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                //创建文件流对象


                // FileStream fs1= File.OpenRead(@"D:\诛仙.txt");//也可以这样创建文件流对象
                byte[] arr = new byte[1024];//1KB 的缓存  用来临时存储读取到的字节
                while (true)
                {
                    //读取字节存储到arr中
                    int length = fs.Read(arr, 0, 1024);//返回值表示实际读取到的字节
                                                       //解码arr中的字节
                    string str = GB2312.GetString(arr, 0, length);
                    //输出
                    Console.WriteLine(str);
                    var input = Console.ReadLine();
                    if (input == "Q") break;//按Q退出

                }
                // fs.Close();//必须关闭,以保证及时释放文件,也可以使用Using{}
            }
        }


        //使用文件流写入:记得 Flush
        static void Main2(string[] args)
        {
            //创建文件流
            using (var fs = File.Create(@"D:\d.txt"))
            {
                while (true)
                {
                    //获取输入
                    string input = Console.ReadLine();
                    if (input == "Q") break;
                    //编码
                    byte[] arr = Encoding.UTF8.GetBytes(input);
                    //写入
                    fs.Write(arr, 0, arr.Length);//并非调用write就会立刻写入文件
                }
                fs.Flush();//确保底层缓冲区的字节全部写入文件
            }
        }

        //使用读写器包装文件流,方便文本写入和读取
        //读取
        static void Main3(string[] args)
        {
            Encoding GB2312 = Encoding.GetEncoding("GB2312");

            using (FileStream fs = new FileStream(@"D:\诛仙.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr=new StreamReader (fs,GB2312))//读取器
                {
                    
                    while (true)
                    {
                        Console.WriteLine(sr.ReadLine());
                        Console.ReadLine();
                    }
                }
            }
        }
        //写入
        static void Main(string[] args)
        {
            using (var fs = File.Create(@"D:\d.txt"))
            {
                using (StreamWriter sw=new StreamWriter (fs))
                {
                    while (true)
                    {
                       string str= Console.ReadLine();
                        if (str == "Q") break;
                        sw.WriteLine(str);
                    }
                    sw.Flush();
                }
            }
        }
    }
}
