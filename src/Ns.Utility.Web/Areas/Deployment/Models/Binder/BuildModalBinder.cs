using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace Ns.Utility.Web.Areas.Deployment.Models.Binder
{
    public class BuildModalBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(BuildViewModel))
            {
                return false;
            }

            var bodyString = actionContext.Request.Content.ReadAsStringAsync().Result;

            return true;
        }
    }
}