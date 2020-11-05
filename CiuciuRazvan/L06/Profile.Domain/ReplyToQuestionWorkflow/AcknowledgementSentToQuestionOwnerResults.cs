using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.ReplyToQuestionWorkflow
{
   public class AcknowledgementSentToQuestionOwnerResults
    {
        public interface ISendToQuestionOwner { }

        public class ReplyReceived : ISendToQuestionOwner
        {
            public ReplyReceived(string message)
            {
                Message = message;
            }
            public string Message { get; set;}
        }
        public class ReplyUnReceived : ISendToQuestionOwner
        {
            public ReplyUnReceived(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
            public string ErrorMessage { get; set; }
        }
    }
}
