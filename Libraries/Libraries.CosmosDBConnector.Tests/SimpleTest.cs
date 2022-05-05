using System.Collections.Generic;
using System.Linq;
using Xunit;
using Libraries.CosmosDBConnector.Factory;
using Libraries.CosmosDBConnector.Model;
using Libraries.CosmosDBConnector.Service;
using FluentAssertions;

namespace Libraries.CosmosDBConnector.Tests
{
    public class SimpleTest
    {
        [Fact]
        public void GetAllKeys()
        {
            ICosmosDBServiceFactory cosmosFactory = new CosmosDBServiceFactory();
            ICosmosDbService service = cosmosFactory.Create();

            List<MenuButton> result = service.GetItemsAsync().Result.ToList();

            

            result.Count.Should().BeGreaterThan(0);

            //result.
        }

        //[Fact]
        //public void GetAllKeys_fail()
        //{
        //    ICosmosDBServiceFactory cosmosFactory = new CosmosDBServiceFactory();
        //    ICosmosDbService service = cosmosFactory.Create();

        //    List<MenuButton> result = service.GetItemsAsync().Result.ToList();

        //    result.Count.Should().Be(0);
        //}
    }
}