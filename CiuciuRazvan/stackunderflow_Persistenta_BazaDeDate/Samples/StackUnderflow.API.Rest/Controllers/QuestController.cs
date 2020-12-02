using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.EF.Models;
using Access.Primitives.EFCore;
using LanguageExt;
using Microsoft.AspNetCore.Http;
using StackUnderflow.Domain.Core.Contexts.Question;
using StackUnderflow.Domain.Core.Contexts.Question.CreateQuest;
using StackUnderflow.Domain.Core.Contexts.Question.SendConfirm;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("question")]
    public class QuestController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;

        public QuestController(IInterpreterAsync interpreter, StackUnderflowContext dbContext)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
        }
    }

    [HttpPost("post")]
    public async Task<IActionResult> CreateAndConfirmationQuestion([FromBody] CreateQuestCmd createQuestCmd)
    {
        object _dbContext = null;
        QuestWrite ctx = new QuestWrite(
           new EFList<Post>(_dbContext.Post),
           new EFList<User>(_dbContext.User));

        var dependencies = new QuestDependencies();
        dependencies.GenerateConfirmationToken = () => Guid.NewGuid().ToString();
        dependencies.SendConfirmationEmail = (ConfirmLetter letter) => async () => new ConfirmAcknowledgement(Guid.NewGuid().ToString());
        
        var expr = from createQuestResult in Domain.Core.Contexts.Question.CreateQuest.CreateQuestCmd(createQuestCmd)
                   let question = createQuestResult.SafeCast<CreateQuestResult.QuestCreated>.Select(p => p.Question)
                   let confirmQuestionCmd = new ConfirmQuestCmd(question)
                   from ConfirmQuestResult in Question.ConfirmQuestCmd(confirmQuestCmd)
                   select new { createQuestResult, ConfirmQuestResult };
        var r = await _interpreter.Interpret(expr, ctx, dependencies);
        _dbContext.SaveChanges();
        return r.createQuestionResult.Match(
            created => (IActionResult)Ok(created.Post. .TenantId),
            notCreated => StatusCods(StatusCodes.Status500InternalServerError, "Question could not be created."),
        invalidRequest => BadRequest("Invalid request."));

    }
}
