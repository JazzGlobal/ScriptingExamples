using System;
using CSScriptLibrary;

namespace ScriptingExamples.csscripts.ScriptLoad
{
    public class ScriptLoad
    {
        public static dynamic LoadScript(string filepath)
        {
            try
            {
                string scriptText = System.IO.File.ReadAllText(filepath);
                dynamic script_obj = CSScript.LoadCode(scriptText).CreateObject("*");
                return script_obj;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
    }
}
