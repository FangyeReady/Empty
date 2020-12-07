using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 控制台游戏
{
    class Program
    {
        static void Main(string[] args)
        {
            //地图
            int[,] map = {
                { 0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0},
            };

            //随机生成可以被吃的食物
            Random random = new Random((int)DateTime.Now.Ticks);
            int x = random.Next(0, 9);
            int y = random.Next(0, 9);
            //修改地图坐标
            map[x, y] = 2;

            //分数
            int score = 0;
            //控制星星的位置
            int index = 0;
            //重置星星移动后的位置
            int preIndex = 0;
            Console.WriteLine("按任意键游戏开始！");
            Console.ReadKey();
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Q)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.W: {
                            if (index / 10 > 0)
                            {
                                index -= 10;
                            }
                        }break;
                    case ConsoleKey.S: {
                            if (index / 10 < 9)
                            {
                                index += 10;
                            }
                        }break;
                    case ConsoleKey.A: {
                            if (index % 10 > 0)
                            {
                                index -= 1;
                            }
                        }break;
                    case ConsoleKey.D: {
                            if (index % 10 < 9)
                            {
                                index += 1;
                            }
                        }break;
                    default:
                        break;
                }

                //清空星星移动前的位置
                int x1 = preIndex / 10;
                int y1 = preIndex % 10;
                map[x1, y1] = 0;
                //更新preIndex
                preIndex = index;

                int x2 = index / 10;
                int y2 = index % 10;

                //判断下一个位置是什么：
                if (map[x2,y2] == 2)//可以吃的东西
                {
                    int m = random.Next(0, 9);
                    int n = random.Next(0, 9);
                    map[m, n] = 2;

                    score += 1;
                    map[x2, y2] = 1;
                }



                //星星此时的位置
                map[x2, y2] = 1;


                Console.WriteLine(" 分数：" + score);
                Console.WriteLine();
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        switch (map[i,j])
                        {
                            case 0: Console.Write("○");break;
                            case 1: Console.Write("★"); break;
                            case 2: Console.Write("■"); break;  //可以被吃掉的玩意儿
                            default:
                                break;
                        }
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
    }
}
