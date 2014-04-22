using Ns.Utility.Core.Model.Ranges;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Framework.DomainModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Projects
{
    public class RangeCreatedHandler : IHandles<RangeCreated>
    {
        private IRepository<Project> repository;
        private IUnitOfWork unitOfWork;

        public RangeCreatedHandler(IRepository<Project> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Handle(RangeCreated args)
        {
            var project = repository.Get(args.ProjectId);
            project.AssignRange();
            repository.Update(project);
            unitOfWork.Commit();
        }
    }
}
