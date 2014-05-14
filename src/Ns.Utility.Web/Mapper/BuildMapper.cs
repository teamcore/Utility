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
            AutoMapper.Mapper.CreateMap<SqlScriptModel, Script>();
        }

        protected override void CreateModelMap()
        {
            AutoMapper.Mapper.CreateMap<Build, BuildModel>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
                .ForMember(dest => dest.Packages, opt => opt.Ignore())
                .ForMember(dest => dest.Scripts, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<Package, PackageModel>();
            AutoMapper.Mapper.CreateMap<Script, SqlScriptModel>();
        }

        protected override void CreateEntityUpdateMap()
        {
            AutoMapper.Mapper.CreateMap<Build, Build>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.Packages, opt => opt.Ignore())
                .ForMember(dest => dest.Scripts, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<Package, Package>();
            AutoMapper.Mapper.CreateMap<Script, Script>();
        }

        protected override Build Mapping(BuildModel model)
        {
            Build build = base.Mapping(model);
            var packages = AutoMapper.Mapper.Map<ICollection<PackageModel>, ICollection<Package>>(model.Packages);
            foreach (var package in packages)
            {
                build.Packages.Add(package);
            }

            var scripts = AutoMapper.Mapper.Map<ICollection<SqlScriptModel>, ICollection<Script>>(model.Scripts);
            foreach (var script in scripts)
            {
                build.Scripts.Add(script);
            }

            return build;
        }

        protected override BuildModel Mapping(Build entity)
        {
            var model = base.Mapping(entity);
            var packages = AutoMapper.Mapper.Map<ICollection<Package>, ICollection<PackageModel>>(entity.Packages);
            foreach (var package in packages)
            {
                model.Packages.Add(package);
            }

            var scripts = AutoMapper.Mapper.Map<ICollection<Script>, ICollection<SqlScriptModel>>(entity.Scripts);
            foreach (var script in scripts)
            {
                model.Scripts.Add(script);
            }

            return model;
        }
    }
}