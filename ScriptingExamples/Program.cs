using System;
using System.Collections.Generic;
using System.Threading;
using ScriptingExamples.csscripts.ScriptLoad;

namespace ScriptingExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            CSharpScriptingExample.Start();
        }
    }

    class CSharpScriptingExample
    {
        static dynamic logging_script;
        static dynamic reporting_script;
        public static void Start()
        {
            logging_script = ScriptLoad.LoadScript(@".\csscripts\logging\logging.cs", null);
            logging_script.ConfigLog();
            logging_script.LogMessage("Hello World");


            List<string> rowData = new List<string>();
            rowData.Add("Data entry 1");
            rowData.Add("Data entry 2");
            rowData.Add("Data entry 3");
            rowData.Add("Data entry 4");
            rowData.Add("Data entry 5");

            var files = System.IO.Directory.GetFiles(@".\csscripts\reporting","*_report.cs");
            while (true)
            {
                foreach (var file in files)
                {
                    try
                    {
                        reporting_script = ScriptLoad.LoadScript(file, new object[] { "Temp Title", rowData });
                        Console.WriteLine(reporting_script.CreateReportData());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        continue;
                    }
                }
                Thread.Sleep(5000);
            }
        }
    }
}
