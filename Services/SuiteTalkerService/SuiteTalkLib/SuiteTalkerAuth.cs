using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuitetalkerService;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Cryptography;
namespace Chameleon.Services.SuiteTalkerService.SuiteTalkLib
{
    
    public class SuiteTalkerAuth
    {
        private static NetSuitePortTypeClient _netSuitePortTypeClient;
        private static SearchPreferences _searchPreferences = new SearchPreferences();
        private static Preferences _preferences = new Preferences();
        private static PartnerInfo _partnerInfo = new PartnerInfo();
        private static bool _isProduction;
        public SuiteTalkerAuth(bool isProduction) 
        {
            _isProduction = isProduction;
            if(isProduction)
                _netSuitePortTypeClient = new NetSuitePortTypeClient(NetSuitePortTypeClient.EndpointConfiguration.NetSuitePort, "https://5459104.suitetalk.api.netsuite.com/services/NetSuitePort_2021_2");
            else
                _netSuitePortTypeClient = new NetSuitePortTypeClient(NetSuitePortTypeClient.EndpointConfiguration.NetSuitePort, "https://5459104-sb1.suitetalk.api.netsuite.com/services/NetSuitePort_2021_2");
        }
        public static PartnerInfo Partner
        {
            get
            {
                return _partnerInfo;
            }
            set
            {
                _partnerInfo = value; //""
            }
        }
        public static NetSuitePortTypeClient Client
        {
            get
            {
                return _netSuitePortTypeClient;
            }
            set
            {
                _netSuitePortTypeClient = value;
            }
        }
        public Preferences GetPreferences()
        {
            _preferences.warningAsErrorSpecified = true;
            _preferences.warningAsError = false;
            _preferences.ignoreReadOnlyFieldsSpecified = true;
            _preferences.ignoreReadOnlyFields = true;
            return _preferences;
        }
        public void SetSearchPreferences(bool bodyFieldsOnly, bool returnColumns)
        {
            _searchPreferences.bodyFieldsOnly = bodyFieldsOnly;
            _searchPreferences.returnSearchColumns = returnColumns;
            _searchPreferences.pageSize = 1000;
            _searchPreferences.pageSizeSpecified = true;
        }
        public static SearchPreferences GetSearchPreferences()
        {
            return _searchPreferences;
        }
        public static TokenPassport CreateTokenPassport()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string account;
            string consumerKey;
            string consumerSecret;
            string tokenId;
            string tokenSecret;
            if (_isProduction)
            {
               account = config["SuiteTalkerSetting_Product:Account"];
               consumerKey = config["SuiteTalkerSetting_Product:ConsumerKey"];
               consumerSecret = config["SuiteTalkerSetting_Product:ConsumerSecret"];
               tokenId = config["SuiteTalkerSetting_Product:TokenId"];
               tokenSecret = config["SuiteTalkerSetting_Product:TokenSecret"];
            }
            else
            {
                account = config["SuiteTalkerSetting_SendBox:Account"];
                consumerKey = config["SuiteTalkerSetting_SendBox:ConsumerKey"];
                consumerSecret = config["SuiteTalkerSetting_SendBox:ConsumerSecret"];
                tokenId = config["SuiteTalkerSetting_SendBox:TokenId"];
                tokenSecret = config["SuiteTalkerSetting_SendBox:TokenSecret"];
            }
            string nonce = ComputeNonce();
            long timestamp = ComputeTimestamp();
            TokenPassportSignature signature = ComputeSignature(account, consumerKey, consumerSecret, tokenId, tokenSecret, nonce, timestamp);

            TokenPassport tokenPassport = new TokenPassport();
            tokenPassport.account = account;
            tokenPassport.consumerKey = consumerKey;
            tokenPassport.token = tokenId;
            tokenPassport.nonce = nonce;
            tokenPassport.timestamp = timestamp;
            tokenPassport.signature = signature;
            return tokenPassport;
        }
        private static string ComputeNonce()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] data = new byte[20];
            rng.GetBytes(data);
            int value = Math.Abs(BitConverter.ToInt32(data, 0));
            return value.ToString();
        }
        private static long ComputeTimestamp()
        {
            return ((long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
        }
        private static TokenPassportSignature ComputeSignature(string compId, string consumerKey, string consumerSecret,
                           string tokenId, string tokenSecret, string nonce, long timestamp)
        {
            string baseString = compId + "&" + consumerKey + "&" + tokenId + "&" + nonce + "&" + timestamp;
            string key = consumerSecret + "&" + tokenSecret;
            string signature = "";
            var encoding = new ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes(key);
            byte[] baseStringBytes = encoding.GetBytes(baseString);
            using (var hmacSha256 = new HMACSHA256(keyBytes))
            {
                byte[] hashBaseString = hmacSha256.ComputeHash(baseStringBytes);
                signature = Convert.ToBase64String(hashBaseString);
            }
            TokenPassportSignature sign = new TokenPassportSignature();
            sign.algorithm = "HMAC-SHA256";
            sign.Value = signature;
            return sign;
        }

    }
}
