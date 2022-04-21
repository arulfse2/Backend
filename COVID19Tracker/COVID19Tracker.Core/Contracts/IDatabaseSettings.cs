namespace COVID19Tracker.Core.Contracts
{
    public interface IDatabaseSettings
    {
        public UserCon UserConfig { get; set; }
        public CovidCon CovidConfig { get; set; }
        public GeographicCon GeographicConfig { get; set; }
    }
    public interface UserCon
    {
        public UserCollectionName CollectionNames { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface UserCollectionName
    {
        public string UserCollectioName { get; set; }
        public string RoleCollectioName { get; set; }
        public string UserRoleCollectioName { get; set; }
    }
    public interface CovidCon
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface GeographicCon
    {
        public GeographicCollectionName CollectionNames { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface GeographicCollectionName
    {
        public string CountryCollectioName { get; set; }
        public string StateCollectioName { get; set; }
        public string CityCollectioName { get; set; }
    }
}
