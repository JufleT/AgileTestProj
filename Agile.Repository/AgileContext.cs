using System;
using Agile.Repository.Abstract.Models;
using Microsoft.EntityFrameworkCore;

namespace Agile.Repository
{
    public class AgileContext : DbContext
    {
        public AgileContext(DbContextOptions<AgileContext> options) : base(options)
        {
            Database.EnsureCreated();
;       }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
