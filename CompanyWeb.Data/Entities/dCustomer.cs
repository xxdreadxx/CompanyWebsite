using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Entities
{
    public class dCustomer
    {
        public long ID { get; set; }
        public int? ID_CCustomer { get; set; }
        public string? Title { get; set; }
        public string? MetaTitle { get; set; }
        public string? Avatar { get; set; }
        public string? Content { get; set; }
        public byte? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
