using System;

namespace Lab_MVC.Models
{
    public class Train
    {
        public int TrainId { get; set; }

        public string TrainName { get; set; }

        public DateTime? DepartureTime { get; set; }

        public string Destination { get; set; }
    }
}