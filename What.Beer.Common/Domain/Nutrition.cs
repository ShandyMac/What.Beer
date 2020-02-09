namespace What.Beer.Common.Domain
{
    /// <summary>
    /// The <see cref="Nutrition"/> class.
    /// </summary>
    public class Nutrition
    {
        /// <summary>
        /// Gets or sets the abv.
        /// </summary>
        public double Abv { get; set; }

        /// <summary>
        /// Gets or sets the carbohydrates.
        /// </summary>
        public int Carbohydrates { get; set; }
        
        /// <summary>
        /// Gets or sets the calories.
        /// </summary>
        public int Calories { get; set; }
        
        /// <summary>
        /// Gets the unit of measurement.
        /// </summary>
        public UnitOfMeasurement Measurement => UnitOfMeasurement.Millilitres;
        
        /// <summary>
        /// Gets the serving size.
        /// </summary>
        public int ServingSize => 355;
    }
}
