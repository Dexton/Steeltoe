﻿//
// Copyright 2015 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Extensions.Logging;
using Xunit;


namespace SteelToe.Discovery.Eureka.ITest
{
    public class DiscoveryClientTest : AbstractBaseTest
    {


        [Fact]
        public void ClientRegisters_And_FetchesRegistry()
        {

            var logFactory = new LoggerFactory();
            logFactory.MinimumLevel = LogLevel.Debug;
            logFactory.AddConsole(minLevel: LogLevel.Debug);

            var clientConfig = new EurekaClientConfig()
            {
                RegistryFetchIntervalSeconds = 1
            };

            var instConfig = new EurekaInstanceConfig()
            {
                AppName = "MyTestApp",
                LeaseRenewalIntervalInSeconds = 1,
                IsInstanceEnabledOnInit = true
            };

            DiscoveryManager.Instance.Initialize(clientConfig, instConfig, logFactory);

            bool foundApp = false;
            for (int i = 0; i < 30; i++)
            {
                // Can take a while before app is returned from Eureka server
                System.Threading.Thread.Sleep(2000);
                var client = DiscoveryManager.Instance.Client;
                var apps = client.Applications.GetRegisteredApplications();
                Assert.NotNull(apps);
                if (apps.Count == 1)
                {
                    if ("MyTestApp".ToUpperInvariant().Equals(apps[0].Name))
                    {
                        foundApp = true;
                        client.ShutdownAsyc();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    }
                }
            }

            Assert.True(foundApp);
        }
    }
}
