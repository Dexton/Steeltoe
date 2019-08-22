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

using Steeltoe.Management.Census.Common;
using Steeltoe.Management.Census.Internal;
using System;

namespace Steeltoe.Management.Census.Tags
{
    [Obsolete("Use OpenCensus project packages")]
    internal sealed class NoopTagger : TaggerBase
    {
        internal static readonly ITagger INSTANCE = new NoopTagger();

        public override ITagContext Empty
        {
            get
            {
                return NoopTags.NoopTagContext;
            }
        }

        public override ITagContext CurrentTagContext
        {
            get
            {
                return NoopTags.NoopTagContext;
            }
        }

        public override ITagContextBuilder EmptyBuilder
        {
            get
            {
                return NoopTags.NoopTagContextBuilder;
            }
        }

        public override ITagContextBuilder ToBuilder(ITagContext tags)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags));
            }

            return NoopTags.NoopTagContextBuilder;
        }

        public override ITagContextBuilder CurrentBuilder
        {
            get
            {
                return NoopTags.NoopTagContextBuilder;
            }
        }

        public override IScope WithTagContext(ITagContext tags)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags));
            }

            return NoopScope.INSTANCE;
        }
    }
}