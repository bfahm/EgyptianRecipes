using System.ComponentModel.DataAnnotations;

namespace EgyptianRecipes.ViewModels.ValidationAttributes
{
    public class TimeSpanMoreThanAttribute : TimeSpanComparisonAttribute
    {
        public TimeSpanMoreThanAttribute(string other, string otherDisplayName) : base(other, otherDisplayName, 1, "more than")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
