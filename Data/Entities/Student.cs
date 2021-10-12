using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [ForeignKey("UserId")]
        public Guid Id { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<StudentRegistration> StudentRegistrations { get; set; }
      
    }
}
