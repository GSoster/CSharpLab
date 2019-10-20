using PluginShared;
using System;

namespace PrintPlugin
{
    public class PrintPlugin : IPlugin
    {
        public string Name => nameof(PrintPlugin);

        public string Description
        {
            get
            {
                return $"{nameof(PrintPlugin)} is a plugin to facilitate printing information to default output";
            }
        }

        public void Execute()
        {
            Console.WriteLine(Description);
        }
    }
}
