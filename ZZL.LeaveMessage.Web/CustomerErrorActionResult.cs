using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZZL.LeaveMessage.Web
{
    public class CustomerErrorActionResult
    {
        private static readonly string _controller;

        static CustomerErrorActionResult()
        {
            _controller = "Error";
        }

        public static ActionResult NotFundResult => new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
        {
            controller = _controller,
            action = "NotFund"
        }));

        public static ActionResult BadRequestResult => new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
        {
            controller = _controller,
            action = "BadRequest"
        }));

        public static ActionResult ServerError => new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
        {
            controller = _controller,
            action = "ServerError"
        }));
    }
}