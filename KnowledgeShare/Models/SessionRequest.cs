using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowledgeShare.Models
{
    public class SessionRequest
    {
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        public string LearnerId { get; set; }
        [ForeignKey("LearnerId")]
        public virtual ApplicationUser Learner { get; set; }

        public string TutorId { get; set; }
        [ForeignKey("TutorId")]
        public virtual ApplicationUser Tutor { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
