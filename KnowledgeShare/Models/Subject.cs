using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeShare.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // tutor - subject --> many-to-many
        public virtual ICollection<ApplicationUser> Tutors { get; set; } = new List<ApplicationUser>();
    }
}
