using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDgame
{
    class Program
    {
        public class Core
        {
            int[] red = new int[6];
            int ired = 0;
            int blue = 0;

            private int getnum(int max)
            {
                int inum = 1;
                Random random = new Random();
                inum = random.Next(1, max);
                return inum;
            }

            public void getred0()
            {
                for (int i = 0; i < 6; i++)
                {
                    red[i] = getnum(33);
                }
            }
            public void getred1()
            {
                Random random = new Random();
                for (int i = 0; i < 6; i++)
                {
                    red[i] = random.Next(1, 33);
                }
            }


            public void getred2()
            {
                bool flag = true;                       //创建判断值
                do
                {
                    int temp;                           //创建暂时存储的数字
                    temp = getnum(33);                  //调用随机算法获取数字
                    if (red.Contains(temp))             //调用Contains方法判断是否存在
                    {
                        flag = true;                    //若已存在，判断值标记为存在
                    }
                    else
                    {
                        red[ired] = temp;               //若不存在，将数值赋值给数组
                        ired++;                         //数组检索+1
                        if (ired > red.Length-1)        //当数量超过数组大小时
                        {
                            flag = false;               //不可继续执行
                        }
                        else
                        {
                            flag = true;                //不超过数组大小可继续执行
                        }
                    }
                } while (flag);                         //循环判断
            }

            public void getblue()
            {
                blue = getnum(16);
            }

            public void getarray()
            {
                //getred0();
                //getred1();
                getred2();
                getblue();
                Console.WriteLine("中奖数组为： " 
                    + ToString()+ " {" + blue.ToString()+"}");


                //普通数字输出方法
                //for (int i = 0; i < red.Length; i++)
                //{
                //    Console.WriteLine(red[i]);
                //}
                //Console.WriteLine();
                //Console.WriteLine(blue);
            }
            public override string ToString()
            {
                return red[0].ToString() + "--" + red[1].ToString() + 
                    "--" + red[2].ToString() + "--" + red[3].ToString() + 
                    "--" + red[4].ToString() + "--" + red[5].ToString();
            }
        }

        static void Main(string[] args)
        {
            Core core = new Core();
            core.getarray();
        }
    }
}
