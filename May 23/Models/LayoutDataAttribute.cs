using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace May_23.Models
{
    public class LayoutDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var repo = new CandidatesRepository(Properties.Settings.Default.ConStr);
            filterContext.Controller.ViewBag.PendingCount = repo.GetPendingCount();
            filterContext.Controller.ViewBag.ConfirmedCount = repo.GetConfirmedCount();
            filterContext.Controller.ViewBag.RefusedCount = repo.GetRefusedCount();
            base.OnActionExecuted(filterContext);
        }
    }
}