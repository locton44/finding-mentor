using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class CourseAddModels
    {
     
        public string SubjectId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Guid MentorId { get; set; }
        public DateTime StartDate { get; set; } 
    }

    public class CourseUpdateModels
    {
        public string SubjectId { get; set; }
        public Guid MentorId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
    }
    public class CourseViewModel
    {
        public string SubjectId { get; set; }
        public Guid MentorId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
