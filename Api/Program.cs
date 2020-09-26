using System;
using Application.Common.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Api {
    public class Program {
        public static void Main (string[] args) {
            var host = CreateWebHostBuilder (args).Build ();
            try {
                Log.Information ("Starting host");
                host.Run ();
            } catch (System.Exception ex) {
                Log.Fatal (ex, "Host terminated unexpectedly");
            } finally {
                Log.CloseAndFlush ();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .ConfigureAppConfiguration ((hostingContext, config) => {
                var env = hostingContext.HostingEnvironment;

                config.AddJsonFile ("appsettings.json", optional : true, reloadOnChange : true);

                config.AddEnvironmentVariables ();

                if (args != null) {
                    config.AddCommandLine (args);
                }
            })
            .UseKestrel ((h, o) => { o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes (h.Configuration.GetValue<double> (Constant.KeepAliveTimeoutKey, Constant.KeepAliveTimeout)); o.AddServerHeader = false; })
            .UseStartup<Startup> ().UseSerilog ((hostingContext, loggerConfiguration) => loggerConfiguration
                .ReadFrom.Configuration (hostingContext.Configuration));
    }
}