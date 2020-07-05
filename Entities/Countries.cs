using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class Countries
    {
        public Countries()
        {

            Cities = new HashSet<Cities>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string alternateCountry { get; set; }

        public ICollection<Cities> Cities { get; set; }
    }
}
