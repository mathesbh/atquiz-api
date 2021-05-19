using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AtQuiz.Data;
using AtQuiz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtQuiz.Controllers
{
    [ApiController]
    [Route("api/questionnaires")]
    public class QuestionnaireController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Questionnaire>>> Get([FromServices] DataContext context)
        {           
            var questionnaires = await context.Questionnaires.ToListAsync();
            return questionnaires;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Questionnaire>> Post([FromServices] DataContext context, [FromBody] Questionnaire model)
        {
            if(ModelState.IsValid)
            {
                model.RegistrationDate = DateTime.Now;
                context.Questionnaires.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Questionnaire>> GetById([FromServices] DataContext context, int id)
        {
            var quiz = await context.Questionnaires.FirstOrDefaultAsync(item => item.Id == id);
            return quiz;
        }
    }
}