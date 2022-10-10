using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011064226_PhamAnhHao
{
    internal class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext() : base("name=con") { }
        public DbSet<Employer> Emplist { get; set; }
    }
}
