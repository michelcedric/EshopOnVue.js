﻿using EshopOnVue.js.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EshopOnVue.js.Infrastructure.Data
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options) : base(options)
        {

        }

        public DbSet<CatalogItem> CatalogItems { get; set; }
    }
}
