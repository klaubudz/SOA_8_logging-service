using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace LogDB
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions<LogContext> options) : base(options)
        {

        }

        public DbSet<Log> Logs { get; set; }
    }
}
