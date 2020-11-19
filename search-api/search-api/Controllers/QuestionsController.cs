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
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public QuestionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("questions/{question_id:int}")]
        public async Task<IActionResult> Get([FromRoute] int question_id)
        {
            if (question_id == 0)
                return BadRequest("Invalid Id");

            try
            {
                return Ok(await mediator.Send(new GetQuestionByIdQuery(question_id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("questions")]
        public async Task<IActionResult> Get([FromQuery]int limit, [FromQuery]int offset, [FromQuery]string filter)
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
        [Route("questions")]
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


        [HttpPut]
        [Route("questions/{question_id:int}")]
        public async Task<IActionResult> Put([FromRoute]int question_id, [FromBody]UpdateQuestionCommand model)
        {
            model.Id = question_id;

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
