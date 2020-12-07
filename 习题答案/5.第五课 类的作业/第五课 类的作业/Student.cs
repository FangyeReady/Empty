using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第五课_类的作业
{
    class Student
    {
        private string _name;
        public string Name
        {
           private set { _name = value; }
           get { return _name; }
        }

        private string _sex;
        public string Sex
        {
            private set { _sex = value; }
            get { return _sex; }
        }

        private int _class;
        public int Class
        {
            private set { _class = value; }
            get { return _class; }
        }

        private string _favorate;
        public string Favorate
        {
            private set { _favorate = value; }
            get { return _favorate; }
        }


        public Student(string name, string sex, int classes, string favorate)
        {
            _name = name;
            _sex = sex;
            _class = classes > 0 ? classes : 1;
            _favorate = favorate;
        }

        public void PrintInfo()
        {
            Console.WriteLine("姓名：" + _name + "  性别：" + _sex + "  班级：" + _class + "  爱好：" + _favorate);
        }
    }
}
