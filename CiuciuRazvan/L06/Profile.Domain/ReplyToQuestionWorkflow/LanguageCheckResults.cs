using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.ReplyToQuestionWorkflow
{
    public class LanguageCheckResults
    {
        public interface IVerifyLanguage { }

        public class VerifiedText : IVerifyLanguage
        {
            public VerifiedText(int assurance)
            {
                Assurance = assurance;
            }
            public int Assurance { get; } 
        }

        public class UnverifiedText : IVerifyLanguage
        {
            public UnverifiedText(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }

            public string ErrorMessage { get; private set; }

        }
    }
}
