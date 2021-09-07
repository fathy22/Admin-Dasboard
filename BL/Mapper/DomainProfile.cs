using AutoMapper;
using MyDemo.DAL.Entities;
using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            //to map between Entity and ViewModel
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, Department>();

            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();
        }
    }
}
