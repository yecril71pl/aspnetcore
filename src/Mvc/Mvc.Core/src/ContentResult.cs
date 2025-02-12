// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Mvc;

/// <summary>
/// A <see cref="ActionResult"/> that when executed will produce a response with content.
/// </summary>
public class ContentResult : ActionResult, IStatusCodeActionResult
{
    /// <summary>
    /// Gets or set the content representing the body of the response.
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// Gets or sets the Content-Type header for the response.
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    /// Gets or sets the HTTP status code.
    /// </summary>
    public int? StatusCode { get; set; }

    /// <inheritdoc />
    public override Task ExecuteResultAsync(ActionContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var executor = context.HttpContext.RequestServices.GetRequiredService<IActionResultExecutor<ContentResult>>();
        return executor.ExecuteAsync(context, this);
    }
}
