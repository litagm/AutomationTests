using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;

namespace AutomationTests.Helpers
{
    public static class FileReader
    {
        public static string ReadJsonFile(string folderName, string fileName)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, folderName, fileName);
            return File.ReadAllText(path);
        }
    }
}
