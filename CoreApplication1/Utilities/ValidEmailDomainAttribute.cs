using System.ComponentModel.DataAnnotations;

namespace CoreApplication1.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string _allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            _allowedDomain = allowedDomain;
        }

        public override bool IsValid(object value)
        {
            string[] strings1 = value.ToString().Split('@');

            return strings1[1].ToUpper() == _allowedDomain.ToUpper();
        }

    }
}









