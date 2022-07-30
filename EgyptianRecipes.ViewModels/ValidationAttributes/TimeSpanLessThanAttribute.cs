using System.ComponentModel.DataAnnotations;

namespace EgyptianRecipes.ViewModels.ValidationAttributes
{
    public class TimeSpanLessThanAttribute : TimeSpanComparisonAttribute
    {
        public TimeSpanLessThanAttribute(string other, string otherDisplayName) : base(other, otherDisplayName, -1, "less than")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
