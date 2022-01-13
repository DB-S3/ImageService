using Image_Service;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class IntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly TestingWebAppFactory<Startup> _client;

        public IntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory;
        }

        //[Fact]
        //public async Task CreateWebsite()
        //{
        //    var client = _client.CreateClient(
        //    new WebApplicationFactoryClientOptions
        //    {
        //        AllowAutoRedirect = false
        //    });
        //    // Act
        //    var response = await client.GetAsync("/file/upload/fileTestOwnerId");

        //    // Assert
        //    response.EnsureSuccessStatusCode();
        //    var responseString = await response.Content.ReadAsStringAsync();

        //    Assert.Contains("", responseString);
        //    client.Dispose();
        //}

        //[Fact]
        //public async Task GetImage()
        //{
        //    var client = _client.CreateClient(
        //    new WebApplicationFactoryClientOptions
        //    {
        //        AllowAutoRedirect = false
        //    });
        //    // Act
        //    var response = await client.GetAsync("/file/getimage/99ff9bef-9c6b-41b6-ace2-991a73c10f63");

        //    // Assert
        //    response.EnsureSuccessStatusCode();
        //    var responseString = await response.Content.ReadAsStringAsync();

        //    Assert.Contains("", responseString);
        //    client.Dispose();
        //}
    }
}

