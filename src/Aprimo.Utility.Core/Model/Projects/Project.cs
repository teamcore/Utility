﻿using Aprimo.Utility.Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprimo.Utility.Core.Model.Projects
{
    [DomainSignature]
    public class Project : Entity
    {
        protected Project()
        {

        }

        internal Project(string name, string code, string description = "")
        {
            Name = name;
            Code = code;
            Description = description;
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }

    }
}