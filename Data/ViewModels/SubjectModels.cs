using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class SubjectAddModels
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
        public class SubjectUpdateModels
    {

        public string Description { get; set; }
        public string Name { get; set; }
    }
    public class SubjectViewModel
    {
        public String Id { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
