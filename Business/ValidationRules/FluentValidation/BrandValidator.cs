using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b=>b.Name).NotEmpty();
            RuleFor(b => b.Name).MinimumLength(2);
            RuleFor(b => b.Name).Must(IsLetterOrDigit).WithMessage("Marka adında özel karakter olamaz.");
            
        }

        private bool IsLetterOrDigit(string arg) 
        {
            foreach (char c in arg)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }                
            }
            return true;
        }
    }
}
