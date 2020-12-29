using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第六课_面向对象三大特性作业
{
    static class BookFactory
    {

        public static Book CreateBook(string type, string name)
        {
            Book result;
            switch (type)
            {
                case "文学": result = new LiteratureBook(type, name);break;
                case "历史": result = new HistoryBook(type, name); break;
                case "有声": result = new VoiceBook(type, name); break;
                default:
                    result = null;
                    break;
            }
            return result;
        }


    }

    static class BookSystem
    {
        public static void Subscribe()
        {
            Book[] bkArray = new Book[3];
            int index = 0;
            while (true)
            {
                Console.WriteLine("请输入你想订阅的书类别:");
                string input1 = Console.ReadLine();
                Console.WriteLine("请输入你想订阅的书名:");
                string input2 = Console.ReadLine();
                Book bk = BookFactory.CreateBook(input1, input2);
                if (bk != null)
                {
                    bkArray[index++] = bk;
                    Console.WriteLine("订阅成功!");
                }
                Console.ReadKey();
                Console.Clear();

                if (index >= bkArray.Length)
                {
                    Console.WriteLine("能够订阅的书籍已达上限, 分别是:");
                    for (int i = 0; i < bkArray.Length; i++)
                    {
                        bkArray[i].ShowBookInfo();
                    }

                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
