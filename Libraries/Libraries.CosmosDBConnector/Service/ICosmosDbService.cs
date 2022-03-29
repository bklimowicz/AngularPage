using Libraries.CosmosDBConnector.Model;

namespace Libraries.CosmosDBConnector.Service
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<MenuButton>> GetItemsAsync();
    }
}
