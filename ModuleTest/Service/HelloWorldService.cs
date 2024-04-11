namespace ModuleTest.Service
{
    public interface IHelloWorldService
    {
        string Hello();
    }

    public class HelloWorldService : IHelloWorldService
    {
        public string Hello()
        {
            return "Hello workd";
        }
    }
}
