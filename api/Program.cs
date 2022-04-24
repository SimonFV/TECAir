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
            List<string> scaleList = new()
            {
                "Salvador",
                "Mexico"
            };
            DAL.Insert_rute(1, "Costa Rica", scaleList, "USA", 2560);
            DAL.Insert_rute(2, "Costa Rica", scaleList, "USA", 2560);
            */

            //DAL.Insert_rute(2, "USA", "Mexico", "Costa Rica", 2560);
            //DAL.Insert_rute(3, "Francia", null, "España", 556);
            //DAL.Insert_rute(4, "España", null, "Francia", 556);
            //DAL.Insert_plane("QD21", 68, "boeing 737");
            //DAL.Insert_flight(1, "QD21", 1, 1, new DateTime(2022, 4, 25, 13, 30, 0));
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
