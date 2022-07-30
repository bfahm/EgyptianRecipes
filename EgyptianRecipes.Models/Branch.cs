using System;
using System.ComponentModel.DataAnnotations;

namespace EgyptianRecipes.Models
{
    public class Branch
    {
        public long Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string ManagerName { get; set; }

        public TimeSpan OpeningHour { get; set; }
        public TimeSpan ClosingHour { get; set; }
    }
}
