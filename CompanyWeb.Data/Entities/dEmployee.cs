using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Entities
{
    public class dEmployee
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Avatar { set; get; }
        public string? ExperienceYear { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        //1: Đang sử dụng; 2: Vô hiệu hóa; 10: Xóa
        public byte? Status { get; set; }
    }
}
