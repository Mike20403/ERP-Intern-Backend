﻿using DotNetStarter.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class HasPrivilegeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _privilege;

        public HasPrivilegeAttribute(string privilege)
        {
            _privilege = privilege;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                return;
            }

            var privileges = context.HttpContext.GetCurrentUserPrivileges();

            var isAuthorized = privileges.Contains(_privilege);
            if (!isAuthorized)
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                return;
            }
        }
    }
}
