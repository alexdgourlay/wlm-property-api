using Microsoft.EntityFrameworkCore;
using System;


namespace UK_Property_API.Models
{
    public class PropertyContext : DbContext
    {
        public PropertyContext(DbContextOptions<PropertyContext> options) : base(options)
        {
        }

        public DbSet<Property> PropertyData { get; set; }
    }
}
