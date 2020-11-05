using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.ReplyToQuestionWorkflow
{
   public class LanguageCheck
    {
        public string AnswerTxt { get; set; }

        public LanguageCheck(string answerTxt)
        {
            AnswerTxt = answerTxt;
        }
    }
}
