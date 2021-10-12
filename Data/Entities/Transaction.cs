using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Transaction")]
    public class Transaction: BaseEntity
    {
        public double Deposit { get; set; }
        public double Withdraw { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
