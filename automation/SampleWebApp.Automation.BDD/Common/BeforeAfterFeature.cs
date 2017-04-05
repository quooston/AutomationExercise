using System.Collections.Generic;
using TechTalk.SpecFlow;
using SampleWebApp.Automation.Helpers.Configuration;
using SampleWebApp.Automation.Helpers.Utility;

namespace SampleWebApp.Automation.BDD.Common
{
    [Binding]
    public class BeforeAfterFeature
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {
            // Remove all registered users from the database
            using (var sqlServerDb = new SqlServerUtility(ConfigurationHelpers.ConnectionString))
            {
                var sqlServerCmd = "DELETE FROM [dbo].[AspNetUsers];";
                var sqlServerParas = new List<SqlQueryParameter>();
                sqlServerDb.Delete(sqlServerCmd, sqlServerParas);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            // Remove all registered users from the database
            using (var sqlServerDb = new SqlServerUtility(ConfigurationHelpers.ConnectionString))
            {
                var sqlServerCmd = "DELETE FROM [dbo].[AspNetUsers];";
                var sqlServerParas = new List<SqlQueryParameter>();
                sqlServerDb.Delete(sqlServerCmd, sqlServerParas);
            }
        }
    }
}