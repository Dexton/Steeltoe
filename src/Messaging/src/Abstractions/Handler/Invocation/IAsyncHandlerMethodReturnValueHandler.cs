﻿// Copyright 2017 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Reflection;

namespace Steeltoe.Messaging.Handler.Invocation
{
    /// <summary>
    /// TODO: Evaluate if this can be removed
    /// </summary>
    public interface IAsyncHandlerMethodReturnValueHandler : IHandlerMethodReturnValueHandler
    {
        /// <summary>
        /// TODO: Evaluate if this can be removed
        /// </summary>
        /// <param name="returnValue">the value</param>
        /// <param name="parameterInfo">the return type info</param>
        /// <returns>true if the return type represents a async value</returns>
        bool IsAsyncReturnValue(object returnValue, ParameterInfo parameterInfo);
    }
}
