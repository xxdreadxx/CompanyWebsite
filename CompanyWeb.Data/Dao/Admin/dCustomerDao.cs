using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Admin
{
    public class dCustomerDao
    {
        private readonly CompanyDbContext _context;
        public dCustomerDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<dCustomer> getAll()
        {
            return _context.dCustomers.Where(x => x.Status != 10).ToList();
        }

        public dCustomer getDetail(int ID)
        {
            return _context.dCustomers.FirstOrDefault(x => x.ID == ID);
        }

        public bool Add(dCustomer item, ref string mess)
        {
            bool kt = true;
            try
            {
                _context.dCustomers.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                kt = false;
                mess = "Có lỗi sảy ra, thêm mới không thành công";
            }
            return kt;
        }

        public bool Update(dCustomer res, ref string mess)
        {
            bool kt = true;
            var item = _context.dCustomers.FirstOrDefault(x => x.ID == res.ID);
            if (item != null)
            {
                item.Title = res.Title;
                item.MetaTitle = res.MetaTitle;
                item.Content = res.Content;
                item.Status = res.Status;
                if (res.Avatar != "\\")
                {
                    item.Avatar = res.Avatar;
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
            var item = _context.dCustomers.FirstOrDefault(x => x.ID == ID);
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
