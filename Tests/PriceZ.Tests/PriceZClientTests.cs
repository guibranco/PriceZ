namespace PriceZ.Tests
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class PriceZClientTests
    {
        private readonly PriceZClient _priceZ;

        public PriceZClientTests()
        {
            var client = new HttpClient { BaseAddress = new Uri("https://ddd.pricez.com.br/") };
            client.DefaultRequestHeaders.ExpectContinue = false;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(@"application/json"));
            _priceZ = new PriceZClient(client);
        }

        [Fact]
        public async Task ValidateGetAreCodes()
        {
            var areaCodes = await _priceZ.GetAreaCodesAsync(CancellationToken.None);
            var areaCodesList = areaCodes.ToList();
            Assert.Contains(11, areaCodesList);
            Assert.Contains(21, areaCodesList);
        }

        [Fact]
        public async Task ValidateGetCitiesByAreaCode()
        {
            var cities = await _priceZ.GetCitiesAsync(11, CancellationToken.None);
            var citiesList = cities.ToList();
            Assert.Contains(citiesList, city => city.AreaCode.Equals(11));
            Assert.Contains(citiesList, city => city.City.Equals("São Paulo"));
            Assert.Contains(citiesList, city => city.StateInitials.Equals("SP"));
        }

        [Fact]
        public async Task ValidateGetStates()
        {
            var states = await _priceZ.GetStatesAsync(CancellationToken.None);
            var statesList = states.ToList();
            Assert.Contains("SP", statesList);
            Assert.Contains("RJ", statesList);
        }

        [Fact]
        public async Task ValidateGetCitiesByState()
        {
            var cities = await _priceZ.GetCitiesAsync("SP", CancellationToken.None);
            var citiesList = cities.ToList();
            Assert.Contains(citiesList, city => city.AreaCode.Equals(11));
            Assert.Contains(citiesList, city => city.City.Equals("São Paulo"));
            Assert.Contains(citiesList, city => city.StateInitials.Equals("SP"));
        }

        [Fact]
        public async Task GetZipCode()
        {
            var zipCode = await _priceZ.GetZipCodeAsync("01001000", CancellationToken.None);
            Assert.Equal("Sé", zipCode.Neighborhood);
            Assert.Equal("01001000", zipCode.ZipCode);
            Assert.Equal("São Paulo", zipCode.City);
            Assert.Equal("SP", zipCode.StateInitials);
            Assert.Equal("Praça da Sé", zipCode.Address);
            Assert.Equal(11, zipCode.AreaCode);
            Assert.Equal(152111, zipCode.CityInfo.Area);
            Assert.Equal("1521.11", zipCode.CityInfo.AreaInternal);
            Assert.Equal(3550308, zipCode.CityInfo.IBGECode);
            Assert.Null(zipCode.CityInfo.Name);
        }
    }
}
