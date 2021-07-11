using System;
using CSScriptLibrary;
using csscript;
using ScriptingExamples.csscripts.ScriptLoad;

namespace ScriptingExamples
{
    class Program
    {
        static dynamic logging_script;
        static void Main(string[] args)
        {
            logging_script = ScriptLoad.LoadScript(@".\csscripts\logging\logging.cs");
            logging_script.ConfigLog();
            logging_script.LogMessage("Hello World");
            Console.ReadKey();
        }
    }
}
