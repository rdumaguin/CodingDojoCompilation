using System;
using System.ComponentModel.DataAnnotations;

namespace Wall.Models
{
    public class CreateMessage
    {
        [Required(ErrorMessage="Please type a message first!")]
        public string Content {get;set;}
    }
    
    public class CreateComment
    {
        [Required(ErrorMessage="Please type a comment first!")]
        public string Content {get;set;}
        public string MessageId {get;set;}
    }
    
    public class WallBundle
    {
        public CreateMessage Message {get;set;}
        public CreateComment Comment {get;set;}
    }

}