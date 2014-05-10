using Ns.Utility.Core.Shared;
using Ns.Utility.Framework.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ns.Utility.Core.Service
{
    public class FileUploader : IFileUploader
    {
        private readonly IStorageProvider storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUploader"/> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        public FileUploader(IStorageProvider storage)
        {
            this.storage = storage;
        }

        public FileResult Upload(HttpPostedFileBase file, string directoryName, string fileName)
        {
            string path = storage.GetStoragePath(directoryName);
            var extension = Path.GetExtension(fileName);
            var fullPath = Path.Combine(path, fileName);
            storage.CreateFolder(path);
            file.SaveAs(fullPath);
            return new FileResult(fileName, path, storage.GetPublicUrl(Path.Combine(directoryName, fileName)), file.ContentType, extension);
        }
    }
}
