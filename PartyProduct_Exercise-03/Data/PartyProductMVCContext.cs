using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProduct_Exercise_03.Data
{
    public class PartyProductMVCContext : DbContext
    {
        public PartyProductMVCContext(DbContextOptions<PartyProductMVCContext> options)
            : base(options)
        {
        }
        public DbSet<Party> Party { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<AssignParty> AssignParty { get; set; }
        public DbSet<ProductRate> ProductRate { get; set; }
        public DbSet<Invoice> Invoice { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Party>().HasIndex(x => new { x.PartyName }).IsUnique(true);
            mb.Entity<Product>().HasIndex(x => new { x.ProductName }).IsUnique(true);
            mb.Entity<ProductRate>().HasIndex(x => new { x.ProductId }).IsUnique(true);
        }
    }
}
