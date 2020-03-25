using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Revues.Domaine;
using Revues.Repository;

namespace Revues
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RevueContext context = new RevueContext();

            CrudRepository<Articles> crud = new CrudRepository(context);

            var auteurs = aRepo.FindAll();

            foreach (var auteur in auteurs)
            {
                Console.WriteLine(auteurs);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
