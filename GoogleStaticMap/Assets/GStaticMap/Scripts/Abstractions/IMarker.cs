
///
namespace GSMap
{
    /// <summary>
    /// Map marker abstraction
    /// </summary>
    public interface IMarker
    {
        /// <summary>
        /// Geographic latitude
        /// </summary>
        float latitude
        {
            get; set;
        }

        /// <summary>
        /// Geographic longitude
        /// </summary>
        float longitude
        {
            get; set;
        }
    }
}
