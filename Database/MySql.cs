using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using Model;

namespace Database
{
    public class MySqlContext : DbContext
    {
        public DbSet<SensorData> SensorData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(
                @"server=db.funsw.us;database=db;user=db;password=fc16c58e9e221bf980874e43cc837824a4d75a7768a3b5073fef2ad8393a05ad");
        }
    }
}