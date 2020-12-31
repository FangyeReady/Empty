using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 第七课_结构体和枚举的作业
{
    class Role
    {
        private RoleData roleData;
        private List<Equipment> equipList;

        public Role(string name,  RoleType type, int hp, int atk, int def)
        {
            roleData.Name = name;
            roleData.Hp = hp;
            roleData.Def = def;
            roleData.Atk = atk;
            roleData.roleType = type;

            equipList = new List<Equipment>();
        }

        public string GetRoleName()
        {
            return roleData.Name;
        }


        public void PickEquipment(Equipment equip)
        {
            bool isContain = false;
            for (int i = 0; i < equipList.Count; i++)
            {
                if (equipList[i].ID == equip.ID)
                {
                    isContain = true;
                }
            }

            if (!isContain)
            {
                equipList.Add(equip);
            }
        }


        private int GetAttack()
        {
            int atk = roleData.Atk;

            for (int i = 0; i < equipList.Count; i++)
            {
                atk += equipList[i].Atk;
            }
            return atk;
        }

        private int GetDefence()
        {
            int def = roleData.Def;

            for (int i = 0; i < equipList.Count; i++)
            {
                def += equipList[i].Def;
            }
            return def;
        }


        public void OnHurt(int damage)
        {
            int result = damage - GetDefence();
            if (result < 0)
            {
                result = 0;
            }

            roleData.Hp -= result;
            if (roleData.Hp < 0)
            {
                roleData.Hp = 0;
                //todo:调用死亡逻辑
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(roleData.Name + " 受到了攻击, 损失 " + result + " 血量");
            Console.ForegroundColor = ConsoleColor.White;


            Console.WriteLine();
        }


        public void AttackEnemy(Role role)
        {
            int damage = GetAttack();


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(roleData.Name);


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" 向 ");


            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(role.GetRoleName());


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("发起了攻击");

            Console.WriteLine();

            role.OnHurt(damage);
        }


    }
}
