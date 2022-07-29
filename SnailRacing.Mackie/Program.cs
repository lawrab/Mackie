// Bot invite URL https://discord.com/api/oauth2/authorize?client_id=1002520271275692082&permissions=11006241872&scope=bot
using SnailRacing.Mackie.Infrastructure;

namespace SnailRacing.Mackie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartUp.Init();
            Console.WriteLine("Hello, World!");
        }
    }
}