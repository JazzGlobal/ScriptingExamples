//css_nuget NLog
using System;

public class ScriptLogging
{
    private string _scriptEngineName = "Script Engine Logger";
    
    public void SetLogName(string name)
    {
        _scriptEngineName = name;
    }

    public void ConfigLog()
    {
        var config = new NLog.Config.LoggingConfiguration();
        var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log.txt" };
        var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
        
        config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logconsole);
        config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, logfile);

        NLog.LogManager.Configuration = config;
    }

    public void LogMessage(string message)
    {
        NLog.Logger Logger = NLog.LogManager.GetLogger(_scriptEngineName);
        Logger.Info(message);
    }

    public string GenerateLogMessage(string message)
    {
        string _logEntry = String.Format("{0} - {1}", DateTime.Now.ToString("hh:mm:ss.fff"), message);
        return _logEntry;
    }
}