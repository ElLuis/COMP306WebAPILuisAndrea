using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306WebAPILuisAndrea.Models
{
    public class DrivingDbContext : DbContext
    {
        public DrivingDbContext(DbContextOptions<DrivingDbContext> options):base(options)
        {
        }
        public DbSet<DrivingCentre> DrivingCentres { get; set; }
        public object DrivingCentre { get; internal set; }
    }
}
