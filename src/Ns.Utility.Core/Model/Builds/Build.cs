using Ns.Utility.Core.Model.Projects;
using Ns.Utility.Core.Service;
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
    public class Build : Entity
    {
        private ProgressHandler publisher;

        protected Build() : this(string.Empty, string.Empty, string.Empty, 0)
        {

        }

        internal Build(string name, string changeSet, string release, int projectId)
        {
            Name = name;
            ChangeSet = changeSet;
            Release = release;
            ProjectId = projectId;
            Packages = new HashSet<Package>();
            Scripts = new HashSet<Script>();
            Files = new HashSet<File>();
            publisher = ProgressHandler.Instance;
        }

        public string Name { get; private set; }
        public string ChangeSet { get; private set; }
        public string Release { get; private set; }
        public int ProjectId { get; private set; }
        public Project Project { get; private set; }
        public ICollection<Package> Packages { get; private set; }
        public ICollection<Script> Scripts { get; private set; }
        public ICollection<File> Files { get; private set; }

        #region Behaviours

        public void BuildFileList()
        {
            publisher.Initialize();
            string path = @"C:\temp\" + Guid.NewGuid().ToString();
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
                publisher.Update("Temp folder created.");
            }

            var files = CopyTo(path);
            var extractPath = ExtractFiles(files);
            var extracts = Directory.EnumerateFiles(extractPath, "*.*", SearchOption.AllDirectories);
            foreach (var extract in extracts)
            {
                var fileName = extract.Replace(extractPath + "\\", "");
                var file = new File(System.IO.Path.GetFileName(fileName), System.IO.Path.GetExtension(fileName), fileName);
                file.AssociateToBuild(Id);
                Files.Add(file);
                publisher.Update(string.Format("File: {0}", fileName));
            }

            if (System.IO.Directory.Exists(path))
            {
                System.IO.Directory.Delete(path, true);
                publisher.Update("Cleaning up.");
            }

            publisher.Complete();
        }

        private string ExtractFiles(IEnumerable<string> files)
        {
            string path = System.IO.Path.GetDirectoryName(files.FirstOrDefault());
            string extractPath = System.IO.Path.Combine(path, "extract");

            foreach (var file in files)
            {
                using (ZipArchive archive = ZipFile.OpenRead(file))
                {
                    publisher.Update("Extractiing...");
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".pkg", StringComparison.OrdinalIgnoreCase))
                        {
                            publisher.Update("Extracting pkg file.");
                            string pkgName = System.IO.Path.GetFileNameWithoutExtension(entry.FullName);
                            string pkgPath = System.IO.Path.Combine(extractPath, pkgName);
                            string pkgFileName = string.Format("{0}.pkg", path);

                            if (!System.IO.Directory.Exists(pkgPath))
                            {
                                System.IO.Directory.CreateDirectory(pkgPath);
                            }

                            entry.ExtractToFile(pkgFileName);
                            ZipFile.ExtractToDirectory(pkgFileName, extractPath);
                        }
                    }
                }
            }

            return extractPath;
        }

        private IEnumerable<string> CopyTo(string path)
        {
            publisher.Update("Copying files.");
            ICollection<string> files = new HashSet<string>();
            foreach (var package in Packages)
            {
                string source = Path.Combine(package.Path, package.Name);
                string destination = Path.Combine(path, package.Name);
                System.IO.File.Copy(source, destination);
                files.Add(destination);
            }
            
            publisher.Update(string.Format("Renamed and move to temp folder: {0}", System.IO.Path.GetFileName(path)));

            return files;
        }

        #endregion
    }
}
