using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Serilog;

class Program
{
    static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("serilog.json")
            .Build();

        var log = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        while (true)
        {
            log.Verbose("This is a Verbose log message");
            log.Debug("This is a Debug log message");
            log.Information("This is an Information log message");
            log.Warning("This is a Warning log message");
            log.Error("This is a Error log message");
            log.Fatal("This is a Fatal log message");
            await Task.Delay(1000);
        }
    }
}