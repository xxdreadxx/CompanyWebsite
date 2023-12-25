using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Entities
{
    public class dQnA
    {
        public long ID { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public DateTime? CreatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
