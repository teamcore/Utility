using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Models
{
    public class ScriptModel
    {
        public ScriptModel()
        {
            ResourceIDs = new List<int>();
        }

        public string Script { get; set; }
        public List<int> ResourceIDs { get; private set; }
    }
}