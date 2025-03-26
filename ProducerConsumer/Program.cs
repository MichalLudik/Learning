using System.Diagnostics;

namespace ProducerConsumer
{
    internal class Program
    {
        static Stopwatch sw = new Stopwatch();

        static async Task Main(string[] args)
        {
            sw.Start();

            // one producer one consumer
            var pcQueue = new PCQueue();

            Action action;
            var t1 = Task.Run(() => EnqueueWorkWithRandomDelay());
            var t2 = Task.Run(() => pcQueue.DequeueWork());

            await t1;
            await t2;

            Console.WriteLine(pcQueue.Queue.Count());


            async Task EnqueueWorkWithRandomDelay()
            {
                Random random = new Random();

                for (int i = 0; i < 10; i++)
                {
                    int x = i;
                    Thread.Sleep(TimeSpan.FromMilliseconds(random.Next(100, 500)));
                    Console.WriteLine($"[{sw.ElapsedMilliseconds}] Adding action no. {x}");

                    action = () => Console.WriteLine($"[{sw.ElapsedMilliseconds}] Performing action no. {x}");
                    pcQueue.EnqueueWork(action);
                }

                pcQueue.shouldProcess = false;
            }
        }


        public class PCQueue
        {
            public bool shouldProcess = true;

            public Queue<Action> Queue = new Queue<Action>();

            public void EnqueueWork(Action action)
            {
                Queue.Enqueue(action);
            }

            public async Task DequeueWork()
            {
                while (shouldProcess)
                {
                    Console.WriteLine($"[{sw.ElapsedMilliseconds}] --- DEQUEUE ---");

                    await Task.Delay(1000);

                    Dequeue();
                }
            }

            private void Dequeue()
            {
                while (Queue.TryDequeue(out var item))
                {
                    //Console.WriteLine("Dequeuing action...");
                    item();
                }
            }
        }
    }
}
