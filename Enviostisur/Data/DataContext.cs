using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enviostisur.Data.Entities;

namespace Enviostisur.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<MDGranel> Granels { get; set; }
        public virtual DbSet<MDTmreca> MDTmrecas  { get; set; }
        public virtual DbSet<MDTcdocu_orig> MDTcdocu_Origs { get; set; }
        public virtual DbSet<MDTddocu_orig> MDTddocu_Origs { get; set; }

    }
}
