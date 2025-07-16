using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chameleon.Models;

namespace Chameleon.DTOs.Employee
{
  public class HomeAnnouncementNotificationsDTO
  {
    public Announcement announcement { get; set; }
    public string notifications { get; set; }
  }
}
