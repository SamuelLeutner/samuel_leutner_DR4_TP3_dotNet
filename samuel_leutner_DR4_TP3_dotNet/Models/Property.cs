namespace samuel_leutner_DR4_TP3_dotNet.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public int CityId { get; set; }
        public City City { get; set; } = default!;
        public DateTime? DeletedAt { get; set; }
    }
}
