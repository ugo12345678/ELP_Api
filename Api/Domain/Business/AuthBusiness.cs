using Aodren.Domain.Interfaces.Business;
using Aodren.Domain.Interfaces.Managers;
using Aodren.Domain.Models;
using Aodren.Domain.Models.Config;
using Aodren.Domain.Models.Requests.Auth;
using Aodren.Domain.Tools;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aodren.Domain.Business
{
    public class AuthBusiness : IAuthBusiness
    {
        public IUtilisateurManager _utilisateurManager;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public AuthBusiness(IUtilisateurManager utilisateurManager, IOptions<JwtSettings> jwtSettings)
        {
            _utilisateurManager = utilisateurManager;
            _jwtSettings = jwtSettings;
        }

        public TokenModel ConnectUser(ConnectUserRequest request)
        {
            TokenModel result = null;
            var existingTineos = _utilisateurManager.AuthenticateUtilisateur(request.Mail, request.Password);
            if (existingTineos != null)
            {
                result = new TokenModel
                {
                    Mail = existingTineos.Mail,
                    Token = TokenTool.GenerateJwt(existingTineos, _jwtSettings.Value)
                };
            }

            return result;
        }

    }
}
