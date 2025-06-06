﻿namespace samuel_leutner_DR4_TP3_dotNet.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public Country Country { get; set; } = default!;
        public List<Property> Properties { get; set; } = new List<Property>();
    }
}
