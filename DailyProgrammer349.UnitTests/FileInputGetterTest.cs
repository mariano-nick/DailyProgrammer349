using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailyProgrammer349.UnitTests
{
    [TestClass]
    public class FileInputGetterTest
    {
        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void StringConstructor_EmptyString_ThrowArgumentNullException()
        {
            var fih = new FileInputGetter("");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileInfoConstructor_NonExistantFile_ThrowsFileNotFoundException()
        {
            var fih = new FileInputGetter(new FileInfo(@"C:\temp\temp\temp.txt"));
        }
    }
}
