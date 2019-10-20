using PluginShared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PluginApp
{
    public sealed class PluginProvider
    {
        private static PluginProvider instance;

        public static PluginProvider Instance
        {
            get
            {
                return instance ?? (instance = new PluginProvider());
            }
        }

        private List<IPlugin> pluginInstances;

        public int PluginCount => pluginInstances.Count();

        private PluginProvider(){ }

        

        public void Initialize()
        {
            Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, @"Plugin\"));
            pluginInstances = pluginInstances ??
                (from file in Directory.GetFiles(Path.Combine(AppContext.BaseDirectory, @"Plugin\"), "*.dll")
                 from type in Assembly.LoadFrom(file).GetTypes()
                 where type.GetInterfaces().Contains(typeof(IPlugin))
                 select (IPlugin)Activator.CreateInstance(type)).ToList();                
        }

        public void Action()
        {
            if (pluginInstances != null)
                pluginInstances.ForEach(plugin => plugin.Execute());
        }
    }
}
