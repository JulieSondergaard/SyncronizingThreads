using System;
using System.Threading;

namespace SyncronizingThreads
{
    class Program
    {

        static int count;
        static object _lock = new object();


        static void Main(string[] args)
        {
            Thread add = new Thread(Add);
            Thread subtract = new Thread(Subtract);

            add.Start();
            subtract.Start();
                        
        }

        static void Add()
        {
            while (true)
            {
                Monitor.Enter(_lock);

                count += 2;
                Console.WriteLine("[Adding] Count:" + count);
                Thread.Sleep(1000);

                Monitor.Exit(_lock);
            }
        }

        static void Subtract()
        {
            while (true)
            {
                Monitor.Enter(_lock);

                count--;
                Console.WriteLine("[Subtracting] Count: " + count);
                Thread.Sleep(1000);

                Monitor.Exit(_lock);
            }
        }
    }
}
