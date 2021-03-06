﻿using Ns.Utility.Core.Model.Builds;
using Ns.Utility.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Data.Mapping.Core
{
    public class FileMap : EntityMapping<File>
    {
        public FileMap()
        {
            HasRequired(x => x.Build).WithMany(x => x.Files).HasForeignKey(x => x.BuildId).WillCascadeOnDelete(false);
        }
    }
}
