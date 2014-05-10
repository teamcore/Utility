using Ns.Utility.Core.Model.Builds;
using Ns.Utility.Web.Areas.Deployment.Models;
using Ns.Utility.Web.Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Mapper
{
    public class BuildMapper : CollectionModelMapper<Build, BuildModel>
    {
        protected override void CreateEntityMap()
        {
            AutoMapper.Mapper.CreateMap<BuildModel, Build>()
                .ForMember(dest => dest.Packages, opt => opt.Ignore())
                .ForMember(dest => dest.Scripts, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<PackageModel, Package>();
            AutoMapper.Mapper.CreateMap<FileModel, File>();
        }

        protected override void CreateEntityUpdateMap()
        {
            AutoMapper.Mapper.CreateMap<Build, Build>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.Packages, opt => opt.Ignore())
                .ForMember(dest => dest.Scripts, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<Package, Package>();
            AutoMapper.Mapper.CreateMap<File, File>();
        }

        protected override Build Mapping(BuildModel model)
        {
            Build build = base.Mapping(model);
            var packages = AutoMapper.Mapper.Map<IList<PackageModel>, IList<Package>>(model.Packages);
            foreach (var package in packages)
            {
                build.Packages.Add(package);
            }

            var scripts = AutoMapper.Mapper.Map<IList<FileModel>, IList<File>>(model.Scripts);
            foreach (var script in scripts)
            {
                build.Scripts.Add(script);
            }

            return build;
        }
    }
}