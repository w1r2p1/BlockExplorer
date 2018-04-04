﻿using Serilog;
using Serilog.Events;
using Stratis.Bitcoin.Builder;

namespace Stratis.IndexerD
{
    public static class FullNodeBuilderExtensions
    {
        public static IFullNodeBuilder UseSerilog(this IFullNodeBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("", "")
                .WriteTo.RollingFile("log-{Date}.txt")
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
            builder.NodeSettings.LoggerFactory.AddSerilog();
            return builder;
        }
    }
}