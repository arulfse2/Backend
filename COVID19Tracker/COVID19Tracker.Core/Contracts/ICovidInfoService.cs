using COVID19Tracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COVID19Tracker.Core.Contracts
{
    public interface ICovidInfoService
    {
        Task<CovidInfo> AddInfo(CovidInfo user);
        Task<CovidInfo> UpdateInfo(CovidInfo input, string infoId);
        Task<bool> DeleteInfo(string infoId);
        Task<IEnumerable<CovidInfo>> GetAllInfo();
        Task<CovidInfo> GetInfoById(string infoId);
        Task<IEnumerable<CovidInfo>> GetAllInfoByGeographic(string? countryId, string? stateId, string? cityId);
    }
}
