using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第九课_集合作业
{
    class UserAccountManager
    {
        static Dictionary<string, string> userDataDic = new Dictionary<string, string>();

        public static bool AddUser(string account, string password)
        {
            if (userDataDic.ContainsKey(account))
            {
                return false;
            }

            userDataDic.Add(account, password);
            return true;
        }

        public static void DelUserData(string account)
        {
            if (userDataDic.ContainsKey(account))
            {
                userDataDic.Remove(account);     
            }
        }

        public static void ChangUserPassword(string account, string password)
        {
            if (userDataDic.ContainsKey(account))
            {
                userDataDic[account] = password;
            }
        }

        public static void GetAllUserData()
        {
            Console.Clear();
            if (userDataDic.Count == 0)
            {
                Console.WriteLine("数据库中没有数据！");
                Console.ReadKey();
                return;
            }

            foreach (var item in userDataDic)
            {
                Console.WriteLine("用户名： {0}     密码：  {1}", item.Key, item.Value);
            }

            Console.ReadKey();
        }

        private static bool FindUser(string account)
        {
            if (userDataDic.ContainsKey(account))
            {
                var password = userDataDic[account];
                Console.Clear();
                //Console.WriteLine("已找到用户：\n 用户名：{0}， 密码:{1}", account, password);
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("未找到用户 {0}!", account);
                return false;
            }
        }

        public static bool CheckUserInfo(string account, string password)
        {
            bool hasFind = FindUser(account);

            if (hasFind)
            {
                return userDataDic[account] == password;
            }

            return false;
        }
       
    }
}
