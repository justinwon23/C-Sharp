using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BeltExam.Models;

namespace BeltExam.Models
{
    public class Event
    {
        [Key]
        public int EventId {get; set;}

        [Display(Name = "Title")]
        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
        public string Title { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "is required.")]
        [DataType(DataType.DateTime)]
        [FutureDate]
        public DateTime? EventDate { get; set; }

        [Required(ErrorMessage = "is required.")]

        public int Duration {get; set;}
        
        [Required(ErrorMessage = "is required.")]
        [Display(Name =" ")]
        public string TimeMeasure {get; set;}

        [Display(Name = "Description")]
        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserId {get; set;}
        public User Planner {get; set;}

        public List<EventUserJoin> EventUserJoins {get; set;}

        public string DateInNumbers(DateTime dateTime)
        {
            DateTime dateNumbers = dateTime;

            return dateNumbers.ToString("M/dd @ hh:m tt");
        }

    }
}