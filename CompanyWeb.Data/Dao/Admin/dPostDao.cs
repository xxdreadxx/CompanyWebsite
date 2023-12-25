using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Admin
{
    public class dPostDao
    {
        private readonly CompanyDbContext _context;
        public dPostDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<dPost> getAll()
        {
            return _context.dPosts.Where(x => x.Status != 10).ToList();
        }

        public dPost getDetail(int ID)
        {
            return _context.dPosts.FirstOrDefault(x => x.ID == ID);
        }

        public bool Add(dPost item, ref string mess)
        {
            bool kt = true;
            try
            {
                _context.dPosts.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                kt = false;
                mess = "Có lỗi sảy ra, thêm mới không thành công";
            }
            return kt;
        }

        public bool Update(dPost res, ref string mess)
        {
            bool kt = true;
            var item = _context.dPosts.FirstOrDefault(x => x.ID == res.ID);
            if (item != null)
            {
                item.Title = res.Title;
                item.ID_CPost = res.ID_CPost;
                if (res.Image != null)
                {
                    item.Image = res.Image;
                }
                if (res.Thumbnail != null)
                {
                    item.Thumbnail = res.Thumbnail;
                }
                item.MetaTitle = res.MetaTitle;
                item.Description = res.Description;
                item.Content = res.Content;
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
            var item = _context.dPosts.FirstOrDefault(x => x.ID == ID);
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
