using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Admin
{
    public class dFeedbackDao
    {
        private readonly CompanyDbContext _context;
        public dFeedbackDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<dFeedback> getAll()
        {
            return _context.dFeedbacks.Where(x => x.Status != 10).ToList();
        }

        public dFeedback getDetail(int ID)
        {
            return _context.dFeedbacks.FirstOrDefault(x => x.ID == ID);
        }

        public bool Add(dFeedback item, ref string mess)
        {
            bool kt = true;
            try
            {
                _context.dFeedbacks.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                kt = false;
                mess = "Có lỗi sảy ra, thêm mới không thành công";
            }
            return kt;
        }

        public bool Update(dFeedback res, ref string mess)
        {
            bool kt = true;
            var item = _context.dFeedbacks.FirstOrDefault(x => x.ID == res.ID);
            if (item != null)
            {
                item.Name = res.Name;
                item.IDProduct = res.IDProduct;
                item.Star = res.Star;
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
            var item = _context.dFeedbacks.FirstOrDefault(x => x.ID == ID);
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
