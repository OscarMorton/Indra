using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indra.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

namespace Indra.Infrastructure.Persistance
{
    public class Context : DbContext
    {
        public DbSet<Student> Student { get; set; }

        public DbSet<User> User { get; set; }

        public Context()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(config.GetConnectionString("DbConnection"));
                //  optionsBuilder.UseSqlServer("Server=localhost\\SQLDEVELOPER;Database=Bag;Trusted_Connection=True;");
            }
        }
    }
}