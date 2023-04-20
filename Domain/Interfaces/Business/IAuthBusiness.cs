using Aodren.Domain.Models;
using Aodren.Domain.Models.Requests.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aodren.Domain.Interfaces.Business
{
    public interface IAuthBusiness
    {
        TokenModel ConnectUser(ConnectUserRequest request);
    }
}
