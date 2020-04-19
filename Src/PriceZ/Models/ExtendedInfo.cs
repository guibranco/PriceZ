namespace PriceZ.Models
{
    using Newtonsoft.Json;
    using System.Globalization;

    /// <summary>
    /// The extended info class.
    /// </summary>
    public sealed class ExtendedInfo
    {
        /// <summary>
        /// Gets or sets the area internally as string
        /// </summary>
        [JsonProperty("area_km2")]
        public string AreaInternal
        {
            get => Area.ToString(CultureInfo.InvariantCulture);
            set
            {
                if (decimal.TryParse(value,
                                     NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands,
                                     new CultureInfo("pt-BR"),
                                     out var v))
                    Area = v;
            }
        }

        /// <summary>
        /// Gets or sets the area
        /// </summary>
        [JsonIgnore]
        public decimal Area { get; set; }

        /// <summary>
        /// Gets or sets the IBGE code
        /// </summary>
        [JsonProperty("codigo_ibge")]
        public int IBGECode { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [JsonProperty("nome")]
        public string Name { get; set; }
    }
}
