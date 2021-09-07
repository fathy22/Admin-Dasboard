using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.DAL.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country country { get; set; }
        public virtual ICollection<District> DistrictsCollection { get; set; }

    }
}
