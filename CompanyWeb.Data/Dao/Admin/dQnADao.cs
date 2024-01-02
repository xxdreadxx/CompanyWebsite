using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Admin
{
    public class dQnADao
    {
        private readonly CompanyDbContext _context;
        public dQnADao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<dQnA> getAll()
        {
            return _context.dQnAs.Where(x => x.Status != 10).ToList();
        }

        public dQnA getDetail(int ID)
        {
            return _context.dQnAs.FirstOrDefault(x => x.ID == ID);
        }

        public bool Add(dQnA item, ref string mess)
        {
            bool kt = true;
            try
            {
                _context.dQnAs.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                kt = false;
                mess = "Có lỗi sảy ra, thêm mới không thành công";
            }
            return kt;
        }

        public bool Update(dQnA res, ref string mess)
        {
            bool kt = true;
            var item = _context.dQnAs.FirstOrDefault(x => x.ID == res.ID);
            if (item != null)
            {
                item.Question = res.Question;
                item.Answer = res.Answer;
                item.Status = res.Status;
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
            var item = _context.dQnAs.FirstOrDefault(x => x.ID == ID);
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
