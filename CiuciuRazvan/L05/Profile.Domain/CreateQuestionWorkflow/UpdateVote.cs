using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Profile.Domain.CreateQuestionWorkflow.CreateQuestionResult;
using static Question.Domain.CreateQuestionWorkflow.Question;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class UpdateVote
    {
        public QuestionCreated Update(QuestionCreated question, Vote vote)
        {
            var votes = question.AllVotes;
            votes.Append(vote);

            return new QuestionCreated(question.QuestionId, question.Title,question.Description, question.Tags, votes.Sum(v => Convert.ToInt32(v)), votes);
        }
    }
}
