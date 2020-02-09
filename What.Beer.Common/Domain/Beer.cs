namespace What.Beer.Common.Domain
{
    public class Beer : DomainObject
    {
        public string Name { get; set; }

        public Nutrition NutritionalInformation { get; set; }
    }
}
