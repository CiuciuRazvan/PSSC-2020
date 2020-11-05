using CSharp.Choices;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.ReplyToQuestionWorkflow
{
    public class ReplyValidationResults
    {
        public interface IReplyValidation { }
        public class ValidatedReply : IReplyValidation
        {
            public ValidatedReply(Guid idQuestion, string answerTxt, Guid idAuthorReply)
            {
                IdQuestion = idQuestion;
                AnswerTxt = answerTxt;
                IdAuthorReply = idAuthorReply;
            }
            public Guid IdQuestion { get; private set; }
            public string AnswerTxt { get; private set; }

            public Guid IdAuthorReply { get; private set; }
        }
        public class UnValidatedReply : IReplyValidation
        {
            public UnValidatedReply(Guid idQuestion, string answerTxt, Guid idAuthorReply)
            {
                IdQuestion = idQuestion;
                AnswerTxt = answerTxt;
                IdAuthorReply = idAuthorReply;
            }
            public Guid IdQuestion { get; private set; }
            public string AnswerTxt { get; private set; }

            public Guid IdAuthorReply { get; private set; }

            private static bool IsAnswerTxtValid(string answerTxt)
            {

                //validate 
                if (answerTxt.Length >= 10 && answerTxt.Length >= 500)
                {
                    return true;
                }
                return false;
            }

            public static Result<UnValidatedReply> SendEmail(Guid idQuestion, string answerTxt, Guid idAuthorReply)
            {
                if (IsAnswerTxtValid(answerTxt))
                {
                    return new UnValidatedReply(idQuestion, answerTxt, idAuthorReply);
                }
                else
                {
                    return new Result<UnValidatedReply>(new InvalidAnswer(answerTxt));
                }
            }
        }
    }
}
