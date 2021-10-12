using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class MajorAddModel
    {
        public String Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }

    public class MajorViewModel
    {
        public String Id { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }

    public class MajorUpdateModel
    {
        
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
