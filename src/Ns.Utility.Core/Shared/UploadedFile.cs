using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Shared
{
    public class UploadedFile
    {
        public UploadedFile(string name, string originalName, string location, string contentType, string extension)
        {
            Name = name;
            OriginalName = originalName;
            Location = location;
            ContentType = contentType;
            Extension = extension;
        }

        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Location { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }
    }
}
