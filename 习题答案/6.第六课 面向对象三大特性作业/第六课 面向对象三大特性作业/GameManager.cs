using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第六课_面向对象三大特性作业
{
    class GameManager
    {

        public static bool GameEnd = false;

        public static void BeginGame()
        {
            while (true)
            {
                Console.WriteLine("请选择你的敌人：\n1.怪物\n2.士兵");
                string input = Console.ReadLine();
                int choice;
                bool isChoose = int.TryParse(input, out choice);
                if (isChoose)
                {
                    GoBattle(choice);
                }
            }
        }

        private static void GoBattle(int choice)
        {
            Character enemy = CreateEnemy(choice);

            Character player = new Hero("李逍遥", 99, 9, 999);

            Console.WriteLine("按回车键开始战斗！");
            Console.ReadKey();

            StringBuilder sb = new StringBuilder();

            while (true)
            {
                Console.Clear();
               
                //发起战斗
                player.Attack(enemy);

                //打印战斗过程
                string playerAttack = string.Format("{0}向{1}发起进攻, 造成{2}伤害!!!!", player.Name, enemy.Name, player.ATK);
                sb.AppendLine(playerAttack + "\n");
                Console.WriteLine(player.Name + " 血量：" + player.HP + "\t" + enemy.Name + " 血量 " + enemy.HP + "\n");
                Console.Write(sb.ToString());

                //判断谁胜利
                if (GameEnd)
                {
                    Console.Clear();
                    Console.WriteLine("恭喜" + player.Name + "获得胜利！");
                    Console.ReadKey();
                    break;
                }

                //按键清空
                Console.ReadKey();
                Console.Clear();

              
                //发起战斗
                enemy.Attack(player);

                //打印战斗过程
                string enemyAttack = string.Format("{0}向{1}发起进攻, 造成{2}伤害.", enemy.Name, player.Name, enemy.ATK);
                sb.AppendLine(enemyAttack + "\n");
                Console.WriteLine(player.Name + " 血量：" + player.HP + "\t" + enemy.Name + " 血量 " + enemy.HP + "\n");
                Console.Write(sb.ToString());
                //sb.Clear();

                //判断谁胜利
                if (GameEnd)
                {
                    Console.Clear();
                    Console.WriteLine("你已经死了！.");
                    Console.ReadKey();
                    break;
                }

                //按键继续
                Console.ReadKey();
            }

            GameEnd = false;
            Console.WriteLine("游戏结束！");
            Console.ReadKey();
            Console.Clear();

        }

        private static Character CreateEnemy(int choice)
        {
            Character ch;
            switch (choice)
            {
                case 1: ch = new Monster("史莱姆", 55, 20, 1000); break;
                case 2: ch = new Solider("瑞恩", 20, 5, 10000); break;
                default:
                    ch = new Monster("巫妖王", 999, 999, 99999);
                    break;
            }
            return ch;
        }

    }
}
