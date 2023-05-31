using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.DataAccess.Data
{
    public class BlazorContext : IdentityDbContext
    {
        public BlazorContext(DbContextOptions<BlazorContext> options) :base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
    }
}
