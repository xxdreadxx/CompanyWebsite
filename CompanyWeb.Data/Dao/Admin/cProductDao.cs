using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Admin
{
    public class cProductDao
    {
        private readonly CompanyDbContext _context;
        public cProductDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<cProduct> getAll()
        {
            return _context.cProducts.Where(x => x.Status != 10).ToList();
        }

        public cProduct getDetail(int ID)
        {
            return _context.cProducts.FirstOrDefault(x => x.ID == ID);
        }

        public bool Add(cProduct item, ref string mess)
        {
            bool kt = true;
            try
            {
                _context.cProducts.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                kt = false;
                mess = "Có lỗi sảy ra, thêm mới không thành công";
            }
            return kt;
        }

        public bool Update(cProduct res, ref string mess)
        {
            bool kt = true;
            var item = _context.cProducts.FirstOrDefault(x => x.ID == res.ID);
            if (item != null)
            {
                item.Title = res.Title;
                if (res.Image != null)
                {
                    item.Image = res.Image;
                }
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
            var item = _context.cProducts.FirstOrDefault(x => x.ID == ID);
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
