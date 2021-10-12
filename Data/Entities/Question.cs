using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Question")]
    public class Question : BaseEntity
    {
        public string Content { get; set; }

        public Guid StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        public Guid SectionId { get; set; }
        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }
    }
}
