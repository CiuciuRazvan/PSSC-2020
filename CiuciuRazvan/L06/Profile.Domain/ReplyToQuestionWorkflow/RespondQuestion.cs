using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.ReplyToQuestionWorkflow
{
   public class RespondQuestion
    {
        public RespondQuestion(Guid idQuestion, string answerTxt, string user)
        {
            IdQuestion = idQuestion;
            AnswerTxt = answerTxt;
            UserAuthorReply = user;
        }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(50)]
        public string AnswerTxt { get; private set; }

        [Required]
        public Guid IdQuestion { get; private set; }

        [Required]
        public string UserAuthorReply { get; private set; }
    }
}
