using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class UserViewModels
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public double Balance { get; set; }
        public Boolean IsEnabledMentor { get; set; }

    }
}
