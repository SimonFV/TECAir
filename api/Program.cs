using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DAL.Insert_rute(1, "CostaRica", "Mexico", "USA");
            //DAL.Insert_plane("QD21", 68, "boeing 737");
            //DAL.Insert_flight(1, "QD21", 1, 1, "Friday 13:00");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
