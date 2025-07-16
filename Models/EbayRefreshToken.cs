using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EbayRefreshToken
    {
        public int TokenId { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiresTime { get; set; }
        public string TokenType { get; set; }
    }
}
