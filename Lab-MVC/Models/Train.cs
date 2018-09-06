using System;
using System.ComponentModel.DataAnnotations;

namespace Lab_MVC.Models
{
    public class Train
    {
        [Required]
        public int? TrainId { get; set; }

        [TrainNameValidation]
        public string TrainName { get; set; }

        public DateTime? DepartureTime { get; set; }

        public string Destination { get; set; }
    }
}