using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        //[RegularExpression("aaa@aaaaa.com",ErrorMessage = "Write A valid Format")]
        public string Email { get; set; }
        [Required]
        [MaxLength(8),MinLength(5)]
        public string Password { get; set; }
    }
}
