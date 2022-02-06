using Newtonsoft.Json;
using Stackoverflow.Core.Stackoverflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackoverflowServer.Models
{
    public class QuestionModel
    {
        [JsonProperty("questionContent")]
        public string QuestionContent { get; set; }

        [JsonProperty("questionId")]
        public Guid QuestionId { get; set; }

        public QuestionModel() { }

        public QuestionModel(Question que)
        {
            QuestionContent = que.QuestionContent;
            QuestionId = que.Id;
        }
    }
}
