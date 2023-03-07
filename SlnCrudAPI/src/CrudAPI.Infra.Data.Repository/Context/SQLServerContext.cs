using CrudAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Infra.Data.Repository.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> option) : base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasData(
                    new { Id=1, Name="Lucas", LastName="Kreuch", Age=17, Occupation="Programmer" }
                );
        }

        #region DbSets
        public DbSet<Person> Persons { get ; set; }
        #endregion
    }
}
