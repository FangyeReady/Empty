using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第五课_类的作业
{
    class Grades
    {
        Classes[] gradeClasses;//这个是班级类,用于管理班级对象
        int classCount;
        public Grades(int classNum)
        {
            classNum = Math.Abs(classNum);

            gradeClasses = new Classes[classNum];
            classCount = 0;
        }

        public void AddClass(Classes cl)
        {
            for (int i = 0; i < gradeClasses.Length; i++)
            {
                if (gradeClasses[i] == null)
                {
                    continue;
                }

                if (gradeClasses[i].ClassLevel == cl.ClassLevel)
                {
                    Console.WriteLine("不能有相同班级被添加！");
                    return;
                }
            }

            if (classCount >= gradeClasses.Length)
            {
                Classes[] newArray = new Classes[gradeClasses.Length + 10];
                for (int i = 0; i < gradeClasses.Length; i++)
                {
                    newArray[i] = gradeClasses[i];
                }

                gradeClasses = newArray;             
            }
            
            gradeClasses[classCount++] = cl;
        }

        public void GetClassMemberNum(int classLevel)
        {
            for (int i = 0; i < gradeClasses.Length; i++)
            {
                if (gradeClasses[i].ClassLevel == classLevel)
                {
                    Console.WriteLine( classLevel + "班学生人数为" + gradeClasses[i].ClassStuCount + "人");
                    break;
                }
            }
        }

        public void GetStudentInfo(string name)
        {
            int count = 0;
            for (int i = 0; i < gradeClasses.Length; i++)
            {
                bool hasFind = gradeClasses[i].ShowStudentInfo(name);
                if (hasFind)
                {
                    count++;
                }  
            }

            Console.WriteLine();
            Console.WriteLine("在全年级中一共找到" + count + "个名字叫" + name + "的同学");
            
        }

        public void GetBoyAndGirlsNum()
        {
            int boysNum = 0;
            int girlsNum = 0;
            for (int i = 0; i < gradeClasses.Length; i++)
            {
                boysNum += gradeClasses[i].GetBoysOrGirlsCount("男");
                girlsNum += gradeClasses[i].GetBoysOrGirlsCount("女");
            }
            Console.WriteLine("全年级共计： 男生" + boysNum + "人" + ",女生" + girlsNum + "人");    
        }

    }
}
