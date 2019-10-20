using System;

namespace PluginApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading Plugins...");
            var pluginProvider = PluginProvider.Instance;
            pluginProvider.Initialize();
            Console.WriteLine($"{pluginProvider.PluginCount} plugins loaded.");
            pluginProvider.Action();
            Console.WriteLine("Ending execution of Plugins");
        }
    }
}
