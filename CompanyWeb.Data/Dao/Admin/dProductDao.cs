using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Admin
{
    public class dProductDao
    {
        private readonly CompanyDbContext _context;
        public dProductDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<dProduct> getAll()
        {
            return _context.dProducts.Where(x => x.Status != 10).ToList();
        }

        public dProduct getDetail(int ID)
        {
            return _context.dProducts.FirstOrDefault(x => x.ID == ID);
        }

        public bool Add(dProduct item, ref string mess)
        {
            bool kt = true;
            try
            {
                _context.dProducts.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                kt = false;
                mess = "Có lỗi sảy ra, thêm mới không thành công";
            }
            return kt;
        }

        public bool Update(dProduct res, ref string mess)
        {
            bool kt = true;
            var item = _context.dProducts.FirstOrDefault(x => x.ID == res.ID);
            if (item != null)
            {
                item.ID_CProduct = res.ID_CProduct;
                item.MetaTitle = res.MetaTitle;
                item.Title = res.Title;
                item.Content = res.Content;
                item.Description = res.Description;
                if (res.Image != null)
                {
                    item.Image = res.Image;
                }
                if (res.Thumbnail != null)
                {
                    item.Thumbnail = res.Thumbnail;
                }
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
            var item = _context.dProducts.FirstOrDefault(x => x.ID == ID);
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
