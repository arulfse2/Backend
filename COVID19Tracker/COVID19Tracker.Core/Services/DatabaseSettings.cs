namespace COVID19Tracker.Core.Services
{
    public class DatabaseSettings
    {
        public UserConfig UserConfig { get; set; }
        public CovidConfig CovidConfig { get; set; }
        public GeographicConfig GeographicConfig { get; set; }
    }
    public class UserConfig
    {
        public UserCollectionName CollectionNames { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public class UserCollectionName
    {
        public string UserCollectioName { get; set; }
        public string RoleCollectioName { get; set; }
        public string UserRoleCollectioName { get; set; }
    }
    public class CovidConfig
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public class GeographicConfig
    {
        public GeographicCollectionName CollectionNames { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public class GeographicCollectionName
    {
        public string CountryCollectioName { get; set; }
        public string StateCollectioName { get; set; }
        public string CityCollectioName { get; set; }
    }
}
