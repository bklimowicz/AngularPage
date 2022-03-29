using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries.CosmosDBConnector.Service;
using System.Configuration;
using System.Reflection;
using Microsoft.Azure.Cosmos;

namespace Libraries.CosmosDBConnector.Factory
{
    public class CosmosDBServiceFactory : ICosmosDBServiceFactory
    {
        public ICosmosDbService Create()
        {
            var appSettingValFromInstance =
                ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

            
            var endpoint = appSettingValFromInstance.AppSettings.Settings["Endpoint"].Value;
            var primaryKey = appSettingValFromInstance.AppSettings.Settings["Primarykey"].Value;

            if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(primaryKey))
            {
                throw new ArgumentException($"{nameof(CosmosDBServiceFactory)}.{nameof(Create)} is missing parameters.");
            }

            var client = new CosmosClient(endpoint, primaryKey);
            return new CosmosDbService(client, "Libraries", "MenuButtons");
        }
    }

    public class CosmosDBServiceOptions : ICosmosDBServiceOptions
    {

    }

    public interface ICosmosDBServiceOptions
    {
    }

    public interface ICosmosDBServiceFactory
    {
        ICosmosDbService Create();
    }
}
