using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

namespace WebDownloader
{
    public static class DownloadProcesser
    {
        private static string outputFolderPath = string.Empty;

        public static string OutputFolderPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(outputFolderPath))
                {
                    outputFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                return outputFolderPath;
            }
            set { outputFolderPath = value; }
        }

        private static List<TargetPageItem> pageList = new List<TargetPageItem>();

        public static List<TargetPageItem> PageList
        {
            get
            {
                return pageList;
            }
        }

        private static RemoteWebDriver webDriver = null;

        public static RemoteWebDriver WebDriver
        {
            get
            {
                if (webDriver == null)
                {
                    //ChromeDriver:谷歌浏览器,如果使用其他浏览器比如IE,需要使用其对应类
                    //ChromeDriverDirectory:不指定默认是当前运行路径文件夹里查找
                    webDriver = new ChromeDriver(options);
                }
                return webDriver;
            }
        }

        private static bool isThreadStop = false;

        public static void CloseDriver()
        {
            if (webDriver != null)
            {
                //关闭驱动
                webDriver.Quit();
            }
        }
        private static ChromeOptions options = new ChromeOptions()
        {
            //Chrome浏览器路径
            BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
        };

        public static Action doWhenFinish;

        public static Action doWhenStoped;

        public static Action doWhenOneTaskFinish;

        static DownloadProcesser()
        {
            options.AddArgument("--headless");
        }

        public static void AddPage(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("不能添加空地址");
            }

            if (!IsUrl(url))
            {
                throw new ArgumentException("非法的Url");
            }

            pageList.Add(LoadTargetItemInfo(url));
        }

        private static bool IsUrl(string url)
        {
            var regex = new Regex("^((https|http|ftp|rtsp|mms)?://)[^\\s]+");
            return regex.IsMatch(url);
        }

        private static TargetPageItem LoadTargetItemInfo(string url)
        {
            try
            {
                WebDriver.Navigate().GoToUrl(url);
                string audioUrl = WebDriver.FindElement(By.Id("audio")).GetAttribute("src");
                string userName = WebDriver.FindElement(By.ClassName("uname")).Text;
                string songName = WebDriver.FindElement(By.ClassName("title")).Text;
                string fileName = string.Format("{0} - {1}", userName, songName);

                return new TargetPageItem()
                {
                    Url = url,
                    TargetFileUrl = audioUrl,
                    Title = userName + " - " + songName,
                    Status = DownloadStatus.未下载
                };
            }
            catch (Exception ex)
            {
                throw new MethodAccessException("获取文件信息错误", ex);
            }
        }

        public static void Start()
        {
            Task[] tasks = new Task[pageList.Count];
            int index = 0;
            foreach (var item in pageList)
            {
                tasks[index++] = Task.Factory.StartNew(() =>
                {
                    if (!isThreadStop)
                    {
                        try
                        {
                            string extendFileName = item.TargetFileUrl.Substring(item.TargetFileUrl.LastIndexOf('.'));
                            if (!string.IsNullOrEmpty(HttpDownloadFile(item.TargetFileUrl, string.Empty, outputFolderPath + "\\" + item.Title + extendFileName)))
                            {
                                item.Status = DownloadStatus.下载完成;
                            }
                            else
                            {
                                item.Status = DownloadStatus.出错;
                            }
                        }
                        catch (Exception ex)
                        {
                            item.Status = DownloadStatus.出错;
                            throw new MethodAccessException(string.Format("文件下载出错：{0}", item.Title), ex);
                        }
                    }
                });
            }
            //等待所有任务结束
            Task.WaitAll(tasks);
            //执行回调
            if (isThreadStop)
            {
                doWhenStoped();
            }
            else
            {
                doWhenFinish();
            }
        }

        public static void Stop()
        {
            isThreadStop = true;
        }

        public static string HttpDownloadFile(string url, string param, string path)
        {
            byte[] bs = Encoding.UTF8.GetBytes(param);
            // 设置参数
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            System.Net.ServicePointManager.Expect100Continue = false;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            //发送请求并获取相应回应数据
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();

            //创建本地文件写入流
            Stream stream = new FileStream(path, FileMode.Create);

            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            return path;
        }
    }
}
