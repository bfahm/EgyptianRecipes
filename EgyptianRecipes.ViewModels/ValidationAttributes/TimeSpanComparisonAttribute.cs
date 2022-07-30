using System;
using System.ComponentModel.DataAnnotations;

namespace EgyptianRecipes.ViewModels.ValidationAttributes
{
    public abstract class TimeSpanComparisonAttribute : ValidationAttribute
    {
        private readonly string _other;
        private readonly string _otherDisplayName;
        private readonly int _validator;
        private readonly string _validatorDisplayName;
        public TimeSpanComparisonAttribute(string other, string otherDisplayName, int validator, string validatorDisplayName)
        {
            _other = other;
            _otherDisplayName = otherDisplayName;
            _validator = validator;
            _validatorDisplayName = validatorDisplayName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_other);
            if (property == null)
            {
                return new ValidationResult(
                    string.Format("Unknown property: {0}", _other)
                );
            }
            var currentValue = (TimeSpan)value;
            var otherValue = (TimeSpan)property.GetValue(validationContext.ObjectInstance, null);

            if (TimeSpan.Compare(currentValue, otherValue) != _validator)
                return new ValidationResult($"This value should be {_validatorDisplayName} than {_otherDisplayName}");

            return null;
        }
    }
}
