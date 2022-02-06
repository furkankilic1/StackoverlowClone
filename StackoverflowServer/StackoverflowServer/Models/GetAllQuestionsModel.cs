using Newtonsoft.Json;
using Stackoverflow.Core.Stackoverflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackoverflowServer.Models
{
    public class GetAllQuestionsModel
    {
        [JsonProperty("Questions")]
        public List<QuestionModel> Questions { get; set; }
    }
}
