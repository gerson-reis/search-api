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
    public class QuestionsController : Controller
    {
        private readonly IMediator mediator;

        public QuestionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]int id)
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
