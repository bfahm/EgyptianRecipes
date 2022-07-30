using System;

namespace EgyptianRecipes.Models
{
    public class BusinessException : Exception
    {
        public new string Message { get; set; }

        public BusinessException(string message)
        {
            Message = message;
        }
    }
}
