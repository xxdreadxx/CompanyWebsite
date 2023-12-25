using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Entities
{
    public class dRecuitment
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? WorkPosition { get; set; }
        public string? WorkAddress { get; set; }
        public int? Quantity { get; set; }
        public string? Content { get; set; }
        public string? Requirement { get; set; }
        public string? Treatment { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public byte? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
