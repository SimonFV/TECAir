using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
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
            /*
            DAL.Insert_rute(1, "Costa Rica", new List<string>() { "Salvador", "Mexico" }, "USA", 2560);
            
            //DAL.Insert_plane("QD21", 68, "boeing 737");
            //DAL.Insert_flight(1, "QD21", 1, 1, new DateTime(2022, 4, 25, 13, 30, 0));

            DAL.Insert_rute(1, "SJO", "MEX", "JFK", 2560);
            DAL.Insert_rute(2, "LAX", "MEX", "SJO", 2560);
            DAL.Insert_rute(3, "CDG", null, "MAD", 556);
            DAL.Insert_rute(4, "MAD", null, "CDG", 556);
            DAL.Insert_rute(5, "SJO", "SLV", "JFK", 556);
            DAL.Insert_rute(6, "SJO", null, "JFK", 556);
            DAL.Insert_rute(7, "JFK", "HOU", "LAX", 556);
            DAL.Insert_rute(8, "JFK", null, "LAX", 556);*/
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
