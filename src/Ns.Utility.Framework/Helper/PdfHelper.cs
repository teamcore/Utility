using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Framework.Helper
{
    public class PdfHelper
    {
        public static string PdfToString(string fileName)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(fileName);
            StringBuilder buffer = new StringBuilder();
            foreach (PdfPageBase page in doc.Pages)
            {
                buffer.Append(page.ExtractText());
            }

            return buffer.ToString();
        }
    }
}
