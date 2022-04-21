using COVID19Tracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COVID19Tracker.Core.Contracts
{
    public interface ICovidInfoService
    {
        Task<CovidInfo> AddInfo(CovidInfo user);
        Task<CovidInfo> UpdateInfo(CovidInfo input, Guid infoId);
        Task<bool> DeleteInfo(Guid infoId);
        Task<IEnumerable<CovidInfo>> GetAllInfo();
        Task<CovidInfo> GetInfoById(Guid infoId);
        Task<IEnumerable<CovidInfo>> GetAllInfoByGeographic(Guid? countryId, Guid? stateId, Guid? cityId);
    }
}
