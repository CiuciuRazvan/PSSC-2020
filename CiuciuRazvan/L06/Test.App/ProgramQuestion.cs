using LanguageExt;
using Question.Domain.CreateQuestionWorkflow;
using Profile.Domain.CreateQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static Profile.Domain.CreateQuestionWorkflow.CreateQuestionResult;
using static Question.Domain.CreateQuestionWorkflow.Question;
namespace Test.App
{
    class ProgramQuestion
    {
        static void Main(string[] args)
        {
            var cmd = new CreateQuestionCmd("Titlu1", "Descriere1", "c#");
            var result = CreateQuestion(cmd);
            result.Match(
                ProcessQuestionCreated,
                ProcessQuestionNotCreated,
                ProcessInvalidQuestion
                );
            Console.ReadLine();
        }
        private static ICreateQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }
        private static ICreateQuestionResult ProcessQuestionNotCreated(QuestionNotCreated questionNotCreatedResult)
        {
            Console.WriteLine($"Question not created: {questionNotCreatedResult.Reason}");
            return questionNotCreatedResult;
        }
        private static ICreateQuestionResult ProcessQuestionCreated(QuestionCreated question)
        {
            Console.WriteLine($"Question {question.QuestionId}");
            return question;
        }
        public static ICreateQuestionResult CreateQuestion(CreateQuestionCmd createQuestionCommand)
        {
            if (string.IsNullOrWhiteSpace(createQuestionCommand.Title) || string.IsNullOrWhiteSpace(createQuestionCommand.Description))
            {
                var errors = new List<string>() { "Invalid title or description" };
                return new QuestionValidationFailed(errors);
            }
            if (new Random().Next(10) > 1)
            {
                return new QuestionNotCreated("Question could not be verified");
            }
            var questionId = Guid.NewGuid();
            var results = new QuestionCreated(questionId, createQuestionCommand.Title, createQuestionCommand.Description, createQuestionCommand.Tags);
            return results;
        }
        private static void VoteQuestion(UnverifiedQuestion question)
        {
            var voteQuestionResult = new VerifyQuestion().Verify(question);
            voteQuestionResult.Match(
                voteQuestion =>
                {
                    new VerifyVote().VerifyQuestionIsPosted(voteQuestion).Wait();
                    return Unit.Default;
                },
                ex =>
                {
                    Console.WriteLine("You are not able to vote");
                    return Unit.Default;
                }
                );
        }
    }
}
