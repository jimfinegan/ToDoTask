using System.Web;
using System.Web.Mvc;

namespace ToDoTasks
{
    /// <summary>
    /// Initialises the filters
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Sets the global filters
        /// </summary>
        /// <param name="filters">The Gloabl Filter collection</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}