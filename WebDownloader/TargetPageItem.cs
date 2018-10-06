using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDownloader
{
    public class TargetPageItem
    {
        public string Url { get; set; }

        public string TargetFileUrl { get; set; }

        public string Title { get; set; }

        public DownloadStatus Status { get; set; }
    }
}
