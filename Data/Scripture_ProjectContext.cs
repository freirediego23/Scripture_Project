using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scripture_Project.Models;

namespace Scripture_Project.Data
{
    public class Scripture_ProjectContext : DbContext
    {
        public Scripture_ProjectContext (DbContextOptions<Scripture_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Scripture_Project.Models.Scripture> Scripture { get; set; }
    }
}
