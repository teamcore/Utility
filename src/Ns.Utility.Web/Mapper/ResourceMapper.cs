using Ns.Utility.Core.Model.Resources;
using Ns.Utility.Web.Framework.Mapper;
using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Mapper
{
    public class ResourceMapper : CollectionModelMapper<Resource, ResourceModel>
    {
        protected override void CreateEntityMap()
        {
            AutoMapper.Mapper.CreateMap<ResourceModel, Resource>()
                .ForMember(dest => dest.DisplayText, opt => opt.Ignore());
        }

        protected override void CreateEntityUpdateMap()
        {
            AutoMapper.Mapper.CreateMap<Resource, Resource>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.DisplayText, opt => opt.Ignore());
        }
    }
}