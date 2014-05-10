using Ns.Utility.Core.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ns.Utility.Core.Service
{
    public interface IFileUploader
    {
        FileResult Upload(HttpPostedFileBase file, string directoryName, string fileName);
    }
}
