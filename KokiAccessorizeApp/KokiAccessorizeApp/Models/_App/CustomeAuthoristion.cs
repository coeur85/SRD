using System;
using System.Web;
using System.Web.Mvc;
//using Microsoft.AspNet.Identity;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using KokiDB;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
public class MagdiWebPagesAuthorize : AuthorizeAttribute
{
  //  public string DefaultURL { get; set; }
    protected override bool AuthorizeCore(HttpContextBase context)
    {
        try
        {
            KokiAccessorizeAppDBEntities db = new KokiAccessorizeAppDBEntities();
            var cu = _App.Current.User;
            int UID = cu.UserID; //context.User.Identity.GetUserId();
            if (UID == 0)
            {
                // string url = context.Request.Url.AbsolutePath;
                //if (string.IsNullOrEmpty(url)) { context.Response.Redirect("~/login/index"); }
                //else { context.Response.Redirect("~/login/index?returnUrl=" + url); }
                context.Response.Redirect("~/login/index");

                return false; }


            return true;
          
        }
        catch (Exception)
        {
            return false;
        }
    }
    
}


public class ApiAuthintication : AuthorizationFilterAttribute
{
    public override void OnAuthorization(HttpActionContext actionContext)
    {
        base.OnAuthorization(actionContext);
    }
}