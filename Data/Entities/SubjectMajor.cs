using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SubjectMajor")]
    public class SubjectMajor
    {
        public string SubjectId { get; set; }
        [Key, ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        public string MajorId { get; set; }
        [Key, ForeignKey("MajorId")]
        public virtual Major Major { get; set; }
    }
}
