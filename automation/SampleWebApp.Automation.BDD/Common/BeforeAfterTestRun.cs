using System.IO;
using TechTalk.SpecFlow;
using SampleWebApp.Automation.Helpers.Utility;

namespace SampleWebApp.Automation.BDD.Common
{
    [Binding]
    public class BeforeAfterTestRun
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
			// TODO:
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            // Copy all required java script files to view the test summary report
            // into the Report folder
            var srcReportDir = Path.Combine(DirectoryUtility.AssemblyDirectory, Constants.ReportFolderName);
            var jsFiles = Directory.GetFiles(srcReportDir, Constants.JavaScriptFileExt);
            var dstReportDir = Path.Combine(Directory.GetCurrentDirectory(), Constants.ReportFolderName);

            foreach (var jsFile in jsFiles)
            {
                var fileName = Path.GetFileName(jsFile);
                if (fileName != null)
                {
                    var destPathName = Path.Combine(dstReportDir, fileName);

                    if (fileName.ToLower().EndsWith(Constants.SortTableJaveScriptFile))
                        if (File.Exists(destPathName))
                            continue;
                    FileUtility.Copy(jsFile, destPathName);
                }
            }
        }
    }
}