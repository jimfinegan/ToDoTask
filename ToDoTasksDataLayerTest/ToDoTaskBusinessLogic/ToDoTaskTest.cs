using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTaskBusinessLogic;
using ToDoTasksDataLayer.DataService;
using ToDoTasksDataLayer.Entities;
using ToDoTasksDataLayer.Repository;
using Xunit;

namespace ToDoTasksTest.ToDoTaskBusinessLogic
{
    public class ToDoTaskTest
    {
        [Fact]
        public void GetAllTasksForForUsers_CorrectParameters_ReturnsCorrectObject()
        {
            IRepository<ToDoTasks, int> iRepository = Substitute.For<IRepository<ToDoTasks, int>>();

            List<ToDoTasks> taskUserExpected = new List<ToDoTasks>();
            taskUserExpected.Add(new ToDoTasks  { CheckedDone = false, LastUpdated = System.DateTime.Now, TaskDescription = "someDescription", TaskUserId = 1, ToDoTaskId = 1 });

            iRepository.FindAll().Returns(taskUserExpected);

            ToDoTask toDoTasks = new ToDoTask(iRepository);

            List<ToDoTasks> taskUserActual  = toDoTasks.GetAllTasksForUser(1);

            Assert.Equal(taskUserExpected, taskUserActual);

        }


        [Fact]
        public void GetAllTasksForForUsers_InCorrectParameters_ReturnsEmptyObject()
        {
            IRepository<ToDoTasks, int> iRepository = Substitute.For<IRepository<ToDoTasks, int>>();

            List<ToDoTasks> taskUserExpected = new List<ToDoTasks>();
            taskUserExpected.Add(new ToDoTasks { CheckedDone = false, LastUpdated = System.DateTime.Now, TaskDescription = "someDescription", TaskUserId = 1, ToDoTaskId = 1 });

            iRepository.FindAll().Returns(taskUserExpected);

            ToDoTask toDoTasks = new ToDoTask(iRepository);

            List<ToDoTasks> taskUserActual = toDoTasks.GetAllTasksForUser(2);

            Assert.True (taskUserActual.Count == 0);

        }


        [Fact]
        public void GetTasks_CorrectParameters_ReturnsCorrectObject()
        {
            IRepository<ToDoTasks, int> iRepository = Substitute.For<IRepository<ToDoTasks, int>>();
            
            ToDoTasks toDoTaskExpected = new ToDoTasks
                    {
                        CheckedDone = false,
                        LastUpdated = System.DateTime.Now,
                        TaskDescription = "someDescription",
                        TaskUserId = 1,
                        ToDoTaskId = 1
                    };
            
            iRepository.FindBy (1).Returns(toDoTaskExpected);

            ToDoTask toDoTasks = new ToDoTask(iRepository);

            ToDoTasks taskUserActual = toDoTasks.GetTasks(1);

            Assert.Equal(toDoTaskExpected, taskUserActual);

        }
        
        [Fact]
        public void GetTasks_InCorrectParameters_ReturnsCorrectObject()
        {
            IRepository<ToDoTasks, int> iRepository = Substitute.For<IRepository<ToDoTasks, int>>();

            ToDoTasks toDoTaskExpected = new ToDoTasks
            {
                CheckedDone = false,
                LastUpdated = System.DateTime.Now,
                TaskDescription = "someDescription",
                TaskUserId = 1,
                ToDoTaskId = 1
            };

            iRepository.FindBy(1).Returns(toDoTaskExpected);

            ToDoTask toDoTasks = new ToDoTask(iRepository);

            ToDoTasks taskUserActual = toDoTasks.GetTasks(2);

            Assert.Null(taskUserActual);
        }
        
        [Fact]
        public void SaveNew_CorrectParameters_CallsSaveNew()
        {

            IRepository<ToDoTasks, int> iRepository = Substitute.For<IRepository<ToDoTasks, int>>();

            ToDoTasks toDoTask = new ToDoTasks
            {
                CheckedDone = false,
                LastUpdated = System.DateTime.Now,
                TaskDescription = "someDescription",
                TaskUserId = 1,
                ToDoTaskId = 1
            };
            
            ToDoTask toDoTasks = new ToDoTask(iRepository);
                        
            ToDoTaskRepository toDoTaskRepo = new ToDoTaskRepository(iRepository);
            toDoTaskRepo.SaveNew(toDoTask);
            
            iRepository.Received().Add(toDoTask);
        }
        
        [Fact]
        public void Save_CorrectParameters_CallsSaveNew()
        {

            IRepository<ToDoTasks, int> iRepository = Substitute.For<IRepository<ToDoTasks, int>>();

            ToDoTasks toDoTask = new ToDoTasks
            {
                CheckedDone = false,
                LastUpdated = System.DateTime.Now,
                TaskDescription = "someDescription",
                TaskUserId = 1,
                ToDoTaskId = 1
            };

            ToDoTask toDoTasks = new ToDoTask(iRepository);

            ToDoTaskRepository toDoTaskRepo = new ToDoTaskRepository(iRepository);
            toDoTaskRepo.UpdateTask (toDoTask);

            iRepository.Received().Save (toDoTask);
        }
    }
}
