using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("StudentRegistration")]
    public class StudentRegistration : BaseEntity
    {
        public Guid StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        public Guid CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
