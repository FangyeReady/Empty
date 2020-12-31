using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第七课_结构体和枚举的作业
{
    class Program
    {
        static void Main(string[] args)
        {
            Role role = new Role("英雄A", RoleType.Solider, 100, 10, 5);

            Role role1 = new Role("怪物A", RoleType.Monster, 20, 10, 2);



            role.AttackEnemy(role1);

            role1.AttackEnemy(role);


            Console.ReadKey();
        }
    }
}
