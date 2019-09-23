namespace PriceZ
{
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// The PriceZ client interface
    /// </summary>
    internal interface IPriceZClient
    {
        /// <summary>
        /// Gets the dd ds.
        /// </summary>
        /// <returns></returns>
        IEnumerable<int> GetDDDs();

        /// <summary>
        /// Gets the cities.
        /// </summary>
        /// <param name="ddd">The DDD.</param>
        /// <returns></returns>
        IEnumerable<CityData> GetCities(int ddd);

        /// <summary>
        /// Gets the states.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetStates();

        /// <summary>
        /// Gets the cities.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        IEnumerable<CityData> GetCities(string state);

        /// <summary>
        /// Gets the zipcode.
        /// </summary>
        /// <param name="zipCode">The zip code.</param>
        /// <returns></returns>
        ZipCodeData GetZipcode(string zipCode);
    }
}
