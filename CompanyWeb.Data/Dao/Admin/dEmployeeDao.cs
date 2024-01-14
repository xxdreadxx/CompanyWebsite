using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Admin
{
    public class dEmployeeDao
    {
        private readonly CompanyDbContext _context;
        public dEmployeeDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<dEmployee> getAll()
        {
            return _context.dEmployees.Where(x => x.Status != 10).ToList();
        }

        public dEmployee getDetail(int ID)
        {
            return _context.dEmployees.FirstOrDefault(x => x.ID == ID);
        }

        public bool Add(dEmployee item, ref string mess)
        {
            bool kt = true;
            try
            {
                _context.dEmployees.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                kt = false;
                mess = "Có lỗi sảy ra, thêm mới không thành công";
            }
            return kt;
        }

        public bool Update(dEmployee res, ref string mess)
        {
            bool kt = true;
            var item = _context.dEmployees.FirstOrDefault(x => x.ID == res.ID);
            if (item != null)
            {
                item.Name = res.Name;
                if (res.Avatar != "\\")
                {
                    item.Avatar = res.Avatar;
                }
                item.Position = res.Position;
                item.ExperienceYear = res.ExperienceYear;
                item.Content = res.Content;
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
            var item = _context.dEmployees.FirstOrDefault(x => x.ID == ID);
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
