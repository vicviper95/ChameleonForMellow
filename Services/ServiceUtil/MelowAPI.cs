using System.Net.Http;
namespace Chameleon.Services.ServiceUtil
{
	public class APIClient
	{

		private static string baseUrl = "https://bpmsvr01:9461";

		public static MellowAPI Client
		{
			get
			{
				// Bypass the certificate
				HttpClientHandler clientHandler = new HttpClientHandler();
				clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

				HttpClient client = new HttpClient(clientHandler);
				return new MellowAPI(baseUrl, client);
			}
		}
	}
}
