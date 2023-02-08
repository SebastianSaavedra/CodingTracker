using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Model
{
    public class CodingSession
    {
        public int Id { get; set; }

        [Required]
        public string? StartTime { get; set; }

        public string? EndTime { get; set; }

        public int Duration { get; set; }
    }
}
