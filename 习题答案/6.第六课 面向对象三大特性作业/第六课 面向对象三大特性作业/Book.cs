using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第六课_面向对象三大特性作业
{
    abstract class Book
    {
        protected string _type;

        public Book(string type)
        {
            _type = type;
        }

        abstract public void ShowBookInfo();
    }


    class HistoryBook : Book
    {
        private string _name;

        public HistoryBook(string type, string name) : base(type)
        {
            _name = name;
        }

        public override void ShowBookInfo()
        {
            Console.WriteLine(_type + "书 : " + _name);
        }
    }


    class VoiceBook : Book
    {
        private string _name;
        public VoiceBook(string type, string name) : base(type)
        {
            _name = name;
        }

        public override void ShowBookInfo()
        {
            Console.WriteLine(_type + "书 : " + _name);
        }
    }

    class LiteratureBook : Book
    {
        private string _name;
        public LiteratureBook(string type, string name) : base(type)
        {
            _name = name;
        }

        public override void ShowBookInfo()
        {
            Console.WriteLine(_type + "书 : " + _name);
        }
    }
}
