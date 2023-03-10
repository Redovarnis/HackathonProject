using Application.Features.Corporates.Commands.CreateCorporate;
using Application.Features.Corporates.Commands.RemoveCorporate;
using Application.Features.Corporates.Commands.UpdateCorporate;
using Application.Features.Corporates.Dtos;
using Application.Features.Corporates.Models;
using Application.Features.Corporates.Queries.GetByIdCorporate;
using Application.Features.Corporates.Queries.GetListCorporate;
using Core.Application.Requests;
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

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCorporateQuery getListCorporateQuery = new() { PageRequest = pageRequest };
            CorporateListModel result = await Mediator.Send(getListCorporateQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCorporateQuery
            getByIdCorporateQuery)
        {
            CorporateGetByIdDto corporateGetByIdDto = await Mediator.Send(getByIdCorporateQuery);
            return Ok(corporateGetByIdDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RemoveCorporateCommand removeCorporateCommand)
        {
            RemovedCorporateDto result = await Mediator.Send(removeCorporateCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCorporateCommand updatedCorporateCommand)
        {
            UpdatedCorporateDto result = await Mediator.Send(updatedCorporateCommand);
            return Ok(result);
        }
    }
}
