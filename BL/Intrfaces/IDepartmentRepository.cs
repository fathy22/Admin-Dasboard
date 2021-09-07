using MyDemo.DAL.Entities;
using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Intrfaces
{
    public interface IDepartmentRepository
    {
        //to retrieve a list of departrment
        public IQueryable<DepartmentViewModel> Get();

        //to retrieve a list of departrment  by id
        DepartmentViewModel GetById(int id);

        //to add one departrment
        void Add(DepartmentViewModel dpt);

        //to update one departrment
        void Edit(DepartmentViewModel dpt);

        //to Delete one departrment
        void Delete(int id);
    }
}
