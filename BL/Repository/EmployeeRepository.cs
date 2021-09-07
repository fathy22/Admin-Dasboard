using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyDemo.BL.Helper;
using MyDemo.BL.Intrfaces;
using MyDemo.DAL.Entities;
using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DeptDbContext db;
        private readonly IMapper mapper;

        public EmployeeRepository(DeptDbContext _db,IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        public IEnumerable<EmployeeViewModel> Get()
        {
            IEnumerable<EmployeeViewModel> data = GetAllEmployee();
            return data;
        }

        public EmployeeViewModel GetById(int id)
        {
            EmployeeViewModel data = GetEmployeeById(id);
            return data;
        }
        public void Add(EmployeeViewModel emp)
        {
            var data =mapper.Map<Employee>(emp);
           data.PhotoName= UploadFile.SaveFile(emp.PhotoUrl, "Photos");
           data.CvName= UploadFile.SaveFile(emp.CvUrl, "Docs");
            db.Employees.Add(data);
            db.SaveChanges();
        }
        public void Edit(EmployeeViewModel emp)
        {
            var data = mapper.Map<Employee>(emp);
            data.PhotoName = UploadFile.SaveFile(emp.PhotoUrl, "Photos");
            data.CvName = UploadFile.SaveFile(emp.CvUrl, "Docs");
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var DeletedEmployee = db.Employees.Find(id);
            UploadFile.RemoveFile("Photos/", DeletedEmployee.PhotoName);
            UploadFile.RemoveFile("Docs/", DeletedEmployee.CvName);
            db.Employees.Remove(DeletedEmployee);
            db.SaveChanges();
        }

       
        //Refactor
        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            return db.Employees
                     .Select(a => new EmployeeViewModel { Id = a.Id, Name = a.Name, Salary = a.Salary, Address = a.Address, HireDate = a.HireDate, IsActive = a.IsActive, Email = a.Email, Notes = a.Notes,DepartmentId=a.DepartmentId,DepartmentName=a.Department.DepartmentName, DistrictId = a.DistrictId,DistrictName=a.District.DistrictName,PhotoName=a.PhotoName,CvName=a.CvName});
        }

        public EmployeeViewModel GetEmployeeById(int id)
        {
            
            return db.Employees.Where(a => a.Id == id)
                                    .Select(a =>new EmployeeViewModel { Id = a.Id, Name = a.Name, Salary = a.Salary, Address = a.Address, HireDate = a.HireDate, IsActive = a.IsActive, Email = a.Email, Notes = a.Notes, DepartmentId=a.DepartmentId,DepartmentName=a.Department.DepartmentName, DistrictId = a.DistrictId, DistrictName = a.District.DistrictName,PhotoName=a.PhotoName,CvName=a.CvName})
                                    .FirstOrDefault();
        }

        
    }

}
