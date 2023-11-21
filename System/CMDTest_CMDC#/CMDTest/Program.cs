using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMDTest
{
    public class RandomNumber
    {
        public int getRnum(int max)
        {
            int inum = 0;
            Random random = new Random();
            inum = random.Next(1, max);
            return inum;
        }

        public int getRRnum(int max)
        {
            int inum = 0;
            Random random0 = new Random();
            var seed = random0.Next();
            //Console.Write("seed:" + seed);
            Random random = new Random(seed);
            inum = random.Next(1,max);
            return inum;
        }

        public int getTrnum(int max)
        {
            int inum = 0;
            Random random = new Random(DateTime.Now.Millisecond);
            inum = random.Next(1, max);
            return inum;
        }
    }

    public class GuidNumber
    {
        public void Gnum()
        {
            Guid guid = Guid.NewGuid();
            Console.WriteLine(guid.ToString());
        }

        public int getGnum(int max)
        {
            byte[] guid = Guid.NewGuid().ToByteArray();      //生成字节数组
            int seed = BitConverter.ToInt32(guid, 0);        //利用BitConvert方法把字节数组转换为整数
            //Console.WriteLine(seed);                       
            Random random = new Random(seed);                //以这个生成的整数为种子
            int inum = 0;
            inum = random.Next(1, max);
            return inum;
        }
    }

    public class CSPNumber
    {
        public void RNG()
        {
            RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
            byte[] byteCsp = new byte[10];
            csp.GetBytes(byteCsp);
            Console.WriteLine(BitConverter.ToString(byteCsp));
        }
        public int getCnum(int max)
        {
            RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();  //实例化RNG方法
            byte[] byteCsp = new byte[10];                                  //创建字节组
            csp.GetBytes(byteCsp);                                          //使用csp给字节组赋值
            long Longseed = BitConverter.ToInt64(byteCsp, 0);               //long类型转化字节组
            int seed = (int)Longseed;                                       //强制将64位截取32位
            Random random = new Random(seed);                               //将转换结果作为随机种子
            int inum = 0;
            inum = random.Next(1, max);
            return inum;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            int maxNum = 100;
            //正常随机数字
            Console.Write("正常随机数字: ");
            for (int i = 0; i < 10; i++)
            {
                RandomNumber way01 = new RandomNumber();
                var resNum = way01.getRnum(maxNum);
                Console.Write("— " + resNum);
            }
            Console.WriteLine();
            //双重随机嵌套
            Console.Write("双重随机数组: ");
            for (int i = 0; i < 10; i++)
            {
                RandomNumber way01 = new RandomNumber();
                var resNum = way01.getRRnum(maxNum);
                Console.Write("— " + resNum);
            }
            Console.WriteLine();
            //根据时间生成随机数字
            Console.Write("时间种子数组: ");
            for (int i = 0; i < 10; i++)
            {
                RandomNumber way01 = new RandomNumber();
                var resNum2 = way01.getTrnum(maxNum);
                Console.Write("— " + resNum2);
            }
            Console.WriteLine();
            //GUID方法生成随机数字
            Console.Write("GUID随机数组: ");
            for (int i = 0; i < 10; i++)
            {
                GuidNumber way02 = new GuidNumber();
                var resNum = way02.getGnum(maxNum);
                Console.Write("— " + resNum);
            }
            Console.WriteLine();
            //CSP加密方法生成随机数字
            Console.Write("CSP随机数组 : ");
            for (int i = 0; i < 10; i++)
            {
                CSPNumber way03 = new CSPNumber();
                var resNum = way03.getCnum(maxNum);
                Console.Write("— " + resNum);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
