using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class MentorAddModel
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Status { get; set; }
        public string MajorId { get; set; }
    }

    public class MentorViewModel
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Status { get; set; }
        public string MajorId { get; set; }
        public double Balance { get; set; }     
        public bool IsEnabledMentor { get; set; }
        public bool IsDisable { get; set; }
    }
    public class MentorUpdateModel
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Status { get; set; }
        public string MajorId { get; set; }
    }
}
