﻿/*
 * Copyright (c) 2021 eBay Inc.
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 *
 */

using System;
using Microsoft.Extensions.Configuration;

namespace EbayEventNotificationSDK
{
    public class ConfigEbay : IConfigEbay
    {

        public ConfigEbay(IConfiguration configuration)
        {
            this.ClientCredentialsFile = configuration["ClientCredentialsFile"];
            this.environment = configuration["environment"];
            this.endpoint = configuration["endpoint"];
            this.verificationToken = configuration["verificationToken"];
        }

        public string ClientCredentialsFile { get; set; }
        public string environment { get; set; }
        public string endpoint { get; set; }
        public string verificationToken { get; set; }
    }
}
