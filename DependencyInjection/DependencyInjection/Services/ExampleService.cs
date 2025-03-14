namespace DependencyInjection.Services
{
    public class ExampleService : IExampleService
    {
        private readonly string message;

        public ExampleService(string message)
        {
            this.message = message;
        }

        public string Pozdrav()
        {
            return message;
        }
    }
}
