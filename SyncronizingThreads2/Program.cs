using System;
using System.Threading;

namespace SyncronizingThreads2
{
    class Program
    {

        static int count;

        static object _lock = new object();


        static void Main(string[] args)
        {
            Thread stars = new Thread(Print);
            Thread hashtags = new Thread(Print);

            stars.Start("*");
            hashtags.Start("#");

        }

        static void Print(object symbol)
        {
            while (true)
            {
                lock (_lock)
                {


                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write(symbol.ToString());

                        if (i == 59)
                        {
                            count += 60;
                        }  
                    }
                    Console.Write($" {count}\n");
                    Thread.Sleep(1000);
                }
            }
        }

        
    }
}
