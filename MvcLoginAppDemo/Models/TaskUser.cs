using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoTasks.Models
{
    public class TaskUser
    {

        public int UserId { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string UserName { get; set; }

        [DisplayName("Passowrd")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string UserPassword { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}