using Jeppesen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeppesen.Data
{
    public class RecordStoreContext : DbContext
    {
        public RecordStoreContext(DbContextOptions<RecordStoreContext> options) : base(options)
        {
        }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Record> Records{ get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().ToTable("Log").HasKey(log => log.ID);
            modelBuilder.Entity<Record>().ToTable("Record").HasKey(record => new { record.Band, record.Title });
            modelBuilder.Entity<User>().ToTable("User").HasKey(user => user.ID);
        }
    }
}
