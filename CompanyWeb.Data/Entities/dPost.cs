using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Entities
{
    public class dPost
    {
        public long ID { get; set; }
        public string? Title { get; set; }
        public string? MetaTitle { get; set; }
        public int? ID_CPost { get; set; }
        public string? Image { get; set; }
        public string? Thumbnail { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public byte? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
