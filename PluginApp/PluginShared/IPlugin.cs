using System;
using System.Collections.Generic;
using System.Text;

namespace PluginShared
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }

        void Execute();
    }
}
