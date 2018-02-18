using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class RSVP
    {
        [Key]
        public int RsvpId {get;set;}
        public int UserId {get;set;}
        public User Guest {get;set;}
        public int WeddingId {get;set;}
        public WeddingPlanned WeddingRSVP {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        public RSVP()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}