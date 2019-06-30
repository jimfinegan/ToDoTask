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
    public class TaskUserRepository
    {
        [Fact]
        public void LoginUser_CorrectParameters_ReturnsCorrectObject()
        {
            IRepository<TaskUsers, int> iRepository = Substitute.For<IRepository<TaskUsers, int>>();

            List< TaskUsers> taskUserReturned = new List<TaskUsers>();
            taskUserReturned.Add(new TaskUsers());

            iRepository.FindAll().Returns(taskUserReturned);

            TaskUsers taskUsersExpected = taskUserReturned.FirstOrDefault();
            
            TaskUsers taskUsersActual = iRepository.FindAll().FirstOrDefault();

            Assert.Equal(taskUsersExpected, taskUsersActual); 
        }
        
    }
}
