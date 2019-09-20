namespace PriceZ.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The zip code data class.
    /// </summary>
    public sealed class ZipCodeData
    {
        /// <summary>
        /// Gets or sets the neighborhood
        /// </summary>
        [JsonProperty("bairro")]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets the zip code
        /// </summary>
        [JsonProperty("cep")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        [JsonProperty("cidade")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the city info
        /// </summary>
        [JsonProperty("cidade_info")]
        public ExtendedInfo CityInfo { get; set; }

        /// <summary>
        /// Gets or sets the area code
        /// </summary>
        [JsonProperty("ddd")]
        public int AreaCode { get; set; }

        /// <summary>
        /// Gets or sets the state initials
        /// </summary>
        [JsonProperty("estado")]
        public string StateInitials { get; set; }

        /// <summary>
        /// Gets or sets the state info
        /// </summary>
        [JsonProperty("estado_info")]
        public ExtendedInfo StateInfo { get; set; }

        /// <summary>
        /// Gets or sets the address
        /// </summary>
        [JsonProperty("logradouro")]
        public string Address { get; set; }
    }
}
