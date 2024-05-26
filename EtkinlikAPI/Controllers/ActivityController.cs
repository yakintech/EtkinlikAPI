using EtkinlikAPI.Models.DTO;
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

        [HttpGet]
        public IActionResult Get()
        {
            List<GetAllActivitiesResponseDto> model = _db.Activities.Where(x => x.IsDeleted == false).Select(x => new GetAllActivitiesResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                StartDate = x.StartDate,
                CategoryName = x.Category.Name,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            }).ToList();


            foreach (var item in model)
            {
                item.Images = _db.ActivityImages.Where(x => x.ActivityID == item.Id && x.IsDeleted == false).Select(x => x.ImagePath).ToList();
            }

            return Ok(model);
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var activity = _db.Activities.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (activity == null)
            {
                return NotFound();
            }

            GetActivityResponseDto model = new GetActivityResponseDto();
            model.Id = activity.Id;
            model.Name = activity.Name;
            model.Description = activity.Description;
            model.StartDate = activity.StartDate;
            model.CategoryName = activity.Category.Name;

            model.Images = _db.ActivityImages.Where(x => x.ActivityID == id && x.IsDeleted == false).Select(x => x.ImagePath).ToList();

            return Ok(model);
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


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var activity = _db.Activities.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (activity == null)
            {
                return NotFound();
            }

            activity.IsDeleted = true;
            _db.SaveChanges();

            return Ok();
        }
    }
}
