using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackoverflowServer.Models
{
    public class GetAnswersModel
    {
        [JsonProperty("Answers")]
        public List<AnswerModel> Answers { get; set; }
    }
}
