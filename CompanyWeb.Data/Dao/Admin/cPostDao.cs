using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Admin
{
    public class cPostDao
    {
        private readonly CompanyDbContext _context;
        public cPostDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<cPost> getAll()
        {
            return _context.cPosts.Where(x => x.Status != 10).ToList();
        }

        public cPost getDetail(int ID)
        {
            return _context.cPosts.FirstOrDefault(x => x.ID == ID);
        }

        public bool Add(cPost item, ref string mess)
        {
            bool kt = true;
            try
            {
                _context.cPosts.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                kt = false;
                mess = "Có lỗi sảy ra, thêm mới không thành công";
            }
            return kt;
        }

        public bool Update(cPost res, ref string mess)
        {
            bool kt = true;
            var item = _context.cPosts.FirstOrDefault(x => x.ID == res.ID);
            if (item != null)
            {
                item.Title = res.Title;
                item.MetaTitle = res.MetaTitle;
                try
                {
                    _context.SaveChanges();
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

        public bool ChangeStatus(int ID, byte status, ref string mess)
        {
            bool kt = true;
            var item = _context.cPosts.FirstOrDefault(x => x.ID == ID);
            if (item != null)
            {
                item.Status = status;
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    kt = false;
                    mess = "Có lỗi sảy ra, Đổi trạng thái không thành công";
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
