using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

    [NotMapped]
    public class dCustomerView:dCustomer { 
        public string CCustomer_Title { get; set; }
    }
}
