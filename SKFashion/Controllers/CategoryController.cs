﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKFashion.Models;

namespace SKFashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }
    }
}
