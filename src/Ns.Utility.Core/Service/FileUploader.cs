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

        public UploadedFile Upload(HttpPostedFile file, string directoryName, string fileName)
        {
            return Upload(file.InputStream, file.ContentLength, file.ContentType, directoryName, fileName, file.FileName);
        }

        public UploadedFile Upload(Stream stream, int contentLength, string contentType, string directoryName, string fileName, string originalFileName)
        {
            if (stream.Length == 0) return null;
            string path = storage.GetStoragePath(directoryName);
            var fileExtension = Path.GetExtension(originalFileName);
            var fullFileName = string.Format("{0}{1}", fileName, fileExtension);
            var fullPath = Path.Combine(path, fullFileName);
            var storageFile = storage.CreateFile(fullPath);
            var fileStream = storageFile.OpenWrite();

            // Create a FileStream object to write a stream to a file
            using (fileStream)
            {
                // Fill the bytes[] array with the stream data
                byte[] bytesInStream = new byte[contentLength];
                stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

                // Use FileStream object to write to the specified file
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }

            return new UploadedFile(fullFileName, originalFileName, storage.GetPublicUrl(Path.Combine(directoryName, fullFileName)), contentType, fileExtension);
        }
    }
}
