using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using search_application.Command;
using search_application.Dto;
using search_application.Handler;
using search_data;
using search_model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace seach_application_test
{
    [TestClass]
    public class UpdateQuestionHandlerTest
    {
        private Mock<IRepository<Question>> repositoryMock;
        private UpdateQuestionCommand command;

        [TestInitialize]
        public void Setup()
        {
            repositoryMock = new Mock<IRepository<Question>>();
            command = new UpdateQuestionCommand()
            {
                Choices = new List<QuestionChoiceDto>()
                {
                    new QuestionChoiceDto() { Choice = "dasd"}
                },
                Image_url = "google.com",
                Question = "question 1",
                Thumb_url = "google.com"
            };

            var choices = command.Choices.Select(x => new QuestionChoice(x.Choice)).ToList();
            repositoryMock.Setup(x => x.Update(It.IsAny<Question>())).Returns(Task.FromResult(new Question(command.Question, command.Image_url, command.Thumb_url, choices)));
            repositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(new Question(command.Question, command.Image_url, command.Thumb_url, choices)));
        }

        [TestMethod]
        public void HandlerTest()
        {
            var handler = new UpdateQuestionHandler(repositoryMock.Object);
            handler.Handle(command, new CancellationToken()).Wait();
            repositoryMock.Verify(x => x.Update(It.IsAny<Question>()), Times.Once);
        }

        [TestMethod]
        public void HandlerCountChoices()
        {
            var handler = new UpdateQuestionHandler(repositoryMock.Object);
            handler.Handle(command, new CancellationToken()).Wait();
            repositoryMock.Verify(x => x.Update(It.Is<Question>(x => x.Choices.Count == 2)), Times.Once);
        }
    }
}
