using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011064226_PhamAnhHao
{
    internal class Employer
    {
        public int id { get; set; }
        [StringLength(100)]
        public string name { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Phone]
        public string phone { get; set; }
        [StringLength(196)]
        public string image { get; set; }

        [Display(Name ="Tuổi")]
        public string birth { get; set; }
    }
}
