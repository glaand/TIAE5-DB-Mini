﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace TIAE5_DB_Mini.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IActionDescriptorCollectionProvider provider;
        public HomeController(IActionDescriptorCollectionProvider provider)
        {
            this.provider = provider;
        }

        public IActionResult Index()
        {
            var urls = this.provider.ActionDescriptors.Items
                .Select(descriptor => string.Join(" --> ", descriptor.RouteValues.Values.Where(v => v != null) ))
                .Distinct()
                .ToList();

            return Ok(urls);
        }
    }
}
