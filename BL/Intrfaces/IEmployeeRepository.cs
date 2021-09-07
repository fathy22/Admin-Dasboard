using MyDemo.DAL.Entities;
using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Intrfaces
{
    public interface IEmployeeRepository
    {
        //to retrieve a list of Employee
        public IEnumerable<EmployeeViewModel> Get();
        //to retrieve a list of Employee  by id
        EmployeeViewModel GetById(int id);

        //to add one employee
        void Add(EmployeeViewModel emp);

        //to update one employee
        void Edit(EmployeeViewModel emp);

        //to Delete one employee
        void Delete(int id);
    }
}
