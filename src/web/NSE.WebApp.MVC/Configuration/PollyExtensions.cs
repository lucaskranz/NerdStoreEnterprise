﻿using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace NSE.WebApp.MVC.Configuration
{
    public class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
        {
            var retryWaitPolicy = HttpPolicyExtensions
               .HandleTransientHttpError()
               .WaitAndRetryAsync(new[]
               {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10)
               }, (outcome, timespan, retryCount, context) =>
               {
                   Console.ForegroundColor = ConsoleColor.Blue;
                   Console.WriteLine($"Tentando pela {retryCount} vez!");
                   Console.ForegroundColor = ConsoleColor.White;
               });

            return retryWaitPolicy;
        }
    }
}
