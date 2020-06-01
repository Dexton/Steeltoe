﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

using System;

namespace Steeltoe.Management.Endpoint
{
    public interface IEndpoint
    {
        string Id { get; }

        bool Enabled { get; }

        [Obsolete("Use Exposure options instead")]
        bool Sensitive { get; }

        IEndpointOptions Options { get; }

        string Path { get; }
    }

    public interface IEndpoint<out TResult> : IEndpoint
    {
        TResult Invoke();
    }

    public interface IEndpoint<out TResult, in TRequest> : IEndpoint
    {
        TResult Invoke(TRequest arg);
    }
}
