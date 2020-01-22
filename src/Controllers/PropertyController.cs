using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UK_Property_API.Models;

namespace UK_Property_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyContext _context;

        public PropertyController(PropertyContext context) => _context = context;

        //GET: api/properties
        [HttpGet]
        public ActionResult<IEnumerable<Property>> GetProperty()
        {

            return _context.PropertyData;
        }

        public ActionResult<IEnumerable<string>> GetString()
        {
            return new string[] { "this", "is", "hard", "coded" };
        }
    }
}
