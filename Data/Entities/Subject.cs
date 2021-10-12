using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Subject")]
    public class Subject 
    {
        [Key]
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public string Name { get; set; }

        public virtual ICollection<SubjectMajor> SubjectMajors { get; set; }
    }
}
