namespace RozvozJidla.GeoApi.Common.Configuration
{
    /// <summary>
    /// Configuration Resolver for IOC
    /// </summary>
    /// <typeparam name="T">Configuration class</typeparam>
    public interface IConfigurationResolver<out T> where T : class
    {
        /// <summary>
        /// Returns given config type
        /// </summary>
        /// <returns></returns>
        T GetConfig();
    }
}