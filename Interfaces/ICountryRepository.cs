using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AnimeReviewAPI.Models;

namespace AnimeReviewAPI.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByStudio(int studioId);
        bool CountryExists(int id);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
        bool Save();
    }
}
