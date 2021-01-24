using MarketProxy.Model;
using MarketProxy.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MarketProxy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarketProxyController
    {
        private IConfiguration Configuration { get; }
        private readonly IProxySnapshotRepository _snapshotRepository;
        
        public MarketProxyController(IConfiguration configuration, IProxySnapshotRepository snapshotRepository)
        {
            this.Configuration = configuration;
            this._snapshotRepository = snapshotRepository;
        }
        
        [HttpGet]
        public MarketSnapshot Get()
        {
            return _snapshotRepository.Get()[0];
        }
    }
}