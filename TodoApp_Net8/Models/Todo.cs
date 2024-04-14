using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp_Net8.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Summary { get; set; }
        public string? Detail { get; set; }
        public DateTime Limit { get; set; }
        public bool Done { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public User User { get; set; }

    }
}
