using Chirper.API.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chirper.API.Infrastructure
{
    public class DataContext : IdentityDbContext<ChirperUser>
    {
        public DataContext() : base("Chirper")
        {
        }
        public IDbSet<Chirp> Chirps { get; set; }
        public IDbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chirp>()
                .HasMany(c => c.Comments)
                .WithRequired(c => c.Chirp)
                .HasForeignKey(c => c.ChirpId);

            modelBuilder.Entity<ChirperUser>()
                .HasMany(u => u.Chirps)
                .WithRequired(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<ChirperUser>()
                .HasMany(u => u.Comments)
                .WithRequired(c => c.User)
                .HasForeignKey(c => c.UserId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}