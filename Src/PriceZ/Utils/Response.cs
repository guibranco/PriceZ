namespace PriceZ.Utils
{
    /// <summary>
    /// The response class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        /// <value>
        /// The payload.
        /// </value>
        public T Payload { get; set; }
    }
}
