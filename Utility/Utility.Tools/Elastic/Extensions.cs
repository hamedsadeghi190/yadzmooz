using Elasticsearch.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.Elastic
{
    public static class Extensions
    {
        public static void AddElastic(this IServiceCollection services,IConfiguration config)
        {
            var options = new ElasticSetting();
            var section = config.GetSection("ElasticSetting");
            section.Bind(options);
            services.Configure<ElasticSetting>(section);
            var pool = new SingleNodeConnectionPool(new Uri(options.ConnectionString));
            var settings = new ConnectionSettings(pool)
                .DefaultIndex(options.MainIndex);                
            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);

        }
        
    }
}
