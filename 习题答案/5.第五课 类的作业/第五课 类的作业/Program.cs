using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第五课_类的作业
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu1 = new Student("张三", "男", 1, "喜欢爬山1");
            Student stu2 = new Student("张四", "女", 1, "喜欢爬山2");
            Student stu3 = new Student("刘四", "女", 1, "喜欢爬山3");
            Student stu4 = new Student("罗四", "男", 1, "喜欢爬山4");

            Student stu5 = new Student("张五", "男", 2, "喜欢爬山5");
            Student stu6 = new Student("李四", "女", 2, "喜欢爬山6");
            Student stu7 = new Student("李六", "男", 2, "喜欢爬山7");
            Student stu8 = new Student("罗四", "男", 2, "喜欢爬山8");


            Classes clas1 = new Classes(1);
            clas1.AddStudent(stu1);
            clas1.AddStudent(stu2);
            clas1.AddStudent(stu3);
            clas1.AddStudent(stu4);


            Classes clas2 = new Classes(2);
            clas2.AddStudent(stu5);
            clas2.AddStudent(stu6);
            clas2.AddStudent(stu7);
            clas2.AddStudent(stu8);
            clas2.DelStudent("罗四");





            Console.ReadKey();


            Grades grades = new Grades(2);
            grades.AddClass(clas1);
            grades.AddClass(clas2);




            grades.GetBoyAndGirlsNum();
            Console.WriteLine();
            grades.GetClassMemberNum(1);
            Console.WriteLine();
            grades.GetClassMemberNum(2);
            Console.WriteLine();
            grades.GetStudentInfo("李六");
            Console.WriteLine();
            grades.GetStudentInfo("罗四");








            Console.ReadKey();

        }
    }
}
