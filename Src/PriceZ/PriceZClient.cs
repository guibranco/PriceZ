namespace PriceZ
{
    using Models;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    public class PriceZClient : IPriceZClient
    {
        /// <summary>
        /// The HTTP client
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceZClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public PriceZClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region Implementation of IPriceZClient

        /// <summary>
        /// Gets the area codes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<int>> GetAreaCodesAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync("ddds", cancellationToken);
            var result = await response.Content.ReadAsAsync<Response<int[]>>(cancellationToken);
            return result.Payload;
        }

        /// <summary>
        /// Gets the cities asynchronous.
        /// </summary>
        /// <param name="areaCode">The area code.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<CityData>> GetCitiesAsync(int areaCode, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"ddds/{areaCode}", cancellationToken);
            var result = await response.Content.ReadAsAsync<Response<CityData[]>>(cancellationToken);
            return result.Payload;
        }

        /// <summary>
        /// Gets the states.
        /// </summary> 
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetStatesAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync("estados", cancellationToken);
            var result = await response.Content.ReadAsAsync<Response<string[]>>(cancellationToken);
            return result.Payload;
        }

        /// <summary>
        /// Gets the cities asynchronous.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<CityData>> GetCitiesAsync(string state, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"estados/{state}", cancellationToken);
            var result = await response.Content.ReadAsAsync<Response<CityData[]>>(cancellationToken);
            return result.Payload;
        }

        /// <summary>
        /// Gets the zip code asynchronous.
        /// </summary>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<ZipCodeData> GetZipCodeAsync(string zipCode, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"cep/{zipCode}", cancellationToken);
            var result = await response.Content.ReadAsAsync<Response<ZipCodeData>>(cancellationToken);
            return result.Payload;
        }

        #endregion
    }
}
