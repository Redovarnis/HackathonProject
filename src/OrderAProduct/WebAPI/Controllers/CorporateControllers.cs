using Application.Features.Corporates.Commands.CreateCorporate;
using Application.Features.Corporates.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateControllers : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCorporateCommand createCorporateCommand)
        {
            CreatedCorporateDto result = await Mediator?.Send(createCorporateCommand)!;
            return Created("", result);
        }
    }
}
