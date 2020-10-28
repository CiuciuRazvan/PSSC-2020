using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Profile.Domain.CreateQuestionWorkflow
{
    public struct CreateQuestionCmd
    {
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Description { get; private set; }
        [Required]
        public string Tags { get; private set; }

        public CreateQuestionCmd(string Title, string Description, string Tags)
        {
            this.Title = Title;
            this.Description = Description;
            this.Tags = Tags;
        }
    }
}
