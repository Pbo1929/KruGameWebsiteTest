using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorkModels.Models;

namespace WorkServices.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        public DbSet<Work> Works { get; set; }
    }
}
