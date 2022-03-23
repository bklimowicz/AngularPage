namespace CouchDBConnector.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using CosmosDB.Models;
    using CosmosDB.Services;

    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;
        public ItemController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItem()
        {
            return Ok(await _cosmosDbService.GetItemsAsync("SELECT * FROM c"));
        }
    }
}
