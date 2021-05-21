// <copyright file="Program.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace WebApp
{
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    [SuppressMessage("ReSharper", "SA1600", Justification = "tmp")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "tmp")]
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(
                    webBuilder => { webBuilder.UseStartup<Startup>(); });

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}
