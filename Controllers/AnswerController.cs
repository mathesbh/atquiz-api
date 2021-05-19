using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AtQuiz.Data;
using AtQuiz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AtQuiz.Controllers
{
    [ApiController]
    [Route("api/answers")]
    public class AnswerController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Answer>>> Get([FromServices] DataContext context)
        {
            var answers = await context.Answers.Include(item => item.Questionnaire).ToListAsync();
            return answers;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Answer>> Post([FromServices] DataContext context, [FromBody] Answer model)
        {
            if(ModelState.IsValid)
            {
                model.RegistrationDate = DateTime.Now;
                context.Answers.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("questionnaires/{id:int}")]
        public async Task<ActionResult<List<Answer>>> GetByQuestionnaires([FromServices] DataContext context, int id)
        {
            var answers = await context.Answers.Include(item => item.Questionnaire).Where(item => item.QuestionnaireId == id).ToListAsync();
            return answers;
        }
        
    }
}