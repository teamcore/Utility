﻿using System.Web.Mvc;

namespace Ns.Utility.Web.Areas.Deployment
{
    public class DeploymentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Deployment";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Deployment_default",
                "Deployment/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "Ns.Utility.Web.Areas.Deployment.Controllers" }
            );
        }
    }
}