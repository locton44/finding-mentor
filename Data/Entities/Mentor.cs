using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Mentor")]
    public class Mentor
    {
        [Key]
        [ForeignKey("UserId")]
        public Guid Id { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual Major Major { get; set; }

        public int Status { get; set; }
    }
}
