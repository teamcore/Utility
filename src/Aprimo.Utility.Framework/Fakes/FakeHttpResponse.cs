using System.Text;
using System.Web;

namespace Aprimo.Utility.Framework.Fakes
{
    public class FakeHttpResponse : HttpResponseBase
    {
        private readonly StringBuilder outputString = new StringBuilder();

        public string ResponseOutput
        {
            get { return outputString.ToString(); }
        }

        public override int StatusCode { get; set; }

        public override string RedirectLocation { get; set; }

        public override void Write(string s)
        {
            outputString.Append(s);
        }

        public override string ApplyAppPathModifier(string virtualPath)
        {
            return virtualPath;
        }
    }
}