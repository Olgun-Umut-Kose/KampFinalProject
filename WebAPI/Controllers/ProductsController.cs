using System.Collections.Generic;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }


        [HttpGet("getall")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {

            var result = _service.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        
        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _service.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}