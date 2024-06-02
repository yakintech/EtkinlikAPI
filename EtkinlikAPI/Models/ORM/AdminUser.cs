namespace EtkinlikAPI.Models.ORM
{
    public class AdminUser : BaseEntity
    {
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}
