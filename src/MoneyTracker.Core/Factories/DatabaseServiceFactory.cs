using MoneyTracker.Core.Services;

namespace MoneyTracker.Core.Factories
{
    public static class DatabaseServiceFactory
    {
        public static DatabaseService GetNewDatabaseService()
        {
            const string connectionstringName = "MoneyTrackerDatabase";
            //todo: where should this come from?
            //var nameOrConnStr = @"Data Source=.\;Initial Catalog=personal;Integrated Security=True;MultipleActiveResultSets=True";
            //System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString
            return new DatabaseService(connectionstringName);
        }
    }
}
