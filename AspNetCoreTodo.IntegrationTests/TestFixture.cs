using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace AspNetCoreTodo.IntegrationTests
{
    public class TestFixture: IDisposable
    {
        private readonly TestServer _Server;
        public HttpClient Client { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TestFixture()
        {
            var builder = new WebHostBuilder().UseStartup< AspNetCoreTodo.Startup>().
                ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\AspNetCoreTodo"));
                config.AddJsonFile("appsettings.json");
            });

            _Server = new TestServer(builder);
            Client = _Server.CreateClient();
            //Client.BaseAddress = new Uri("http://localhost:8888");
            Client.BaseAddress = new Uri("http://localhost:8888/Identity/Account");

        }

        public void Dispose()
        {
            Client.Dispose();
            _Server.Dispose();
        }

    }
}
