using EtkinlikAPI.Models.DTO;
using EtkinlikAPI.Models.ORM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtkinlikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AkademiEventContext _db;
        public CategoryController(AkademiEventContext db)
        {
            _db = db;
        }


        // get all categories
        [HttpGet]

        public IActionResult Get()
        {
            List<GetAllCategoriesResponseDto> categories = _db.Categories.Where(x => x.IsDeleted == false).Select(x => new GetAllCategoriesResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                AddDate = x.AddDate
            }).OrderBy(q => q.AddDate).ToList();

            return Ok(categories);
        }

        // get category by id
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entity = _db.Categories.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                GetCategoryResponseDto model = new GetCategoryResponseDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    AddDate = entity.AddDate
                };

                return Ok(model);
            }
        }


        [Authorize]
        // add category
        [HttpPost]
        public IActionResult Post(CreateCategoryRequestDto model)
        {
            var entity = new Category
            {
                Name = model.Name,
                Icon = ""
            };

            _db.Categories.Add(entity);
            _db.SaveChanges();

            return Ok(model);
        }

        // delete category
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = _db.Categories.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                entity.IsDeleted = true;
                entity.DeleteDate = DateTime.Now;
                _db.SaveChanges();

                return Ok();
            }
        }


        [HttpPut("{id}")] // api/category/{id}
        public IActionResult Update(Guid id, UpdateRequestCategoryDto model)
        {
           var category = _db.Categories.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                category.Name = model.Name;
                category.UpdateDate = DateTime.Now;
                _db.SaveChanges();

                return Ok(model);
            }
        }

    }
}
