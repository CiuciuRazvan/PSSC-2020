using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.ReplyToQuestionWorkflow
{
    public class AcknowledgementSentToQuestionOwner
    {
        public AcknowledgementSentToQuestionOwner(global::System.String answerTxt, Guid idQuestion, Guid idAuthorReply)
        {
            AnswerTxt = answerTxt;
            IdQuestion = idQuestion;
            IdAuthorReply = idAuthorReply;
        }
        [Required]
        public string AnswerTxt { get; private set; }

        [Required]
        public Guid IdQuestion { get; private set; }

        [Required]
        public Guid IdAuthorReply { get; private set; }
    }
}
