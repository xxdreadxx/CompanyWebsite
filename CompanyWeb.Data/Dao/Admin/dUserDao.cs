using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Admin
{
    public class dUserDao
    {
        private CompanyDbContext _context;
        //private CompanyDbContext _context = new CompanyDbContext();
        public dUserDao(CompanyDbContext context)
        {
            _context = context;
        }

        public byte Login(string username, string password, ref string returnText, ref int IDUser)
        {
            byte res = 0;
            IDUser = 0;
            var user = _context.dUsers.FirstOrDefault(x => x.Username == username && x.Status != 10);
            if (user == null)
            {
                res = 0;
                returnText = "Tài khỏa không tồn tại trong hệ thống, vui lòng thử lại!";
            }
            else
            {
                if (user.Password != password)
                {
                    res = 0;
                    returnText = "Tài khỏa không tồn tại trong hệ thống, vui lòng thử lại!";
                }
                else
                {
                    if (user.Status != 1)
                    {
                        res = 0;
                        returnText = "Có lỗi xảy ra, đăng nhập không thành công, vui lòng thử lại sau!";
                    }
                    else
                    {
                        res = 1;
                        IDUser = user.ID;
                        returnText = "Đăng nhập thành công! Xin chào " + user.Name;
                    }
                }
            }
            return res;
        }

        public List<dUser> getAllUser()
        {
            return _context.dUsers.Where(x => x.Status != 10).ToList();
        }

        public dUser getUserDetail(int ID)
        {
            return _context.dUsers.FirstOrDefault(x => x.ID == ID);
        }

        public bool Add(dUser user, ref string mess)
        {
            bool kt = true;
            try
            {
                _context.dUsers.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                kt = false;
                mess = "Có lỗi sảy ra, thêm mới không thành công";
            }
            return kt;
        }

        public bool Update(dUser user, ref string mess)
        {
            bool kt = true;
            var item = _context.dUsers.FirstOrDefault(x => x.ID == user.ID);
            if (item != null)
            {
                if (user.Avatar != null)
                {
                    item.Avatar = user.Avatar;
                }
                item.Name = user.Name;
                item.Password = user.Password;
                item.Status = user.Status;
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
            var item = _context.dUsers.FirstOrDefault(x => x.ID == ID);
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
