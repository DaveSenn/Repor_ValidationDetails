using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ValidationDetails.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class FooController : ControllerBase
    {
        [HttpPut]
        public IActionResult Create( CreateFoo foo ) =>
            Ok();
    }

    public record CreateFoo( [Required] String Name );
}