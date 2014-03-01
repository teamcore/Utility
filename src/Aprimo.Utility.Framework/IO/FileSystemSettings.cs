using Aprimo.Utility.Framework.Settings;

namespace Aprimo.Utility.Framework.IO
{
    public class FileSystemSettings : ISetting
    {
        public static FileSystemSettings Default()
        {
            return new FileSystemSettings { DirectoryName = "" };
        }

        public string DirectoryName { get; set; }
    }
}