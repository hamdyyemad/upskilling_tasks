using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace filter_task_webapi.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Task description is required")]
        [StringLength(500)]
        public string Description { get; set; }

        public string Status { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [ForeignKey("TeamMember")]
        public int MemberId { get; set; }
        public TeamMember TeamMember { get; set; }
    }
} 