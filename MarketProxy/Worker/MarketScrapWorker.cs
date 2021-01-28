using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MarketProxy.Worker
{
    public class MarketScrapWorker : IHostedService, IDisposable
    {
        private ILogger<MarketScrapWorker> Logger { get; }

        private Timer _timer;

        public MarketScrapWorker(ILogger<MarketScrapWorker> logger)
        {
            Logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.Logger.LogDebug("Starting Market Scrap Worker");
            _timer = new Timer(QueryMarket, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(350));
            
            return Task.CompletedTask;
        }

        private void QueryMarket(object state)
        {
            Logger.LogDebug("Querying the market");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogDebug("Stopping Market Scrap Worker");
            _timer.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}