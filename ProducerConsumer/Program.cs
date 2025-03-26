namespace ProducerConsumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // one producer one consumer
            var producer = new PCQueue();

            Action action;
            EnqueueWorkWithRandomDelay();

            Console.WriteLine(producer.Queue.Count());


            void EnqueueWorkWithRandomDelay()
            {
                Random random = new Random();

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(random.Next(100, 2000)));
                    action = () => Console.WriteLine($"Attempt {i}");
                    producer.EnqueueWork(action);
                }
            }
        }
    }

    public class PCQueue
    {
        public Queue<Action> Queue = new Queue<Action>();

        public void EnqueueWork(Action action)
        {
            Queue.Enqueue(action);
        }
    }
}
