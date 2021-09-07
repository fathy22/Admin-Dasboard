using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public string DepartmentCode { get; set; }
    }
}
