using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;
using ToDoTasksDataLayer.Repository;
using ToDoTasksDataLayer.Entities;
using ToDoTasksDataLayer;
using ToDoTasksDataLayer.DataService;

namespace ToDoTasksTest.ToDoTasksDataLayer
{
    public class ToDoTaskRepositoryTest
    {
        [Fact]
        public void GetTasksForUser_CheckParameters_ReturnsPredictedResult()
        {
            IRepository<ToDoTasks, int> iRepository = Substitute.For<IRepository<ToDoTasks, int>>();
            ToDoTasks taskExpected = new ToDoTasks { TaskUserId = 1 };

            iRepository.FindBy(Arg.Compat.Any<int>()).Returns<ToDoTasks>(taskExpected);

            ToDoTaskRepository toDoRepository = new ToDoTaskRepository(iRepository);

            ToDoTasks taskActual = toDoRepository.GetTasks(8);

            Assert.Equal(taskExpected, taskActual);
        }

        [Fact]
        public void GetTasksForUser_InCorrectUserID_ReturnsNullResult()
        {
            IRepository<ToDoTasks, int> iRepository = Substitute.For<IRepository<ToDoTasks, int>>();
            ToDoTasks taskExpected = null;

            iRepository.FindBy(Arg.Compat.Any<int>()).Returns<ToDoTasks>(taskExpected);

            ToDoTaskRepository toDoRepository = new ToDoTaskRepository(iRepository);

            ToDoTasks taskActual = toDoRepository.GetTasks(8);

            Assert.Equal(taskExpected, taskActual);
        }

        [Fact]
        public void GetTasksForUsers_CheckParameters_ReturnPredictedResults()
        {
            IRepository<ToDoTasks, int> iRepository = Substitute.For<IRepository<ToDoTasks, int>>();
            List<ToDoTasks> taskExpected = new List<ToDoTasks>();
            taskExpected.Add(new ToDoTasks { CheckedDone = false, LastUpdated = DateTime.Now, TaskDescription = "SomeTaskDescription", TaskUserId = 8, ToDoTaskId = 8 });
            iRepository.FindAll().Returns(taskExpected);

            ToDoTaskRepository toDoRepository = new ToDoTaskRepository(iRepository);

            List<ToDoTasks> taskActual = toDoRepository.GetTasksForUser(8).ToList();

            Assert.Equal(taskExpected, taskActual);
        }

        [Fact]
        public void GetTasksForUsers_InCorrectUserID_ReturnNullResults()
        {
            IRepository<ToDoTasks, int> iRepository = Substitute.For<IRepository<ToDoTasks, int>>();
            List<ToDoTasks> taskExpected = new List<ToDoTasks>();
            iRepository.FindAll().Returns(taskExpected);

            ToDoTaskRepository toDoRepository = new ToDoTaskRepository(iRepository);

            List<ToDoTasks> taskActual = toDoRepository.GetTasksForUser(8).ToList();

            Assert.Equal(taskExpected, taskActual);
        }

        [Fact]
        public void SaveNew_Assert_CallsAdd()
        {
            IRepository<ToDoTasks, int> iRepository = Substitute.For<IRepository<ToDoTasks, int>>();
            ToDoTasks toDoTask = new ToDoTasks();

            ToDoTaskRepository toDoRepository = new ToDoTaskRepository(iRepository);

            toDoRepository.SaveNew(toDoTask);

            iRepository.Received().Add(toDoTask);
        }

        [Fact]
        public void UpdateTask_Assert_CallsSave()
        {
            IRepository<ToDoTasks, int> iRepository = Substitute.For<IRepository<ToDoTasks, int>>();
            ToDoTasks toDoTask = new ToDoTasks();

            ToDoTaskRepository toDoRepository = new ToDoTaskRepository(iRepository);

            toDoRepository.UpdateTask(toDoTask);

            iRepository.Received().Save(toDoTask);
        }
    }
}
