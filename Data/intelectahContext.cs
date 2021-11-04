using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using intelectah.Models;

namespace intelectah.Data
{
    public class intelectahContext : DbContext
    {
        public intelectahContext (DbContextOptions<intelectahContext> options)
            : base(options)
        {
        }

        public DbSet<intelectah.Models.Patient> Patient { get; set; }

        public DbSet<intelectah.Models.ExamsTypes> ExamsTypes { get; set; }

        public DbSet<intelectah.Models.Exams> Exams { get; set; }

        public DbSet<intelectah.Models.Appointments> Appointments { get; set; }


    }
}
