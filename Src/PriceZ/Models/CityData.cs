namespace PriceZ.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The city data class.
    /// </summary>
    public sealed class CityData
    {
        /// <summary>
        /// Gets or sets the city
        /// </summary>
        [JsonProperty("cidade")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state initials
        /// </summary>
        [JsonProperty("estado")]
        public string StateInitials { get; set; }

        /// <summary>
        /// Gets or sets the area code
        /// </summary>
        [JsonProperty("ddd")]
        public int AreaCode { get; set; }
    }
}
