using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Intrfaces
{
    interface IUserRepository
    {
        //to retrieve a list of Users
        public IQueryable<UserViewModel> Get();

        //to retrieve a list of user  by id
        UserViewModel GetById(int id);

        //to add one user
        void Add(UserViewModel usr);

        //to update one user
        void Edit(UserViewModel usr);

        //to Delete one user
        void Delete(int id);
    }
}
