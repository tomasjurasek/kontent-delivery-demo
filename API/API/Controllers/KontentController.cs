using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kentico.Kontent.Delivery.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontentController : ControllerBase
    {
        private readonly IDeliveryClientFactory deliveryClientFactory;

        public KontentController(IDeliveryClientFactory deliveryClientFactory)
        {
            this.deliveryClientFactory = deliveryClientFactory;
        }

        [HttpGet("one")]
        public async Task<int> GetOne()
        {
            var client = deliveryClientFactory.Get("client1");
            var result = await client.GetItemsAsync();
            return result.Items.Count();
        }

        [HttpGet("two")]
        public async Task<int> GetTwo()
        {
            var client = deliveryClientFactory.Get("client2");
            var result = await client.GetItemsAsync();
            return result.Items.Count();
        }
    }
}