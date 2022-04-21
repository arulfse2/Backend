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
        Task<Country> UpdateCountry(Country country, Guid countryId);
        Task<bool> DeleteCountry(Guid countryId);
        Task<IEnumerable<Country>> GetAllCountry();
        Task<Country> GetCountryById(Guid countryId);
        #endregion country

        #region state
        Task<State> AddState(State state);
        Task<State> UpdateState(State state, Guid stateId);
        Task<bool> DeleteState(Guid stateId);
        Task<IEnumerable<State>> GetAllState();
        Task<State> GetStateById(Guid stateId);
        #endregion state

        #region city
        Task<City> AddCity(City city);
        Task<City> UpdateCity(City city, Guid cityId);
        Task<bool> DeleteCity(Guid cityId);
        Task<IEnumerable<City>> GetAllCity();
        Task<City> GetCityById(Guid cityId);
        #endregion city
    }
}
