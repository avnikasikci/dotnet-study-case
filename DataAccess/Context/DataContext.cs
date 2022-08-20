using DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<NewsAgency> NewsAgency { get; set; }
        public DbSet<NewsAgencyCategory> NewsAgencyCategory { get; set; }
        public DbSet<Localization> Localization { get; set; }
        public DbSet<Language> Language { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
