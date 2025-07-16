using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.Services
{
    public class MailService
    {
		public static void Send(string eSubject, string eBody, string eToAddr, string eCCAddr, bool isBodyHtml = false, List<string> fileNames = null)
		{
			Send(eSubject, eBody, new List<string> { eToAddr }, new List<string> { eCCAddr }, isBodyHtml, fileNames);
		}
		public static void Send(string eSubject, string eBody, List<string> eToAddr, string eCCAddr, bool isBodyHtml = false, List<string> fileNames = null)
		{
			Send(eSubject, eBody, eToAddr, new List<string> { eCCAddr }, isBodyHtml, fileNames);
		}
		public static void Send(string eSubject, string eBody, string eToAddr, List<string> eCCAddr, bool isBodyHtml = false, List<string> fileNames = null)
		{
			Send(eSubject, eBody, new List<string> { eToAddr }, eCCAddr, isBodyHtml, fileNames);
		}
		public static void Send(string eSubject, string eBody, List<string> eToAddr, List<string> eCCAddr, bool isBodyHtml = false, List<string> fileNames = null)
		{
			if (eToAddr == null || eToAddr.Count == 0)
				return;

			try
			{
				var bodyBuilder = new BodyBuilder();
				if (isBodyHtml)
					bodyBuilder.HtmlBody = eBody;
				else
				{
					StringBuilder htmlBody = new StringBuilder();
					htmlBody.AppendLine("<p>");
					htmlBody.AppendLine(eBody.Replace("\r\n", "<br/>").Replace("\n", "<br/>"));
					htmlBody.AppendLine("<br/>");
					htmlBody.AppendLine("<br/>");
					htmlBody.AppendLine("<b>");
					htmlBody.AppendLine("***PLEASE DO NOT RESPOND TO THIS MESSAGE***");
					htmlBody.AppendLine("</b>");
					htmlBody.AppendLine("</p>");
					bodyBuilder.HtmlBody = htmlBody.ToString();
				}

				// Attachments
				if (fileNames != null)
				{
					foreach (var file in fileNames)
					{
						bodyBuilder.Attachments.Add(file);
					}
				}

				MimeMessage message = new MimeMessage();
				message.Subject = eSubject;
				message.Body = bodyBuilder.ToMessageBody();
				message.From.Add(new MailboxAddress("BPM Admin", "bpmadmin@bpmatt.com"));
				message.ReplyTo.Add(new MailboxAddress("Do Not Reply", "no-reply@bpmatt.com"));

				foreach (var to in eToAddr)
					message.To.Add(MailboxAddress.Parse(to));

				if (eCCAddr != null)
				{
					foreach (var cc in eCCAddr.FindAll(x => string.IsNullOrEmpty(x) == false))
						message.Cc.Add(MailboxAddress.Parse(cc));
				}

				using (var client = new MailKit.Net.Smtp.SmtpClient())
				{
					try
					{
						client.Connect("outlook.office365.com", 587, SecureSocketOptions.StartTls);

						// Note: only needed if the SMTP server requires authentication
						client.Authenticate("bpmadmin@bpmatt.com", "Bpm@94577!");

						client.Send(message);
						client.Disconnect(true);
					}
					catch (Exception ex) 
					{ 
					}
				}
			}
            catch (Exception ex)
            { 
			}
		}
	}
}
