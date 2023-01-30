﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using CodingTracker.Model;

namespace CodingTracker
{
    internal class CodingTrackerContext : DbContext
    {
        public DbSet<CodingSession> Sessions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={ConfigurationManager.ConnectionStrings["DatabasePath"].ConnectionString}");
    }
}
