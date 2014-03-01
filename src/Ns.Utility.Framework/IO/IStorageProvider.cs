using System.Collections.Generic;

namespace Ns.Utility.Framework.IO
{
    public interface IStorageProvider
    {
        string GetPublicUrl(string path);
        string GetStoragePath(string path);
        IStorageFile GetFile(string path);
        IEnumerable<IStorageFile> ListFiles(string path);
        IEnumerable<IStorageFolder> ListFolders(string path);
        void CreateFolder(string path);
        void DeleteFolder(string path);
        void RenameFolder(string path, string newPath);
        void DeleteFile(string path);
        void RenameFile(string path, string newPath);
        IStorageFile CreateFile(string path);
    }
}