using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using Models;

namespace Database
{
    public class MySqlContext : DbContext
    {
        public DbSet<SensorData> SensorData { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Device> Devices { get; set; }
        //public DbSet<Ebox> Ebox { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(
                @"server=db.funsw.us;database=db;user=db;password=fc16c58e9e221bf980874e43cc837824a4d75a7768a3b5073fef2ad8393a05ad");
        }

        public DbSet<Models.User> User { get; set; }
    }
}