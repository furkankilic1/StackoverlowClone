using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackoverflow.Core.Stackoverflow.Interfaces
{
    public interface IStackoverflowRepository
    {
        IList<Question> GetAllQuestionsFromDb();

        Question GetQuestionFromDb(Guid questionId);

        IList<Answer> GetAllAnswersFromDb(Guid questionId);

        Question AddNewQuestionToDb(string questionContent); 

        Answer AddNewAnswerToDb(Guid questionId, string answerContent);
    }
}
 