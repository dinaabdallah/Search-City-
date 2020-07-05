using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CitiesVm
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; } 
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }

}
