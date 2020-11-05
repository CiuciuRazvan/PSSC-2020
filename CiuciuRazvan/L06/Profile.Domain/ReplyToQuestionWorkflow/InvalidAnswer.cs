using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.ReplyToQuestionWorkflow
{
   public class InvalidAnswer :Exception
    {
        public InvalidAnswer()
        {

        }

        public InvalidAnswer(string answerTxt) : base($"The value \"{answerTxt}\" is not a valid answer format.")
        {

        }
    }
}
