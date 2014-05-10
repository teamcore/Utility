using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Shared
{
    public class FileResult
    {
        public FileResult(string name, string location, string downloadLink, string contentType, string extension)
        {
            Name = name;
            Location = location;
            DownloadLink = downloadLink;
            ContentType = contentType;
            Extension = extension;
        }

        public string Name { get; private set; }
        public string Location { get; private set; }
        public string DownloadLink { get; private set; }
        public string ContentType { get; private set; }
        public string Extension { get; private set; }
    }
}
