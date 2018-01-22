using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace AppBug59184
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public string DatabasePath { get; private set; }
        public DbSet<Model.NullableEntity> NullableEntities { get; set; }

        public DbContext() : base()
        {
            DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appbug59184.db");
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }
    }
}
