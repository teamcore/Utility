using Ns.Utility.Core.Service;
using Ns.Utility.Framework.DomainModel;
using Ns.Utility.Framework.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Builds
{
    public class Package : Entity
    {
        protected Package()
        {
            Files = new HashSet<File>();
        }

        internal Package(string name, string path, float size, string description = "")
        {
            Name = name;
            Path = path;
            Size = size;
            Description = description;
            Files = new HashSet<File>();
        }

        public string Name { get; private set; }
        public string Path { get; private set; }
        public float Size { get; private set; }
        public string Description { get; private set; }
        public ICollection<File> Files { get; private set; }
        public int BuildId { get; private set; }
        public Build Build { get; private set; }

        public void AssociateToBuild(int buildId)
        {
            BuildId = buildId;
        }

        public void ExtractFiles()
        {
            var publisher = ProgressHandler.Instance;
            publisher.Initialize();
            publisher.Update("Copying files.");
            string path = @"C:\temp\" + Guid.NewGuid().ToString();
            if(!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            
            string sourceFileName = System.IO.Path.Combine(Path, Name);
            string destinationFileName = System.IO.Path.Combine(path, System.IO.Path.GetFileNameWithoutExtension(Name) + ".zip");
            System.IO.File.Copy(sourceFileName, destinationFileName);
            publisher.Update(string.Format("Renamed and move to temp folder: {0}", System.IO.Path.GetFileNameWithoutExtension(Name) + ".zip"));

            using (ZipArchive archive = ZipFile.OpenRead(destinationFileName))
            {
                publisher.Update("Extractiing...");
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".pkg", StringComparison.OrdinalIgnoreCase))
                    {
                        publisher.Update("Extracting pkg file.");
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
                            publisher.Update(string.Format("File: {0}", fileName));
                        }
                    }
                }
            }

            if (System.IO.Directory.Exists(path))
            {
                System.IO.Directory.Delete(path, true);
                publisher.Update("Cleaning up.");
            }

            publisher.Complete();
        }
    }
}
