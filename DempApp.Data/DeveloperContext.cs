using DemoApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace DempApp.Data
{
    public class DeveloperContext : DbContext
    {
        public DbSet<Developer> Developer { get; set; }

        public DeveloperContext(DbContextOptions<DeveloperContext> options) : base(options)
        {

        }
       
    }
}
