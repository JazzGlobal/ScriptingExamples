using System;
using System.Reflection;
using CSScriptLibrary;

namespace ScriptingExamples.csscripts.ScriptLoad
{
    public class ScriptLoad
    {
        public static dynamic LoadScript(string filepath, object[] parameters=null)
        {
            try
            {
                string scriptText = System.IO.File.ReadAllText(filepath);
                dynamic script_obj = CSScript.LoadCode(scriptText).CreateObject("*", parameters);
                return script_obj;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(MethodBase.GetCurrentMethod());
                return null;
            }
        }
    }
}
