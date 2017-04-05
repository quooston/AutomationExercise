using System.IO;

namespace SampleWebApp.Automation.Helpers.Utility
{
    public class FileUtility
    {
        public static void Copy(string srcFile, string dstFile, bool overwrite = true)
        {
            if (File.Exists(srcFile))
            {
                string parentDirectory = null;
                var directoryInfo = new DirectoryInfo(dstFile).Parent;
                if (directoryInfo != null)
                    parentDirectory = directoryInfo.FullName;

                if ((parentDirectory != null) && !Directory.Exists(parentDirectory))
                    Directory.CreateDirectory(parentDirectory);
                File.Copy(srcFile, dstFile, overwrite);
            }
        }
    }
}