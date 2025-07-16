using AutoMapper;
using Chameleon.Models;
using Chameleon.DTOs.Utility;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Chameleon.Services.UtilityService
{
  public class UtilityService : IUtilityService
  {
    private readonly KOALAContext _kc;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UtilityService(IMapper mapper, KOALAContext kc, IHttpContextAccessor httpContextAccessor)
    {
      _kc = kc;
      _mapper = mapper;
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> SendEmail(List<EmailAddressDTO> emailList, string titleOfEmail, string contentOfEmail)
    {
      string recipients = "";

      foreach (EmailAddressDTO tmpDto in emailList)
      {
        if (recipients == "")
        { recipients = tmpDto.LoginID; }
        else
        { recipients = recipients + "," + tmpDto.LoginID; }
      }

      using (SmtpClient client = new SmtpClient()
      {
        Host = "smtp.office365.com",
        Port = 587,
        UseDefaultCredentials = false, // This require to be before setting Credentials property
        DeliveryMethod = SmtpDeliveryMethod.Network,
        Credentials = new NetworkCredential("bpmadmin@bpmatt.com", "Bpm@94577!"), // you must give a full email address for authentication 
        TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
        EnableSsl = true // Set to avoid secure connection exception
      })

      {
        MailMessage message = new MailMessage()
        {
          From = new MailAddress("bpmadmin@bpmatt.com"), // sender must be a full email address
          Subject = titleOfEmail,
          IsBodyHtml = true,
          Body = contentOfEmail,
          BodyEncoding = System.Text.Encoding.UTF8,
          SubjectEncoding = System.Text.Encoding.UTF8,

        };
        var toAddresses = recipients.Split(',');
        foreach (var to in toAddresses)
        {
          message.To.Add(to.Trim());
        }

        try
        {
          client.Send(message);
        }
        catch (Exception ex)
        {
          Debug.WriteLine(ex.Message);
        }
      }

      return true;
    }







  } // End of class
}// End of nameplace
