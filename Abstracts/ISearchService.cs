using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Abstracts
{
   public interface ISearchService
   {
       List<CitiesSm> SearchCity(string CityName);
   }
}
