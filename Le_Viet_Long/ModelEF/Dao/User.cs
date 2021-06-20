using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class User
    {
        private LeVietLongContext db =null;
        public User()
        {
            db = new LeVietLongContext();
        }
        // kiểm tra đăng nhập nếu tồn tại tài khoản thì return 1
        public int Login(string user, string pass)
        {
            var result = db.UserAccount.SingleOrDefault(x => x.UserName==user);
            if (result == null)
            { return 0; }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == pass)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2; 
                    }
                }             
            }
        }
        //tạo mới user
        public string Insert(UserAccount entityUser)
        {

            db.UserAccount.Add(entityUser);
            db.SaveChanges();
            return entityUser.UserName;
        }
        public bool checktaikhoan(string UserName)
        {
            IEnumerable <UserAccount> checklist= db.UserAccount.ToList();
            //kiem tra tài khoản ban đầu chưa được tạo
            bool taikhoan = false;
            foreach (var item in checklist)
            {
                if (item.UserName.ToString() == UserName.Trim())
                {
                    //tài khoản đã tồn tại
                    taikhoan = true; break;
                }

            }
            return taikhoan;
        }


        // hiển thị list user
        public IEnumerable<UserAccount> ListAll()
        {
            return db.UserAccount.ToList();
        }
        public IEnumerable<UserAccount> ListWhereAll(string searchString, int page, int pagesize)
        {
            IQueryable<UserAccount> mode = db.UserAccount;
            if (!string.IsNullOrEmpty(searchString))
            {
                mode = mode.Where(x => x.UserName.Contains(searchString));
            }
            return mode.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.UserAccount.Find(id);
                db.UserAccount.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
