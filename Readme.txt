The zip file contains two parts, being the sample web app and the automation solution to test the app.

The sample web app is really simple. It just basically allows users to register, log in and edit their names after they have successfully logged in.

The automation solution has been set up properly to test the sample web app:

* The site URL, DB connection string and etc are configured properly to point to the sample web app in the App.config file under the automation solution directory.
* The automation framework has already taken care of the following:
  1. Standing data setup and tear-down have been set up in the feature hooks.
  2. Starting/stopping browsers have been setup in the scenario hooks.
  3. Taking screenshots have been set up in the scenario step hooks.
  4. Customised report generation has been setup up in the test run hooks.
  5. Acceptance criteria have been documented in the feature files.
  
What you need to do:

1. Create Page Objects to represent the screens of the sample web app.
2. Create and implement step definitions to acutally verify the acceptance criteria documented in feature files.
3. Enhance the framework if you can or raise any ideas of how to improve the automation framework.
4. Send us back the automation solution along with a most recently executed html report.

How to run the sample web app:
1. Open up the SampleWebApp.sln solution under the source folder.
2. Build the SampleWebApp solution.
3. Run it by clicking the Google Chrome button next to Debug





