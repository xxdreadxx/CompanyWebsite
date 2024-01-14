using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Admin
{
    public class sSystemDao
    {
        private readonly CompanyDbContext _context;
        public sSystemDao(CompanyDbContext context)
        {
            _context = context;
        }

        public sSystem getData()
        {
            return _context.sSystems.FirstOrDefault();
        }

        public bool Update(sSystem res, ref string mess)
        {
            bool kt = true;
            var item = _context.sSystems.FirstOrDefault();
            if (item != null)
            {
                item.Name = res.Name;
                item.Code = res.Code;
                item.Address = res.Address;
                item.Email = res.Email;
                item.Video = res.Video;
                item.Fax = res.Fax;
                item.TaxCode = res.TaxCode;
                item.Phone = res.Phone;
                item.GoogleMap = res.GoogleMap;
                item.Zalo = res.Zalo;
                item.Facebook = res.Facebook;
                item.Instagram = res.Instagram;
                item.Tiktok = res.Tiktok;
                item.Twitter = res.Twitter;
                item.History = res.History;
                item.ValueAndMission = res.ValueAndMission;
                item.Recruitment_condition = res.Recruitment_condition;
                item.Recruitment_procedure = res.Recruitment_procedure;
                if (res.Favicon != "\\")
                {
                    item.Favicon = res.Favicon;
                }
                try
                {
                    _context.SaveChanges();
                    mess = "Cập nhật thông tin thành công";
                }
                catch (Exception ex)
                {
                    kt = false;
                    mess = "Có lỗi sảy ra, cập nhật không thành công";
                }
            }
            else
            {
                kt = false;
                mess = "Không tìm thấy bản ghi";
            }
            return kt;
        }
    }
}
