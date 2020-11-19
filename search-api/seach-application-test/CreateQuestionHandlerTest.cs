using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using search_application.Command;
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
    public class CreateQuestionHandlerTest
    {
        private Mock<IRepository<Question>> repositoryMock;

        [TestInitialize]
        public void Setup()
        {
            repositoryMock = new Mock<IRepository<Question>>();
        }

        [TestMethod]
        public void HandlerTest()
        {
            var command = new CreateQuestionCommand()
            {
                Choices = new List<string>()
                {
                    "option 1"
                },
                Image_url = "google.com",
                Question = "question 1",
                Thumb_url = "google.com"
            };

            var choices = command.Choices.Select(x => new QuestionChoice(x)).ToList();
            repositoryMock.Setup(x => x.Insert(It.IsAny<Question>())).Returns(Task.FromResult(new Question(command.Question, command.Image_url, command.Thumb_url, choices)));

            var handler = new CreateQuestionHandler(repositoryMock.Object);
            handler.Handle(command, new CancellationToken()).Wait();
            repositoryMock.Verify(x => x.Insert(It.IsAny<Question>()), Times.Once);
        }
    }
}
