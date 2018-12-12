# 使用NLog

快速入门:<https://github.com/NLog/NLog.Web/wiki/Getting-started-with-ASP.NET-Core-2>

* 使用VSCode
* $> dotnet new mvc -au Individual -uld -name Coding002
* in csproj:


```xml
<PackageReference Include="NLog.Web.AspNetCore" Version="4.7.0" />
<PackageReference Include="NLog" Version="4.5.11" />
```

* $> dotnet restore
* Create a nlog.config file

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
      autoReload="true"
      internalLogLevel="info"
      internalLogFile="c:\temp\internal-nlog.txt">

  <!-- enable asp.net core layout renderers -->
  <extensions>
    <add assembly="NLog.Web.AspNetCore"/>
  </extensions>

  <!-- the targets to write to -->
  <targets>
    <!-- write logs to file  -->
    <target xsi:type="File" name="allfile" fileName="logs\nlog-all-${shortdate}.log"
            layout="${longdate}|${event-properties:item=EventId_Id}|${uppercase:${level}}|${logger}|${message} ${exception:format=tostring}" />

    <!-- another file log, only own logs. Uses some ASP.NET core renderers -->
    <target xsi:type="File" name="ownFile-web" fileName="logs\nlog-own-${shortdate}.log"
            layout="${longdate}|${event-properties:item=EventId_Id}|${uppercase:${level}}|${logger}|${message} ${exception:format=tostring}|url: ${aspnet-request-url}|action: ${aspnet-mvc-action}" />
  </targets>

  <!-- rules to map from logger name to target -->
  <rules>
    <!--All logs, including from Microsoft-->
    <logger name="*" minlevel="Trace" writeTo="allfile" />

    <!--Skip non-critical Microsoft logs and so log only own logs-->
    <logger name="Microsoft.*" maxLevel="Info" final="true" /> <!-- BlackHole without writeTo -->
    <logger name="*" minlevel="Trace" writeTo="ownFile-web" />
  </rules>
</nlog>
```

* Update program.cs

```C#
public static void Main(string[] args)
{
    // NLog: setup the logger first to catch all errors
    var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
    try
    {
        logger.Debug("init main");
        BuildWebHost(args).Run();
    }
    catch (Exception ex)
    {
        //NLog: catch setup errors
        logger.Error(ex, "Stopped program because of exception");
        throw;
    }
    finally
    {
        // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
        NLog.LogManager.Shutdown();
    }
}

public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
        })
        .UseNLog()  // NLog: setup NLog for Dependency injection
        .Build();
```

* Configure appsettings.json

```json
// The Logging configuration specified in appsettings.json overrides any call to SetMinimumLevel. So either remove "Default": or adjust it correctly to your needs.
{
    "Logging": {
        "LogLevel": {
            "Default": "Trace",
            "Microsoft": "Information"
        }
    }
}
```

* Write logs
* $> dotnet run

```C#
// Inject the ILogger in your controller:
using Microsoft.Extensions.Logging;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Index page says hello");
        return View();
    }
}
```

## 剩下的后续再继续探索。