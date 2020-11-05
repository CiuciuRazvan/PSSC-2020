using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.ReplyToQuestionWorkflow
{
    public class ValidationError
    {
        public string ErrorMessage { get; private set; }

        internal ValidationError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
