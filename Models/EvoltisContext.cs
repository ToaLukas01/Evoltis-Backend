﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Models.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EvoltisContext : DbContext
    {
        public EvoltisContext(DbContextOptions<EvoltisContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }

    // --- Conexion con SqlServer para aplicar migraciones ---
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EvoltisContext>
    {
        public EvoltisContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = Environment.GetEnvironmentVariable("CS") ?? configuration.GetConnectionString("CS"); ;
            var optionsBuilder = new DbContextOptionsBuilder<EvoltisContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EvoltisContext(optionsBuilder.Options);
        }
    }


    // --- Conexion con MySQL para aplicar migraciones ---
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EvoltisContext>
    //{
    //    public EvoltisContext CreateDbContext(string[] args)
    //    {
    //        var configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();

    //        var connectionString = Environment.GetEnvironmentVariable("CS") ?? configuration.GetConnectionString("CS"); ;
    //        var optionsBuilder = new DbContextOptionsBuilder<EvoltisContext>();
    //        optionsBuilder.UseMySql(connectionString,
    //            ServerVersion.AutoDetect(connectionString));

    //        return new EvoltisContext(optionsBuilder.Options);
    //    }
    //}


}
