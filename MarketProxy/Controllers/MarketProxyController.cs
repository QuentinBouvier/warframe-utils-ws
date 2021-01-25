using System.Net;
using System.Threading.Tasks;
using MarketProxy.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MarketProxy.Controllers
{
    [ApiController]
    [Route("Proxy/Market")]
    public class MarketProxyController
    {
        private readonly IProxySnapshotRepository _snapshotRepository;

        public MarketProxyController(IProxySnapshotRepository snapshotRepository)
        {
            this._snapshotRepository = snapshotRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var marketItem = await this._snapshotRepository.FindByName(name);
            if (marketItem == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.NotFound);
            }

            return new OkObjectResult(marketItem);
        }
    }
}