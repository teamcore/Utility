﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Web.Framework.Security
{
    public interface IUserSession
    {
        int UserId { get; }
        string UserName { get; }
        string DisplayName { get; }
        bool IsAdmin { get; }
        string ProjectName { get; }
        int ProjectID { get; }
        bool HasProject { get; }
    }
}
