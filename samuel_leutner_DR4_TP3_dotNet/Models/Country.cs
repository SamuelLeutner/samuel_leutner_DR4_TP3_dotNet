namespace samuel_leutner_DR4_TP3_dotNet.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
        public List<City> Cities { get; set; } = new List<City>();

    }
}
