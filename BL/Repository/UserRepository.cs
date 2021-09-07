using MyDemo.BL.Intrfaces;
using MyDemo.DAL.Entities;
using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DeptDbContext db;
        public UserRepository(DeptDbContext _db)
        {
            db = _db;
        }

        public IQueryable<UserViewModel> Get()
        {
            var data = db.Users.Select(a => new UserViewModel { Id = a.Id, UserName = a.UserName, Email = a.Email, Password = a.Password });
            return data;
        
        }

        public UserViewModel GetById(int id)
        {
           var data=db.Users.Where(a=>a.Id ==id)
                             .Select(a => new UserViewModel { Id = a.Id, UserName = a.UserName, Email = a.Email, Password = a.Password })
                             .FirstOrDefault();
            return data;
        }
        public void Add(UserViewModel usr)
        {
            User u = new User();
            //for mapping
            u.UserName = usr.UserName;
            u.Email = usr.Email;
            u.Password = usr.Password;
            db.Users.Add(u);
            db.SaveChanges();
        }

        public void Edit(UserViewModel usr)
        {
            var OldUser = db.Users.Find(usr.Id);
            OldUser.UserName = usr.UserName;
            OldUser.Email = usr.Email;
            OldUser.Password = usr.Password;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var DeletedUser = db.Users.Find(id);
            db.Users.Remove(DeletedUser);
            db.SaveChanges();
        }

        //to do comment: ctrl + k + c
        //to undo comment: ctrl + k + u
        //public LoginViewModel LoginFunction(string name, string password)
        //{
        //    User u = new User();
        //    var data = db.Users.Where(a => a.UserName == name && a.Password == password)
        //                        .Select(a => new LoginViewModel { UserName = a.UserName, Password = a.Password })
        //                        .FirstOrDefault();
        //    if (data.UserName == u.UserName && data.Password == u.Password)
        //    {
        //        return data;
        //    }
        //    else
        //    {

        //    }

        //}

    }
}
