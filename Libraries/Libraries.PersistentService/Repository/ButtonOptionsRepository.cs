using CouchDBConnector.Interfaces;

namespace CouchDBConnector.Repository
{
    public class ButtonOptionsRepository : CouchDbRepository, IButtonOptionsRepository
    {        
        public ButtonOptionsRepository(IConfiguration configuration, IHttpClientFactory clientFactory) : base(configuration, clientFactory)
        {

        }

        public async Task<HttpClientResponse> GetButtonOptionByIdAsync(string id)
        {
            HttpClientResponse response = new HttpClientResponse();
            var dbClient = DbHttpClient();

            //CouchDB URL : GET http://{hostname_or_IP}:{Port}/{couchDbName}/{_id}  
            var dbResult = await dbClient.GetAsync(_couchDbName + "/" + id);

            if (dbResult.IsSuccessStatusCode)
            {
                response.IsSuccess = true;
                response.SuccessContentObject = await dbResult.Content.ReadAsStringAsync();
            }
            else
            {
                response.IsSuccess = false;
                response.FailedReason = dbResult.ReasonPhrase;
            }
            return response;
        }

        public async Task<HttpClientResponse> GetButtonOptionsAsync()
        {
            HttpClientResponse response = new HttpClientResponse();
            var dbClient = DbHttpClient();

            //CouchDB URL : GET http://{hostname_or_IP}:{Port}/{couchDbName}/{_id}  
            var dbResult = await dbClient.GetAsync(_couchDbName + "/_all_docs");

            if (dbResult.IsSuccessStatusCode)
            {
                response.IsSuccess = true;
                response.SuccessContentObject = await dbResult.Content.ReadAsStringAsync();
            }
            else
            {
                response.IsSuccess = false;
                response.FailedReason = dbResult.ReasonPhrase;
            }
            return response;
        }
    }
}
