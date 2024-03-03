using Newtonsoft.Json;
using ServerFinder.Context;
using ServerFinder.Entities;
using ServerFinder.Models;

namespace ServerFinder;

public class ExchangeRateService : BackgroundService
{
    const string API_KEY = "cdb39b192db4dc6f7ce93d0b1fe0cf80";
    private async Task ExecuteTaskAsync()
    {
        using HttpClient client = new();

        var req = await client.GetAsync($"http://api.exchangeratesapi.io/v1/latest?access_key={API_KEY}&format=1&base=EUR");

        var body = await req.Content.ReadAsStringAsync();

        ExchangeRate rates = JsonConvert.DeserializeObject<ExchangeRate>(body)!;
        
        using MainDbContext context = new MainDbContext();

        foreach (var (key, value) in rates.Rates)
        {
            var existing = await context.TblRates.FindAsync(key);

            if (existing != null)
            {
                existing.Rate = value;
            }
            else
            {
                context.TblRates.Add(new TblRates()
                {
                    Currency = key,
                    Rate = value
                });
            }
            
            Console.WriteLine($"{key} {value}");
        }

        await context.SaveChangesAsync();
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromHours(24));
        
        // Run on startup.
        //await ExecuteTaskAsync();
        
        while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            await ExecuteTaskAsync();
        }
    }
}