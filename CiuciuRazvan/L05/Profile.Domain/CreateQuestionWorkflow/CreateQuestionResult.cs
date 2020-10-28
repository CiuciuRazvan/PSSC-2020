using CSharp.Choices;
using Question.Domain.CreateQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Profile.Domain.CreateQuestionWorkflow
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        public interface ICreateQuestionResult { }

        public class QuestionCreated : ICreateQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string Title { get; private set; }
            public string Description { get; private set; }
            public string Tags { get; private set; }

            public int VoteCounter { get; private set; }
            public IReadOnlyCollection<Vote> AllVotes { get; private set; }
            public Guid QuestionId1 { get; }

            public QuestionCreated(Guid QuestionId, string Title, string Description, string Tags, int voteCounter, IReadOnlyCollection<Vote> allVotes)
            {
                this.QuestionId = QuestionId;
                this.Title = Title;
                this.Description = Description;
                this.Tags = Tags;
                VoteCounter = voteCounter;
                AllVotes = allVotes;
            }

            public QuestionCreated(Guid questionId, string title, string description, string tags)
            {
                QuestionId1 = questionId;
                Title = title;
                Description = description;
                Tags = tags;
            }
        }

        public class QuestionNotCreated : ICreateQuestionResult
        {          
            public QuestionNotCreated(string reason)            {                Reason = reason;            }            public string Reason { get; set; }        }
        public class QuestionValidationFailed : ICreateQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }            public QuestionValidationFailed(IEnumerable<string> errors)            {                ValidationErrors = errors.AsEnumerable();            }
        }
    }
}

