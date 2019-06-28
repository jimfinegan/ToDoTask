using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using ToDoTasksDataLayer.Repository;
using ToDoTasksDataLayer.Entities;

namespace ToDoTasks
{
    public class IocConfigurator
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<RepositoryOrmlite<ToDoTasksDataLayer.Entities.ToDoTasks, int>>().As<IRepository<ToDoTasksDataLayer.Entities.ToDoTasks, int>>();
            builder.RegisterType<RepositoryOrmlite<TaskUsers, int>>().As<IRepository<TaskUsers, int>>();

            builder.RegisterType<Facade.ToDoTasksFacade>().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}