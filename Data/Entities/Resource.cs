using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Resource")]
    public class Resource : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public string Link { get; set; }
        public byte[] File { get; set; }

        public Guid SubjectMentorId { get; set; }
        [ForeignKey("SubjectMentorId")]
        public virtual SubjectMentor SubjectMentor { get; set; }
    }
}
