using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Major")]
    public class Major
    {

        public String Id { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<SubjectMajor> SubjectMajors { get; set; }

        public virtual ICollection<Mentor> Mentors { get; set; }
    }
}
