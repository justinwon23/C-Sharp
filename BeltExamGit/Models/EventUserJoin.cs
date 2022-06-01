using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeltExam.Models
{
    public class EventUserJoin
    {
        [Key]
        public int EventUserJoinId {get; set;}


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserId {get; set;}
        public User User {get; set;}

        public int EventId {get ;set;}
        public Event Event {get; set;}
        
    }
}