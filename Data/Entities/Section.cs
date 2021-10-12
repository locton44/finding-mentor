using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Section")]
    public class Section : BaseEntity
    {
        public string Title { get; set; }

        public Guid CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
