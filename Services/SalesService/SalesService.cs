using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Security.Claims;
using Chameleon.Models;
using Microsoft.AspNetCore.Http;
using Chameleon.DTOs.SalesReports;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace Chameleon.Services.SalesService
{
  public class SalesService : ISalesService
  {
    private readonly KOALAContext _kc;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public SalesService(IMapper mapper, KOALAContext kc, IHttpContextAccessor httpContextAccessor)
    {
      _kc = kc;
      _mapper = mapper;
      _httpContextAccessor = httpContextAccessor;
    }


  }
}
