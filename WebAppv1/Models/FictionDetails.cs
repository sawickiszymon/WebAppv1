using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
public enum AvailableFictionTypes { Action, Fantasy, Adventure, Comedy}

namespace RecApp.Models
{
    public class FictionDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public AvailableFictionTypes FictionType { get; set; }

        [Required]
        public String Description { get; set; }

        public int FictionId { get; set; }

        [ForeignKey("FictionId")]
        public Fiction Fiction { get; set; }
    }
}
