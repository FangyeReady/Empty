    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第五课_类的作业
{
    class Classes
    {
        int capacity = 1;
        int studentCount;//学生人数
        int _classLevel;//班级
        Student[] students;



        public int ClassStuCount
        {
            get { return studentCount; }
        }

        public int ClassLevel
        {
            get { return _classLevel; }
        }


        public Classes(int classLevel)
        {
            studentCount = 0;
            students = new Student[1];
            _classLevel = classLevel;
        }

        public void AddStudent(Student stu)
        {
            //如果下标越界了，则应该扩充数组
            if (studentCount >= students.Length )
            {
                //创建一个更大的数组
                Student[] newArray = new Student[students.Length + capacity];
                //遍历原来的数组
                for (int i = 0; i < students.Length; i++)
                {
                    //将数据移动到新的数组中
                    newArray[i] = students[i];
                }
                //把新的数组地址,赋值给旧的数组变量
                students = newArray;
            }

            students[studentCount++] = stu;
        }

        public void AddStudent(string name, string sex)
        { 
        
        }

        public void DelStudent(string name)
        {
           
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Name == name)
                {
                    students[i] = null;
                    studentCount--;
                }
            }

            Student[] newStudent = new Student[studentCount];

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    newStudent[i] = students[i];
                }
            }

            students = newStudent;
        }



        public bool ShowStudentInfo(string name)
        {
            bool hasFind = false;
            for (int i = 0; i < students.Length; i++)
            {
                Student stu = students[i];
                if (stu != null)
                {
                    if (stu.Name == name)
                    {
                        stu.PrintInfo();
                      
                        hasFind = true;
                    }
                }  
            }

            return hasFind;
        }

        /// <summary>
        /// 得到男生或女生的人数
        /// </summary>
        /// <param name="boyOrGirl">男生，女生</param>
        /// <returns></returns>
        public int GetBoysOrGirlsCount(string boyOrGirl)
        {
            int count = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (boyOrGirl == students[i].Sex)
                {
                    count++;
                }
            }
            return count;
        }



    }
}
