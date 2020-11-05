using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.ReplyToQuestionWorkflow
{
   public class AcknowledgmentSentToReplyAuthor
    {

        public AcknowledgmentSentToReplyAuthor(string answerTxt, Guid idQuestion, Guid idReply)
        {
            AnswerTxt = answerTxt;
            IdQuestion = idQuestion;
            IdReply = idReply;
        }

        [Required]
        public string AnswerTxt { get; private set; }

        [Required]
        public Guid IdQuestion { get; private set; }

        [Required]
        public Guid IdReply { get; private set; }
    }
}
