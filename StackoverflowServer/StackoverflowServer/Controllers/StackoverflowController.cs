using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stackoverflow.Core.Stackoverflow;
using Stackoverflow.Core.Stackoverflow.Interfaces;
using Stackoverflow.Domain.Stackoverflow.Repositories;
using StackoverflowServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackoverflowServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StackoverflowController : ControllerBase
    {
        private IStackoverflowRepository stackoverflow = new StackoverflowRepository();

        [HttpGet]
        [Route("getAllQuestions")]
        public ActionResult<GetAllQuestionsModel> GetAllQuestions()
        {
            var result = new GetAllQuestionsModel { Questions = new List<QuestionModel>() };

            try
            {
                List<Question> questions = stackoverflow.GetAllQuestionsFromDb().ToList();

                if (questions.ToArray().Length == 0)
                {
                    return Ok("Soru bulunamamıştır.");
                }

                foreach (var question in questions)
                {
                    result.Questions.Add(new QuestionModel(question));
                }

            }
            catch (Exception e)
            {
                return null;
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("getQuestion")]
        public ActionResult<GetQuestionModel> GetQuestion(Guid questionId)
        {
            var result = new GetQuestionModel { Question = new QuestionModel() };

            try
            {
                Question question = stackoverflow.GetQuestionFromDb(questionId);

                result.Question.QuestionContent = question.QuestionContent;
                result.Question.QuestionId = question.Id;
            }
            catch (Exception e)
            {
                return null;
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("getAnswersForQuestion")]
        public ActionResult<GetAllQuestionsModel> GetAnswersForQuestion(Guid questionId)
        {
            var result = new GetAnswersModel { Answers = new List<AnswerModel>() };

            try
            {
                List<Answer> answers = stackoverflow.GetAllAnswersFromDb(questionId).ToList();

                if (answers.ToArray().Length == 0)
                {
                    return Ok(result);
                }

                foreach (var answer in answers)
                {
                    result.Answers.Add(new AnswerModel(answer));
                }

            }
            catch (Exception e)
            {
                return null;
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("post_AddQuestion")]
        public ActionResult<AddQuestionModel> AddQuestion(string questionContent)
        {
            var result = new AddQuestionModel { Question = new Question() };

            try
            {
                result.Question = stackoverflow.AddNewQuestionToDb(questionContent);

            }
            catch (Exception e)
            {
                result.Question = null;
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("post_AddAnswer")]
        public ActionResult<AddAnswerModel> AddAnswer(Guid questionId, string answerContent)
        {
            var result = new AddAnswerModel { Answer = new Answer()};

            try
            {
                result.Answer = stackoverflow.AddNewAnswerToDb(questionId, answerContent);

            }
            catch (Exception e)
            {
                result.Answer = null;
            }

            return Ok(result);
        }


    }
}
