using MediatR;
using Microsoft.AspNetCore.Mvc;
using search_application.Command;
using search_application.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace search_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public QuestionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return BadRequest("Invalid Id");

            try
            {
                return Ok(await mediator.Send(new GetQuestionByIdQuery(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/{offset?}/{limit?}/{filter?}")]
        public async Task<IActionResult> Get([FromRoute]int limit, [FromRoute]int offset, [FromRoute]string filter)
        {
            try
            {
                return Ok(await mediator.Send(new GetQuestionsPagedQuery(offset, limit, filter)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateQuestionCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await mediator.Send(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
