using DependencyInjection;
using DependencyInjection.Services;
using Moq;

namespace DITests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var transientServiceMock = new Mock<ITransientService>();
            var scopedServiceMock = new Mock<IScopedService>();
            var singletonServiceMock = new Mock<ISingletonService>();

            var service = new ServiceLifetimeReporter(
                transientServiceMock.Object,
                scopedServiceMock.Object,
                singletonServiceMock.Object);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            service.Report("abc");

            Assert.That(sw.ToString(), Is.EqualTo("a"));
        }
    }
}