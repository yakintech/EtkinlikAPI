namespace EtkinlikAPI.Models.DTO.activity
{
    public class CreateActivityRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public Guid CategoryID { get; set; }

        //image list from form data
        public List<IFormFile> Images { get; set; }
       

    }
}
