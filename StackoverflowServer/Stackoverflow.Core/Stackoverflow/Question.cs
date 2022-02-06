using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackoverflow.Core.Stackoverflow
{
    public class Question
    {
        public Guid Id { get; set; }

        public string QuestionContent { get; set; }

        public Question(string questionContent)
        {
            QuestionContent = questionContent;
        }

        public Question()
        {
        }
    }
}
