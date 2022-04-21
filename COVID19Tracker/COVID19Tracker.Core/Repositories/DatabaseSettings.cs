using COVID19Tracker.Core.Contracts;

namespace COVID19Tracker.Core.Repositories
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public UserCon UserConfig { get; set; }
        public CovidCon CovidConfig { get; set; }
        public GeographicCon GeographicConfig { get; set; }
    }
}
