using System.Text;

namespace CouchDBConnector.Repository
{
    public class CouchDbRepository
    {
        protected readonly string _couchDbUrl;
        protected readonly string _couchDbName;
        protected readonly string _couchDbUser;
        protected readonly IConfiguration _configuration;
        protected readonly IHttpClientFactory _clientFactory;
        public CouchDbRepository(IConfiguration configuration, IHttpClientFactory clientFactory)
        {

            _configuration = configuration;
            _clientFactory = clientFactory;
            _couchDbUrl = this._configuration["CouchDB:URL"];
            _couchDbName = this._configuration["CouchDB:DbName"];
            _couchDbUser = this._configuration["CouchDB:User"];
        }

        protected HttpClient DbHttpClient()
        {
            var httpClient = this._clientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Clear();

            httpClient.BaseAddress = new Uri(_couchDbUrl);
            var dbUserByteArray = Encoding.ASCII.GetBytes(_couchDbUser);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(dbUserByteArray));
            return httpClient;
        }
    }
}
