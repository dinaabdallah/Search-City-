using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(200)]
        public string CityName { get; set; }

        [StringLength(5000)]
        public string CityCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
       
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Countries Country { get; set; }
    }
}
