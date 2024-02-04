using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Domain.Repository
{
    public interface IAuthenticationService
    {
        bool VerifyPassword(string userName, string enteredPassword);
    }
}
