using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptianRecipes.Models
{
    public class Booking
    {
        public long Id { get; set; }

        public long BranchId { get; set; }

        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }

        [MaxLength(100)]
        public string CustomerName { get; set; }
        [MaxLength(20)]
        public string CustomerPhoneNumber { get; set; }
        [MaxLength(100)]
        public string CustomerEmail { get; set; }
    }
}
