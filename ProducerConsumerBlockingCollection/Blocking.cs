using System.Collections.Concurrent;

namespace ProducerConsumerBlockingCollection
{
    internal class Blocking
    {
        static void Main(string[] args)
        {

            BlockingCollection<int> _queue1 = new(5);

            _queue1.TryTake(out var item);

            var prod = new Prod();

            var t1 = Task.Run(prod.Adding);
            var t1x = Task.Run(prod.Adding);
            var t1y = Task.Run(prod.Adding);
            var t1z = Task.Run(prod.Adding);

            var t2 = Task.Run(prod.Consuming);
            var t3x = Task.Run(prod.Consuming);
            var t3y = Task.Run(prod.Consuming);

            Task.WaitAll(t1, t1x, t1y, t1z);
            prod.FinishAdding();

            Task.WaitAll(t2, t3x, t3y);
        }
    }

    class Prod
    {
        BlockingCollection<int> _queue = new(5);


        public void Adding()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Adding item '{i}'");
                _queue.Add(i);
                Thread.Sleep(1000);
            }
        }

        public void FinishAdding()
        {
            Thread.Sleep(10000);
            _queue.CompleteAdding();
        }

        public void Consuming()
        {
            while (!_queue.IsCompleted) // only when CompleteAdding was called and _queue length is 0
            {
                Console.WriteLine("..");
                try
                {
                    _queue.TryTake(out int itemTakenAndRemoved);

                    Console.WriteLine($"Consuming item '{itemTakenAndRemoved}'");

                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    throw new Exception("Something bad happened.", ex);
                }

            }
        }
    }
}
