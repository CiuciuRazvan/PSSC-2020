using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.ReplyToQuestionWorkflow
{
    public class AcknowledgmentSentToReplyAuthorResults
    {
        public interface ISendToReplyAuthor {}

        public class ReplyPublished : ISendToReplyAuthor
        {
            public ReplyPublished(string message)
            {
                Message = message;
            }
            public string Message { get; private set; }
        }
        public class ReplyUnPublished : ISendToReplyAuthor
        {
            public ReplyUnPublished(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }

            public string ErrorMessage { get; private set; }
        }
    }
}
