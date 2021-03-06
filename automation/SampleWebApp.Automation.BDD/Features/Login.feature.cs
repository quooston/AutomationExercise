﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SampleWebApp.Automation.BDD.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Login", new string[] {
            "Chrome"}, Description="\tIn order to view and update my personal information\r\n\tAs a user\r\n\tI want to logi" +
        "n to the website", SourceFile="Features\\Login.feature", SourceLine=1)]
    public partial class LoginFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Login.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Login", "\tIn order to view and update my personal information\r\n\tAs a user\r\n\tI want to logi" +
                    "n to the website", ProgrammingLanguage.CSharp, new string[] {
                        "Chrome"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void ARegisteredUserIsAbleToLogInWithValidCredentials(string exampleDescription, string username, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A registered user is able to log in with valid credentials", exampleTags);
#line 7
 this.ScenarioSetup(scenarioInfo);
#line 8
  testRunner.Given(string.Format("a user has already registered with a valid \'{0}\' and \'{1}\'", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
  testRunner.When("the user logs in with their valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
  testRunner.Then("the user is logged into the website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
  testRunner.And("the user can see their personal information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("A registered user is able to log in with valid credentials, Valid username and pa" +
            "ssword, static", SourceLine=14)]
        public virtual void ARegisteredUserIsAbleToLogInWithValidCredentials_ValidUsernameAndPasswordStatic()
        {
            this.ARegisteredUserIsAbleToLogInWithValidCredentials("Valid username and password, static", "\"somebody@planetinnovation.com.au\"", "\"password123\"", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("A registered user is able to log in with valid credentials, Valid username and pa" +
            "ssword, regex", SourceLine=14)]
        public virtual void ARegisteredUserIsAbleToLogInWithValidCredentials_ValidUsernameAndPasswordRegex()
        {
            this.ARegisteredUserIsAbleToLogInWithValidCredentials("Valid username and password, regex", "^[A-Za-z0-9]{1,60}@[A-Za-z0-9]{5,10}\\.[A-Za-z]{2,4}$", "^[A-Za-z0-9]{8,20}$", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("A registered user is able to log in with valid credentials, Valid username with m" +
            "inimum length (6)", SourceLine=14)]
        public virtual void ARegisteredUserIsAbleToLogInWithValidCredentials_ValidUsernameWithMinimumLength6()
        {
            this.ARegisteredUserIsAbleToLogInWithValidCredentials("Valid username with minimum length (6)", "^[A-Za-z0-9]{1}@[A-Za-z0-9]{1}\\.[A-Za-z]{2}$", "^[A-Za-z0-9]{8,20}$", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("A registered user is able to log in with valid credentials, Valid username with m" +
            "aximum length (76)", SourceLine=14)]
        public virtual void ARegisteredUserIsAbleToLogInWithValidCredentials_ValidUsernameWithMaximumLength76()
        {
            this.ARegisteredUserIsAbleToLogInWithValidCredentials("Valid username with maximum length (76)", "^[A-Za-z0-9]{60}@[A-Za-z0-9]{10}\\.[A-Za-z]{4}$", "^[A-Za-z0-9]{8,20}$", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("A registered user is able to log in with valid credentials, Valid password with m" +
            "inimum length (8)", SourceLine=14)]
        public virtual void ARegisteredUserIsAbleToLogInWithValidCredentials_ValidPasswordWithMinimumLength8()
        {
            this.ARegisteredUserIsAbleToLogInWithValidCredentials("Valid password with minimum length (8)", "^[A-Za-z0-9]{1,60}@[A-Za-z0-9]{5,10}\\.[A-Za-z]{2,4}$", "^[A-Za-z0-9]{8}$", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("A registered user is able to log in with valid credentials, Valid password with m" +
            "aximum length (20)", SourceLine=14)]
        public virtual void ARegisteredUserIsAbleToLogInWithValidCredentials_ValidPasswordWithMaximumLength20()
        {
            this.ARegisteredUserIsAbleToLogInWithValidCredentials("Valid password with maximum length (20)", "^[A-Za-z0-9]{1,60}@[A-Za-z0-9]{5,10}\\.[A-Za-z]{2,4}$", "^[A-Za-z0-9]{20}$", ((string[])(null)));
#line hidden
        }
        
        public virtual void ARegisteredUserIsNotAbleToLogInWithInvalidCredentials(string exampleDescription, string username, string password, string credentials, string errorMessage, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A registered user is not able to log in with invalid credentials", exampleTags);
#line 22
 this.ScenarioSetup(scenarioInfo);
#line 23
  testRunner.Given(string.Format("a user has already registered with a valid \'{0}\' and \'{1}\'", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
  testRunner.When(string.Format("the user attempts to log in with invalid \'{0}\'", credentials), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
  testRunner.Then("the user is not logged into the website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
  testRunner.And(string.Format("an \'{0}\' is returned for the corresponding field on the login page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("A registered user is not able to log in with invalid credentials, Valid username " +
            "and invalid password", SourceLine=29)]
        public virtual void ARegisteredUserIsNotAbleToLogInWithInvalidCredentials_ValidUsernameAndInvalidPassword()
        {
            this.ARegisteredUserIsNotAbleToLogInWithInvalidCredentials("Valid username and invalid password", "^[A-Za-z0-9]{1,60}@[A-Za-z0-9]{5,10}\\.[A-Za-z]{2,4}$", "^[A-Za-z0-9]{8,20}$", "Form", "Invalid login attempt.", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("A registered user is not able to log in with invalid credentials, Invalid usernam" +
            "e and valid password", SourceLine=29)]
        public virtual void ARegisteredUserIsNotAbleToLogInWithInvalidCredentials_InvalidUsernameAndValidPassword()
        {
            this.ARegisteredUserIsNotAbleToLogInWithInvalidCredentials("Invalid username and valid password", "^[A-Za-z0-9]{1,60}@[A-Za-z0-9]{5,10}\\.[A-Za-z]{2,4}$", "^[A-Za-z0-9]{8,20}$", "Form", "Invalid login attempt.", ((string[])(null)));
#line hidden
        }
        
        public virtual void UsernameOutOfBounds(string exampleDescription, string field, string username, string errorMessage, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Username out of bounds", exampleTags);
#line 34
 this.ScenarioSetup(scenarioInfo);
#line 35
  testRunner.Given("a user of the website is on the login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
  testRunner.When(string.Format("the user attempts to log in with a \'{0}\' \'{1}\' that is out of bounds", field, username), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
  testRunner.Then("the user is not logged into the website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
  testRunner.And(string.Format("an \'{0}\' is returned for the corresponding field on the login page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Username out of bounds, Empty username", SourceLine=41)]
        public virtual void UsernameOutOfBounds_EmptyUsername()
        {
            this.UsernameOutOfBounds("Empty username", "Username", "\"\"", "The Username field is required.", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Username out of bounds, Username is not a valid email address", SourceLine=41)]
        public virtual void UsernameOutOfBounds_UsernameIsNotAValidEmailAddress()
        {
            this.UsernameOutOfBounds("Username is not a valid email address", "Username", "^[A-Za-z0-9]{1,60}[A-Za-z0-9]{5,10}\\.[A-Za-z]{2,4}$", "Invalid Username", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Username out of bounds, Username with less than minimum length of characters (<6)" +
            "", SourceLine=41)]
        public virtual void UsernameOutOfBounds_UsernameWithLessThanMinimumLengthOfCharacters6()
        {
            this.UsernameOutOfBounds("Username with less than minimum length of characters (<6)", "Username", "^[A-Za-z0-9]{1}@[A-Za-z0-9]{1}\\.[A-Za-z]{1}$", "Username is too short", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Username out of bounds, Username with more than maximum length of characters (>76" +
            ")", SourceLine=41)]
        public virtual void UsernameOutOfBounds_UsernameWithMoreThanMaximumLengthOfCharacters76()
        {
            this.UsernameOutOfBounds("Username with more than maximum length of characters (>76)", "Username", "^[A-Za-z0-9]{60}@[A-Za-z0-9]{11}\\.[A-Za-z]{4}$", "Username is too long", ((string[])(null)));
#line hidden
        }
        
        public virtual void PasswordOutOfBounds(string exampleDescription, string field, string password, string errorMessage, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Password out of bounds", exampleTags);
#line 48
 this.ScenarioSetup(scenarioInfo);
#line 49
  testRunner.Given("a user of the website is on the login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
  testRunner.When(string.Format("the user attempts to log in with a \'{0}\' \'{1}\' that is out of bounds", field, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
  testRunner.Then("the user is not logged into the website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
  testRunner.And(string.Format("an \'{0}\' is returned for the corresponding field on the login page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Password out of bounds, Empty password", SourceLine=55)]
        public virtual void PasswordOutOfBounds_EmptyPassword()
        {
            this.PasswordOutOfBounds("Empty password", "Password", "\"\"", "The Password field is required.", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Password out of bounds, Password with unsupported characters", SourceLine=55)]
        public virtual void PasswordOutOfBounds_PasswordWithUnsupportedCharacters()
        {
            this.PasswordOutOfBounds("Password with unsupported characters", "Password", "^[A-Za-z0-9]{7,19}\\?$", "Invalid password", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Password out of bounds, Password with less than minimum length of characters (<8)" +
            "", SourceLine=55)]
        public virtual void PasswordOutOfBounds_PasswordWithLessThanMinimumLengthOfCharacters8()
        {
            this.PasswordOutOfBounds("Password with less than minimum length of characters (<8)", "Password", "^[A-Za-z0-9]{7}$", "Password is too short", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Password out of bounds, Password with more than maximum length of characters (>20" +
            ")", SourceLine=55)]
        public virtual void PasswordOutOfBounds_PasswordWithMoreThanMaximumLengthOfCharacters20()
        {
            this.PasswordOutOfBounds("Password with more than maximum length of characters (>20)", "Password", "^[A-Za-z0-9]{21}$", "Password is too long", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
