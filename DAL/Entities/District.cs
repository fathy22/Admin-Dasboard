using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.DAL.Entities
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string DistrictName { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City city { get; set; }
        public virtual ICollection<Employee> EmployeesCollection { get; set; }


    }
}
