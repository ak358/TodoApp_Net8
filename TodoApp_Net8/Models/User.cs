using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp_Net8.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        [ValidateNever]
        public Role Role { get; set; }

    }
}
