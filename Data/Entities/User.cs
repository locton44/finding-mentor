using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Text;

namespace Data.Entities
{
    [Table("User")]
    public class User : IdentityUser
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        public double Balance { get; set; }

        public string MajorId { get; set; }
        [ForeignKey("MajorId")]
        public virtual Major Major { get; set; }

        public bool IsEnabledMentor { get; set; }
        public bool IsDisable { get; set; }

        public static ClaimsIdentity Identity { get; internal set; }

    }
}
