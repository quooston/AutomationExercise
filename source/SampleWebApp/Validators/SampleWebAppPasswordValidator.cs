using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace SampleWebApp.Validators
{
    public class SampleWebAppPasswordValidator : IIdentityValidator<string>
    {
        public int RequiredLength { get; set; }
        public int MaxLength { get; set; }

        public SampleWebAppPasswordValidator(int minLength, int maxLength)
        {
            RequiredLength = minLength;
            MaxLength = maxLength;
        }

        public Task<IdentityResult> ValidateAsync(string item)
        {
            if (string.IsNullOrEmpty(item) || item.Length < RequiredLength)
            {
                return Task.FromResult(IdentityResult.Failed("Password should too short"));
            }

            if (item.Length > MaxLength)
            {
                return Task.FromResult(IdentityResult.Failed("Password should too long"));
            }

            string pattern = "^[A-Za-z0-9_\\.]+$";

            if (!Regex.IsMatch(item, pattern))
            {
                return Task.FromResult(IdentityResult.Failed("Invalid Password"));
            }

            return Task.FromResult<IdentityResult>(IdentityResult.Success);
        }
    }
}