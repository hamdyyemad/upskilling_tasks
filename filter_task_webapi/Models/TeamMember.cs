using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace filter_task_webapi.Models
{
    public class TeamMember
    {
        [Key]
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Member name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100)]
        public string Email { get; set; }

        public ICollection<TaskItem>? Tasks { get; set; }
    }
} 