﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKFashion.Models;

namespace SKFashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }
    }
}
