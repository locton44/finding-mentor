using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SubjectMentor")]
    public class SubjectMentor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string MentorId { get; set; }
        [ForeignKey("MentorId")]
        public virtual User Mentor { get; set; }

        public string SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
