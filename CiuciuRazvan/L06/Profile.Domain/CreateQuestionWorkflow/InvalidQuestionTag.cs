using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
   public class InvalidQuestionTag : Exception
    {
        public InvalidQuestionTag()
        {

        }

        public InvalidQuestionTag(List<string> tags) : base($"The value \"{tags.Count}\" is an invalid format.Please do not use more than 3 tags.")
        {

        }
    }
}
