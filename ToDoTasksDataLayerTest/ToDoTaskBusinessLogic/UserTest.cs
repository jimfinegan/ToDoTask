using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTaskBusinessLogic;
using ToDoTasksDataLayer.Entities;
using ToDoTasksDataLayer.Repository;
using Xunit;

namespace ToDoTasksTest.ToDoTaskBusinessLogic
{
    public class UserTest
    {
        [Fact]
        public void Login_WithCorrectCreditentials_ReturnCorrectInt()
        {
            IRepository<TaskUsers, int> iRepository = Substitute.For<IRepository<TaskUsers, int>>();

            List<TaskUsers> taskUserReturned = new List<TaskUsers>();
            taskUserReturned.Add(new TaskUsers { UserId = 1, UserName = "test", UserPassword = "pwd123"});

            iRepository.FindAll().Returns(taskUserReturned);

            TaskUsers taskUsersExpected = taskUserReturned.FirstOrDefault();
            int expected = taskUsersExpected.UserId;

            User user = new User(iRepository);
            
            int actual = user.LoginUser("test", "pwd123");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Login_WithInCorrectCreditentials_ReturnCorrectInt()
        {
            IRepository<TaskUsers, int> iRepository = Substitute.For<IRepository<TaskUsers, int>>();

            List<TaskUsers> taskUserReturned = new List<TaskUsers>();
            taskUserReturned.Add(new TaskUsers { UserId = 1, UserName = "testx", UserPassword = "pwd123x" });

            iRepository.FindAll().Returns(taskUserReturned);

            TaskUsers taskUsersExpected = taskUserReturned.FirstOrDefault();
            int expected = 0; ;

            User user = new User(iRepository);

            int actual = user.LoginUser("test", "pwd123");

            Assert.Equal(expected, actual);
        }
    }
}
