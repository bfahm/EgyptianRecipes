using EgyptianRecipes.ViewModels.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace EgyptianRecipes.ViewModels
{
    public class BranchViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title length should be 200 max.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Manager Name is required.")]
        [StringLength(250, ErrorMessage = "Manager Name length should be 250 max.")]
        public string ManagerName { get; set; }

        [Required(ErrorMessage = "Opening Hour is required.")]
        [TimeSpanLessThan(nameof(ClosingHour), "Closing Hour")]
        [TimeSpanInterval(30)]
        public TimeSpan OpeningHour { get; set; }

        [Required(ErrorMessage = "Closing Hour is required.")]
        [TimeSpanMoreThan(nameof(OpeningHour), "Opening Hour")]
        [TimeSpanInterval(30)]
        public TimeSpan ClosingHour { get; set; }
    }
}
