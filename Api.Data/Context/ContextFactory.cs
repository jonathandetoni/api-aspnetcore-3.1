using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        [Obsolete]
        public MyContext CreateDbContext(string[] args)
        {
            // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            var connectionString = "Server=;Port=;Database=;Uid=;Pwd=";
            optionsBuilder.UseMySql(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
