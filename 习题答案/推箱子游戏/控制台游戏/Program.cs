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
            //初始化地图
            int[,] map = {
                { 1,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
            };

           
            //初始化食物
            while (true)
            {
                Random random = new Random((int)DateTime.Now.Ticks);
                int x = random.Next(0, 9);
                int y = random.Next(0, 9);

                //不要和星星重合
                if (map[x,y] != 1 )
                {
                    map[x, y] = 2;
                    break;
                } 
            }

            //初始化箱子       
            while (true)
            {        
                Random random = new Random((int)DateTime.Now.Ticks);
                int x = random.Next(0, 9);
                int y = random.Next(0, 9);
                //不和食物重合  且 不和星星重合
                if (map[x, y] == 0 )
                {
                    map[x, y] = 3;
                    break;
                }
            }

            //初始化终点
            int desX = 0;
            int desY = 0;
            while (true)
            {
                Random random = new Random((int)DateTime.Now.Ticks);
                desX = random.Next(0, 9);
                desY = random.Next(0, 9);
                //只有空白区域生成终点
                if (map[desX, desY] == 0)
                {
                    map[desX, desY] = 4;
                    break;
                }
            }
            //TODO:游戏失败
            bool isFailed = false;


            //分数
            int score = 0;

            //用于控制星星坐标
            int index = 0;

            //用于清空星星坐标
            int preIndex = 0;

            //用于控制箱子移动方向 
            int orderH = 0;//行
            int orderV = 0;//列

            //游戏内容
            Console.WriteLine("按任意键开始.");
            while (true)
            {
                //如果输出为Q则退出游戏
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                Console.Clear();
                //根据输入的键修改index的值
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.W: {
                            if ( index / 10 > 0 )
                            {
                                index -= 10;

                                orderV = -1;
                                orderH = 0;
                            }
                        }break;
                    case ConsoleKey.S: {
                            if (index / 10 < 9)
                            {
                                index += 10;

                                orderV = 1;
                                orderH = 0;
                            }
                        }break;
                    case ConsoleKey.A: {
                            if ( index % 10 > 0 )
                            {
                                index -= 1;

                                orderH = -1;
                                orderV = 0;
                            }
                        }break;
                    case ConsoleKey.D: {
                            if (index % 10 < 9)
                            {
                                index += 1;

                                orderH = 1;
                                orderV = 0;
                            }
                        }
                        break;
                    case ConsoleKey.Q:
                        {
                            return;//退出游戏
                        }
                }

                //计算星星当前的值
                int x1 = preIndex / 10;
                int y1 = preIndex % 10;
              
               
                //计算星星下一步要走的位置
                int x2 = index / 10;//行
                int y2 = index % 10;//列

                //得到箱子的下一个位置
                int boxX = x2 + orderV;//行
                int boxY = y2 + orderH;//列

                //判断下一个位置是什么：
                switch (map[x2, y2])
                {
                    //食物
                    case 2: {
                            //食物即将被吃掉，因此需要重新生成一个食物
                            Random random = new Random((int)DateTime.Now.Ticks);
                            int m = random.Next(0, 9);
                            int n = random.Next(0, 9);
                            map[m, n] = 2;
                            //更新分数
                            score += 1;
                            //更新星星位置
                            map[x2, y2] = 1;
                        }
                        break;
                    //箱子
                    case 3: {
                            //判断箱子界限
                            if ((boxY >= 0 && boxY <= 9) && (boxX >= 0 && boxX <= 9))
                            {
                                map[boxX, boxY] = 3;
                                if (boxX == desX && boxY == desY)
                                {
                                    Console.Clear();
                                    Console.WriteLine("恭喜通关！！！");
                                    Console.WriteLine("按回车结束游戏！");
                                    Console.ReadKey();
                                    return;
                                }
                            }
                            else//如果箱子推不动了
                            {
                                //则星星也不该动
                                x2 = x1;
                                y2 = y1;
                                index = preIndex;

                                isFailed = true;
                            }    
                        }
                        break;
                    //终点
                    case 4: {

                        }
                        break;
                    default:
                        break;
                }

                //更新星星位置 : 星星如果移动了   x1: 前一个位置    x2:移动后的位置
                if (x1 != x2 || y1 != y2)
                {
                    //清空           判断是否是终点
                    map[x1, y1] =    desX == x1 && desY == y1 ? 4 : 0;
                    //更新星星位置
                    map[x2, y2] = 1;
                    //更新前一个位置为移动后的位置
                    preIndex = index;
                }
                
                Console.WriteLine("分数：" + score);
                Console.WriteLine();
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        switch (map[i,j])
                        {
                            case 0: Console.Write("○");break;//空白区域
                            case 1: Console.Write("人"); break;
                            case 2: Console.Write("吃"); break;  //可以被吃掉的玩意儿
                            case 3: Console.Write("箱"); break;  //箱子
                            case 4: Console.Write("终"); break;  //终点
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
