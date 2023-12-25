using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Entities
{
    public class dFeedback
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Company { get; set; }
        public int? IDProduct { get; set; }
        public int? Star { get; set; }
        public string? Content { get; set; }
        public byte Status { get; set; }
    }
}
