using System.ComponentModel.DataAnnotations.Schema;

namespace EtkinlikAPI.Models.ORM
{
    public class Activity : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public Guid CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

    }
}
