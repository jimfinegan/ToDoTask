using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoTasks.Models
{
    /// <summary>
    /// The model of the user object
    /// </summary>
    public class TaskUser
    {
        /// <summary>
        /// The user id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The user name
        /// </summary>
        [DisplayName("User Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string UserName { get; set; }

        /// <summary>
        /// The password
        /// </summary>
        [DisplayName("Passowrd")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string UserPassword { get; set; }

        /// <summary>
        /// The returned error message if there is one.
        /// </summary>
        public string LoginErrorMessage { get; set; }
    }
}