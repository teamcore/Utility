using Ns.Utility.Core.Model.Ranges;
using Ns.Utility.Web.Areas.Admin.Models;
using Ns.Utility.Web.Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Mapper
{
    public class RangeMapper : CollectionModelMapper<Range, RangeModel>
    {
        protected override void CreateEntityMap()
        {
            AutoMapper.Mapper.CreateMap<RangeModel, Range>()
                .ForMember(dest => dest.Next, opt => opt.Ignore());
        }

        protected override void CreateEntityUpdateMap()
        {
            AutoMapper.Mapper.CreateMap<Range, Range>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.Next, opt => opt.Ignore());
        }
    }
}