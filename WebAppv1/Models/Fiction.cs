using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


public enum AvailableFictionTypes { Action, Fantasy, Adventure, Comedy }


namespace RecApp.Models
{
    public class Fiction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Author { get; set; }


        [Required]
        public AvailableFictionTypes FictionType { get; set; }

        public String Description { get; set; }


    }
}
