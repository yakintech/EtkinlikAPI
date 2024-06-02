namespace EtkinlikAPI.Models.ORM
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string? Icon { get; set; }
    }
}
