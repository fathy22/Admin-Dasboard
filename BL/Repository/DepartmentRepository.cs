using AutoMapper;
using MyDemo.BL.Intrfaces;
using MyDemo.DAL.Entities;
using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DeptDbContext db;
        private readonly IMapper mapper;

        public DepartmentRepository(DeptDbContext _db,IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public IQueryable<DepartmentViewModel> Get()
        {
            var data = db.Departments.Select(a => new DepartmentViewModel { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
            return data;
        }

        public DepartmentViewModel GetById(int id)
        {
            var data = db.Departments.Where(a => a.Id == id)
                                     .Select(a => new DepartmentViewModel { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode })
                                     .SingleOrDefault();
            return data;
        }
       
        public void Add(DepartmentViewModel dpt)
        {
            //Department d = new Department();
            //for mapping
            var data = mapper.Map<Department>(dpt);
            //d.DepartmentName = dpt.DepartmentName;
            //d.DepartmentCode = dpt.DepartmentCode;
            db.Departments.Add(data);
            db.SaveChanges();
        }

        public void Edit(DepartmentViewModel dpt)
        {
            //var OldDepatrtment = db.Departments.Find(dpt.Id);
            //OldDepatrtment.DepartmentName = dpt.DepartmentName;
            //OldDepatrtment.DepartmentCode = dpt.DepartmentCode;
            // to mapping through AutoMapper Tool
            var data = mapper.Map<Department>(dpt);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var DeletedDepatrtment = db.Departments.Find(id);
            db.Departments.Remove(DeletedDepatrtment);
            db.SaveChanges();
        }
    }
}
