using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class StudentAddModel
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Status { get; set; }
        public string MajorId { get; set; }
    }

    public class StudentViewModel
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Status { get; set; }
        public string MajorId { get; set; }
        public double Balance { get; set; }
        public bool IsDisable { get; set; }
    }
    public class StudentUpdateModel
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Status { get; set; }
        public string MajorId { get; set; }
    }
}
