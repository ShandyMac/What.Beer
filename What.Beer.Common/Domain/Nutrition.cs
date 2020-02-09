namespace What.Beer.Common.Domain
{
    public class Nutrition
    {
        public double Abv { get; set; }
        public int Carbohydrates { get; set; }
        public int Calories { get; set; }
        public UnitOfMeasurement Measurement => UnitOfMeasurement.Millilitres;
        public int ServingSize => 355;
    }
}
