using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Infrastructure.NotificationService
{
    public class BackgroundScheduler : BackgroundService
    {
        private readonly TimeSpan _period = TimeSpan.FromSeconds(6);
        private readonly ILogger<BackgroundScheduler> _logger;

        IServiceProvider _serviceProvider;

        public BackgroundScheduler(ILogger<BackgroundScheduler> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            CacheDatabase();

            return base.StartAsync(cancellationToken);  
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(_period);



            while (!stoppingToken.IsCancellationRequested &&
                   await timer.WaitForNextTickAsync(stoppingToken))
            {
               await CheckForNotificationAsync(stoppingToken);
            }
        }



        public void CacheDatabase()
        {
            Console.WriteLine("Caching notifys from db");
        }


        private async Task CheckForNotificationAsync(CancellationToken stoppingToken)
        {
            

            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IScopedNotificationService scopedProcessingService =
                    scope.ServiceProvider.GetRequiredService<IScopedNotificationService>();

                await scopedProcessingService.CheckForNotificationAsync(stoppingToken);
            }
        }
    }
}

