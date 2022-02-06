using Newtonsoft.Json;
using Stackoverflow.Core.Stackoverflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackoverflowServer.Models
{
    public class AddQuestionModel
    {
        [JsonProperty("question")]
        public Question Question { get; set; }
    }
}
