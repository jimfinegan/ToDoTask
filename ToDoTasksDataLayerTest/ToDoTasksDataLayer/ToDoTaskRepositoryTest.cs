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
            var iRepository = Substitute.For<IRepository<ToDoTasks, int>>();
            ToDoTasks taskExpected = new ToDoTasks { TaskUserId = 1 };

            iRepository.FindBy(Arg.Compat.Any<int>()).Returns<ToDoTasks>(taskExpected);

            ToDoTaskRepository toDoRepository = new ToDoTaskRepository(iRepository);

            ToDoTasks taskActual = toDoRepository.GetTasks(8);

            Assert.Equal(taskExpected, taskActual);
        }
    }
}
