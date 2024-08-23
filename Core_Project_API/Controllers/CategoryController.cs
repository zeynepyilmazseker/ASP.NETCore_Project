using Core_Project_API.DAL.ApiContext;
using Core_Project_API.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Core_Project_API.Controllers
{
    //API üzerinden CRUD işlemleri
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategoryList()
        {
            using var context = new Context();
            return Ok(context.Categories.ToList());

        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            using var context = new Context();
            var value = context.Categories.Find(id);
            if (value == null)
            {
                return NotFound();//kodu 404

            }
            else
            {
                return Ok(value); //kodu 200
            }


        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            using var context = new Context();

            if (p == null)
            {
                return BadRequest();
            }
            else
            {

                context.Add(p);
                context.SaveChanges();
                return Created("", p);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            using var context = new Context();
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(category);
                context.SaveChanges();
                return NoContent();
            }

        }

        [HttpPut]
        public IActionResult UpdateCategory(Category p)
        {
            using var context = new Context();
            var value = context.Find<Category>(p.CategoryID);
            if(value == null)
            {
                return NotFound();
            }

            
            value.CategoryName = p.CategoryName;
            context.Update(value);
            context.SaveChanges();
            return Ok(value);

        }
    }
}
