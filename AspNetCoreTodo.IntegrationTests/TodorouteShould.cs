using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreTodo.IntegrationTests
{
    public class TodoRouteShould: IClassFixture< TestFixture>
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fixture"></param>
        public TodoRouteShould( TestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task ChallengeAnonimousUser()
        {
            //arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/Todo");

            //act: request the todo route
            var response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);

            Assert.Equal("http://localhost:8888/Identity/Account" + "/Login?ReturnUrl=%2FTodo", 
                response.Headers.Location.ToString());


        }
    }
}
