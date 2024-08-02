
namespace BlazorApp1
{
    public class DiscordTimer : IHostedService, IDisposable
    {
        private ILogger<DiscordTimer> _logger;
        private Timer? _timer;
        private Config _config;


        public DiscordTimer(ILogger<DiscordTimer> logger, Config config) 
        {
            _config = config;
            _logger = logger;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void DoWork(object? state)
        {
            _logger.LogInformation(_config.DiscordKey);
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
       }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
