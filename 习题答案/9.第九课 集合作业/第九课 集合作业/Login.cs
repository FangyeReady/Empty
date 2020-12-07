using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第九课_集合作业
{
    class LoginManager
    { 
        public static void StartApp()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("请选择以下业务：\n1.登录\n2.注册\n3.注销\n4.修改密码\n5.查看所有用户数据");
                string input = Console.ReadLine();
                int choice;
                bool isChoice = int.TryParse(input, out choice);
                if (isChoice && choice > 0 && choice < 6)
                {
                    ChooseJob(choice);
                }
                else
                {
                    Console.WriteLine("输入有误，请重新输入!");
                    Console.ReadKey();
                    Console.Clear();
                }

            }

        }


        private static void ChooseJob(int choice)
        {
            Console.Clear();
            switch (choice)
            {
                case 1: Login(); break;
                case 2: CreateUserData(); break;
                case 3: DeleteUserData(); break;
                case 4: ChangePassword(); break;
                case 5: LookAllUserInfo(); break;
                default:
                    break;
            }

        }

        private static void Login()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("请输入用户名:");
                string account = Console.ReadLine();
                Console.WriteLine("请输入密码:");
                string password = Console.ReadLine();

                bool isSuccess = UserAccountManager.CheckUserInfo(account, password);
                Console.Clear();
                if (isSuccess)
                {
                    Console.WriteLine("恭喜！登陆成功！");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("请重新选择，按回车键继续！按Q回到上一级菜单！");
                    ConsoleKeyInfo info = Console.ReadKey();
                    if (info.Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else if (info.Key == ConsoleKey.Q)
                    {
                        break;
                    }

                }
            }
            Console.Clear();
        }

        private static void CreateUserData()
        {
            while (true)
            { 
                Console.WriteLine("请输入用户名:");
                string account = Console.ReadLine();
                Console.WriteLine("请输入密码:");
                string password = Console.ReadLine();


                bool isSuccess = UserAccountManager.AddUser(account, password);
                if (isSuccess)
                {
                    Console.Clear();
                    Console.WriteLine("恭喜！注册账号成功！");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("该用户名已经被注册！");
                    Console.WriteLine("请重新选择，按回车键继续！按Q回到上一级菜单！");
                    ConsoleKeyInfo info = Console.ReadKey();
                    if (info.Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else if (info.Key == ConsoleKey.Q)
                    {
                        break;
                    }
                }
            }
        }


        private static void DeleteUserData()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("请输入要注销的用户名:");
                string account = Console.ReadLine();
                Console.WriteLine("请输入要注销的密码:");
                string password = Console.ReadLine();

                bool isSuccess = UserAccountManager.CheckUserInfo(account, password);
                if (isSuccess)
                {
                    UserAccountManager.DelUserData(account);
                    Console.WriteLine("已注销用户：{0}", account);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("未找到用户：{0}", account);
                    Console.WriteLine("请重新选择，按回车键继续！按Q回到上一级菜单！");
                    ConsoleKeyInfo info = Console.ReadKey();
                    if (info.Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else if (info.Key == ConsoleKey.Q)
                    {
                        break;
                    }
                }
            }

        }


        private static void ChangePassword()
        {

            Console.Clear();
            Console.WriteLine("请输入用户名:");
            string account = Console.ReadLine();
            Console.WriteLine("请输入旧密码:");
            string oldPassword = Console.ReadLine();
            Console.WriteLine("请输入新密码:");
            string newPassword = Console.ReadLine();

            bool isSuccess = UserAccountManager.CheckUserInfo(account, oldPassword);
            if (!isSuccess)
            {
                Console.WriteLine("旧密码错误， 设置密码失败！");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                UserAccountManager.ChangUserPassword(account, newPassword);
                Console.Clear();
                Console.WriteLine("设置密码成功！");
                Console.ReadKey();
            }
            
        }

        private static void LookAllUserInfo()
        {
            UserAccountManager.GetAllUserData();
        }


    }
}
