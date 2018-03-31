using System;
using System.Threading;

namespace Lock1
{
    class Program
    {
        //声明创建加锁对象
        public static object LockExample = new object();
        //声明共享变量
        static int i = 0;
        static void Main(string[] args)
        {
            //创建子线程1和子线程2
            Thread ThreadIWayFirst = new Thread(new ThreadStart(MethodIWayFirst));
            Thread ThreadIWaySecond = new Thread(new ThreadStart(MethodIWaySecond));
            //启动线程子线程1
            ThreadIWayFirst.Start();
            //启动线程子线程2
            ThreadIWaySecond.Start();
        }
        //到这里线程已经启动，并且已经调用方法，执行输出。
        /*       do
               {
   	//如果按e键并回车则结束子线程，退出循环
                   if (Console.Read() == 'e')
                   {
   	//终止线程A
                       ThreadIWayFirst.Abort();
   	//终止线程B
                       ThreadSubB.Abort();
   	//中断循环
                       break;
                   }
               } while (1 == 1);
           }
   */
        public static void MethodIWayFirst()
        {
            //  do
            {
                //对线程内的操作进行锁定操作
                // lock (LockExample)
                lock (LockExample)
                {
                    //在线程A中操作共享变量i
                  //  i = i + 1;
                    for(;i<12;i++)
                        if (i < 12)
                            Console.WriteLine("线程1开始，共享数据值i={0}", i);
                    //线程A休眠2000毫秒
                    Thread.Sleep(2000);
                    //输出线程A的信息

               //     if (i < 12)

                        Console.WriteLine("线程1结束，共享数据值i={0}", i);
                }
                //    } while (i < 12);
            }

        }
        public static void MethodIWaySecond()
        {
              do  //do while 语句或者if语句  在这里如果不用do-while语句的话那么 MethodIWaySecond()方法就不会被循环，且只执行一次
            {
                //对线程内的操作进行锁定
                lock (LockExample)
                //  lock (LockExample)
                {
                    //在线程B中操作共享变量i
                    //  i = i - 1;
                    //  a = a + 1;
                    i = i - 3;//加上这一句共享数据就会有所不同的了
                    //  if(i<120)//无作用
                    Console.WriteLine("线程2开始，共享数据值i={0}", i);
                    //线程B休眠2000毫秒
                    Thread.Sleep(2000);
                    //输出线程B的信息
                    if (i < -9)
                        Console.WriteLine("线程2退出，共享数据值i={0}", i);
                    Thread.Sleep(2000);
                }
            } while (i>-10);
                Console.ReadLine();
           // *中国的芯片加工精度只有58纳米，典型的大块头，大功耗，低效率。
            }
       }
    }



