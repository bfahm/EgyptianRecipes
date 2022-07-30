using System;
using System.ComponentModel.DataAnnotations;

namespace EgyptianRecipes.ViewModels.ValidationAttributes
{
    public class TimeSpanIntervalAttribute : ValidationAttribute
    {
        private readonly int _interval;

        public TimeSpanIntervalAttribute(int interval)
        {
            _interval = interval;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (TimeSpan)value;

            if (currentValue.TotalMinutes % _interval != 0)
                return new ValidationResult($"This value should have an interval of 30 mins.");

            return null;
        }
    }
}
