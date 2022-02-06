using Stackoverflow.Core.Stackoverflow;
using Stackoverflow.Core.Stackoverflow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackoverflow.Domain.Stackoverflow.Repositories
{
    public class StackoverflowRepository : IStackoverflowRepository
    {
        private readonly StackoverflowDbContext sofDbContext;

        public StackoverflowRepository()
        {
            sofDbContext = new StackoverflowDbContext();
        }

        public IList<Question> GetAllQuestionsFromDb()
        {
            return sofDbContext.Questions.ToList();
        }

        public Question GetQuestionFromDb(Guid questionId)
        {
            Question question = sofDbContext.Questions.Find(questionId);

            return question;
        }

        public IList<Answer> GetAllAnswersFromDb(Guid questionId)
        {
            List<Answer> answersOfQuestion = sofDbContext.Answers.ToList().Where(x => x.QuestionId == questionId).ToList();

            return answersOfQuestion;
        }

        public Question AddNewQuestionToDb(string questionContent)
        {
            Question newQuestion = new(questionContent);

            sofDbContext.Questions.Add(newQuestion);
            sofDbContext.SaveChanges();

            return newQuestion;
        }

        public Answer AddNewAnswerToDb(Guid questionId, string answerContent)
        {
            Answer newAnswer = new(questionId, answerContent);
            
            sofDbContext.Answers.Add(newAnswer);
            sofDbContext.SaveChanges();

            return newAnswer;
        }

    }
}
