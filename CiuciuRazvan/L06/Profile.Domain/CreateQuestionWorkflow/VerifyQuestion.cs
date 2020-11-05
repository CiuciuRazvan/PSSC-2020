using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.CreateQuestionWorkflow.Question;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class VerifyQuestion
    {
        public Result<VerifiedQuestion> Verify(UnverifiedQuestion question)
        {
            return new VerifiedQuestion(question.Question, question.Tags);
        }
    }
}
