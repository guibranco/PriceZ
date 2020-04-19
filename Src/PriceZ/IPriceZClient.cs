namespace PriceZ
{
    using Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The PriceZ client interface
    /// </summary>
    public interface IPriceZClient
    {
        /// <summary>
        /// Gets the area codes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<int>> GetAreaCodesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the cities asynchronous.
        /// </summary>
        /// <param name="areaCode">The area code.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<CityData>> GetCitiesAsync(int areaCode, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the states asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetStatesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the cities asynchronous.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<CityData>> GetCitiesAsync(string state, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the zip code asynchronous.
        /// </summary>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<ZipCodeData> GetZipCodeAsync(string zipCode, CancellationToken cancellationToken);
    }
}
