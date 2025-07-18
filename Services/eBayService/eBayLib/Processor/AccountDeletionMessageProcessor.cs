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
using System.Text.Json;
using Chameleon.DTOs.eBay;
using EbayEventNotificationSDK.Models;

namespace EbayEventNotificationSDK.Processor
{
    public class AccountDeletionMessageProcessor : BaseMessageProcessor 
    {

        public AccountDeletionMessageProcessor()
        { 
        }

        protected override void processInternal(Data data)
        {
            AccountDeletionData accountDeletionData = JsonSerializer.Deserialize<AccountDeletionData>(getJSONString(data));
            Console.WriteLine("userId:" + accountDeletionData.userId);
            Console.WriteLine("username:" + accountDeletionData.username);
        }

        private String getJSONString(object obj)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            return JsonSerializer.Serialize(obj, options);
        }

    }
}
