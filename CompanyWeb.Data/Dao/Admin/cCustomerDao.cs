using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;

namespace CompanyWeb.Data.Dao.Admin
{
    public class cCustomerDao
    {
        private readonly CompanyDbContext _context;
        public cCustomerDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<cCustomer> getAll()
        {
            return _context.cCustomers.Where(x => x.Status != 10).ToList();
        }

        public cCustomer getDetail(int ID)
        {
            return _context.cCustomers.FirstOrDefault(x => x.ID == ID);
        }

        public bool Add(cCustomer item, ref string mess)
        {
            bool kt = true;
            try
            {
                _context.cCustomers.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                kt = false;
                mess = "Có lỗi sảy ra, thêm mới không thành công";
            }
            return kt;
        }

        public bool Update(cCustomer res, ref string mess)
        {
            bool kt = true;
            var item = _context.cCustomers.FirstOrDefault(x => x.ID == res.ID);
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
            var item = _context.cCustomers.FirstOrDefault(x => x.ID == ID);
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
