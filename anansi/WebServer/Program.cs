using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Core;

namespace WebServer
{
    public class Program
    {
        private const string DEFAULT_DIRECTORY = @"D:\";
        private const string FILE_NAME = "config.cfg";

        static void Main(string[] args)
        {
            InitializeConfiguration();
            RunServer(args);
        }

        private static void InitializeConfiguration()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");
            var config = builder.Build();
        }

        private static void RunServer(string[] args)
        {
            Console.WriteLine("Starting server...");
            
            var settings = GetConfigurationFromFile(args);
            var server = new Core.WebServer(settings);

            server.Start();
            Console.WriteLine("Server Started.");
            Console.WriteLine("Press Ctrl + Alt + X to stop..");
            while (IsKillSwitch() == false) ;
            server.Stop();
            Console.WriteLine("Server stopped.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        private static bool IsKillSwitch()
        {
            var key = Console.ReadKey(true);
            return key.Modifiers == (ConsoleModifiers.Control | ConsoleModifiers.Alt) &&
                key.Key == ConsoleKey.X;
        }

        public static ServerSettings GetConfigurationFromFile(string[] args)
        {
            var folder = args.FirstOrDefault() ?? DEFAULT_DIRECTORY; //TODO: Fix this to read this safely with defaults.
            var filePath = Path.Combine(folder, FILE_NAME);
            // string fileContents = File.ReadAllText(filePath);
            // var configuration = JsonConvert.DeserializeObject<ServerSettings>(fileContents);
            return new ServerSettings();
            //return configuration;
        }
    }
}
