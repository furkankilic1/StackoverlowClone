using Newtonsoft.Json;
using Stackoverflow.Core.Stackoverflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackoverflowServer.Models
{
    public class AddAnswerModel
    {
        [JsonProperty("answer")]
        public Answer Answer { get; set; }
    }
}
