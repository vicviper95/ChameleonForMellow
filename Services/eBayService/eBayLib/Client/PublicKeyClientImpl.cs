﻿
/*
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
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using eBay.ApiClient.Auth.OAuth2;
using eBay.ApiClient.Auth.OAuth2.Model;
using EbayEventNotificationSDK.Exceptions;
using EbayEventNotificationSDK.Models;
using Microsoft.Extensions.Logging;
using static eBay.ApiClient.Auth.OAuth2.CredentialUtil;

namespace EbayEventNotificationSDK.Client
{
    public class PublicKeyClientImpl : IPublicKeyClient
    {

        private HttpClient httpClient;

        private static OAuth2Api oAuth2Api = new OAuth2Api();

        private readonly IConfigEbay config;

        private readonly ILogger<PublicKeyClientImpl> logger;


        public PublicKeyClientImpl(HttpClient httpClient, IConfigEbay configuration, ILogger<PublicKeyClientImpl> logger)
        {
            this.httpClient = httpClient;
            this.config = configuration;
            this.logger = logger;
        }

        public PublicKey getPublicKey(string keyId)
        {
            try
            {
                logger.LogInformation("keyId" + keyId);
                var baseURL = ClientConstants.GetEndPoints(config.environment);
                logger.LogInformation("baseURL" + baseURL);
                var token = fetchToken(config.environment);
                logger.LogInformation("token" + token);
                httpClient.DefaultRequestHeaders.Add(ClientConstants.Authorization, token);
                return httpClient.GetFromJsonAsync<PublicKey>(baseURL + keyId).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                var message = "Public Key retrieval failed with: " + ex.Message;
                logger.LogError(message);
                throw new ClientException(message, ex);
            }
        }


        public String fetchToken(string environment)
        {
            logger.LogInformation(1001, "enviroment: " + environment);
            var oAuthEnv = (environment != null && environment.Equals(Constants.Sandbox))
                ? OAuthEnvironment.SANDBOX : OAuthEnvironment.PRODUCTION;
            try
            {
                OAuthResponse oAuthResponse = oAuth2Api.GetApplicationToken(oAuthEnv, ClientConstants.scopes);
                return ClientConstants.Bearer + oAuthResponse.AccessToken.Token;
            }
            catch (Exception ex)
            {
                var message = "Fetch application token failed with: " + ex.Message;
                logger.LogError(message);
                throw new OAuthTokenException(message, ex);
            }
        }

        public String fetchTokenNoBearer(string environment)
        {
            logger.LogInformation(1001, "enviroment: " + environment);
            var oAuthEnv = (environment != null && environment.Equals(Constants.Sandbox))
                ? OAuthEnvironment.SANDBOX : OAuthEnvironment.PRODUCTION;
            try
            {
                OAuthResponse oAuthResponse = oAuth2Api.GetApplicationToken(oAuthEnv, ClientConstants.scopes);
                return oAuthResponse.AccessToken.Token;
            }
            catch (Exception ex)
            {
                var message = "Fetch application token failed with: " + ex.Message;
                logger.LogError(message);
                throw new OAuthTokenException(message, ex);
            }
        }
        public String fetchUserToken(string environment)
        {
            logger.LogInformation(1001, "enviroment: " + environment);
            var oAuthEnv = (environment != null && environment.Equals(Constants.Sandbox))
                ? OAuthEnvironment.SANDBOX : OAuthEnvironment.PRODUCTION;
            try
            {
                //OAuthResponse oAuthResponse = oAuth2Api.GetAccessToken(oAuthEnv, ,ClientConstants.scopes);
                //ClientConstants.scopes.RemoveAt(0);
                //ClientConstants.scopes.Add(HttpUtility.UrlEncode("https://api.ebay.com/oauth/api_scope"));
                //ClientConstants.scopes.Add(HttpUtility.UrlEncode("https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly"));
                //ClientConstants.scopes.Add(HttpUtility.UrlEncode("https://api.ebay.com/oauth/api_scope/sell.fulfillment"));
                OAuthResponse oAuthResponse = oAuth2Api.GetApplicationToken(oAuthEnv, ClientConstants.scopes);
                //OAuthResponse oAuthResponse2 = oAuth2Api.ExchangeCodeForAccessToken(oAuthEnv, oAuthResponse);
                return oAuthResponse.AccessToken.Token;
            }
            catch (Exception ex)
            {
                var message = "Fetch application token failed with: " + ex.Message;
                logger.LogError(message);
                throw new OAuthTokenException(message, ex);
            }
        }


    }
}
