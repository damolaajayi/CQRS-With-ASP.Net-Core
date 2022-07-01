using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesWithEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


       [HttpGet("all", Name = "GetAllCategories")]
       [ProducesResponseType(StatusCodes.Status200OK)]
       public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
       {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
       }

       [HttpGet("allwithevents", Name = "GetAllCategoriesWithEvents")]
       [ProducesResponseType(StatusCodes.Status200OK)]
       public async Task<ActionResult<List<CategoryListVm>>> GetCategoriesWithEvents(bool includeHistory)
       {
           GetCategoriesListWithEventsQuery getCategoriesWithEventsQuery = new GetCategoriesListWithEventsQuery() { IncludeHistory = includeHistory };
           var dtos = await _mediator.Send(new GetCategoriesListWithEventsQuery());
           return Ok(dtos);
       }

       [HttpPost(Name = "AddCategory")]
       public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
       {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
       }


    }
}
