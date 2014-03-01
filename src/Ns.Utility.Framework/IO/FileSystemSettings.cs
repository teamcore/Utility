using Ns.Utility.Framework.Settings;

namespace Ns.Utility.Framework.IO
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