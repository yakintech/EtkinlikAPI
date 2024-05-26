using EtkinlikAPI.Models.DTO.activity;
using EtkinlikAPI.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtkinlikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly AkademiEventContext _db;
        public ActivityController(AkademiEventContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Post(CreateActivityRequestDto model)
        {
            // save image to server
            List<string> imagePaths = new List<string>();
            foreach (var image in model.Images)
            {

                //extension control
                if (image.ContentType != "image/jpeg" && image.ContentType != "image/jpg" && image.ContentType != "image/png")
                {
                    return BadRequest("Lütfen sadece jpeg,jpg ve png formatında resim yükleyiniz.");
                }

                var guidName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", guidName);


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                imagePaths.Add(guidName);
            }


            // save activity
            Activity activity = new Activity
            {
                Name = model.Name,
                Description = model.Description,
                StartDate = model.StartDate,
                CategoryID = model.CategoryID,
            };

            _db.Activities.Add(activity);
            _db.SaveChanges();

            // save images
            foreach (var item in imagePaths)
            {
                ActivityImages activityImage = new ActivityImages();
                activityImage.ActivityID = activity.Id;
                activityImage.ImagePath = item;

                _db.ActivityImages.Add(activityImage);
            }

            _db.SaveChanges();

            return Ok();
        }
    }
}
