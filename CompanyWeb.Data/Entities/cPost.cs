using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Entities
{
    public class cPost
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? MetaTitle { get; set; }
        public byte Status { get; set; }
    }
}
