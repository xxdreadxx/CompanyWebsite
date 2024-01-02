using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Admin
{
    public class dRecuitmentDao
    {
        private readonly CompanyDbContext _context;
        public dRecuitmentDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<dRecuitment> getAll()
        {
            return _context.dRecuitments.Where(x => x.Status != 10).ToList();
        }

        public dRecuitment getDetail(int ID)
        {
            return _context.dRecuitments.FirstOrDefault(x => x.ID == ID);
        }

        public bool Add(dRecuitment item, ref string mess)
        {
            bool kt = true;
            try
            {
                _context.dRecuitments.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                kt = false;
                mess = "Có lỗi sảy ra, thêm mới không thành công";
            }
            return kt;
        }

        public bool Update(dRecuitment res, ref string mess)
        {
            bool kt = true;
            var item = _context.dRecuitments.FirstOrDefault(x => x.ID == res.ID);
            if (item != null)
            {
                item.Title = res.Title;
                item.WorkPosition = res.WorkPosition;
                item.WorkAddress = res.WorkAddress;
                item.Requirement = res.Requirement;
                item.Quantity = res.Quantity;
                item.Treatment = res.Treatment;
                item.Content = res.Content;
                item.FromDate = res.FromDate;
                item.ToDate = res.ToDate;
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
            var item = _context.dRecuitments.FirstOrDefault(x => x.ID == ID);
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
