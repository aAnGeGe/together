﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Together.Activity.Infrastructure.Data;
using Nutshell.Extensions.WebHost;
using Together.Activity.API.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Together.Activity.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDbContext<ActivityDbContext>(async (context, services) =>
                {
                    var logger = services.GetService<ILogger<ActivityDbContextSeed>>();
                    new ActivityDbContextSeed()
                        .SeedAsync(context, logger)
                        .Wait();
                })
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
