using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class InvalidQuestionText : Exception
    {
        public InvalidQuestionText()
        {

        }

        public InvalidQuestionText(string question) : base($"The value \"{question}\" is an invalid question format.")
        {
        }
    }
}
