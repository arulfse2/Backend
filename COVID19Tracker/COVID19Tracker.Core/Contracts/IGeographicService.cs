using COVID19Tracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COVID19Tracker.Core.Contracts
{
    public interface IGeographicService
    {
        #region country
        Task<Country> AddCountry(Country country);
        Task<Country> UpdateCountry(Country country, string countryId);
        Task<bool> DeleteCountry(string countryId);
        Task<IEnumerable<Country>> GetAllCountry();
        Task<Country> GetCountryById(string countryId);
        #endregion country

        #region state
        Task<State> AddState(State state);
        Task<State> UpdateState(State state, string stateId);
        Task<bool> DeleteState(string stateId);
        Task<IEnumerable<State>> GetAllState();
        Task<State> GetStateById(string stateId);
        #endregion state

        #region city
        Task<City> AddCity(City city);
        Task<City> UpdateCity(City city, string cityId);
        Task<bool> DeleteCity(string cityId);
        Task<IEnumerable<City>> GetAllCity();
        Task<City> GetCityById(string cityId);
        #endregion city
    }
}
