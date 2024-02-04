using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Domain.Entities
{
    public class AuthenticationResult
    {
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Message { get; set; }
    }
}
