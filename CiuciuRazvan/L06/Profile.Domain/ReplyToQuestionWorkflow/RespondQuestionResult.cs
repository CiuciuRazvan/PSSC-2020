using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question.Domain.ReplyToQuestionWorkflow
{
   public class RespondQuestionResult
    {
        public interface IReplay { }

        public class ReplayPosted : IReplay
        {
            public ReplayPosted(string replyTxt)
            {
                ReplyTxt = replyTxt;
            }

            public string ReplyTxt { get; private set; }
        }

        public class InvalidReply : IReplay
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public InvalidReply(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }

        public class ReplyNotPosted : IReplay
        {
            public ReplyNotPosted(string reason)
            {
                Reason = reason;
            }

            public string Reason { get; set; }
        }
    }
}
