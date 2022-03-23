namespace CouchDBConnector.Interfaces
{
    public interface IButtonOptionsRepository
    {        
        Task<HttpClientResponse> GetButtonOptionByIdAsync(string id);
        Task<HttpClientResponse> GetButtonOptionsAsync();
    }
}
