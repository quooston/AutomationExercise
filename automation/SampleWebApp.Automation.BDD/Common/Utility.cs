using Fare;
using SampleWebApp.Automation.Helpers.Extensions;
using SampleWebApp.Automation.BDD.ContextClasses;

namespace SampleWebApp.Automation.BDD.Common
{
    public static class Utility
    {
        public static Credential GenerateRandomCredential(string usernameRegex, string passwordRegex)
        {
            if (!usernameRegex.IsValidRegexPattern() ||
                !passwordRegex.IsValidRegexPattern())
                return null;

            var usernameGenerator = new Xeger(usernameRegex);
            var passwordGenerator = new Xeger(passwordRegex);

            var credential = new Credential
            {
                Username = usernameGenerator.Generate(),
                Password = passwordGenerator.Generate()
            };
            return credential;
        }

        public static PersonalInformation GenerateRandomPersonalInformation(string familyNameRegex,
            string givenNameRegex)
        {
            if (!familyNameRegex.IsValidRegexPattern() ||
                !givenNameRegex.IsValidRegexPattern())
                return null;

            var familyNameGenerator = new Xeger(familyNameRegex);
            var givenNameGenerator = new Xeger(givenNameRegex);

            var personalInformation = new PersonalInformation
            {
                FamilyName = familyNameGenerator.Generate(),
                GivenName = givenNameGenerator.Generate()
            };
            return personalInformation;
        }
    }
}