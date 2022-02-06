using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackoverflow.Core.Stackoverflow
{
    public class Answer
    {
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }

        public string AnswerContent { get; set; }

        public Answer(Guid questionId, string answerContent)
        {
            QuestionId = questionId;
            AnswerContent = answerContent;
        }

        public Answer()
        {
        }
    }
}
