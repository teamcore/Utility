using Ns.Utility.Core.Model.Resources;
using Ns.Utility.Web.Framework.Mapper;
using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Mapper
{
    public class TermMapper : CollectionModelMapper<Term, TermModel>
    {
        protected override void CreateEntityUpdateMap()
        {
            AutoMapper.Mapper.CreateMap<TermModel, Term>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore());
        }
    }
}