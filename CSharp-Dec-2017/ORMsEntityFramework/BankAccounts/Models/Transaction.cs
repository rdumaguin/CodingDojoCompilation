using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class Transaction
    {
        [Key]
        public int Id {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}
        public float Amount {get;set;} // Each instance holds a certain amount withdrawn/deposited
        public DateTime CreatedAt {get;set;}

        public DateTime UpdatedAt {get;set;}
        public Transaction()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}