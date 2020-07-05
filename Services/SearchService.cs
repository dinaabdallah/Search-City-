using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracts;
using Entities;
using Model;

namespace Services
{
    public class SearchService : ISearchService
    {
        DBCities DB = new DBCities();
        public List<CitiesSm> SearchCity(string CityName)
        {
            var listOfCities = FindAll();

            var resultList = new List<CitiesSm>();
            foreach (var item in listOfCities)
            {
                var Resultobject = new CitiesSm();
                int cost = Compute(item.CityName, CityName);
                Resultobject.Name = item.CityName +","+ item.CityCode +","+ item.CountryName;   
                Resultobject.Longitude = item.Longitude;
                Resultobject.Latitude = item.Latitude;
                Resultobject.Score = cost;
                    
                resultList.Add(Resultobject);
            }

            return resultList.OrderBy(a=>a.Score).Take(4).ToList();

        }


        public List<CitiesVm> FindAll()
        {
            return (from Cities in DB.Cities
                join Countries in DB.Countries on Cities.CountryId equals Countries.Id
                select new CitiesVm
                { 
                    Id = Cities.Id,
                    CityName = Cities.CityName,
                    CityCode = Cities.CityCode,
                    Latitude = Cities.Latitude,
                    Longitude = Cities.Longitude,
                    CountryName = Countries.CountryName,
                    CountryCode = Countries.CountryCode

                }).ToList();
        }

        //implement Levenshtein Distance Algorithm
        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;

            int[,] d = new int[n + 1, m + 1];
            // Step 1
            if (n == 0)
            {
                return m;
            }
            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }
            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }
}
