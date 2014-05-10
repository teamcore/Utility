using Ns.Utility.Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Builds
{
    public class Package : Entity
    {
        protected Package()
        {

        }
        internal Package(string name, string path, float size, string description = "")
        {
            Name = name;
            Path = path;
            Size = size;
            Description = description;
            Files = new List<File>();
        }

        public string Name { get; private set; }
        public string Path { get; private set; }
        public float Size { get; private set; }
        public string Description { get; private set; }
        public IList<File> Files { get; private set; }

        public void ExtractFiles()
        {
            string path = @"C:\temp\" + Guid.NewGuid().ToString();
            if(!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            string sourceFileName = System.IO.Path.Combine(Path, Name);
            string destinationFileName = System.IO.Path.Combine(path, System.IO.Path.GetFileNameWithoutExtension(Name) + ".zip");
            System.IO.File.Move(sourceFileName, destinationFileName);

            using (ZipArchive archive = ZipFile.OpenRead(destinationFileName))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".pkg", StringComparison.OrdinalIgnoreCase))
                    {
                        string pkgFullPath = System.IO.Path.Combine(path, entry.FullName);
                        var pkgPath = pkgFullPath.Replace(".pkg", "");
                        
                        if (!System.IO.Directory.Exists(pkgPath))
                        {
                            System.IO.Directory.CreateDirectory(pkgPath);
                        }

                        entry.ExtractToFile(pkgFullPath);
                        
                        string extractPath = pkgPath + "\\extract";
                        if (!System.IO.Directory.Exists(extractPath))
                        {
                            System.IO.Directory.CreateDirectory(extractPath);
                        }
                        
                        ZipFile.ExtractToDirectory(pkgFullPath, extractPath);

                        var files = Directory.EnumerateFiles(extractPath, "*.*", SearchOption.AllDirectories);
                        foreach (var file in files)
                        {
                            var fileName = file.Replace(extractPath + "\\", "");
                            Files.Add(new File(System.IO.Path.GetFileName(fileName), System.IO.Path.GetExtension(fileName), fileName));
                        }
                    }
                }
            }

            if (System.IO.Directory.Exists(path))
            {
                System.IO.Directory.Delete(path, true);
            }
        }
    }
}
