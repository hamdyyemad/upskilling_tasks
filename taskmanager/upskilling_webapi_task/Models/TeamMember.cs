using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace upskilling_webapi_task.Models
{
    public class TeamMember
    {
        [Key]
        public int MemberId { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Member name is required")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Email address is not valid")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        public string Email { get; set; }

        public ICollection<TaskItem>? Tasks { get; set; }
    }
} 