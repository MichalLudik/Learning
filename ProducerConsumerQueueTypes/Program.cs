using System.Collections.Concurrent;

namespace ProducerConsumerQueueTypes
{
    internal class Program
    {
        static BlockingCollection<int> concurrentQueue = new(new ConcurrentQueue<int>());
        static BlockingCollection<int> concurrentStack = new(new ConcurrentStack<int>());

        static void Main(string[] args)
        {
            int[] col = Enumerable.Range(0, 10).ToArray();

            AddItemsToCollection(concurrentQueue, col);
            AddItemsToCollection(concurrentStack, col);

            Console.WriteLine("Dequeuing Concurrent Queue");
            Dequeue(concurrentQueue);

            Console.WriteLine("Dequeuing Concurrent Stack");
            Dequeue(concurrentStack);
        }

        static void AddItemsToCollection(BlockingCollection<int> collection, int[] items)
        {
            foreach (int item in items)
            {
                collection.Add(item);
            }
        }

        static void Dequeue(BlockingCollection<int> collection)
        {
            while (collection.Count > 0)
            {
                if (collection.TryTake(out int item))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
