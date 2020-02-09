namespace What.Beer.Common.Domain
{
    /// <summary>
    /// The <see cref="Beer"/> class.
    /// </summary>
    public class Beer : DomainObject
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the nutritional information.
        /// </summary>
        public Nutrition NutritionalInformation { get; set; }
    }
}
