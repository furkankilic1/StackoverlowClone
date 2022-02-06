using Newtonsoft.Json;
using Stackoverflow.Core.Stackoverflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackoverflowServer.Models
{
    public class AnswerModel
    {

        [JsonProperty("answerContent")]
        public string AnswerContent { get; set; }

        public AnswerModel()
        {
        }

        public AnswerModel(Answer answer)
        {
            AnswerContent = answer.AnswerContent;
        }
    }
}
