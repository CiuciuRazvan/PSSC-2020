using Primitives.IO;
using Question.Domain.ReplyToQuestionWorkflow;


using System;
using System.Collections.Generic;
using System.Text;
using LanguageExt;
using static PortExt;


namespace Test.App
{
    public static class BoundedContext
    {
        public static Port<ReplyValidationResults.IReplyValidation> ValidatedReply(Guid idQuestion, string answerTxt, Guid idAuthorReply)
            => NewPort<ReplyValidation, ReplyValidationResults.IReplyValidation>(new ReplyValidation(idQuestion, answerTxt,  idAuthorReply));

        public static Port<LanguageCheckResults.IVerifyLanguage> LanguageCheck(string answerTxt)
            => NewPort<LanguageCheck, LanguageCheckResults.IVerifyLanguage>(new LanguageCheck(answerTxt));

        public static Port<AcknowledgementSentToQuestionOwnerResults.ISendToQuestionOwner> ReplyReceivedAcknowledgementSentToQuestionOwner(string answerTxt, Guid idQuestion, Guid idAuthorReply)
       => NewPort<AcknowledgementSentToQuestionOwner, AcknowledgementSentToQuestionOwnerResults.ISendToQuestionOwner>(new AcknowledgementSentToQuestionOwner(answerTxt, idQuestion, idAuthorReply));

        public static Port<AcknowledgmentSentToReplyAuthorResults.ISendToReplyAuthor> ReplyPublishedAcknowledgmentSentToReplyAuthor(string answerTxt, Guid idQuestion, Guid idReply)
        => NewPort<AcknowledgmentSentToReplyAuthor, AcknowledgmentSentToReplyAuthorResults.ISendToReplyAuthor>(new AcknowledgmentSentToReplyAuthor(answerTxt, idQuestion, idReply));
    }
}
