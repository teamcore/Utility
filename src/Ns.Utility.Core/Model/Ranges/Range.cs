﻿using Ns.Utility.Core.Model.Projects;
using Ns.Utility.Framework.DomainModel;
using Ns.Utility.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Ranges
{
    [DomainSignature]
    public class Range : Entity
    {
        protected Range()
        {

        }

        internal Range(string name, int min, int max, int projectId)
            : this(name, string.Empty, min, max, projectId)
        {

        }

        internal Range(string name, string description, int min, int max, int projectId)
        {
            Name = name;
            Description = description;
            Min = min;
            Max = max;
            Next = min;
            IsExhausted = false;
            ProjectId = projectId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Min { get; private set; }
        public int Max { get; private set; }
        public int Next { get; private set; }
        public bool IsExhausted { get; private set; }
        public Project Project { get; private set; }
        public int ProjectId { get; private set; }

        #region Methods

        public int GetNextId()
        {
            if (IsExhausted) throw new RangeExhaustedException();
            int value = Next;
            IsExhausted = value >= Max;
            Next++;
            return value;
        }

        public void Renew(int max)
        {
            if (max <= Max) throw new FunctionalException("Invalid max value.");
            Max = max;
            IsExhausted = false;
        }

        #endregion
    }
}
