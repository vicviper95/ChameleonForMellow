using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Parameters;
using RestSharp;

namespace Chameleon.Services.WalmartService
{
    public class WalmartAuth
    {
        private string _serviceName = "Walmart Supplier";
        static private string _channelType = "d62e611e-606e-41b9-96cf-38ee37331c47";
        private string _privateKey = "MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwggJdAgEAAoGBAJvSgCsssadWGLZjgvoeUWTAC+D4uqSYw8LAAhFvnsYHMIfGYqxQC3CpEwWm/rCcfpkYUFLwEkLcH2rWiPft406n7rVj5cvw7WSca4KIZjguDPvklv2e41Rrdfemxug3bzgzMhK6zYHKurcqWIJXm460Wd40Rk/+15k4VgLxLX03AgMBAAECgYBpBGi/MGMXHU6QdebLPW2r0kbvO5NG5XJiKdf6+lhurF/H0iukaFoddsXMNG1IiGBGO/2+t/AGwaYm8injtp9Pz1TRIdZsJlT9VHH/3DwVXgRXI/JHSj84OZYMjdA5A2yuTRi06TSjAqSECTXbOtr60vKj0UmW83Ce8gDN2nmOmQJBAOIHT53kLNeisBVyDAd8ULryBPQOAqOx4noDfeeOJtgVUnXToxfrheVkRIKFayZ/b5rdS4y0fmVjCXfr6WU7e1MCQQCwe/2cdrjqTbEpwD/mGuBKhKh5Bs167qlpRrcvPCWgZQ5gTz6zqiCfe3Hxup4fXgjX+P7InxKYPxeI6gc2aZ4NAkAZEBx48osyYfzKc/n3foZpJFr+QOt0AU6OnwKAAZg3D640GIKWLWyMciDSpD6sZycV8gHlmUIGtgOfw43+xqi3AkEAr0Dxf8aFqmasX4GB8scNo/JIOqb+tez6XojSsB1SYAz6Ublf0ppG+xhi9mETVKLUtWOV3zPYC0fb3yJHN0l6oQJBAJ21uFOv8/bnkFt4ZUewGYM4NT0xEN1oxgCN5RF/flzQv+0xFlUHY4L6ZoUL1pTA5g5WY2YpZNH+1iDLUa0RcSo=";
        static private string _consumerId = "fdd04513-ac0f-47f7-8b7a-eb3a48f70bcd";
        static private string _timesStamp;
        static private string _randomId;
        public WalmartAuth()
        {

        }

        public string GetSignature(string fullURL, string method)
        {
            _timesStamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeMilliseconds().ToString();
            _randomId = Guid.NewGuid().ToString();
            string sortedHashString = _consumerId + '\n' + fullURL + '\n' + method + '\n' + _timesStamp + '\n';
            byte[] encodedKeyBytes = Convert.FromBase64String(_privateKey);
            var stringToSignInBytes = Encoding.UTF8.GetBytes(sortedHashString);

            AsymmetricKeyParameter asymmetricKeyParameter = PrivateKeyFactory.CreateKey(encodedKeyBytes);
            RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
            ISigner signer = SignerUtilities.GetSigner("SHA-256withRSA");
            signer.Init(true, rsaKeyParameters);
            signer.BlockUpdate(stringToSignInBytes, 0, stringToSignInBytes.Length);
            var signature = signer.GenerateSignature();
            return Convert.ToBase64String(signature);
        }

        public IRestRequest setWmtHeader(IRestRequest request, string signture)
        {
            request.AddHeader("Accept", "application/xml");
            request.AddHeader("WM_CONSUMER.ID", ConsumerId);
            request.AddHeader("WM_SVC.NAME", "Walmart Supplier");
            request.AddHeader("WM_QOS.CORRELATION_ID", RandomId);
            request.AddHeader("WM_SEC.TIMESTAMP", TimesStamp);
            request.AddHeader("WM_SEC.AUTH_SIGNATURE", signture);
            request.AddHeader("WM_CONSUMER.CHANNEL.TYPE", ChannelType);
            return request;
        }

        static public string ChannelType { get => _channelType; }
        static public string ConsumerId { get => _consumerId; }
        static public string TimesStamp { get => _timesStamp; }
        static public string RandomId { get => _randomId; }
    }
}

