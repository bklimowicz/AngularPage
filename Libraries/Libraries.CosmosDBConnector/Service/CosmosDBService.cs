using Libraries.CosmosDBConnector.Model;
using Microsoft.Azure.Cosmos;

namespace Libraries.CosmosDBConnector.Service
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<MenuButton>> GetItemsAsync()
        {
            var sqlQueryText = "SELECT * FROM c";

            Console.WriteLine("Running query: {0}\n", sqlQueryText);

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            using FeedIterator<MenuButton> queryResultSetIterator = this._container.GetItemQueryIterator<MenuButton>(queryDefinition);

            List<MenuButton> result = new List<MenuButton>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<MenuButton> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (MenuButton button in currentResultSet)
                {
                    result.Add(button);
                }
            }

            return result;
        }
    }
}
