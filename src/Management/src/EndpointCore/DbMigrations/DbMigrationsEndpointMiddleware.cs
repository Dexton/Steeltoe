// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Steeltoe.Management.Endpoint.Middleware;
using Steeltoe.Management.EndpointBase.DbMigrations;
using Steeltoe.Management.EndpointCore.ContentNegotiation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Steeltoe.Management.Endpoint.DbMigrations
{
    public class DbMigrationsEndpointMiddleware : EndpointMiddleware<Dictionary<string, DbMigrationsDescriptor>>
    {
        private RequestDelegate _next;

        public DbMigrationsEndpointMiddleware(RequestDelegate next, DbMigrationsEndpoint endpoint, IEnumerable<IManagementOptions> mgmtOptions, ILogger<DbMigrationsEndpointMiddleware> logger = null)
            : base(endpoint, mgmtOptions, logger: logger)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (RequestVerbAndPathMatch(context.Request.Method, context.Request.Path.Value))
            {
                await HandleEntityFrameworkRequestAsync(context);
            }
            else
            {
                await _next(context);
            }
        }

        protected internal async Task HandleEntityFrameworkRequestAsync(HttpContext context)
        {
            var serialInfo = HandleRequest();
            _logger?.LogDebug("Returning: {0}", serialInfo);

            context.HandleContentNegotiation(_logger);
            await context.Response.WriteAsync(serialInfo);
        }
    }
}