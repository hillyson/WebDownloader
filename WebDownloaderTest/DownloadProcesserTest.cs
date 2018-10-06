using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebDownloaderTest
{
    [TestClass]
    public class DownloadProcesserTest
    {
        [TestMethod]
        public void TestFileDownload()
        {
            string filePath = "D:\\Hillyson - 离兮.mp3";
            string path = WebDownloader.DownloadProcesser.HttpDownloadFile("http://qiniuuwmp3.changba.com/1105569687.mp3",
                string.Empty, filePath);
            Assert.IsTrue(File.Exists(filePath));
        }
    }
}
