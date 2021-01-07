using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RankingApp_Rookiss.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RankingApp_Rookiss.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<GameResult> GameResult { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
