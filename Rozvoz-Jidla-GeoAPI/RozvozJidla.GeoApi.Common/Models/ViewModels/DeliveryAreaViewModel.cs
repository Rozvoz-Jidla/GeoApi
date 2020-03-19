namespace RozvozJidla.GeoApi.Common.Models.ViewModels
{
    /// <summary>
    /// Delivery Area view model for API return
    /// </summary>
    public class DeliveryAreaViewModel
    {
        /// <summary>
        /// Delivery Provider Name - company
        /// </summary>
        public string DeliveryProviderName { get; set; }

        /// <summary>
        /// Delivery Provider web site
        /// </summary>
        public string DeliveryProviderWebSite { get; set; }

        /// <summary>
        /// Name of Polygon - delivery area, like area in city
        /// </summary>
        public string DeliveryAreaName { get; set; }
    }
}
