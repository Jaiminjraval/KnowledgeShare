using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeShare.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; }

        [StringLength(500)]
        public string? Bio { get; set; }

        // the subjects tutor teaches --> many-to-many
        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

        // requests sent by a Learner
        public virtual ICollection<SessionRequest> SentSessionRequests { get; set; } = new List<SessionRequest>();

        // requests received by a Tutor
        public virtual ICollection<SessionRequest> ReceivedSessionRequests { get; set; } = new List<SessionRequest>();
    }
}
