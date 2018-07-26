using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IFileDownLoader
    {
        void DownLoadFile(string url, string path);
    }

    class FileDownLoader : IFileDownLoader
    {
        /* This method encapsulates the code that touches an external resource
           inside the FileDownLoader class. This allows it to be extracted to an 
           interface and have the ability to be mocked for unit testing.
        */
        public void DownLoadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}
