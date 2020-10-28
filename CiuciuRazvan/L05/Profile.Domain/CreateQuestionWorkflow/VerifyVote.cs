using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Question.Domain.CreateQuestionWorkflow.Question;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class VerifyVote
    {
        public Task VerifyQuestionIsPosted(VerifiedQuestion question)
        {
            return Task.CompletedTask;
        }
    }
}
