using Elections.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Persistenc
{
    public class ElectionDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Fault> Faults { get; set; }
        public DbSet<OptionToVote> OptionToVotes { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public ElectionDbContext(DbContextOptions<ElectionDbContext> options):base(options)
        {

        }
    }
}
