using System.Collections.Generic;

namespace ProducerConsumerThreads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            bool cancel = false;


            Thread thread1 = new Thread(() =>
            {
                // enqueue actions
                Random random = new Random();

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(random.Next(10,300)));

                    int x = i;
                    
                    queue.Enqueue($"Item {x} from Thread {Thread.CurrentThread.ManagedThreadId}");
                }
            });

            Thread thread2 = new Thread(() => {
                Console.WriteLine($"Starting service ABC from Thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(TimeSpan.FromSeconds(3));
                autoResetEvent.Set();

                Thread.Sleep(TimeSpan.FromSeconds(10));
                cancel = true;

            });

            Thread thread3 = new Thread(() =>
            {
                Console.WriteLine($"Waiting for service start from Thread {Thread.CurrentThread.ManagedThreadId}");
                autoResetEvent.WaitOne();
                Console.WriteLine($"Service has started from Thread {Thread.CurrentThread.ManagedThreadId}");

                while (!cancel)
                {
                    if (queue.Count > 0)
                    {
                        Console.WriteLine($"Dequeued item \"{queue.Dequeue()}\" from Thread {Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(TimeSpan.FromMilliseconds(100));
                    }
                }

            });

            thread1.Start();
            thread2.Start();
            thread3.Start();
        }
    }
}
